namespace JesseHouwing.CheckinPolicies
{
    partial class WarnMultipleBranchPolicyEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.warnMultipleProjects = new System.Windows.Forms.CheckBox();
            this.warnMultipleBranches = new System.Windows.Forms.CheckBox();
            this.warnSourceControlRoot = new System.Windows.Forms.CheckBox();
            this.allowDismiss = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(493, 144);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(412, 144);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // warnMultipleProjects
            // 
            this.warnMultipleProjects.AutoSize = true;
            this.warnMultipleProjects.Location = new System.Drawing.Point(13, 13);
            this.warnMultipleProjects.Name = "warnMultipleProjects";
            this.warnMultipleProjects.Size = new System.Drawing.Size(343, 17);
            this.warnMultipleProjects.TabIndex = 2;
            this.warnMultipleProjects.Text = "Warn when checking into multiple Team Projects in one Changeset";
            this.warnMultipleProjects.UseVisualStyleBackColor = true;
            // 
            // warnMultipleBranches
            // 
            this.warnMultipleBranches.AutoSize = true;
            this.warnMultipleBranches.Location = new System.Drawing.Point(13, 37);
            this.warnMultipleBranches.Name = "warnMultipleBranches";
            this.warnMultipleBranches.Size = new System.Drawing.Size(318, 17);
            this.warnMultipleBranches.TabIndex = 3;
            this.warnMultipleBranches.Text = "Warn when checking into multiple branches in one changeset";
            this.warnMultipleBranches.UseVisualStyleBackColor = true;
            this.warnMultipleBranches.CheckedChanged += new System.EventHandler(this.warnMultipleBranches_CheckedChanged);
            // 
            // warnSourceControlRoot
            // 
            this.warnSourceControlRoot.AutoSize = true;
            this.warnSourceControlRoot.Location = new System.Drawing.Point(32, 60);
            this.warnSourceControlRoot.Name = "warnSourceControlRoot";
            this.warnSourceControlRoot.Size = new System.Drawing.Size(184, 17);
            this.warnSourceControlRoot.TabIndex = 4;
            this.warnSourceControlRoot.Text = "Include Source Control root folder";
            this.warnSourceControlRoot.UseVisualStyleBackColor = true;
            // 
            // allowDismiss
            // 
            this.allowDismiss.AutoSize = true;
            this.allowDismiss.Location = new System.Drawing.Point(12, 115);
            this.allowDismiss.Name = "allowDismiss";
            this.allowDismiss.Size = new System.Drawing.Size(256, 17);
            this.allowDismiss.TabIndex = 5;
            this.allowDismiss.Text = "Allow user to dismiss without overriding the policy";
            this.allowDismiss.UseVisualStyleBackColor = true;
            // 
            // WarnMultipleBranchPolicyEditor
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(580, 179);
            this.Controls.Add(this.allowDismiss);
            this.Controls.Add(this.warnSourceControlRoot);
            this.Controls.Add(this.warnMultipleBranches);
            this.Controls.Add(this.warnMultipleProjects);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(596, 165);
            this.Name = "WarnMultipleBranchPolicyEditor";
            this.ShowInTaskbar = false;
            this.Text = "Configure Multiple Branch Policy";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox warnMultipleProjects;
        private System.Windows.Forms.CheckBox warnMultipleBranches;
        private System.Windows.Forms.CheckBox warnSourceControlRoot;
        private System.Windows.Forms.CheckBox allowDismiss;
    }
}