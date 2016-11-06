namespace osu_mouse2
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.minimizeButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.enableAccelButton = new System.Windows.Forms.Button();
            this.disableAccelButton = new System.Windows.Forms.Button();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.aboutLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "osu!mouse2";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // minimizeButton
            // 
            this.minimizeButton.Location = new System.Drawing.Point(12, 222);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(100, 27);
            this.minimizeButton.TabIndex = 0;
            this.minimizeButton.Text = "Minimize";
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(118, 222);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(100, 27);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // enableAccelButton
            // 
            this.enableAccelButton.Location = new System.Drawing.Point(12, 189);
            this.enableAccelButton.Name = "enableAccelButton";
            this.enableAccelButton.Size = new System.Drawing.Size(100, 27);
            this.enableAccelButton.TabIndex = 2;
            this.enableAccelButton.Text = "Enable Accel";
            this.enableAccelButton.UseVisualStyleBackColor = true;
            this.enableAccelButton.Click += new System.EventHandler(this.enableAccelButton_Click);
            this.enableAccelButton.Paint += new System.Windows.Forms.PaintEventHandler(this.enableAccelButton_Paint);
            this.enableAccelButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.enableAccelButton_MouseUp);
            // 
            // disableAccelButton
            // 
            this.disableAccelButton.Location = new System.Drawing.Point(118, 189);
            this.disableAccelButton.Name = "disableAccelButton";
            this.disableAccelButton.Size = new System.Drawing.Size(100, 27);
            this.disableAccelButton.TabIndex = 3;
            this.disableAccelButton.Text = "Disable Accel";
            this.disableAccelButton.UseVisualStyleBackColor = true;
            this.disableAccelButton.Click += new System.EventHandler(this.disableAccelButton_Click);
            this.disableAccelButton.Paint += new System.Windows.Forms.PaintEventHandler(this.disableAccelButton_Paint);
            this.disableAccelButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.disableAccelButton_MouseUp);
            // 
            // logoPanel
            // 
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(229, 149);
            this.logoPanel.TabIndex = 5;
            this.logoPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // aboutLabel
            // 
            this.aboutLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.aboutLabel.Location = new System.Drawing.Point(0, 149);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(229, 13);
            this.aboutLabel.TabIndex = 0;
            this.aboutLabel.Text = "osu!mouse2 v1.0 - (c) openglfreak 2016";
            this.aboutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoLabel
            // 
            this.infoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.Location = new System.Drawing.Point(0, 162);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(229, 24);
            this.infoLabel.TabIndex = 6;
            this.infoLabel.Text = "Ready, start osu!";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.aboutLabel);
            this.Controls.Add(this.logoPanel);
            this.Controls.Add(this.disableAccelButton);
            this.Controls.Add(this.enableAccelButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.minimizeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "osu!mouse2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button enableAccelButton;
        private System.Windows.Forms.Button disableAccelButton;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Label aboutLabel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button button1;
    }
}

