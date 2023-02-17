using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS322_DZ13;

namespace God_of_War_Sa_Wish_a
{
    public partial class Loot : Form
    {
        static string livePath = Environment.CurrentDirectory;
        static MainMenu meni;
        private static Loot instance;

        static Image[] images = new Image[4];
        static int i;
        static bool isWheelSpinning;
        static Thread spinWheel = new Thread(SpinTheWheel);
        static PictureBox wh = new PictureBox();
        static Querie querie;
        public bool SpinButton {get{return this.Spin_Button.Enabled;} set { this.Spin_Button.Enabled = value; } }

        public Loot()
        {
            InitializeComponent();
            wh = Wheel_PictureBox;
            meni = MainMenu.GetInstance();
            querie = new Querie();
        }

        public static Loot GetInstance()
        {
            if (instance == null)
                instance = new Loot();
            return instance;
        }
        static void ChangeWheel_Image()
        {
            if (i + 1 >= images.Length)
                i = 0;
            else
                i++;
            string parentFolder = Path.GetDirectoryName(Path.GetDirectoryName(livePath));
            string imagePath = Path.Combine(parentFolder, "Resources", "Slot " + (i + 1) + " active.png");
            images[i] = Image.FromFile(imagePath);
            wh.Invoke(new Action(() => wh.BackgroundImage = images[i]));
        }

        static void SpinTheWheel()
        {
            Random rand = new Random();
            String newStat = "";
            int cycle = 1;

            for (int y = 0; y < 3; y++)
            {
                //Fast spin speed
                int fastSpin = rand.Next((55 - ((cycle - 1) * 20)), (65 - ((cycle - 1) * 15)));
                for (int x = 0; x < fastSpin; x++)
                {
                    ChangeWheel_Image();
                    Thread.Sleep(40 * cycle);
                }
                cycle++;
            }

            isWheelSpinning = false;

            switch (i+1)
            {
                case 1:
                    newStat = "ArmorId";
                    break;
                case 2:
                    newStat = "AbilityId";
                    break;
                case 3:
                    newStat = "EnchantmentId";
                    break;
                case 4:
                    newStat = "";
                    break;
            }
            if (i != 3)
            {
                MessageBox.Show($"Congrats!! You won new {newStat.Substring(0, newStat.Length - 2)}");
                querie.UpdateStats(newStat, meni.TierNumber + 1);
            }
            else
                MessageBox.Show("You won nothing :(");
                
            spinWheel.Abort();
        }

        private void Spin_Button_Click(object sender, EventArgs e)
        {
            if (!isWheelSpinning)
            {
                Thread spinWheel = new Thread(SpinTheWheel);
                isWheelSpinning = true;
                spinWheel.Start();
            }
            Spin_Button.Enabled = false;
            meni.BtnLoot = false;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            if(meni == null)
                meni = MainMenu.GetInstance();
            meni.Closed += (s, args) => this.Close(); 
            meni.Show();
        }

    }
}