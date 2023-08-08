using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pyatnashki
{
    public partial class Form1 : Form
    {
        int sise = 50;
        int kol1 = 3;
        const int kol = 3;
        Button but;
        Button[,] but3 = new Button[kol,kol];
        private int[,] mao = new int[kol, kol];

        public Form1()
        {
            InitializeComponent();
            CreatMap();
            MapNamber();
            activ();
            this.Width = kol1*sise+(kol1-1) * kol1 + 20;
            this.Height = kol1 * sise + (kol1+1)  *3 +30 + 20;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CreatMap()
        {
            for(int i = 0; i < kol; i++)
            {
                for (int j = 0; j < kol; j++)
                {
                    but3[i, j] = new Button();
                    but = new Button();
                    but.Size = new Size(sise, sise);
                    but.Location = new Point( j * sise,20+i * sise);
                    but.Click += MyNewButton_Click;
                    but.BackColor = Color.White;
                    Controls.Add(but);
                    but3[i, j] = but;
                    but3[i, j].Font = new Font("Times New Roman", 14);
                }
            }
        }

        private void MapNamber()
        {
            int a = 0;
            for (int i = 0; i < kol; i++)
            {
                for (int j = 0; j < kol; j++)
                {
                    mao[i, j] = a;
                    if (mao[i, j] != 0)
                        but3[i, j].Text = Convert.ToString(a);
                    a++;
                    
                }
            }
        }

        private void MyNewButton_Click(object sender, EventArgs e)
        {

            Button obbaut = sender as Button;
            int a = mao[obbaut.Location.Y / sise, obbaut.Location.X / sise];
            Prow(a);
            activ();
        }

        private void Prow(int a)
        {
            bool q;
            for (int i = 0; i < kol; i++)
            {
                for (int j = 0; j < kol; j++)
                {
                    q = true;
                    if (mao[i, j] == a)
                    {
                        mao[i, j] = 0;
                        but3[i, j].Text = " ";
                        q = false;
                    }
                    if (mao[i, j] == 0 && q==true)
                    {
                        mao[i, j] = a;
                        but3[i, j].Text = Convert.ToString(a);
                    }
                }
            }
        }

        private void activ()
        {
            int x, y, x1=0, y1=0;
            for (int i = 0; i < kol; i++)
                for (int j = 0; j < kol; j++)
                {
                    but3[i, j].Enabled = false;
                    if (mao[i, j] == 0)
                    {
                        x1 = i; 
                        y1 = j;
                    }
                }
            x = x1;
            y = y1;
            if (x++ < kol1 - 1)
                but3[x, y].Enabled = true;
            x = x1;
            if (y++ < kol1 - 1)
                but3[x, y].Enabled = true;
            y = y1;
            if (y-- > 0)
                but3[x, y].Enabled = true;
            y = y1;
            if (x-- > 0)
                but3[x, y].Enabled = true;
        }
    }
}
