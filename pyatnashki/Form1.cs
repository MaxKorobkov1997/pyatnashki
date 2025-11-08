using System;
using System.Drawing;
using System.Windows.Forms;

namespace pyatnashki
{
    public partial class Form1 : Form
    {
        int size = 50, kolPyt = 4;
        const int kolPytConst = 4;
        Button but, butPlayPyt;
        Button[,] but3;
        int[,] map = new int[kolPytConst, kolPytConst];

        public Form1()
        {
            InitializeComponent();
            ButPlay();
            ClientSize = new Size(50, 50);
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void ButPlay()
        {
            butPlayPyt = new Button();
            CreatButton(butPlayPyt, 0, 0, 100, 30, 0, 0);
            butPlayPyt.Click += Pyt_Click;
            butPlayPyt.Font = new Font("Times New Roman", 14);
            butPlayPyt.Text = "Пятнашки";
        }

        private void CreatMap()
        {
            but3 = new Button[kolPyt, kolPyt];
            for (int i = 0; i < kolPyt; i++)
            {
                for (int j = 0; j < kolPyt; j++)
                {
                    but = new Button();
                    CreatButton(but, i, j, size, size, 0, 30);
                    but.Click += MyNewButton_Click;
                    but3[i, j] = new Button();
                    but3[i, j] = but;
                    but3[i, j].Font = new Font("Times New Roman", 14);
                    if (map[i, j] != kolPyt * kolPyt)
                        but3[i, j].Text = Convert.ToString(map[i, j]);
                }   
            }
        }

        private void CreatButton(Button but, int i, int j, int vsise, int gsise, int vert, int gort)
        {
            but.Size = new Size(vsise, gsise);
            but.Location = new Point(vert + j * vsise, gort + i * gsise);
            but.BackColor = Color.White;
            Controls.Add(but);
        }

        private void MapNamber()
        {
            int a = 1;
            for (int i = 0; i < kolPyt; i++)
            {
                for (int j = 0; j < kolPyt; j++)
                {
                    map[i, j] = a;
                    a++;
                }
            }
        }

        private void Pyt_Click(object sender, EventArgs e)
        {
            ClientSize = new Size(kolPytConst * size, kolPytConst * size + 30);
            MapNamber();
            CreatMap();
            Diseble();
            activ(ProvZero().Item1, ProvZero().Item2);
        }

        private void MyNewButton_Click(object sender, EventArgs e)
        {
            Button obbaut = sender as Button;
            int I = map[obbaut.Location.Y / size, obbaut.Location.X / size];
            but3[ProvZero().Item1, ProvZero().Item2].Text = Convert.ToString(I);
            map[ProvZero().Item1, ProvZero().Item2] = I;
            but3[obbaut.Location.Y / size, obbaut.Location.X / size].Text = "";
            map[obbaut.Location.Y / size, obbaut.Location.X / size] = kolPyt * kolPyt;
            Diseble();
            activ(ProvZero().Item1, ProvZero().Item2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void Diseble()
        {
            for (int i = 0; i < kolPyt; i++)
                for (int j = 0; j < kolPyt; j++)
                {
                    but3[i, j].Enabled = false;
                } 
        }
        private Tuple<int, int> ProvZero()
        {
            int x = 0, y = 0;
            for (int i = 0; i < kolPyt; i++)
                for (int j = 0; j < kolPyt; j++)
                    if (map[i, j] == kolPyt * kolPyt)
                    {
                        x = i;
                        y = j;
                    }
            return Tuple.Create(x, y);
        }
        private void activ(int x1, int y1)
        {
            int x, y;
            
            x = x1;
            y = y1;
            if (x++ < kolPyt - 1)
                but3[x, y].Enabled = true;
            x = x1;
            if (y++ < kolPyt - 1)
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
