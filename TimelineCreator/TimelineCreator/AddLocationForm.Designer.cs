namespace TimelineCreator
{
    partial class AddLocationForm
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
            this.txtLocDesc = new System.Windows.Forms.TextBox();
            this.txtNewLoc = new System.Windows.Forms.TextBox();
            this.lblNewLoc = new System.Windows.Forms.Label();
            this.lblLocationList = new System.Windows.Forms.Label();
            this.lblLocList = new System.Windows.Forms.Label();
            this.listLocations = new System.Windows.Forms.ListBox();
            this.btnAddLocation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLocDesc
            // 
            this.txtLocDesc.Location = new System.Drawing.Point(244, 160);
            this.txtLocDesc.Multiline = true;
            this.txtLocDesc.Name = "txtLocDesc";
            this.txtLocDesc.Size = new System.Drawing.Size(340, 222);
            this.txtLocDesc.TabIndex = 0;
            // 
            // txtNewLoc
            // 
            this.txtNewLoc.Location = new System.Drawing.Point(203, 59);
            this.txtNewLoc.Name = "txtNewLoc";
            this.txtNewLoc.Size = new System.Drawing.Size(174, 26);
            this.txtNewLoc.TabIndex = 1;
            this.txtNewLoc.TextChanged += new System.EventHandler(this.txtNewLoc_TextChanged);
            // 
            // lblNewLoc
            // 
            this.lblNewLoc.AutoSize = true;
            this.lblNewLoc.BackColor = System.Drawing.Color.Transparent;
            this.lblNewLoc.Location = new System.Drawing.Point(86, 59);
            this.lblNewLoc.Name = "lblNewLoc";
            this.lblNewLoc.Size = new System.Drawing.Size(109, 20);
            this.lblNewLoc.TabIndex = 2;
            this.lblNewLoc.Text = "New Location:";
            // 
            // lblLocationList
            // 
            this.lblLocationList.AutoSize = true;
            this.lblLocationList.Location = new System.Drawing.Point(241, 121);
            this.lblLocationList.Name = "lblLocationList";
            this.lblLocationList.Size = new System.Drawing.Size(93, 20);
            this.lblLocationList.TabIndex = 3;
            this.lblLocationList.Text = "Description:";
            // 
            // lblLocList
            // 
            this.lblLocList.AutoSize = true;
            this.lblLocList.Location = new System.Drawing.Point(72, 121);
            this.lblLocList.Name = "lblLocList";
            this.lblLocList.Size = new System.Drawing.Size(99, 20);
            this.lblLocList.TabIndex = 5;
            this.lblLocList.Text = "Location List";
            // 
            // listLocations
            // 
            this.listLocations.FormattingEnabled = true;
            this.listLocations.ItemHeight = 20;
            this.listLocations.Location = new System.Drawing.Point(62, 160);
            this.listLocations.Name = "listLocations";
            this.listLocations.Size = new System.Drawing.Size(142, 224);
            this.listLocations.TabIndex = 6;
            // 
            // btnAddLocation
            // 
            this.btnAddLocation.Location = new System.Drawing.Point(398, 59);
            this.btnAddLocation.Name = "btnAddLocation";
            this.btnAddLocation.Size = new System.Drawing.Size(74, 39);
            this.btnAddLocation.TabIndex = 7;
            this.btnAddLocation.Text = "Add";
            this.btnAddLocation.UseVisualStyleBackColor = true;
            this.btnAddLocation.Click += new System.EventHandler(this.btnAddLocation_Click);
            // 
            // AddLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 446);
            this.Controls.Add(this.btnAddLocation);
            this.Controls.Add(this.listLocations);
            this.Controls.Add(this.lblLocList);
            this.Controls.Add(this.lblLocationList);
            this.Controls.Add(this.lblNewLoc);
            this.Controls.Add(this.txtNewLoc);
            this.Controls.Add(this.txtLocDesc);
            this.Name = "AddLocationForm";
            this.Text = "Add Location";
            this.Load += new System.EventHandler(this.AddLocationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLocDesc;
        private System.Windows.Forms.TextBox txtNewLoc;
        private System.Windows.Forms.Label lblNewLoc;
        private System.Windows.Forms.Label lblLocationList;
        private System.Windows.Forms.Label lblLocList;
        private System.Windows.Forms.ListBox listLocations;
        private System.Windows.Forms.Button btnAddLocation;
    }
}