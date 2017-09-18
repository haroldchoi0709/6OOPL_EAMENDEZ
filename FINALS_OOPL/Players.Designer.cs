namespace FINALS_OOPL
{
    partial class Players
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
            this.firstPlay = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.withUsers = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.firstPlay.SuspendLayout();
            this.withUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // firstPlay
            // 
            this.firstPlay.Controls.Add(this.button1);
            this.firstPlay.Controls.Add(this.textBox1);
            this.firstPlay.Controls.Add(this.label1);
            this.firstPlay.Location = new System.Drawing.Point(13, 13);
            this.firstPlay.Name = "firstPlay";
            this.firstPlay.Size = new System.Drawing.Size(283, 236);
            this.firstPlay.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter username : ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(149, 90);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "PLAY";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // withUsers
            // 
            this.withUsers.Controls.Add(this.button2);
            this.withUsers.Location = new System.Drawing.Point(331, 13);
            this.withUsers.Name = "withUsers";
            this.withUsers.Size = new System.Drawing.Size(283, 236);
            this.withUsers.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 35);
            this.button2.TabIndex = 0;
            this.button2.Text = "PLAY";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Players
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 261);
            this.Controls.Add(this.withUsers);
            this.Controls.Add(this.firstPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Players";
            this.Text = "Players";
            this.firstPlay.ResumeLayout(false);
            this.firstPlay.PerformLayout();
            this.withUsers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel firstPlay;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel withUsers;
        private System.Windows.Forms.Button button2;
    }
}