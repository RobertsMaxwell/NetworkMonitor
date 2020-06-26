namespace NetworkMonitor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.processName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.programDownload = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.programUpload = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.downloadDisplay = new System.Windows.Forms.Label();
            this.uploadDisplay = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.processName,
            this.programDownload,
            this.programUpload});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(192, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(589, 426);
            this.listView1.TabIndex = 0;
            this.listView1.TabStop = false;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            // 
            // processName
            // 
            this.processName.Text = "Process";
            this.processName.Width = 212;
            // 
            // programDownload
            // 
            this.programDownload.Text = "Read (Bytes/sec)";
            this.programDownload.Width = 185;
            // 
            // programUpload
            // 
            this.programUpload.Text = "Write (Bytes/sec)";
            this.programUpload.Width = 185;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-3, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Download:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(109, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Upload:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // downloadDisplay
            // 
            this.downloadDisplay.Location = new System.Drawing.Point(-3, 107);
            this.downloadDisplay.Name = "downloadDisplay";
            this.downloadDisplay.Size = new System.Drawing.Size(72, 23);
            this.downloadDisplay.TabIndex = 3;
            this.downloadDisplay.Text = "0";
            this.downloadDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uploadDisplay
            // 
            this.uploadDisplay.Location = new System.Drawing.Point(109, 107);
            this.uploadDisplay.Name = "uploadDisplay";
            this.uploadDisplay.Size = new System.Drawing.Size(72, 23);
            this.uploadDisplay.TabIndex = 4;
            this.uploadDisplay.Text = "0";
            this.uploadDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(36, 24);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(109, 37);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.startButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.uploadDisplay);
            this.panel1.Controls.Add(this.downloadDisplay);
            this.panel1.Location = new System.Drawing.Point(5, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 426);
            this.panel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(36, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bytes/sec";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Network Monitor";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader processName;
        private System.Windows.Forms.ColumnHeader programDownload;
        private System.Windows.Forms.ColumnHeader programUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label downloadDisplay;
        private System.Windows.Forms.Label uploadDisplay;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}

