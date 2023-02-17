using System;
using System.Drawing;
using System.Windows.Forms;

namespace God_of_War_Sa_Wish_a
{
    public class Enemy:IDisposable
    {
        Random rand = new Random();
        private bool disposed;
        public int Health { get; set; }
        public int Shield { get; set; }
        public int Damage { get; set; }
        public int Defense { get; set; }
        public int Luck { get; set; }
        public int Energy { get; set; }
        public int Tier { get; set; }
        public PictureBox PbEnemy { get; set; }

        public Enemy()
        {
        }

        public Enemy(int tier, PictureBox pbEnemy)
        {
            Health = rand.Next(10, 15) * tier;
            Shield = rand.Next(10, 15) * tier;
            Damage = rand.Next(10, 15) * tier;
            Defense = rand.Next(10, 15) * tier;
            Luck = rand.Next(10, 15) * tier;
            Energy = 0;
            Tier = tier;
            
            MakeEnemy(pbEnemy);
        }

        public void MakeEnemy(PictureBox pbEnemy)
        {
            pbEnemy = new PictureBox();
            if (Tier == 1)
            {
                int slika = rand.Next(1, 4);
                int width = 0;
                int heigth = 0;

                switch (slika)
                {
                    case 1:
                        pbEnemy.Image = Properties.Resources.Centaur;
                        break;
                    case 2:
                        pbEnemy.Image = Properties.Resources.Werewolf;
                        break;
                    case 3:
                        pbEnemy.Image = Properties.Resources.Orc;
                        break;
                }
                pbEnemy.Size = new Size(250,260);
                pbEnemy.Left = 710;
                pbEnemy.Top = 485;
                pbEnemy.SizeMode = PictureBoxSizeMode.Zoom;
                pbEnemy.BackColor = Color.Transparent;
                pbEnemy.BringToFront();
            }
            if (Tier == 2)
            {
                int slika = rand.Next(1, 3);

                switch (slika)
                {
                    case 1:
                        pbEnemy.Image = Properties.Resources.Dragon;
                        break;
                    case 2:
                        pbEnemy.Image = Properties.Resources.Fenrir;
                        break;
                }
                pbEnemy.Size = new Size(250,260);
                pbEnemy.Left = 710;
                pbEnemy.Top = 485;
                pbEnemy.SizeMode = PictureBoxSizeMode.Zoom;
                pbEnemy.BackColor = Color.Transparent;
                pbEnemy.BringToFront();
            }
            if (Tier == 3)
            {
                pbEnemy.Image = Properties.Resources.PixelArtThor_removebg;
                pbEnemy.Size = new Size(250,260);
                pbEnemy.Left = 710;
                pbEnemy.Top = 485;
                pbEnemy.SizeMode = PictureBoxSizeMode.Zoom;
                pbEnemy.BackColor = Color.Transparent;
                pbEnemy.BringToFront();
            }
            
            PbEnemy = pbEnemy;
        }


        public override string ToString()
        {
            return "\nHealth: " + Convert.ToString(Health)
                   + "\nShield: " + Convert.ToString(Shield)
                   + "\nDamage: " + Convert.ToString(Damage)
                   + "\nDefense: " + Convert.ToString(Defense)
                   + "\nLuck: " + Convert.ToString(Luck)
                   + "\nEnergy: " + Convert.ToString(Energy);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources
                    PbEnemy.Dispose();
                }
                // Dispose unmanaged resources
                disposed = true;
            }
        }

        ~Enemy()
        {
            Dispose(false);
        }
    }
}