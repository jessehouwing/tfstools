using Microsoft.TeamFoundation.VersionControl.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace JesseHouwing.CheckinPolicies
{
    using System.Windows.Forms;

    using JesseHouwing.CheckinPolicies.Properties;

    [Serializable, System.Runtime.InteropServices.GuidAttribute("1A8E2C45-1DAD-4E41-A8E4-7FD4DA6137F5")]
    public class WarnMultipleBranchPolicy : PolicyBase
    {
        [NonSerialized]
        private AffectedTeamProjectsEventHandler _affectedTeamProjectsEventHandler;
        [NonSerialized]
        private EventHandler _checkedPendingChangesEventHandler;

        public bool WarnWhenMultipleProjectsAreSelected { internal set; get; }

        public bool WarnWhenMultipleBranchesAreSelected { internal set; get; }

        public bool WarnWhenRootBranchIsSelected { internal set; get; }

        public bool AllowDismiss { internal set; get; }

        [NonSerialized]
        private bool warningDismissed = false;

        public WarnMultipleBranchPolicy()
        {
            WarnWhenRootBranchIsSelected = false;
            WarnWhenMultipleProjectsAreSelected = true;
            WarnWhenMultipleBranchesAreSelected = true;
            AllowDismiss = false;
        }

        public override void Initialize(IPendingCheckin pendingCheckin)
        {
            base.Initialize(pendingCheckin);

            _affectedTeamProjectsEventHandler = (sender, e) =>
            {
                warningDismissed = false;
                OnPolicyStateChanged(Evaluate());
            };

            _checkedPendingChangesEventHandler = (sender, e) =>
            {
                warningDismissed = false;
                OnPolicyStateChanged(Evaluate());
            };

            pendingCheckin.PendingChanges.AffectedTeamProjectsChanged += _affectedTeamProjectsEventHandler;
            pendingCheckin.PendingChanges.CheckedPendingChangesChanged += _checkedPendingChangesEventHandler;
        }
        
        public override string Description
        {
            get
            {
                return Resources.PolicyDescription;
            }
        }

        public override bool CanEdit
        {
            get
            {
                return true;
            }
        }

        public override bool Edit(IPolicyEditArgs policyEditArgs)
        {
            using (var dialog = new WarnMultipleBranchPolicyEditor(this))
            {
                if (dialog.ShowDialog(policyEditArgs.Parent) == DialogResult.OK)
                {
                    this.WarnWhenMultipleProjectsAreSelected = dialog.WarnWhenMultipleProjectsAreSelected;
                    this.WarnWhenMultipleBranchesAreSelected = dialog.WarnWhenMultipleBranchesAreSelected;
                    this.WarnWhenRootBranchIsSelected = dialog.WarnWhenRootBranchIsSelected;
                    this.AllowDismiss = dialog.AllowDismiss;
                    
                    return true;
                }
            }
            
            return false;
        }

        public override void Activate(PolicyFailure failure)
        {
            if (AllowDismiss)
            {
                var result = MessageBox.Show(
                    Resources.PolicyDismissMessage,
                    Resources.PolicyDismissTitle,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    warningDismissed = true;
                    OnPolicyStateChanged(Evaluate());
                }
            }
        }

        public override PolicyFailure[] Evaluate()
        {
            if (warningDismissed)
            {
                return new PolicyFailure[0];
            }

            List<PolicyFailure>  failures = new List<PolicyFailure>();

            if (WarnWhenMultipleProjectsAreSelected)
            {
                if (PendingCheckin.PendingChanges.AffectedTeamProjectPaths.Length > 1)
                {
                    failures.Add(new PolicyFailure(Resources.PolicyWarningProjects, this));
                }
            }

            if (WarnWhenMultipleBranchesAreSelected)
            {
                var branches =
                this.PendingCheckin.PendingChanges.Workspace.VersionControlServer.QueryRootBranchObjects(
                    RecursionType.Full);

                var groupedChanges = PendingCheckin.PendingChanges.CheckedPendingChanges.GroupBy(
                    change =>

                    branches.SingleOrDefault(branch => IsSubDirectoryOf(branch.Properties.RootItem.Item, change.ServerItem)));

                if (!WarnWhenRootBranchIsSelected)
                {
                    groupedChanges = groupedChanges.Where(group => group.Key != null);
                }

                if (groupedChanges.Count() > 1)
                {
                    failures.Add(new PolicyFailure(Resources.PolicyWarningBranches, this));
                }
            }

            return failures.ToArray();
        }


        public static bool IsSubDirectoryOf(string root, string path)
        {
            var isChild = false;

            var pathInfo = new DirectoryInfo(path);
            var rootInfo = new DirectoryInfo(root);

            while (pathInfo.Parent != null)
            {
                if (pathInfo.Parent.FullName == rootInfo.FullName)
                {
                    isChild = true;
                    break;
                }
                else pathInfo = pathInfo.Parent;
            }


            return isChild;
        }


        public override string Type
        {
            get
            {
                return Resources.PolicyType;
            }
        }

        public override string TypeDescription
        {
            get
            {
                return Resources.PolicyTypeDescription;
            }
        }

        public override void Dispose()
        {
            this.PendingCheckin.PendingChanges.AffectedTeamProjectsChanged -= _affectedTeamProjectsEventHandler;
            this.PendingCheckin.PendingChanges.CheckedPendingChangesChanged -= _checkedPendingChangesEventHandler;

            base.Dispose();
        }
    }
}
