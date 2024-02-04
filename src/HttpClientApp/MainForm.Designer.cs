namespace HttpClientApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGetUsers = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.richTextBoxResponse = new System.Windows.Forms.RichTextBox();
            this.buttonCreateUser = new System.Windows.Forms.Button();
            this.textBoxUserId = new System.Windows.Forms.TextBox();
            this.labelUserId = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxUserJob = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelUserJob = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonGetUsers
            // 
            this.buttonGetUsers.Location = new System.Drawing.Point(29, 51);
            this.buttonGetUsers.Name = "buttonGetUsers";
            this.buttonGetUsers.Size = new System.Drawing.Size(98, 52);
            this.buttonGetUsers.TabIndex = 0;
            this.buttonGetUsers.Text = "Send Get";
            this.buttonGetUsers.UseVisualStyleBackColor = true;
            this.buttonGetUsers.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Enabled = false;
            this.buttonCancel.Location = new System.Drawing.Point(683, 51);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(98, 52);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // richTextBoxResponse
            // 
            this.richTextBoxResponse.Location = new System.Drawing.Point(29, 199);
            this.richTextBoxResponse.Name = "richTextBoxResponse";
            this.richTextBoxResponse.Size = new System.Drawing.Size(773, 288);
            this.richTextBoxResponse.TabIndex = 2;
            this.richTextBoxResponse.Text = "";
            // 
            // buttonCreateUser
            // 
            this.buttonCreateUser.Location = new System.Drawing.Point(29, 119);
            this.buttonCreateUser.Name = "buttonCreateUser";
            this.buttonCreateUser.Size = new System.Drawing.Size(98, 52);
            this.buttonCreateUser.TabIndex = 3;
            this.buttonCreateUser.Text = "Send Post";
            this.buttonCreateUser.UseVisualStyleBackColor = true;
            this.buttonCreateUser.Click += new System.EventHandler(this.buttonCreateUser_Click);
            // 
            // textBoxUserId
            // 
            this.textBoxUserId.Location = new System.Drawing.Point(150, 67);
            this.textBoxUserId.Name = "textBoxUserId";
            this.textBoxUserId.Size = new System.Drawing.Size(155, 23);
            this.textBoxUserId.TabIndex = 4;
            // 
            // labelUserId
            // 
            this.labelUserId.AutoSize = true;
            this.labelUserId.Location = new System.Drawing.Point(150, 49);
            this.labelUserId.Name = "labelUserId";
            this.labelUserId.Size = new System.Drawing.Size(40, 15);
            this.labelUserId.TabIndex = 5;
            this.labelUserId.Text = "UserId";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(150, 135);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(155, 23);
            this.textBoxUserName.TabIndex = 6;
            // 
            // textBoxUserJob
            // 
            this.textBoxUserJob.Location = new System.Drawing.Point(338, 135);
            this.textBoxUserJob.Name = "textBoxUserJob";
            this.textBoxUserJob.Size = new System.Drawing.Size(155, 23);
            this.textBoxUserJob.TabIndex = 7;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(150, 117);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(39, 15);
            this.labelUserName.TabIndex = 8;
            this.labelUserName.Text = "Name";
            // 
            // labelUserJob
            // 
            this.labelUserJob.AutoSize = true;
            this.labelUserJob.Location = new System.Drawing.Point(338, 117);
            this.labelUserJob.Name = "labelUserJob";
            this.labelUserJob.Size = new System.Drawing.Size(25, 15);
            this.labelUserJob.TabIndex = 9;
            this.labelUserJob.Text = "Job";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 511);
            this.Controls.Add(this.labelUserJob);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.textBoxUserJob);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.labelUserId);
            this.Controls.Add(this.textBoxUserId);
            this.Controls.Add(this.buttonCreateUser);
            this.Controls.Add(this.richTextBoxResponse);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonGetUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonGetUsers;
        private Button buttonCancel;
        private RichTextBox richTextBoxResponse;
        private Button buttonCreateUser;
        private TextBox textBoxUserId;
        private Label labelUserId;
        private TextBox textBoxUserName;
        private TextBox textBoxUserJob;
        private Label labelUserName;
        private Label labelUserJob;
    }
}