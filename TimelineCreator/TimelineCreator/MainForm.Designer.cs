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
            this.grpAddEvent = new System.Windows.Forms.GroupBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.comboEventLocation = new System.Windows.Forms.ComboBox();
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
            this.lblRoster = new System.Windows.Forms.Label();
            this.txtRoster = new System.Windows.Forms.TextBox();
            this.listRoster = new System.Windows.Forms.ListBox();
            this.panTimeline = new System.Windows.Forms.Panel();
            this.listLocations = new System.Windows.Forms.ListBox();
            this.grpAddPeopleToEvent = new System.Windows.Forms.GroupBox();
            this.comboConnectionEvents = new System.Windows.Forms.ComboBox();
            this.comboConnectionPeople = new System.Windows.Forms.ComboBox();
            this.btnAddPeopleToEvent = new System.Windows.Forms.Button();
            this.grpAddEvent.SuspendLayout();
            this.grpAddNewPerson.SuspendLayout();
            this.grpAddPeopleToEvent.SuspendLayout();
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
            // grpAddEvent
            // 
            this.grpAddEvent.Controls.Add(this.dateTimePicker);
            this.grpAddEvent.Controls.Add(this.comboEventLocation);
            this.grpAddEvent.Controls.Add(this.lblEventLocation);
            this.grpAddEvent.Controls.Add(this.btnAddEvent);
            this.grpAddEvent.Controls.Add(this.txtEventName);
            this.grpAddEvent.Controls.Add(this.lblAddEventTime);
            this.grpAddEvent.Controls.Add(this.lblEventName);
            this.grpAddEvent.Location = new System.Drawing.Point(31, 33);
            this.grpAddEvent.Name = "grpAddEvent";
            this.grpAddEvent.Size = new System.Drawing.Size(270, 323);
            this.grpAddEvent.TabIndex = 4;
            this.grpAddEvent.TabStop = false;
            this.grpAddEvent.Text = "Add Event";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(46, 214);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(169, 26);
            this.dateTimePicker.TabIndex = 14;
            // 
            // comboEventLocation
            // 
            this.comboEventLocation.FormattingEnabled = true;
            this.comboEventLocation.Items.AddRange(new object[] {
            "(+) New Location"});
            this.comboEventLocation.Location = new System.Drawing.Point(49, 141);
            this.comboEventLocation.Name = "comboEventLocation";
            this.comboEventLocation.Size = new System.Drawing.Size(166, 28);
            this.comboEventLocation.TabIndex = 7;
            this.comboEventLocation.SelectedIndexChanged += new System.EventHandler(this.comboLocation_SelectedIndexChanged);
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
            this.btnShowTimeline.Location = new System.Drawing.Point(31, 377);
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
            // lblRoster
            // 
            this.lblRoster.AutoSize = true;
            this.lblRoster.Location = new System.Drawing.Point(981, 129);
            this.lblRoster.Name = "lblRoster";
            this.lblRoster.Size = new System.Drawing.Size(51, 20);
            this.lblRoster.TabIndex = 11;
            this.lblRoster.Text = "Notes";
            // 
            // txtRoster
            // 
            this.txtRoster.Location = new System.Drawing.Point(985, 152);
            this.txtRoster.Multiline = true;
            this.txtRoster.Name = "txtRoster";
            this.txtRoster.Size = new System.Drawing.Size(334, 204);
            this.txtRoster.TabIndex = 10;
            // 
            // listRoster
            // 
            this.listRoster.FormattingEnabled = true;
            this.listRoster.ItemHeight = 20;
            this.listRoster.Location = new System.Drawing.Point(665, 152);
            this.listRoster.Name = "listRoster";
            this.listRoster.Size = new System.Drawing.Size(120, 204);
            this.listRoster.TabIndex = 9;
            this.listRoster.SelectedValueChanged += new System.EventHandler(this.listRoster_SelectedValueChanged);
            // 
            // panTimeline
            // 
            this.panTimeline.Location = new System.Drawing.Point(31, 429);
            this.panTimeline.Name = "panTimeline";
            this.panTimeline.Size = new System.Drawing.Size(1288, 511);
            this.panTimeline.TabIndex = 12;
            // 
            // listLocations
            // 
            this.listLocations.FormattingEnabled = true;
            this.listLocations.ItemHeight = 20;
            this.listLocations.Location = new System.Drawing.Point(818, 152);
            this.listLocations.Name = "listLocations";
            this.listLocations.Size = new System.Drawing.Size(120, 204);
            this.listLocations.TabIndex = 13;
            // 
            // grpAddPeopleToEvent
            // 
            this.grpAddPeopleToEvent.Controls.Add(this.btnAddPeopleToEvent);
            this.grpAddPeopleToEvent.Controls.Add(this.comboConnectionPeople);
            this.grpAddPeopleToEvent.Controls.Add(this.comboConnectionEvents);
            this.grpAddPeopleToEvent.Location = new System.Drawing.Point(654, 33);
            this.grpAddPeopleToEvent.Name = "grpAddPeopleToEvent";
            this.grpAddPeopleToEvent.Size = new System.Drawing.Size(665, 95);
            this.grpAddPeopleToEvent.TabIndex = 14;
            this.grpAddPeopleToEvent.TabStop = false;
            this.grpAddPeopleToEvent.Text = "Add People to Event";
            // 
            // comboConnectionEvents
            // 
            this.comboConnectionEvents.FormattingEnabled = true;
            this.comboConnectionEvents.Location = new System.Drawing.Point(11, 40);
            this.comboConnectionEvents.Name = "comboConnectionEvents";
            this.comboConnectionEvents.Size = new System.Drawing.Size(151, 28);
            this.comboConnectionEvents.TabIndex = 0;
            // 
            // comboConnectionPeople
            // 
            this.comboConnectionPeople.FormattingEnabled = true;
            this.comboConnectionPeople.Location = new System.Drawing.Point(205, 40);
            this.comboConnectionPeople.Name = "comboConnectionPeople";
            this.comboConnectionPeople.Size = new System.Drawing.Size(137, 28);
            this.comboConnectionPeople.TabIndex = 1;
            // 
            // btnAddPeopleToEvent
            // 
            this.btnAddPeopleToEvent.Location = new System.Drawing.Point(376, 39);
            this.btnAddPeopleToEvent.Name = "btnAddPeopleToEvent";
            this.btnAddPeopleToEvent.Size = new System.Drawing.Size(141, 29);
            this.btnAddPeopleToEvent.TabIndex = 2;
            this.btnAddPeopleToEvent.Text = "Add";
            this.btnAddPeopleToEvent.UseVisualStyleBackColor = true;
            this.btnAddPeopleToEvent.Click += new System.EventHandler(this.btnAddPeopleToEvent_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 901);
            this.Controls.Add(this.grpAddPeopleToEvent);
            this.Controls.Add(this.listLocations);
            this.Controls.Add(this.panTimeline);
            this.Controls.Add(this.lblRoster);
            this.Controls.Add(this.txtRoster);
            this.Controls.Add(this.listRoster);
            this.Controls.Add(this.grpAddNewPerson);
            this.Controls.Add(this.btnShowTimeline);
            this.Controls.Add(this.grpAddEvent);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.grpAddEvent.ResumeLayout(false);
            this.grpAddEvent.PerformLayout();
            this.grpAddNewPerson.ResumeLayout(false);
            this.grpAddNewPerson.PerformLayout();
            this.grpAddPeopleToEvent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.Label lblAddEventTime;
        private System.Windows.Forms.GroupBox grpAddEvent;
        private System.Windows.Forms.Button btnShowTimeline;
        private System.Windows.Forms.GroupBox grpAddNewPerson;
        private System.Windows.Forms.TextBox txtNewPersonName;
        private System.Windows.Forms.Label lblNewPersonName;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.TextBox txtNewPersonEyeColor;
        private System.Windows.Forms.Label lblNewPersonEyeColor;
        private System.Windows.Forms.TextBox txtNewPersonBirthday;
        private System.Windows.Forms.Label lblNewPersonBirthday;
        private System.Windows.Forms.Label lblEventLocation;
        private System.Windows.Forms.Label lblRoster;
        private System.Windows.Forms.TextBox txtRoster;
        private System.Windows.Forms.ListBox listRoster;
        private System.Windows.Forms.Panel panTimeline;
        private System.Windows.Forms.ComboBox comboEventLocation;
        private System.Windows.Forms.ListBox listLocations;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.GroupBox grpAddPeopleToEvent;
        private System.Windows.Forms.Button btnAddPeopleToEvent;
        private System.Windows.Forms.ComboBox comboConnectionPeople;
        private System.Windows.Forms.ComboBox comboConnectionEvents;
    }
}

