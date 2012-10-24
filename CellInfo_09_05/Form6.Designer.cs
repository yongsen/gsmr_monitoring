namespace CellInfo
{
    partial class Form6
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
            this.zGraph1 = new ZhengJuyin.UI.ZGraph();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zGraph1
            // 
            this.zGraph1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zGraph1.BackColor = System.Drawing.Color.White;
            this.zGraph1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zGraph1.Location = new System.Drawing.Point(9, 9);
            this.zGraph1.m_backColorH = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.zGraph1.m_backColorL = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.zGraph1.m_BigXYBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.zGraph1.m_BigXYButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.zGraph1.m_BigXYButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zGraph1.m_ControlButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zGraph1.m_ControlButtonForeColorH = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.zGraph1.m_ControlButtonForeColorL = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.zGraph1.m_ControlItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zGraph1.m_coordinateLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zGraph1.m_coordinateStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zGraph1.m_coordinateStringTitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zGraph1.m_DirectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.zGraph1.m_DirectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.zGraph1.m_fXBeginSYS = 0F;
            this.zGraph1.m_fXEndSYS = 120F;
            this.zGraph1.m_fYBeginSYS = -120F;
            this.zGraph1.m_fYEndSYS = -20F;
            this.zGraph1.m_GraphBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zGraph1.m_iLineShowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.zGraph1.m_iLineShowColorAlpha = 100;
            this.zGraph1.m_SySnameX = "时间";
            this.zGraph1.m_SySnameY = "dBm";
            this.zGraph1.m_SyStitle = "波形显示";
            this.zGraph1.m_titleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.zGraph1.m_titleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zGraph1.m_titlePosition = 0.4F;
            this.zGraph1.m_titleSize = 14;
            this.zGraph1.Margin = new System.Windows.Forms.Padding(0);
            this.zGraph1.MinimumSize = new System.Drawing.Size(390, 270);
            this.zGraph1.Name = "zGraph1";
            this.zGraph1.Size = new System.Drawing.Size(454, 270);
            this.zGraph1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "刷新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 305);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zGraph1);
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "WaveForm";
            this.Load += new System.EventHandler(this.Form6_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ZhengJuyin.UI.ZGraph zGraph1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}