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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtStream = new System.Windows.Forms.TextBox();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabIcecastComm = new System.Windows.Forms.TabPage();
            this.grpsent = new System.Windows.Forms.GroupBox();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.txtSongSendFromZara = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckSongFromZaraToIcecast = new System.Windows.Forms.CheckBox();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtJingles = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtZaraPath = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.txtMailDestination = new System.Windows.Forms.TextBox();
            this.btnShowPlayList = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabIcecastComm.SuspendLayout();
            this.grpsent.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTest);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.txtStream);
            this.groupBox1.Controls.Add(this.txtAdres);
            this.groupBox1.Location = new System.Drawing.Point(19, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 153);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Icecast settings (should match settings in icecast.xml)";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(12, 124);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(115, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test Icecast settings";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "admin password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "admin user:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Stream (shoutcast-mount):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "hostname + port:";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(145, 97);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(157, 20);
            this.txtPass.TabIndex = 0;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(145, 71);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(157, 20);
            this.txtUser.TabIndex = 0;
            // 
            // txtStream
            // 
            this.txtStream.Location = new System.Drawing.Point(145, 45);
            this.txtStream.Name = "txtStream";
            this.txtStream.Size = new System.Drawing.Size(157, 20);
            this.txtStream.TabIndex = 0;
            this.txtStream.Text = "/stream";
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(145, 19);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(157, 20);
            this.txtAdres.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabIcecastComm);
            this.tabControl1.Controls.Add(this.tabConfig);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(543, 420);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabIcecastComm
            // 
            this.tabIcecastComm.Controls.Add(this.grpsent);
            this.tabIcecastComm.Controls.Add(this.groupBox3);
            this.tabIcecastComm.Location = new System.Drawing.Point(4, 22);
            this.tabIcecastComm.Name = "tabIcecastComm";
            this.tabIcecastComm.Padding = new System.Windows.Forms.Padding(3);
            this.tabIcecastComm.Size = new System.Drawing.Size(535, 394);
            this.tabIcecastComm.TabIndex = 0;
            this.tabIcecastComm.Text = "Song2Icecast";
            this.tabIcecastComm.UseVisualStyleBackColor = true;
            // 
            // grpsent
            // 
            this.grpsent.Controls.Add(this.lblDateTime);
            this.grpsent.Controls.Add(this.txtSongSendFromZara);
            this.grpsent.Location = new System.Drawing.Point(12, 69);
            this.grpsent.Name = "grpsent";
            this.grpsent.Size = new System.Drawing.Size(403, 238);
            this.grpsent.TabIndex = 6;
            this.grpsent.TabStop = false;
            this.grpsent.Text = "Sent song info";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.Location = new System.Drawing.Point(7, 22);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(13, 13);
            this.lblDateTime.TabIndex = 4;
            this.lblDateTime.Text = "--";
            // 
            // txtSongSendFromZara
            // 
            this.txtSongSendFromZara.Enabled = false;
            this.txtSongSendFromZara.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSongSendFromZara.Location = new System.Drawing.Point(7, 41);
            this.txtSongSendFromZara.Multiline = true;
            this.txtSongSendFromZara.Name = "txtSongSendFromZara";
            this.txtSongSendFromZara.Size = new System.Drawing.Size(380, 179);
            this.txtSongSendFromZara.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ckSongFromZaraToIcecast);
            this.groupBox3.Location = new System.Drawing.Point(12, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(403, 48);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Watch ZaraStudio\'s txt";
            // 
            // ckSongFromZaraToIcecast
            // 
            this.ckSongFromZaraToIcecast.AutoSize = true;
            this.ckSongFromZaraToIcecast.Location = new System.Drawing.Point(7, 19);
            this.ckSongFromZaraToIcecast.Name = "ckSongFromZaraToIcecast";
            this.ckSongFromZaraToIcecast.Size = new System.Drawing.Size(249, 17);
            this.ckSongFromZaraToIcecast.TabIndex = 2;
            this.ckSongFromZaraToIcecast.Text = "Send Zara\'s current song info to Icecast Server";
            this.ckSongFromZaraToIcecast.UseVisualStyleBackColor = true;
            this.ckSongFromZaraToIcecast.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.groupBox4);
            this.tabConfig.Controls.Add(this.groupBox2);
            this.tabConfig.Controls.Add(this.groupBox1);
            this.tabConfig.Location = new System.Drawing.Point(4, 22);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(535, 394);
            this.tabConfig.TabIndex = 1;
            this.tabConfig.Text = "Configuration";
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtJingles);
            this.groupBox4.Location = new System.Drawing.Point(19, 236);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(393, 155);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Words to filter out (jingles and live show, seperated by comma)";
            // 
            // txtJingles
            // 
            this.txtJingles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJingles.Location = new System.Drawing.Point(3, 16);
            this.txtJingles.Multiline = true;
            this.txtJingles.Name = "txtJingles";
            this.txtJingles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtJingles.Size = new System.Drawing.Size(387, 136);
            this.txtJingles.TabIndex = 0;
            this.txtJingles.Text = "jingle radio scorpio,jingle club 106,Tijdsein - jingle,Jingles Scorpio,Jingles Sc" +
    "orpio Electro,Nieuws - TussenTune,Radio scorpio dubstep,nieuws~0.0,10.48.13,even" +
    "ement";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtZaraPath);
            this.groupBox2.Location = new System.Drawing.Point(19, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 64);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ZaraStudio: current song txt-file";
            // 
            // txtZaraPath
            // 
            this.txtZaraPath.Location = new System.Drawing.Point(12, 20);
            this.txtZaraPath.Name = "txtZaraPath";
            this.txtZaraPath.Size = new System.Drawing.Size(305, 20);
            this.txtZaraPath.TabIndex = 0;
            this.txtZaraPath.Text = "\\\\studio1\\ZaraRadio\\CurrentSong.txt";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(535, 394);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Playlist";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 311);
            this.panel2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(535, 311);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.btnShowPlayList);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dateTimeEnd);
            this.panel1.Controls.Add(this.dateTimeStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 83);
            this.panel1.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSendMail);
            this.groupBox5.Controls.Add(this.txtMailDestination);
            this.groupBox5.Location = new System.Drawing.Point(168, 31);
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
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // txtMailDestination
            // 
            this.txtMailDestination.Location = new System.Drawing.Point(7, 19);
            this.txtMailDestination.Name = "txtMailDestination";
            this.txtMailDestination.Size = new System.Drawing.Size(170, 20);
            this.txtMailDestination.TabIndex = 0;
            this.txtMailDestination.Text = "recipient@hotmail.com";
            this.txtMailDestination.TextChanged += new System.EventHandler(this.txtMailDestination_TextChanged);
            // 
            // btnShowPlayList
            // 
            this.btnShowPlayList.Location = new System.Drawing.Point(11, 31);
            this.btnShowPlayList.Name = "btnShowPlayList";
            this.btnShowPlayList.Size = new System.Drawing.Size(119, 49);
            this.btnShowPlayList.TabIndex = 4;
            this.btnShowPlayList.Text = "Show Playlist";
            this.btnShowPlayList.UseVisualStyleBackColor = true;
            this.btnShowPlayList.Click += new System.EventHandler(this.btnShowPlayList_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(258, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Till";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "From";
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.CustomFormat = "dd-MM-yyyy    HH:mm";
            this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeEnd.Location = new System.Drawing.Point(294, 4);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(200, 20);
            this.dateTimeEnd.TabIndex = 1;
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.CustomFormat = "dd-MM-yyyy    HH:mm";
            this.dateTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeStart.Location = new System.Drawing.Point(44, 4);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(200, 20);
            this.dateTimeStart.TabIndex = 0;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // timer1
            // 
            this.timer1.Interval = 600000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 420);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Update song metadata";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabIcecastComm.ResumeLayout(false);
            this.grpsent.ResumeLayout(false);
            this.grpsent.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabConfig.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtStream;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabIcecastComm;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtZaraPath;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.CheckBox ckSongFromZaraToIcecast;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.TextBox txtSongSendFromZara;
        private System.Windows.Forms.GroupBox grpsent;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnShowPlayList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSendMail;
        private System.Windows.Forms.TextBox txtMailDestination;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtJingles;
    }
}

