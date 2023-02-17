using System;
using System.Windows.Forms;

namespace God_of_War_Sa_Wish_a
{
    public partial class MainMenu : Form
    {
        private Form1 form1;
        private Loot form2;
        private static MainMenu instance;
        private static int stageNumber = 1;
        private static int tierNumber = 1;
        
        public int StageNumber { get { return stageNumber; } set { stageNumber = value; } }
        
        public int TierNumber { get { return tierNumber; } set { tierNumber = value; } }
        
        public string LblStage {get{return this.lblStage.Text;} set { this.lblStage.Text = value; } }
        public bool BtnLoot {get{return this.btnLoot.Enabled;} set { this.btnLoot.Enabled = value; } }
        
        public MainMenu()
        {
            InitializeComponent();
            btnLoot.Enabled = false;
        }
        
        public static MainMenu GetInstance()
        {
            if (instance == null)
                instance = new MainMenu();
            return instance;
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            if(form1 == null)
                form1 = Form1.GetInstance();
            // if (form1.Enemy != null)
            // {
            //     form1.Enemy.Dispose();
            // }
            form1.GameStart();
            form1.Closed += (s, args) => this.Close(); 
            form1.Show();
        }

        private void btnLoot_Click(object sender, EventArgs e)
        {
            this.Hide();
            if(form2 == null)
                form2 = Loot.GetInstance();
            form2.Closed += (s, args) => this.Close(); 
            form2.Show();
            form2.SpinButton = true;
            btnLoot.Enabled = false;
        }

    }
}