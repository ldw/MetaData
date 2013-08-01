namespace MetaData
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
            this.components = new System.ComponentModel.Container();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grpsent = new System.Windows.Forms.GroupBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.ckSongFromZaraToIcecast = new System.Windows.Forms.CheckBox();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.txtSongSendFromZara = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpPlaylist = new System.Windows.Forms.Panel();
            this.groupBoxPlaylist = new System.Windows.Forms.GroupBox();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.txtMailDestination = new System.Windows.Forms.TextBox();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.btnShowPlayList = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.grpsent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpPlaylist.SuspendLayout();
            this.groupBoxPlaylist.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // grpsent
            // 
            this.grpsent.Controls.Add(this.btnTest);
            this.grpsent.Controls.Add(this.ckSongFromZaraToIcecast);
            this.grpsent.Controls.Add(this.lblDateTime);
            this.grpsent.Controls.Add(this.txtSongSendFromZara);
            this.grpsent.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpsent.Location = new System.Drawing.Point(0, 0);
            this.grpsent.Name = "grpsent";
            this.grpsent.Size = new System.Drawing.Size(505, 110);
            this.grpsent.TabIndex = 7;
            this.grpsent.TabStop = false;
            this.grpsent.Text = "Active monitoring";
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.Location = new System.Drawing.Point(353, 12);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 40);
            this.btnTest.TabIndex = 5;
            this.btnTest.Text = "Test Icecast communication";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.button1_Click);
            // 
            // ckSongFromZaraToIcecast
            // 
            this.ckSongFromZaraToIcecast.AutoSize = true;
            this.ckSongFromZaraToIcecast.Enabled = false;
            this.ckSongFromZaraToIcecast.Location = new System.Drawing.Point(9, 22);
            this.ckSongFromZaraToIcecast.Name = "ckSongFromZaraToIcecast";
            this.ckSongFromZaraToIcecast.Size = new System.Drawing.Size(328, 17);
            this.ckSongFromZaraToIcecast.TabIndex = 2;
            this.ckSongFromZaraToIcecast.Text = "Monitoring active (Zara\'s output will be read and sent to Icecast)";
            this.ckSongFromZaraToIcecast.UseVisualStyleBackColor = true;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.Location = new System.Drawing.Point(6, 42);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(13, 13);
            this.lblDateTime.TabIndex = 4;
            this.lblDateTime.Text = "--";
            // 
            // txtSongSendFromZara
            // 
            this.txtSongSendFromZara.Enabled = false;
            this.txtSongSendFromZara.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSongSendFromZara.Location = new System.Drawing.Point(12, 58);
            this.txtSongSendFromZara.Multiline = true;
            this.txtSongSendFromZara.Name = "txtSongSendFromZara";
            this.txtSongSendFromZara.Size = new System.Drawing.Size(483, 46);
            this.txtSongSendFromZara.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 215);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(505, 193);
            this.dataGridView1.TabIndex = 8;
            // 
            // grpPlaylist
            // 
            this.grpPlaylist.Controls.Add(this.groupBoxPlaylist);
            this.grpPlaylist.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPlaylist.Location = new System.Drawing.Point(0, 110);
            this.grpPlaylist.Name = "grpPlaylist";
            this.grpPlaylist.Size = new System.Drawing.Size(505, 105);
            this.grpPlaylist.TabIndex = 9;
            // 
            // groupBoxPlaylist
            // 
            this.groupBoxPlaylist.Controls.Add(this.dateTimeStart);
            this.groupBoxPlaylist.Controls.Add(this.groupBox5);
            this.groupBoxPlaylist.Controls.Add(this.dateTimeEnd);
            this.groupBoxPlaylist.Controls.Add(this.btnShowPlayList);
            this.groupBoxPlaylist.Controls.Add(this.label5);
            this.groupBoxPlaylist.Controls.Add(this.label6);
            this.groupBoxPlaylist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPlaylist.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPlaylist.Name = "groupBoxPlaylist";
            this.groupBoxPlaylist.Size = new System.Drawing.Size(505, 105);
            this.groupBoxPlaylist.TabIndex = 6;
            this.groupBoxPlaylist.TabStop = false;
            this.groupBoxPlaylist.Text = "Playlist";
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.CustomFormat = "dd-MM-yyyy    HH:mm";
            this.dateTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeStart.Location = new System.Drawing.Point(45, 19);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(200, 20);
            this.dateTimeStart.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSendMail);
            this.groupBox5.Controls.Add(this.txtMailDestination);
            this.groupBox5.Location = new System.Drawing.Point(169, 46);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(326, 49);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "E-mail below playlist";
            // 
            // btnSendMail
            // 
            this.btnSendMail.Enabled = false;
            this.btnSendMail.Location = new System.Drawing.Point(184, 19);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(75, 23);
            this.btnSendMail.TabIndex = 1;
            this.btnSendMail.Text = "Send e-mail";
            this.btnSendMail.UseVisualStyleBackColor = true;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click_1);
            // 
            // txtMailDestination
            // 
            this.txtMailDestination.Location = new System.Drawing.Point(7, 19);
            this.txtMailDestination.Name = "txtMailDestination";
            this.txtMailDestination.Size = new System.Drawing.Size(170, 20);
            this.txtMailDestination.TabIndex = 0;
            this.txtMailDestination.Text = "muziek@radioscorpio.be";
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.CustomFormat = "dd-MM-yyyy    HH:mm";
            this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeEnd.Location = new System.Drawing.Point(295, 19);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(200, 20);
            this.dateTimeEnd.TabIndex = 1;
            // 
            // btnShowPlayList
            // 
            this.btnShowPlayList.Location = new System.Drawing.Point(12, 46);
            this.btnShowPlayList.Name = "btnShowPlayList";
            this.btnShowPlayList.Size = new System.Drawing.Size(119, 49);
            this.btnShowPlayList.TabIndex = 4;
            this.btnShowPlayList.Text = "Show Playlist";
            this.btnShowPlayList.UseVisualStyleBackColor = true;
            this.btnShowPlayList.Click += new System.EventHandler(this.btnShowPlayList_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "From";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(259, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Till";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnShowPlayList;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 408);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.grpPlaylist);
            this.Controls.Add(this.grpsent);
            this.Name = "Form1";
            this.Text = "Scorpio\'s Icecast Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.grpsent.ResumeLayout(false);
            this.grpsent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpPlaylist.ResumeLayout(false);
            this.groupBoxPlaylist.ResumeLayout(false);
            this.groupBoxPlaylist.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel grpPlaylist;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSendMail;
        private System.Windows.Forms.TextBox txtMailDestination;
        private System.Windows.Forms.Button btnShowPlayList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.GroupBox grpsent;
        private System.Windows.Forms.CheckBox ckSongFromZaraToIcecast;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.TextBox txtSongSendFromZara;
        private System.Windows.Forms.GroupBox groupBoxPlaylist;
        private System.Windows.Forms.Button btnTest;
    }
}

