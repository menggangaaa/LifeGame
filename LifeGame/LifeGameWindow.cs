using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeGame
{
    public partial class LifeGameWindow : Form
    {
        private int wh;
        private int iwh;
        private Graphics g;
        private Grid[,] grids;
        private Grid[,] newgrids;



        public LifeGameWindow()
        {
            InitializeComponent();
            #region 数据初始化
            wh = 20;
            iwh = 800 / wh;
            arrayInit();
            #endregion
        }

        private void gridPanel_Paint(object sender, PaintEventArgs e)
        {
           g = e.Graphics;
            //g.DrawLine(new Pen(Color.Black), 0, 0, 800, 800);
            for (int i = 0; i < iwh+1; i++)
            {
                g.DrawLine(new Pen(Color.Black), 0, i*wh, 800, i*wh);
                g.DrawLine(new Pen(Color.Black), i*wh, 0, i*wh, 800);
            }
        }
        private void arrayInit()
        {
            grids = new Grid[iwh, iwh];
            for (int i = 0; i < iwh; i++)
            {
                for (int j = 0; j < iwh ; j++)
                {
                    grids[i, j] = new Grid(i * wh, j * wh, 0);
                }
            }
        }
        private void newarrayInit()
        {
            newgrids = new Grid[iwh, iwh];
            for (int i = 0; i < iwh; i++)
            {
                for (int j = 0; j < iwh; j++)
                {
                    newgrids[i, j] = new Grid(i * wh, j * wh, 0);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        private void btnRand_Click(object sender, EventArgs e)
        {

        }

        private void btnEditGrid_Click(object sender, EventArgs e)
        {

        }
    }
}
