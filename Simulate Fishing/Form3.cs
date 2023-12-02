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
    public partial class Form3 : Form
    {
        Positive_fish fs_p = new Positive_fish();
        Negative_fish fs_n = new Negative_fish();
        Fishing_rod pop = new Fishing_rod();

        int score_in_game = 0;

        private Point fish_position_p = new Point(20, 450);
        private Point fish_position_n = new Point(20, 280);
        private Point direction = Point.Empty;
        public Form3()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (fish_position_p.Y > 230)
            {
                fish_position_p.X += direction.X + fs_p.speed;
                fish_position_p.Y += direction.Y + fs_p.speed;
            }
            else if (fish_position_p.Y <= 230)
            {
                fish_position_p.Y = 240;
            }

            if (fish_position_n.Y > 220)
            {
                fish_position_n.X += direction.X + fs_n.speed;
                fish_position_n.Y += direction.Y + fs_n.speed;
            }
            else if (fish_position_n.Y <= 220)
            {
                fish_position_n.Y = 240;
            }

            var fish_react_p = new Rectangle(fish_position_p.X - 50, fish_position_p.Y - 50, 100, 100);
            var fish_react_m = new Rectangle(fish_position_n.X - 20, fish_position_n.Y - 20, 100, 100);

            g.DrawImage(fs_p.textures, fish_react_p);
            g.DrawImage(fs_n.textures, fish_react_m);

            if (comboBox1.Text == "Вудочка")
                pop.Set_poplavok();
            else if(comboBox1.Text == "Спінінг")
                pop.Set_spining();

            var localPosition = this.PointToClient(Cursor.Position);
            g.DrawImage(pop.poplavok, new Rectangle(localPosition.X - 50, localPosition.Y - 50, 100, 100));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();

            if (fish_position_p.X < 0 || fish_position_p.X > 850 || fish_position_p.Y < 0 || fish_position_p.Y > 550)
            {
                Random r = new Random();
                int positon_spawn = r.Next(1, 3);

                if (positon_spawn == 1)
                    fish_position_p = new Point(20, 250);
                else if (positon_spawn == 2)
                    fish_position_p = new Point(20, 400);
            }

            if (fish_position_n.X < 0 || fish_position_n.X > 850 || fish_position_n.Y < 0 || fish_position_n.Y > 550)
            {
                Random r = new Random();
                int positon_spawn = r.Next(1, 3);

                if (positon_spawn == 1)
                    fish_position_n = new Point(20, 250);
                else if (positon_spawn == 2)
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

        private void Form3_MouseClick(object sender, MouseEventArgs e)
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

                if (comboBox1.Text == "Вудочка")
                    score_in_game += fs_p.score_p;
                else if (comboBox1.Text == "Спінінг")
                    score_in_game += fs_p.score_p + 50;


            }

            if (fishRect_n.Contains(localPosition))
            {
                Random r = new Random();
                int positon_spawn = r.Next(3, 3);

                if (positon_spawn == 3)
                    fish_position_n = new Point(20, 400);

                score_in_game -= fs_n.score_n;

            }

            Score_l.Text = score_in_game.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
