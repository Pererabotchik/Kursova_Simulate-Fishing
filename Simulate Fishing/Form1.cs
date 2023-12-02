using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulate_Fishing
{
    public partial class Form1 : Form
    {
        Positive_fish fs_p = new Positive_fish();
        Negative_fish fs_n = new Negative_fish();
        Fishing_rod pop = new Fishing_rod();

        int score_in_game = 0;

        public Point fish_position_p = new Point(20, 400);
        public Point fish_position_n = new Point(20, 250);
        public Point direction = Point.Empty;

        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();

            if (fish_position_p.X < 0 || fish_position_p.X > 850 || fish_position_p.Y < 0 || fish_position_p.Y > 550)
            {
                Random r = new Random();
                int positon_spawn = r.Next(1,4);

                if (positon_spawn == 1)
                    fish_position_p = new Point(20, 40);
                else if (positon_spawn == 2)
                    fish_position_p = new Point(20, 250);
                else if (positon_spawn == 3)
                    fish_position_p = new Point(20, 400);
            }

            if (fish_position_n.X < 0 || fish_position_n.X > 850 || fish_position_n.Y < 0 || fish_position_n.Y > 550)
            {
                Random r = new Random();
                int positon_spawn = r.Next(1, 4);

                if (positon_spawn == 1)
                    fish_position_n = new Point(20, 40);
                else if (positon_spawn == 2)
                    fish_position_n = new Point(20, 250);
                else if (positon_spawn == 3)
                    fish_position_n = new Point(20, 400);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random r = new Random();

            timer2.Interval = r.Next(25, 1000);
            direction.X = r.Next(0, 5);
            direction.Y = r.Next(-4, 1);
        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            fish_position_p.X += direction.X + fs_p.speed;
            fish_position_p.Y += direction.Y + fs_p.speed;

            fish_position_n.X += direction.X + fs_n.speed;
            fish_position_n.Y += direction.Y + fs_n.speed;

            var fish_react_p = new Rectangle(fish_position_p.X - 50, fish_position_p.Y - 50, 100, 100);
            var fish_react_n = new Rectangle(fish_position_n.X - 20, fish_position_n.Y - 20, 100, 100);

            g.DrawImage(fs_p.textures, fish_react_p);
            g.DrawImage(fs_n.textures, fish_react_n);

            var localPosition = this.PointToClient(Cursor.Position);
            g.DrawImage(pop.poplavok, new Rectangle(localPosition.X - 50, localPosition.Y - 50, 100,100));
               
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            var localPosition = this.PointToClient(Cursor.Position);
            var fishRect_p = new Rectangle(fish_position_p.X - 50, fish_position_p.Y - 50, 100, 100);
            var fishRect_n = new Rectangle(fish_position_n.X - 50, fish_position_n.Y - 50, 100, 100);

            if (fishRect_p.Contains(localPosition))
            {
                Random r = new Random();
                int positon_spawn = r.Next(1, 4);

                if (positon_spawn == 1)
                    fish_position_p = new Point(20, 40);
                else if (positon_spawn == 2)
                    fish_position_p = new Point(20, 250);
                else if (positon_spawn == 3)
                    fish_position_p = new Point(20, 400);

                score_in_game += fs_p.score_p;

            }

            if (fishRect_n.Contains(localPosition))
            {
                Random r = new Random();
                int positon_spawn = r.Next(1, 4);

                if (positon_spawn == 1)
                    fish_position_n = new Point(20, 40);
                else if (positon_spawn == 2)
                    fish_position_n = new Point(20, 250);
                else if (positon_spawn == 3)
                    fish_position_n = new Point(20, 400);
                
                score_in_game -= fs_n.score_n;

            }

            Score_l.Text = score_in_game.ToString();

            if (score_in_game == 100)
            {
                DialogResult result_box = MessageBox.Show("Перейти на наступний рівень! ");

                Form3 f3 = new Form3();
                f3.Show();
                this.Hide();
            }
        }
    }
}
