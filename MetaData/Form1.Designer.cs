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
            this.grpsent = new System.Windows.Forms.GroupBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.ckSongFromZaraToIcecast = new System.Windows.Forms.CheckBox();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.txtSongSendFromZara = new System.Windows.Forms.TextBox();
            this.tmrPoll = new System.Windows.Forms.Timer(this.components);
            this.grpsent.SuspendLayout();
            this.SuspendLayout();
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
            // tmrPoll
            // 
            this.tmrPoll.Tick += new System.EventHandler(this.tmrPoll_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 115);
            this.Controls.Add(this.grpsent);
            this.Name = "Form1";
            this.Text = "Waiting for CurrentSong.Txt to become available";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.grpsent.ResumeLayout(false);
            this.grpsent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpsent;
        private System.Windows.Forms.CheckBox ckSongFromZaraToIcecast;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.TextBox txtSongSendFromZara;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Timer tmrPoll;
    }
}

