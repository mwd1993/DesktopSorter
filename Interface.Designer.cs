
namespace DesktopSorterWF
{
    partial class Interface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interface));
            this.HeadingText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.ignoreCompressionText = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.desktopfilesSizeText = new System.Windows.Forms.Label();
            this.sortedDirectorySizeText = new System.Windows.Forms.Label();
            this.lv1Disabled = new System.Windows.Forms.ListView();
            this.lv2Disabled = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // HeadingText
            // 
            this.HeadingText.AutoSize = true;
            this.HeadingText.Font = new System.Drawing.Font("Microsoft YaHei", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HeadingText.Location = new System.Drawing.Point(128, 9);
            this.HeadingText.Name = "HeadingText";
            this.HeadingText.Size = new System.Drawing.Size(292, 50);
            this.HeadingText.TabIndex = 0;
            this.HeadingText.Text = "DesktopSorter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(96, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desktop Files";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(29, 86);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(238, 191);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(375, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sorted Directory";
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(308, 86);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(238, 191);
            this.listView2.TabIndex = 5;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.List;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGreen;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(29, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Compress";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ignoreCompressionText
            // 
            this.ignoreCompressionText.Location = new System.Drawing.Point(128, 301);
            this.ignoreCompressionText.Name = "ignoreCompressionText";
            this.ignoreCompressionText.PlaceholderText = "Ignore IE: .txt,.jpg,folders";
            this.ignoreCompressionText.Size = new System.Drawing.Size(139, 23);
            this.ignoreCompressionText.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(308, 300);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Decompress";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightGreen;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(453, 300);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "View";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightSlateGray;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Location = new System.Drawing.Point(45, 356);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Github";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Gold;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button5.Location = new System.Drawing.Point(161, 356);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "Donate";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(325, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Developed by Marc D | Version: 0.0.4";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(29, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(517, 44);
            this.label4.TabIndex = 13;
            // 
            // desktopfilesSizeText
            // 
            this.desktopfilesSizeText.AutoSize = true;
            this.desktopfilesSizeText.Location = new System.Drawing.Point(29, 280);
            this.desktopfilesSizeText.Name = "desktopfilesSizeText";
            this.desktopfilesSizeText.Size = new System.Drawing.Size(153, 15);
            this.desktopfilesSizeText.TabIndex = 14;
            this.desktopfilesSizeText.Text = "Size: 0KB (Folders Excluded)";
            // 
            // sortedDirectorySizeText
            // 
            this.sortedDirectorySizeText.AutoSize = true;
            this.sortedDirectorySizeText.Location = new System.Drawing.Point(308, 280);
            this.sortedDirectorySizeText.Name = "sortedDirectorySizeText";
            this.sortedDirectorySizeText.Size = new System.Drawing.Size(53, 15);
            this.sortedDirectorySizeText.TabIndex = 15;
            this.sortedDirectorySizeText.Text = "Size: 0KB";
            // 
            // lv1Disabled
            // 
            this.lv1Disabled.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lv1Disabled.Cursor = System.Windows.Forms.Cursors.No;
            this.lv1Disabled.HideSelection = false;
            this.lv1Disabled.Location = new System.Drawing.Point(29, 85);
            this.lv1Disabled.Name = "lv1Disabled";
            this.lv1Disabled.Size = new System.Drawing.Size(238, 191);
            this.lv1Disabled.TabIndex = 16;
            this.lv1Disabled.UseCompatibleStateImageBehavior = false;
            this.lv1Disabled.View = System.Windows.Forms.View.List;
            // 
            // lv2Disabled
            // 
            this.lv2Disabled.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lv2Disabled.Cursor = System.Windows.Forms.Cursors.No;
            this.lv2Disabled.HideSelection = false;
            this.lv2Disabled.Location = new System.Drawing.Point(308, 86);
            this.lv2Disabled.Name = "lv2Disabled";
            this.lv2Disabled.Size = new System.Drawing.Size(238, 191);
            this.lv2Disabled.TabIndex = 17;
            this.lv2Disabled.UseCompatibleStateImageBehavior = false;
            this.lv2Disabled.View = System.Windows.Forms.View.List;
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(577, 412);
            this.Controls.Add(this.sortedDirectorySizeText);
            this.Controls.Add(this.desktopfilesSizeText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ignoreCompressionText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HeadingText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lv2Disabled);
            this.Controls.Add(this.lv1Disabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Interface";
            this.Opacity = 0.96D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DesktopSorter";
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeadingText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ignoreCompressionText;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label desktopfilesSizeText;
        private System.Windows.Forms.Label sortedDirectorySizeText;
        private System.Windows.Forms.ListView lv1Disabled;
        private System.Windows.Forms.ListView lv2Disabled;
    }
}

