namespace TimelineCreator
{
    partial class Roster
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
            this.listRoster = new System.Windows.Forms.ListBox();
            this.txtRoster = new System.Windows.Forms.TextBox();
            this.lblRoster = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listRoster
            // 
            this.listRoster.FormattingEnabled = true;
            this.listRoster.ItemHeight = 20;
            this.listRoster.Location = new System.Drawing.Point(89, 105);
            this.listRoster.Name = "listRoster";
            this.listRoster.Size = new System.Drawing.Size(120, 204);
            this.listRoster.TabIndex = 0;
            this.listRoster.SelectedValueChanged += new System.EventHandler(this.listRoster_SelectedValueChanged);
            // 
            // txtRoster
            // 
            this.txtRoster.Location = new System.Drawing.Point(361, 104);
            this.txtRoster.Multiline = true;
            this.txtRoster.Name = "txtRoster";
            this.txtRoster.Size = new System.Drawing.Size(334, 222);
            this.txtRoster.TabIndex = 1;
            // 
            // lblRoster
            // 
            this.lblRoster.AutoSize = true;
            this.lblRoster.Location = new System.Drawing.Point(357, 66);
            this.lblRoster.Name = "lblRoster";
            this.lblRoster.Size = new System.Drawing.Size(51, 20);
            this.lblRoster.TabIndex = 2;
            this.lblRoster.Text = "Notes";
            // 
            // Roster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblRoster);
            this.Controls.Add(this.txtRoster);
            this.Controls.Add(this.listRoster);
            this.Name = "Roster";
            this.Text = "Roster";
            this.Load += new System.EventHandler(this.Roster_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listRoster;
        private System.Windows.Forms.TextBox txtRoster;
        private System.Windows.Forms.Label lblRoster;
    }
}