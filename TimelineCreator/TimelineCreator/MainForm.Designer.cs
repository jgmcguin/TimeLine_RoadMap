namespace TimelineCreator
{
    partial class MainForm
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
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.lblEventName = new System.Windows.Forms.Label();
            this.lblAddEventTime = new System.Windows.Forms.Label();
            this.txtEventTime = new System.Windows.Forms.TextBox();
            this.grpAddEvent = new System.Windows.Forms.GroupBox();
            this.txtEventLocation = new System.Windows.Forms.TextBox();
            this.lblEventLocation = new System.Windows.Forms.Label();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.btnShowTimeline = new System.Windows.Forms.Button();
            this.grpAddNewPerson = new System.Windows.Forms.GroupBox();
            this.txtNewPersonEyeColor = new System.Windows.Forms.TextBox();
            this.lblNewPersonEyeColor = new System.Windows.Forms.Label();
            this.txtNewPersonBirthday = new System.Windows.Forms.TextBox();
            this.lblNewPersonBirthday = new System.Windows.Forms.Label();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.txtNewPersonName = new System.Windows.Forms.TextBox();
            this.lblNewPersonName = new System.Windows.Forms.Label();
            this.grpConnectPersonEvent = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cmbConnectEventName = new System.Windows.Forms.ComboBox();
            this.cmbPersonName = new System.Windows.Forms.ComboBox();
            this.lblConnectEventName = new System.Windows.Forms.Label();
            this.lblPersonName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.grpAddEvent.SuspendLayout();
            this.grpAddNewPerson.SuspendLayout();
            this.grpConnectPersonEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEventName
            // 
            this.txtEventName.Location = new System.Drawing.Point(49, 72);
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.Size = new System.Drawing.Size(166, 26);
            this.txtEventName.TabIndex = 0;
            this.txtEventName.TextChanged += new System.EventHandler(this.txtEventName_TextChanged);
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.Location = new System.Drawing.Point(45, 40);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(96, 20);
            this.lblEventName.TabIndex = 1;
            this.lblEventName.Text = "Event Name";
            // 
            // lblAddEventTime
            // 
            this.lblAddEventTime.AutoSize = true;
            this.lblAddEventTime.Location = new System.Drawing.Point(45, 193);
            this.lblAddEventTime.Name = "lblAddEventTime";
            this.lblAddEventTime.Size = new System.Drawing.Size(88, 20);
            this.lblAddEventTime.TabIndex = 3;
            this.lblAddEventTime.Text = "Event Time";
            // 
            // txtEventTime
            // 
            this.txtEventTime.Location = new System.Drawing.Point(49, 225);
            this.txtEventTime.Name = "txtEventTime";
            this.txtEventTime.Size = new System.Drawing.Size(166, 26);
            this.txtEventTime.TabIndex = 2;
            this.txtEventTime.TextChanged += new System.EventHandler(this.txtEventTime_TextChanged);
            // 
            // grpAddEvent
            // 
            this.grpAddEvent.Controls.Add(this.txtEventLocation);
            this.grpAddEvent.Controls.Add(this.lblEventLocation);
            this.grpAddEvent.Controls.Add(this.btnAddEvent);
            this.grpAddEvent.Controls.Add(this.txtEventName);
            this.grpAddEvent.Controls.Add(this.lblAddEventTime);
            this.grpAddEvent.Controls.Add(this.lblEventName);
            this.grpAddEvent.Controls.Add(this.txtEventTime);
            this.grpAddEvent.Location = new System.Drawing.Point(31, 33);
            this.grpAddEvent.Name = "grpAddEvent";
            this.grpAddEvent.Size = new System.Drawing.Size(270, 323);
            this.grpAddEvent.TabIndex = 4;
            this.grpAddEvent.TabStop = false;
            this.grpAddEvent.Text = "Add Event";
            // 
            // txtEventLocation
            // 
            this.txtEventLocation.Location = new System.Drawing.Point(49, 143);
            this.txtEventLocation.Name = "txtEventLocation";
            this.txtEventLocation.Size = new System.Drawing.Size(166, 26);
            this.txtEventLocation.TabIndex = 5;
            this.txtEventLocation.TextChanged += new System.EventHandler(this.txtEventLocation_TextChanged);
            // 
            // lblEventLocation
            // 
            this.lblEventLocation.AutoSize = true;
            this.lblEventLocation.Location = new System.Drawing.Point(45, 111);
            this.lblEventLocation.Name = "lblEventLocation";
            this.lblEventLocation.Size = new System.Drawing.Size(115, 20);
            this.lblEventLocation.TabIndex = 6;
            this.lblEventLocation.Text = "Event Location";
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(85, 261);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(75, 36);
            this.btnAddEvent.TabIndex = 4;
            this.btnAddEvent.Text = "Add";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // btnShowTimeline
            // 
            this.btnShowTimeline.Location = new System.Drawing.Point(436, 400);
            this.btnShowTimeline.Name = "btnShowTimeline";
            this.btnShowTimeline.Size = new System.Drawing.Size(165, 34);
            this.btnShowTimeline.TabIndex = 5;
            this.btnShowTimeline.Text = "Show Timeline";
            this.btnShowTimeline.UseVisualStyleBackColor = true;
            this.btnShowTimeline.Click += new System.EventHandler(this.btnShowTimeline_Click);
            // 
            // grpAddNewPerson
            // 
            this.grpAddNewPerson.Controls.Add(this.txtNewPersonEyeColor);
            this.grpAddNewPerson.Controls.Add(this.lblNewPersonEyeColor);
            this.grpAddNewPerson.Controls.Add(this.txtNewPersonBirthday);
            this.grpAddNewPerson.Controls.Add(this.lblNewPersonBirthday);
            this.grpAddNewPerson.Controls.Add(this.btnAddNewPerson);
            this.grpAddNewPerson.Controls.Add(this.txtNewPersonName);
            this.grpAddNewPerson.Controls.Add(this.lblNewPersonName);
            this.grpAddNewPerson.Location = new System.Drawing.Point(370, 33);
            this.grpAddNewPerson.Name = "grpAddNewPerson";
            this.grpAddNewPerson.Size = new System.Drawing.Size(270, 323);
            this.grpAddNewPerson.TabIndex = 6;
            this.grpAddNewPerson.TabStop = false;
            this.grpAddNewPerson.Text = "Add New Person";
            // 
            // txtNewPersonEyeColor
            // 
            this.txtNewPersonEyeColor.Location = new System.Drawing.Point(49, 216);
            this.txtNewPersonEyeColor.Name = "txtNewPersonEyeColor";
            this.txtNewPersonEyeColor.Size = new System.Drawing.Size(166, 26);
            this.txtNewPersonEyeColor.TabIndex = 8;
            this.txtNewPersonEyeColor.TextChanged += new System.EventHandler(this.txtNewPersonEyeColor_TextChanged);
            // 
            // lblNewPersonEyeColor
            // 
            this.lblNewPersonEyeColor.AutoSize = true;
            this.lblNewPersonEyeColor.Location = new System.Drawing.Point(45, 184);
            this.lblNewPersonEyeColor.Name = "lblNewPersonEyeColor";
            this.lblNewPersonEyeColor.Size = new System.Drawing.Size(131, 20);
            this.lblNewPersonEyeColor.TabIndex = 9;
            this.lblNewPersonEyeColor.Text = "Person Eye Color";
            // 
            // txtNewPersonBirthday
            // 
            this.txtNewPersonBirthday.Location = new System.Drawing.Point(49, 143);
            this.txtNewPersonBirthday.Name = "txtNewPersonBirthday";
            this.txtNewPersonBirthday.Size = new System.Drawing.Size(166, 26);
            this.txtNewPersonBirthday.TabIndex = 6;
            this.txtNewPersonBirthday.TextChanged += new System.EventHandler(this.txtNewPersonBirthday_TextChanged);
            // 
            // lblNewPersonBirthday
            // 
            this.lblNewPersonBirthday.AutoSize = true;
            this.lblNewPersonBirthday.Location = new System.Drawing.Point(45, 111);
            this.lblNewPersonBirthday.Name = "lblNewPersonBirthday";
            this.lblNewPersonBirthday.Size = new System.Drawing.Size(121, 20);
            this.lblNewPersonBirthday.TabIndex = 7;
            this.lblNewPersonBirthday.Text = "Person Birthday";
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Location = new System.Drawing.Point(95, 262);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(85, 36);
            this.btnAddNewPerson.TabIndex = 5;
            this.btnAddNewPerson.Text = "Add";
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // txtNewPersonName
            // 
            this.txtNewPersonName.Location = new System.Drawing.Point(49, 72);
            this.txtNewPersonName.Name = "txtNewPersonName";
            this.txtNewPersonName.Size = new System.Drawing.Size(166, 26);
            this.txtNewPersonName.TabIndex = 0;
            this.txtNewPersonName.TextChanged += new System.EventHandler(this.txtNewPersonName_TextChanged);
            // 
            // lblNewPersonName
            // 
            this.lblNewPersonName.AutoSize = true;
            this.lblNewPersonName.Location = new System.Drawing.Point(45, 40);
            this.lblNewPersonName.Name = "lblNewPersonName";
            this.lblNewPersonName.Size = new System.Drawing.Size(105, 20);
            this.lblNewPersonName.TabIndex = 1;
            this.lblNewPersonName.Text = "Person Name";
            // 
            // grpConnectPersonEvent
            // 
            this.grpConnectPersonEvent.Controls.Add(this.btnConnect);
            this.grpConnectPersonEvent.Controls.Add(this.cmbConnectEventName);
            this.grpConnectPersonEvent.Controls.Add(this.cmbPersonName);
            this.grpConnectPersonEvent.Controls.Add(this.lblConnectEventName);
            this.grpConnectPersonEvent.Controls.Add(this.lblPersonName);
            this.grpConnectPersonEvent.Location = new System.Drawing.Point(691, 35);
            this.grpConnectPersonEvent.Name = "grpConnectPersonEvent";
            this.grpConnectPersonEvent.Size = new System.Drawing.Size(281, 249);
            this.grpConnectPersonEvent.TabIndex = 7;
            this.grpConnectPersonEvent.TabStop = false;
            this.grpConnectPersonEvent.Text = "Connect a Person to an Event";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(106, 188);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(85, 36);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cmbConnectEventName
            // 
            this.cmbConnectEventName.FormattingEnabled = true;
            this.cmbConnectEventName.Location = new System.Drawing.Point(47, 154);
            this.cmbConnectEventName.Name = "cmbConnectEventName";
            this.cmbConnectEventName.Size = new System.Drawing.Size(198, 28);
            this.cmbConnectEventName.TabIndex = 3;
            // 
            // cmbPersonName
            // 
            this.cmbPersonName.FormattingEnabled = true;
            this.cmbPersonName.Location = new System.Drawing.Point(47, 75);
            this.cmbPersonName.Name = "cmbPersonName";
            this.cmbPersonName.Size = new System.Drawing.Size(198, 28);
            this.cmbPersonName.TabIndex = 2;
            // 
            // lblConnectEventName
            // 
            this.lblConnectEventName.AutoSize = true;
            this.lblConnectEventName.Location = new System.Drawing.Point(43, 120);
            this.lblConnectEventName.Name = "lblConnectEventName";
            this.lblConnectEventName.Size = new System.Drawing.Size(96, 20);
            this.lblConnectEventName.TabIndex = 1;
            this.lblConnectEventName.Text = "Event Name";
            // 
            // lblPersonName
            // 
            this.lblPersonName.AutoSize = true;
            this.lblPersonName.Location = new System.Drawing.Point(43, 47);
            this.lblPersonName.Name = "lblPersonName";
            this.lblPersonName.Size = new System.Drawing.Size(105, 20);
            this.lblPersonName.TabIndex = 0;
            this.lblPersonName.Text = "Person Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(436, 440);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 34);
            this.button1.TabIndex = 8;
            this.button1.Text = "Show Roster";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 595);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grpConnectPersonEvent);
            this.Controls.Add(this.grpAddNewPerson);
            this.Controls.Add(this.btnShowTimeline);
            this.Controls.Add(this.grpAddEvent);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.grpAddEvent.ResumeLayout(false);
            this.grpAddEvent.PerformLayout();
            this.grpAddNewPerson.ResumeLayout(false);
            this.grpAddNewPerson.PerformLayout();
            this.grpConnectPersonEvent.ResumeLayout(false);
            this.grpConnectPersonEvent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.Label lblAddEventTime;
        private System.Windows.Forms.TextBox txtEventTime;
        private System.Windows.Forms.GroupBox grpAddEvent;
        private System.Windows.Forms.Button btnShowTimeline;
        private System.Windows.Forms.GroupBox grpAddNewPerson;
        private System.Windows.Forms.TextBox txtNewPersonName;
        private System.Windows.Forms.Label lblNewPersonName;
        private System.Windows.Forms.GroupBox grpConnectPersonEvent;
        private System.Windows.Forms.Label lblPersonName;
        private System.Windows.Forms.Label lblConnectEventName;
        private System.Windows.Forms.ComboBox cmbConnectEventName;
        private System.Windows.Forms.ComboBox cmbPersonName;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtNewPersonEyeColor;
        private System.Windows.Forms.Label lblNewPersonEyeColor;
        private System.Windows.Forms.TextBox txtNewPersonBirthday;
        private System.Windows.Forms.Label lblNewPersonBirthday;
        private System.Windows.Forms.TextBox txtEventLocation;
        private System.Windows.Forms.Label lblEventLocation;
    }
}

