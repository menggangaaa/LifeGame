namespace LifeGame
{
    partial class LifeGameWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRand = new System.Windows.Forms.Button();
            this.gridSize = new System.Windows.Forms.Label();
            this.gridSizeText = new System.Windows.Forms.TextBox();
            this.btnEditGrid = new System.Windows.Forms.Button();
            this.labelCount = new System.Windows.Forms.Label();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(810, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 40);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(810, 80);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(90, 40);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRand
            // 
            this.btnRand.Location = new System.Drawing.Point(810, 140);
            this.btnRand.Name = "btnRand";
            this.btnRand.Size = new System.Drawing.Size(90, 40);
            this.btnRand.TabIndex = 2;
            this.btnRand.Text = "随机";
            this.btnRand.UseVisualStyleBackColor = true;
            this.btnRand.Click += new System.EventHandler(this.btnRand_Click);
            // 
            // gridSize
            // 
            this.gridSize.AutoSize = true;
            this.gridSize.Location = new System.Drawing.Point(810, 200);
            this.gridSize.Name = "gridSize";
            this.gridSize.Size = new System.Drawing.Size(65, 12);
            this.gridSize.TabIndex = 3;
            this.gridSize.Text = "网格大小：";
            // 
            // gridSizeText
            // 
            this.gridSizeText.Location = new System.Drawing.Point(810, 220);
            this.gridSizeText.Name = "gridSizeText";
            this.gridSizeText.Size = new System.Drawing.Size(90, 21);
            this.gridSizeText.TabIndex = 4;
            this.gridSizeText.Text = "20";
            // 
            // btnEditGrid
            // 
            this.btnEditGrid.Location = new System.Drawing.Point(810, 260);
            this.btnEditGrid.Name = "btnEditGrid";
            this.btnEditGrid.Size = new System.Drawing.Size(90, 40);
            this.btnEditGrid.TabIndex = 5;
            this.btnEditGrid.Text = "修改网格";
            this.btnEditGrid.UseVisualStyleBackColor = true;
            this.btnEditGrid.Click += new System.EventHandler(this.btnEditGrid_Click);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(810, 320);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(41, 12);
            this.labelCount.TabIndex = 6;
            this.labelCount.Text = "步数：";
            // 
            // gridPanel
            // 
            this.gridPanel.BackColor = System.Drawing.Color.White;
            this.gridPanel.Location = new System.Drawing.Point(5, 5);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(801, 801);
            this.gridPanel.TabIndex = 7;
            this.gridPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gridPanel_Paint);
            // 
            // LifeGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 810);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.btnEditGrid);
            this.Controls.Add(this.gridSizeText);
            this.Controls.Add(this.gridSize);
            this.Controls.Add(this.btnRand);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "LifeGameWindow";
            this.Text = "生命游戏";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRand;
        private System.Windows.Forms.Label gridSize;
        private System.Windows.Forms.TextBox gridSizeText;
        private System.Windows.Forms.Button btnEditGrid;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Panel gridPanel;
    }
}

