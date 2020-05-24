namespace GameStoryEditor
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
            this.button_Player = new System.Windows.Forms.Button();
            this.button_NPC = new System.Windows.Forms.Button();
            this.button_Story = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Player
            // 
            this.button_Player.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_Player.Location = new System.Drawing.Point(28, 30);
            this.button_Player.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Player.Name = "button_Player";
            this.button_Player.Size = new System.Drawing.Size(208, 84);
            this.button_Player.TabIndex = 0;
            this.button_Player.Text = "编辑玩家";
            this.button_Player.UseVisualStyleBackColor = false;
            this.button_Player.Click += new System.EventHandler(this.button_Player_Click);
            // 
            // button_NPC
            // 
            this.button_NPC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_NPC.Location = new System.Drawing.Point(292, 30);
            this.button_NPC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_NPC.Name = "button_NPC";
            this.button_NPC.Size = new System.Drawing.Size(213, 84);
            this.button_NPC.TabIndex = 0;
            this.button_NPC.Text = "编辑NPC";
            this.button_NPC.UseVisualStyleBackColor = false;
            this.button_NPC.Click += new System.EventHandler(this.button_NPC_Click);
            // 
            // button_Story
            // 
            this.button_Story.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_Story.Location = new System.Drawing.Point(562, 30);
            this.button_Story.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Story.Name = "button_Story";
            this.button_Story.Size = new System.Drawing.Size(198, 84);
            this.button_Story.TabIndex = 0;
            this.button_Story.Text = "编辑对话树";
            this.button_Story.UseVisualStyleBackColor = false;
            this.button_Story.Click += new System.EventHandler(this.button_Story_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(28, 412);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "创建数据库";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(889, 466);
            this.Controls.Add(this.button_Story);
            this.Controls.Add(this.button_NPC);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_Player);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Player;
        private System.Windows.Forms.Button button_NPC;
        private System.Windows.Forms.Button button_Story;
        private System.Windows.Forms.Button button1;
    }
}