namespace CellInfo
{
    partial class Wave_Zone
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
            this.刷新 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.zGraph1 = new ZhengJuyin.UI.ZGraph();
            this.SuspendLayout();
            // 
            // 刷新
            // 
            this.刷新.Location = new System.Drawing.Point(228, 282);
            this.刷新.Name = "刷新";
            this.刷新.Size = new System.Drawing.Size(75, 21);
            this.刷新.TabIndex = 1;
            this.刷新.Text = "刷新";
            this.刷新.UseVisualStyleBackColor = true;
            this.刷新.Click += new System.EventHandler(this.刷新_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // zGraph1
            // 
            this.zGraph1.BackColor = System.Drawing.Color.White;
            this.zGraph1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zGraph1.Location = new System.Drawing.Point(7, 8);
            this.zGraph1.m_backColorH = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.zGraph1.m_backColorL = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.zGraph1.m_BigXYBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.zGraph1.m_BigXYButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.zGraph1.m_BigXYButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.zGraph1.m_ControlButtonBackColor = System.Drawing.Color.Silver;
            this.zGraph1.m_ControlButtonForeColorH = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.zGraph1.m_ControlButtonForeColorL = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.zGraph1.m_ControlItemBackColor = System.Drawing.Color.Silver;
            this.zGraph1.m_coordinateLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.zGraph1.m_coordinateStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zGraph1.m_coordinateStringTitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zGraph1.m_DirectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.zGraph1.m_DirectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.zGraph1.m_fXBeginSYS = 0F;
            this.zGraph1.m_fXEndSYS = 120F;
            this.zGraph1.m_fYBeginSYS = -120F;
            this.zGraph1.m_fYEndSYS = 0F;
            this.zGraph1.m_GraphBackColor = System.Drawing.Color.Silver;
            this.zGraph1.m_iLineShowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.zGraph1.m_iLineShowColorAlpha = 100;
            this.zGraph1.m_SySnameX = "时间/s";
            this.zGraph1.m_SySnameY = "信号强度/dBm";
            this.zGraph1.m_SyStitle = "波形显示";
            this.zGraph1.m_titleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.zGraph1.m_titleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zGraph1.m_titlePosition = 0.4F;
            this.zGraph1.m_titleSize = 14;
            this.zGraph1.Margin = new System.Windows.Forms.Padding(0);
            this.zGraph1.MinimumSize = new System.Drawing.Size(390, 270);
            this.zGraph1.Name = "zGraph1";
            this.zGraph1.Size = new System.Drawing.Size(520, 270);
            this.zGraph1.TabIndex = 2;
            // 
            // Wave_Zone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 302);
            this.Controls.Add(this.zGraph1);
            this.Controls.Add(this.刷新);
            this.Name = "Wave_Zone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Ｗave_Zone";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button 刷新;
        private System.Windows.Forms.Timer timer1;
        private ZhengJuyin.UI.ZGraph zGraph1;
    }
}