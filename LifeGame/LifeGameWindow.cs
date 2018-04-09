using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LifeGame
{
    public partial class LifeGameWindow : Form
    {
        private int wh;
        private int iwh;
        private int count;
        private Graphics g;
        private Grid[,] grids;
        private Grid[,] newgrids;
        private Bitmap bm;
        private Thread throad;
        private bool isStop = false;
        private Ant ant;

        public LifeGameWindow()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            //这个是位图的大小，一会画图的范围就是那么大
            bm = new Bitmap(801, 801);
            g = Graphics.FromImage(bm);
            gridPanel.BackgroundImage = bm;

            #region 数据初始化
            wh = 20;
            iwh = 800 / wh;
            count = 0;
            ant = new Ant(iwh / 2, iwh / 2, Direction.UP);
            arrayInit();
            #endregion

            drawGrid();
            drawLine();
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
            throad = new Thread(new ThreadStart(gameBody));
            throad.IsBackground = true;
            throad.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (throad != null)
            {
                if (isStop)
                {
                    throad.Resume();
                    isStop = false;
                }
                else
                {
                    throad.Suspend();
                    isStop = true;
                }
            }
        }

        private void btnRand_Click(object sender, EventArgs e)
        {
            if (throad != null)
            {
                throad.Suspend();
                isStop = true;
            }
            Random random = new Random();
            for (int i = 0; i < iwh; i++)
            {
                for (int j = 0; j < iwh; j++)
                {
                    grids[i, j].flag = random.Next(0,2);
                }
            }
            count = 0;
            g.Clear(Color.White);
            drawGrid();
            drawLine();
            gridPanel.Refresh();
        }

        private void btnEditGrid_Click(object sender, EventArgs e)
        {
            if (throad != null)
            {
                throad.Suspend();
                isStop = true;
            }
            string sizeString=gridSizeText.Text;
            wh = int.Parse(sizeString);
            iwh = 800 / wh;
            count = 0;
            ant = new Ant(iwh / 2, iwh / 2, Direction.UP);
            arrayInit();
            g.Clear(Color.White);
            drawGrid();
            drawLine();
            gridPanel.Refresh();
        }

        private void drawLine()
        {
            for (int i = 0; i < iwh + 1; i++)
            {
                g.DrawLine(new Pen(Color.Black), 0, i * wh, wh * iwh, i * wh);
                g.DrawLine(new Pen(Color.Black), i * wh, 0, i * wh, wh * iwh);
            }
        }

        private void drawGrid()
        {
            for (int i = 0; i < iwh; i++)
            {
                for (int j = 0; j < iwh; j++)
                {
                    if (grids[i,j].flag == 0)
                    {
                        g.FillRectangle(Brushes.White, grids[i, j].x + 1, grids[i, j].y + 1, wh - 2, wh - 2);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.Black, grids[i, j].x + 1, grids[i, j].y + 1, wh - 2, wh - 2);
                    }
                }
            }
            
        }

        private void lifeGameBody()
        {
            int n = 0;
            for (int i = 0; i < iwh; i++)
            {
                for (int j = 0; j < iwh; j++)
                {
                    if (i > 0 && i < iwh - 1 && j > 0 && j < iwh - 1)
                    {
                        // 格子都为都有8个格子的情况
                        n = grids[i - 1,j - 1].flag + grids[i,j - 1].flag + grids[i + 1,j - 1].flag + grids[i - 1,j].flag + grids[i - 1,j + 1].flag + grids[i,j + 1].flag + grids[i + 1,j + 1].flag + grids[i + 1,j].flag;

                    }
                    else
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                n = grids[i + 1,j].flag + grids[i + 1,j + 1].flag + grids[i,j + 1].flag;
                            }
                            else if (j == iwh - 1)
                            {
                                n = grids[i + 1,j].flag + grids[i + 1,j - 1].flag + grids[i,j - 1].flag;
                            }
                            else
                            {
                                n = grids[i,j - 1].flag + grids[i,j + 1].flag + grids[i + 1,j - 1].flag + grids[i + 1,j].flag + grids[i + 1,j + 1].flag;
                            }
                        }
                        else if (i == iwh - 1)
                        {
                            if (j == 0)
                            {
                                n = grids[i,j + 1].flag + grids[i - 1,j + 1].flag + grids[i - 1,j].flag;
                            }
                            else if (j == iwh - 1)
                            {
                                n = grids[i,j - 1].flag + grids[i - 1,j - 1].flag + grids[i - 1,j].flag;
                            }
                            else
                            {
                                n = grids[i,j - 1].flag + grids[i,j + 1].flag + grids[i - 1,j - 1].flag + grids[i - 1,j].flag + grids[i - 1,j + 1].flag;
                            }
                        }
                        else if (j == 0)
                        {
                            n = grids[i - 1,j].flag + grids[i + 1,j].flag + grids[i - 1,j + 1].flag + grids[i,j + 1].flag + grids[i + 1,j + 1].flag;
                        }
                        else if (j == iwh - 1)
                        {
                            n = grids[i - 1,j].flag + grids[i + 1,j].flag + grids[i - 1,j - 1].flag + grids[i,j - 1].flag + grids[i + 1,j - 1].flag;
                        }
                    }
                    switch (n)
                    {
                        case 2:
                            newgrids[i,j].flag = grids[i,j].flag;
                            break;
                        case 3:
                            newgrids[i,j].flag = 1;
                            break;
                        default:
                            newgrids[i,j].flag = 0;
                            break;
                    }
                }
            }
        }

        private void lutonGameBody()
        {
            if (ant.x >= 0 && ant.x < iwh && ant.y >= 0 && ant.y < iwh)
            {
                if (grids[ant.x,ant.y].flag == 1)
                {
                    grids[ant.x,ant.y].flag = 0;
                    switch (ant.direction)
                    {
                        case Direction.UP:
                            ant.direction = Direction.RIGHT;
                            break;
                        case Direction.RIGHT:
                            ant.direction = Direction.DOWN;
                            break;
                        case Direction.DOWN:
                            ant.direction = Direction.LEFT;
                            break;
                        case Direction.LEFT:
                            ant.direction = Direction.UP;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    grids[ant.x,ant.y].flag = 1;
                    switch (ant.direction)
                    {
                        case Direction.UP:
                            ant.direction = Direction.LEFT;
                            break;
                        case Direction.RIGHT:
                            ant.direction = Direction.UP;
                            break;
                        case Direction.DOWN:
                            ant.direction = Direction.RIGHT;
                            break;
                        case Direction.LEFT:
                            ant.direction = Direction.DOWN;
                            break;
                        default:
                            break;
                    }
                }
            }
            switch (ant.direction)
            {
                case Direction.UP:
                    ant.x = ant.x - 1;
                    break;
                case Direction.RIGHT:
                    ant.y = ant.y + 1;
                    break;
                case Direction.DOWN:
                    ant.x = ant.x + 1;
                    break;
                case Direction.LEFT:
                    ant.y = ant.y - 1;
                    break;
                default:
                    break;
            }
        }

        private void gameBody()
        {
            while (true)
            {
                newarrayInit();
                if (lifeRadio.Checked)
                {
                    lifeGameBody();
                    grids = newgrids;
                }
                else if (lutonRadio.Checked)
                {
                    lutonGameBody();
                }
                count++;
                labelCount.Text = "步数：" + count;
                g.Clear(Color.White);
                drawGrid();
                drawLine();
                gridPanel.Refresh();
            }
        }
    }
}
