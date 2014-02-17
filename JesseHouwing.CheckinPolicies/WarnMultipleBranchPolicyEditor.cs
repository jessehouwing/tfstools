using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JesseHouwing.CheckinPolicies
{
    public partial class WarnMultipleBranchPolicyEditor : Form
    {
        public WarnMultipleBranchPolicyEditor(WarnMultipleBranchPolicy policy)
        {
            InitializeComponent();

            warnMultipleProjects.Checked = policy.WarnWhenMultipleProjectsAreSelected;
            warnMultipleBranches.Checked = policy.WarnWhenMultipleBranchesAreSelected;
            warnSourceControlRoot.Checked = policy.WarnWhenRootBranchIsSelected;
            allowDismiss.Checked = policy.AllowDismiss;
        }

        private void warnMultipleBranches_CheckedChanged(object sender, EventArgs e)
        {
            warnSourceControlRoot.Enabled = warnMultipleBranches.Checked;
        }

        public bool WarnWhenMultipleProjectsAreSelected
        {
            get
            {
                return warnMultipleProjects.Checked;
            }
        }

        public bool WarnWhenMultipleBranchesAreSelected
        {
            get
            {
                return warnMultipleBranches.Checked;
            }
        }

        public bool WarnWhenRootBranchIsSelected
        {
            get
            {
                return warnSourceControlRoot.Checked;
            }
        }

        public bool AllowDismiss
        {
            get
            {
                return allowDismiss.Checked;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
