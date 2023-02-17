using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS322_DZ13;
using MySqlConnector;

namespace God_of_War_Sa_Wish_a
{
    public partial class Form1 : Form
    {
        private static Form1 instance;
        private Enemy enemy;
        private Player player;
        private Stats stat;
        private int maxPlayerEnergy = 10;
        private int maxPlayerHealth;
        private int maxPlayerShield;
        private int maxEnemyHealth;
        private int maxEnemyShield;
        private int maxEnemyEnergy = 10;
        private int abilityDamage;
        private int energyReq;
        private int defenseAmount;
        private bool playerDefense;
        private bool enemyDefence;
        private Querie querie;
        private MainMenu meni;
        public Enemy Enemy { get { return this.enemy;} }
        
        
        Random randNum = new Random();
        public Form1()
        {
            InitializeComponent();
            meni = MainMenu.GetInstance();
            querie = new Querie();
            querie.UpdateStats("ArmorId", 1);
            querie.UpdateStats("EnchantmentId", 1);
            querie.UpdateStats("AbilityId", 1);
        }
        public static Form1 GetInstance()
        {
            if (instance == null)
                instance = new Form1();
            return instance;
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            //GameStart();
        }

        public void GameStart()
        {
            if (enemy != null)
            {
                enemy.Dispose();
            }
            //All Select Queries
            String statsUpit = "SELECT * FROM stats";
            String playerUpit = "SELECT * FROM player";
            String enchantmentUpit = "SELECT * FROM enchantments";
            String armorUpit = "SELECT * FROM armors";
            String abilityUpit = "SELECT * FROM abilities";
            
            var stats = querie.Queries(statsUpit, new Stats()).Cast<Stats>().ToList();
            var players = querie.Queries(playerUpit, new Player()).Cast<Player>().ToList();
            var enchantments = querie.Queries(enchantmentUpit, new Enchantment()).Cast<Enchantment>().ToList();
            var armors = querie.Queries(armorUpit, new Armor()).Cast<Armor>().ToList();
            var abilities = querie.Queries(abilityUpit, new Ability()).Cast<Ability>().ToList();
            
            enemy = new Enemy(meni.TierNumber, new PictureBox());
            
            stat = stats[0];
            
            foreach(Enchantment ench in enchantments)
            {
                if (stats[0].EnchantmentId == ench.EnchantmentId)
                {
                    players[0].Damage += ench.Damage;
                    players[0].Defense += ench.Defense;
                    players[0].Luck += ench.Luck;
                }
            }
            foreach(Armor a in armors)
            {
                if (stats[0].ArmorId == a.ArmorId)
                {
                    players[0].Health += a.Health;
                    players[0].Shield += a.Shield;
                    defenseAmount = a.Defense;
                }
            }
            foreach(Ability b in abilities)
            {
                if (b.AbilityId == stat.AbilityId)
                {
                    abilityDamage = b.Damage;
                    energyReq = b.EnergyReq;
                }
            }
            
            player = players[0];
            maxPlayerEnergy = player.Energy;
            maxPlayerHealth = player.Health;
            maxPlayerShield = player.Shield;
            maxEnemyEnergy = enemy.Energy;
            maxEnemyHealth = enemy.Health;
            maxEnemyShield = enemy.Shield;
            
            EnableButtons();
            lblWarning.Text = "";
            lblEnemyAction.Text = "";
            lblPlayerAction.Text = "";
            player.Energy = 0;

            txtPlayerEnergy.Text = $"Energy: {player.Energy}/{maxPlayerEnergy}";
            txtShield.Text = $"Shield: {player.Shield}/{maxPlayerShield}";
            txtHealth.Text = $"Health: {player.Health}/{maxPlayerHealth}";
            
            txtEnemyEnergy.Text = $"Energy: {enemy.Energy}/{maxEnemyEnergy}";
            txtEnemyShield.Text = $"Shield: {enemy.Shield}/{maxEnemyShield}";
            txtEnemyHealth.Text = $"Health: {enemy.Health}/{maxEnemyHealth}";
            
            this.Controls.Add(enemy.PbEnemy);
        }
        
        private async void btnLightAttack_Click_1(object sender, EventArgs e)
        {
            DisableButtons();
            Attack(pbPlayer, 500, 500);
            int reduction = 0;

            if (enemyDefence)
            {
                reduction = enemy.Defense;
                if(player.Damage <= reduction)
                    reduction = player.Damage;
                
                enemyDefence = false;
            }
            
            if (randNum.Next(1, 101) <= 60 + player.Luck)
            {
                if (enemy.Shield > 0 && enemy.Shield > player.Damage - reduction)
                {
                    txtEnemyShield.Text = $"Shield: {enemy.Shield -= player.Damage - reduction}/{maxEnemyShield}";
                }
            
                else if (enemy.Shield == 0)
                {
                    txtEnemyHealth.Text = $"Health: {enemy.Health -= player.Damage - reduction}/{maxEnemyHealth}";
                }
            
                else if (enemy.Shield > 0 && enemy.Shield <= player.Damage - reduction)
                {
                    int razlika = player.Damage - reduction - enemy.Shield;
                    enemy.Shield = 0;
                    txtEnemyShield.Text = $"Shield: {enemy.Shield}/{maxEnemyShield}";
                    txtEnemyHealth.Text = $"Health: {enemy.Health -= razlika}/{maxEnemyHealth}";
                }
            
                lblEnemyAction.Text = $"-{player.Damage - reduction}";
                await Task.Delay(500);
                lblEnemyAction.Text = "";
            }
            else
            {
                lblPlayerAction.Text = "Attack missed!!";
                await Task.Delay(500);
                lblPlayerAction.Text = "";
            }
            
            await Task.Delay(2000);
            PlayerWonCheck();
        }

        

        private async void btnHeavyAttack_Click(object sender, EventArgs e)
        {
            DisableButtons();
            Attack(pbPlayer, 1000, 500);
            int reduction = 0;
            
            if (enemyDefence)
            {
                reduction = enemy.Defense;
                if(player.Damage*2 <= reduction)
                    reduction = player.Damage*2;
                
                enemyDefence = false;
            }
            
            int damage = player.Damage * 2 - reduction;
            if (randNum.Next(1, 101) <= 30 + player.Luck)
            {
                if (enemy.Shield > 0 && enemy.Shield > damage)
                {
                    txtEnemyShield.Text = $"Shield: {enemy.Shield -= damage}/{maxEnemyShield}";
                }
            
                else if (enemy.Shield == 0)
                {
                    txtEnemyHealth.Text = $"Health: {enemy.Health -= damage}/{maxEnemyHealth}";
                }
            
                else if (enemy.Shield > 0 && enemy.Shield <= damage)
                {
                    int razlika = damage - enemy.Shield;
                    enemy.Shield = 0;
                    txtEnemyShield.Text = $"Shield: {enemy.Shield}/{maxEnemyShield}";
                    txtEnemyHealth.Text = $"Health: {enemy.Health -= razlika}/{maxEnemyHealth}";
                }
            
                lblEnemyAction.Text = $"-{damage}";
                await Task.Delay(500);
                lblEnemyAction.Text = "";
            }
            else
            {
                lblPlayerAction.Text = "Attack missed!!";
                await Task.Delay(500);
                lblPlayerAction.Text = "";
            }
            
            await Task.Delay(3500);
            PlayerWonCheck();
        }

        private async void btnAbility_Click(object sender, EventArgs e)
        {
            int reduction = 0;

            
            if (enemyDefence)
            {
                reduction = enemy.Defense;
                if(player.Damage <= reduction)
                    reduction = player.Damage;
                
                enemyDefence = false;
            }
            
            if (player.Energy < energyReq)
            {
                lblWarning.Text = $"You need atleast {energyReq} energy to use this ability";
                await Task.Delay(1000);
                lblWarning.Text = "";
            }
            else
            {
                DisableButtons();
                pbPlayer.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                pbPlayer.Refresh();
                await Task.Delay(500);
                pbPlayer.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                pbPlayer.Refresh();
                await Task.Delay(500);
                if (enemy.Shield > 0 && enemy.Shield > abilityDamage - reduction)
                {
                    txtEnemyShield.Text = $"Shield: {enemy.Shield -= abilityDamage - reduction}/{maxEnemyShield}";
                }
            
                else if (enemy.Shield == 0)
                {
                    txtEnemyHealth.Text = $"Health: {enemy.Health -= abilityDamage - reduction}/{maxEnemyHealth}";
                }
            
                else if (enemy.Shield > 0 && enemy.Shield <= abilityDamage - reduction)
                {
                    int razlika = abilityDamage - reduction - enemy.Shield;
                    enemy.Shield = 0;
                    txtEnemyShield.Text = $"Shield: {enemy.Shield}/{maxEnemyShield}";
                    txtEnemyHealth.Text = $"Health: {enemy.Health -= razlika}/{maxEnemyHealth}";
                }
            
                lblEnemyAction.Text = $"-{abilityDamage - reduction}";
                await Task.Delay(500);
                lblEnemyAction.Text = "";
                player.Energy-= energyReq;
                txtPlayerEnergy.Text = $"Energy: {player.Energy}/{10}";
                PlayerWonCheck();
            }
        }

        private async void btnDefense_Click(object sender, EventArgs e)
        {
            if (enemyDefence)
                enemyDefence = false;
            
            DisableButtons();
            lblPlayerAction.Text = "Defense Up";
            await Task.Delay(1000);
            lblPlayerAction.Text = "";
            await Task.Delay(500);
            playerDefense = true;
            EnemyAttack();
        }

        private async void btnRest_Click(object sender, EventArgs e)
        {
            if (enemyDefence)
                enemyDefence = false;
            if (player.Energy >= 10)
            {
                player.Energy = 10;
                lblPlayerAction.Text = "You can't gain more energy";
                await Task.Delay(1000);
                lblPlayerAction.Text = "";
            }
            DisableButtons();
            lblPlayerAction.Text = "Skipped turn";
            await Task.Delay(1000);
            lblPlayerAction.Text = "Energy++";
            await Task.Delay(1000);
            lblPlayerAction.Text = "";
            await Task.Delay(500);
            EnemyAttack();
            player.Energy++;
            txtPlayerEnergy.Text = $"Energy: {player.Energy}/{10}";
        }
        
        private async void EnemyAttack()
        {
            int action = randNum.Next(1, 6);

            do
            {
                action = randNum.Next(1, 6);
            } while ((enemy.Energy < enemy.Tier && action == 3) || enemy.Energy == 10);

            int reduction = 0;
            switch (action)
            {
                case 1:
                    Attack(enemy.PbEnemy, 500, -500);

                    // if (playerDefense)
                    // {
                    //     reduction = defenseAmount;
                    //     playerDefense = false;
                    // }
                    
                    if (playerDefense)
                    {
                        reduction = defenseAmount;
                        if(enemy.Damage <= reduction)
                            reduction = enemy.Damage;
                        
                        playerDefense = false;
                    }
            
                    if (randNum.Next(1, 101) <= 60 + enemy.Luck)
                    {
                        if (player.Shield > 0 && player.Shield > enemy.Damage - reduction)
                        {
                            txtShield.Text = $"Shield: {player.Shield -= enemy.Damage - reduction}/{maxPlayerShield}";
                        }

                        else if (player.Shield == 0)
                        {
                            txtHealth.Text = $"Health: {player.Health -= enemy.Damage - reduction}/{maxPlayerHealth}";
                        }

                        else if (player.Shield > 0 && player.Shield <= enemy.Damage - reduction)
                        {
                            int razlika = enemy.Damage - reduction - player.Shield;
                            player.Shield = 0;
                            txtShield.Text = $"Shield: {player.Shield}/{maxPlayerShield}";
                            txtHealth.Text = $"Health: {player.Health -= razlika}/{maxPlayerHealth}";
                        }

                        lblPlayerAction.Text = $"-{enemy.Damage}";
                        await Task.Delay(500);
                        lblPlayerAction.Text = "";
                    }
                    else
                    {
                        lblEnemyAction.Text = "Attack missed!!";
                        await Task.Delay(500);
                        lblEnemyAction.Text = "";
                    }

                    await Task.Delay(2000);
                    EnableButtons();
                    break;
                case 2:
                    Attack(enemy.PbEnemy, 1000, -500);
                    
                    if (playerDefense)
                    {
                        reduction = defenseAmount;
                        if(enemy.Damage*2 <= reduction)
                            reduction = enemy.Damage*2;
                        
                        playerDefense = false;
                    }
                    
                    int damage = enemy.Damage * 2 - reduction;
                    if (randNum.Next(1, 101) <= 30 + enemy.Luck)
                    {
                        if (player.Shield > 0 && player.Shield > damage)
                        {
                            txtShield.Text = $"Shield: {player.Shield -= damage}/{maxPlayerShield}";
                        }

                        else if (player.Shield == 0)
                        {
                            txtHealth.Text = $"Health: {player.Health -= damage}/{maxPlayerHealth}";
                        }

                        else if (player.Shield > 0 && player.Shield <= damage)
                        {
                            int razlika = damage - player.Shield;
                            player.Shield = 0;
                            txtShield.Text = $"Shield: {player.Shield}/{maxPlayerShield}";
                            txtHealth.Text = $"Health: {player.Health -= razlika}/{maxPlayerHealth}";
                        }

                        lblPlayerAction.Text = $"-{enemy.Damage*2}";
                        await Task.Delay(500);
                        lblPlayerAction.Text = "";
                    }
                    else
                    {
                        lblEnemyAction.Text = "Attack missed!!";
                        await Task.Delay(500);
                        lblEnemyAction.Text = "";
                    }

                    await Task.Delay(3500);
                    EnableButtons();
                    break;
                case 3:
                    if (playerDefense)
                    {
                        reduction = defenseAmount;
                        if(enemy.Damage <= reduction)
                            reduction = enemy.Damage;
                        
                        playerDefense = false;
                    }
                    
                    enemy.PbEnemy.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                    enemy.PbEnemy.Refresh();
                    await Task.Delay(500);
                    enemy.PbEnemy.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                    enemy.PbEnemy.Refresh();
                    if (player.Shield > 0 && player.Shield > abilityDamage - reduction)
                    {
                        txtShield.Text = $"Shield: {player.Shield -= abilityDamage - reduction}/{maxPlayerShield}";
                    }

                    else if (player.Shield == 0)
                    {
                        txtHealth.Text = $"Health: {player.Health -= abilityDamage - reduction}/{maxPlayerHealth}";
                    }

                    else if (player.Shield > 0 && player.Shield <= abilityDamage - reduction)
                    {
                        int razlika = abilityDamage - reduction - player.Shield;
                        player.Shield = 0;
                        txtShield.Text = $"Shield: {player.Shield}/{maxPlayerShield}";
                        txtHealth.Text = $"Health: {player.Health -= razlika}/{maxPlayerHealth}";
                    }

                    lblPlayerAction.Text = $"-{abilityDamage - reduction}";

                    await Task.Delay(500);
                    enemy.Energy-=enemy.Tier;
                    txtEnemyEnergy.Text = $"Energy: {enemy.Energy}/{10}";
                    EnableButtons();
                    break;
                case 4:
                    lblEnemyAction.Text = "Defense Up";
                    await Task.Delay(1000);
                    lblEnemyAction.Text = "";
                    await Task.Delay(500);
                    EnableButtons();
                    enemyDefence = true;
                    if (playerDefense)
                        playerDefense = false;
                    break;
                case 5:
                    lblEnemyAction.Text = "Skipped turn";
                    await Task.Delay(1000);
                    lblEnemyAction.Text = "Energy++";
                    await Task.Delay(1000);
                    lblEnemyAction.Text = "";
                    await Task.Delay(500);
                    enemy.Energy++;
                    txtEnemyEnergy.Text = $"Energy: {enemy.Energy}/{10}";
                    EnableButtons();
                    if (playerDefense)
                        playerDefense = false;
                    break;
            }
            PlayerLostCheck();
        }

        private async void Attack(PictureBox pb, int delay, int moveValue)
        {
            pb.Left += moveValue;
            await Task.Delay(delay);
            pb.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            pb.Refresh();
            await Task.Delay(delay);
            pb.Left -= moveValue;
            await Task.Delay(delay);
            pb.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            pb.Refresh();
        }
        
        private void DisableButtons()
        {
            btnLightAttack.Enabled = false;
            btnHeavyAttack.Enabled = false;
            btnAbility.Enabled = false;
            btnDefense.Enabled = false;
            btnRest.Enabled = false;
        }
        
        private void EnableButtons()
        {
            btnLightAttack.Enabled = true;
            btnHeavyAttack.Enabled = true;
            btnAbility.Enabled = true;
            btnDefense.Enabled = true;
            btnRest.Enabled = true;
        }
        
        private async void PlayerWonCheck()
        {
            if (enemy.Health <= 0)
            {
                enemy.Health = 0;
                DisableButtons();
                switch (meni.TierNumber)
                {
                    case 1:
                        if (meni.StageNumber < 3)
                            meni.StageNumber++;
                        else
                        {
                            meni.StageNumber = 1;
                            meni.TierNumber = 2;
                        }
                        break;
                    case 2:
                        if (meni.StageNumber < 2)
                            meni.StageNumber++;
                        else
                        {
                            meni.StageNumber = 1;
                            meni.TierNumber = 3;
                        }
                        break;
                    case 3:
                            meni.StageNumber = 1;
                            meni.TierNumber = 1;
                            MessageBox.Show("Congrats!! You won the game!!. Application will now exit");
                            Application.Exit();
                        break;
                    default:
                        Console.WriteLine($"Form1 {meni.TierNumber} - {meni.StageNumber}");
                        break;
                }
                meni.LblStage = $"Stage {meni.TierNumber} - {meni.StageNumber}";
                meni.BtnLoot = true;
                lblWarning.ForeColor = Color.Green;
                lblWarning.Text = "The enemy has fallen";
                Panel();
                await Task.Delay(2000);
                lblWarning.ForeColor = Color.Red;
                lblWarning.Text = "Click any button to continue";
                GameStart();
            }
            else
                EnemyAttack();
        }
        
        private async void PlayerLostCheck()
        {
            if (player.Health <= 0)
            {
                player.Health = 0;
                DisableButtons();
                lblWarning.ForeColor = Color.Green;
                lblWarning.Text = "You have fallen";
                Panel();
                await Task.Delay(2000);
                lblWarning.ForeColor = Color.Red;
                lblWarning.Text = "Click any button to continue";
                GameStart();
            }
        }
        
        private void Panel()
        {
            Form fff;

            fff = new Form();
            fff.ControlBox = false;
            fff.MinimizeBox = false;
            fff.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            fff.Text = "";
            fff.Size = Size;
            fff.BackColor = Color.DarkSlateBlue;
            fff.Opacity = 0.2f;
            fff.Show();
            fff.Location = this.Location;
            
            fff.KeyDown += new KeyEventHandler(Form_KeyDown);
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            Form fff = (Form)sender;
            fff.Close();
            this.Hide();
            if(meni == null)
                meni = MainMenu.GetInstance();
            meni.Closed += (s, args) => this.Close(); 
            meni.Show();
        }
    }
}