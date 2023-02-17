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
        static MySqlConnection connect = new MySqlConnection("SERVER=localhost; user id=root; password=P@ssw0rd; database=god_of_war_wish");
        private Enemy enemy;
        private Player player;
        private Stats stat;
        private int maxPlayerHealth;
        private int maxPlayerShield;
        private int maxEnemyHealth;
        private int maxEnemyShield;
        private int abilityDamage;
        private int energyReq;
        private int defenseAmount;
        private bool playerDefense;
        private bool enemyDefence;
        
        Random randNum = new Random();
        public Form1()
        {
            InitializeComponent();
            enemy = new Enemy(1, new PictureBox());
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            
            //All Select Queries
            String statsUpit = "SELECT * FROM stats";
            String playerUpit = "SELECT * FROM player";
            String enchantmentUpit = "SELECT * FROM enchantments";
            String armorUpit = "SELECT * FROM armors";
            String abilityUpit = "SELECT * FROM abilities";
            
            //Store Data
            var stats = Queries(statsUpit, new Stats()).Cast<Stats>().ToList();
            var players = Queries(playerUpit, new Player()).Cast<Player>().ToList();
            var enchantments = Queries(enchantmentUpit, new Enchantment()).Cast<Enchantment>().ToList();
            var armors = Queries(armorUpit, new Armor()).Cast<Armor>().ToList();
            var abilities = Queries(abilityUpit, new Ability()).Cast<Ability>().ToList();
            
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
            maxPlayerHealth = player.Health;
            maxPlayerShield = player.Shield;
            maxEnemyHealth = enemy.Health;
            maxEnemyShield = enemy.Shield;

            txtShield.Text = $"Shield: {player.Shield}/{maxPlayerShield}";
            txtHealth.Text = $"Health: {player.Health}/{maxPlayerHealth}";
            
            txtEnemyShield.Text = $"Shield: {enemy.Shield}/{maxEnemyShield}";
            txtEnemyHealth.Text = $"Health: {enemy.Health}/{maxEnemyHealth}";
            
            this.Controls.Add(enemy.PbEnemy);
        }
        
        private async void btnLightAttack_Click_1(object sender, EventArgs e)
        {
            DisableButtons();
            Attack(pbPlayer, 500, 500);
            int reduction = 0;

            if (enemyDefence == true)
            {
                reduction = enemy.Defense;
                enemyDefence = false;
            }
            
            if (randNum.Next(1, 101) <= 60)
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
            if (enemy.Health <= 0)
            {
                DisableButtons();
                lblWarning.Text = "Click any button to continue";
                Panel();
            }
            else
                EnemyAttack();
        }
        

        private async void btnHeavyAttack_Click(object sender, EventArgs e)
        {
            DisableButtons();
            Attack(pbPlayer, 1000, 500);
            int reduction = 0;

            if (enemyDefence == true)
            {
                reduction = enemy.Defense;
                enemyDefence = false;
            }
            
            int damage = player.Damage * 2 - reduction;
            if (randNum.Next(1, 101) <= 30)
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
            if (enemy.Health <= 0)
            {
                DisableButtons();
                lblWarning.Text = "Click any button to continue";
                Panel();
            }
            else
                EnemyAttack();
        }

        private async void btnAbility_Click(object sender, EventArgs e)
        {
            int reduction = 0;

            if (enemyDefence == true)
            {
                reduction = enemy.Defense;
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
                if (enemy.Health <= 0)
                {
                    DisableButtons();
                    lblWarning.Text = "Click any button to continue";
                    Panel();
                }
                else
                    EnemyAttack();
            }
        }

        private async void btnDefense_Click(object sender, EventArgs e)
        {
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
            if (enemy.Energy < enemy.Tier && action == 3)
                action = randNum.Next(1, 6);
            
            int reduction = 0;
            switch (action)
            {
                case 1:
                    Attack(enemy.PbEnemy, 500, -500);

                    if (playerDefense == true)
                    {
                        reduction = defenseAmount;
                        playerDefense = false;
                    }
            
                    if (randNum.Next(1, 101) <= 60)
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

                    if (playerDefense == true)
                    {
                        reduction = player.Defense;
                        playerDefense = false;
                    }
                    int damage = enemy.Damage * 2 - reduction;
                    if (randNum.Next(1, 101) <= 30)
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
                    if (enemyDefence == true)
                    {
                        reduction = enemy.Defense;
                        enemyDefence = false;
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
                    break;
            }
            if (player.Health <= 0)
            {
                DisableButtons();
                lblWarning.Text = "Click any button to continue";
                Panel();
            }
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

        public static ArrayList Queries(String upit, Object o)
        {
            var lista = new ArrayList();
            MySqlCommand cmd = new MySqlCommand(upit);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connect;
            connect.Open();
            try
            {
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    switch (o.GetType().Name)
                    {
                        case "Stats":
                            lista.Add(new Stats(dr.GetInt32("StatId"),dr.GetString("CharacterName"), dr.GetInt32("EnchantmentId"), dr.GetInt32("ArmorId"), dr.GetInt32("AbilityId")));
                            break;
                        case "Enchantment":
                            lista.Add(new Enchantment(dr.GetInt32("EnchantmentId"), dr.GetString("EnchantmentName"), dr.GetInt32("Damage"), dr.GetInt32("Defense"), dr.GetInt32("Luck")));
                            break;
                        case "Armor":
                            lista.Add(new Armor(dr.GetInt32("ArmorId"), dr.GetString("ArmorName"), dr.GetInt32("Health"), dr.GetInt32("Shield"), dr.GetInt32("Defense")));
                            break;
                        case "Player":
                            lista.Add(new Player(dr.GetString("CharacterName"), dr.GetInt32("Health"), dr.GetInt32("Shield"), dr.GetInt32("Damage"), dr.GetInt32("Defense"), dr.GetInt32("Luck"), dr.GetInt32("Energy")));
                            break;
                        case "Ability":
                            lista.Add(new Ability(dr.GetInt32("AbilityId"), dr.GetString("AbilityName"), dr.GetInt32("Damage"), dr.GetInt32("EnergyReq")));
                            break;
                        default:
                            Console.WriteLine("Pogresan tip");
                            break;
                    }
                }
        
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        
            return lista;
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
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLightAttack = new System.Windows.Forms.Button();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.btnHeavyAttack = new System.Windows.Forms.Button();
            this.btnAbility = new System.Windows.Forms.Button();
            this.btnDefense = new System.Windows.Forms.Button();
            this.btnRest = new System.Windows.Forms.Button();
            this.txtShield = new System.Windows.Forms.Label();
            this.txtHealth = new System.Windows.Forms.Label();
            this.txtEnemyHealth = new System.Windows.Forms.Label();
            this.txtEnemyShield = new System.Windows.Forms.Label();
            this.lblPlayerAction = new System.Windows.Forms.Label();
            this.lblEnemyAction = new System.Windows.Forms.Label();
            this.txtPlayerEnergy = new System.Windows.Forms.Label();
            this.txtEnemyEnergy = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLightAttack
            // 
            this.btnLightAttack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLightAttack.Location = new System.Drawing.Point(200, 760);
            this.btnLightAttack.Name = "btnLightAttack";
            this.btnLightAttack.Size = new System.Drawing.Size(120, 61);
            this.btnLightAttack.TabIndex = 0;
            this.btnLightAttack.Text = "Light Attack";
            this.btnLightAttack.UseVisualStyleBackColor = true;
            this.btnLightAttack.Click += new System.EventHandler(this.btnLightAttack_Click_1);
            // 
            // pbPlayer
            // 
            this.pbPlayer.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayer.Image = global::God_of_War_Sa_Wish_a.Properties.Resources.PixelArtKratos_removebg_preview;
            this.pbPlayer.Location = new System.Drawing.Point(0, 497);
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.Size = new System.Drawing.Size(187, 247);
            this.pbPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayer.TabIndex = 1;
            this.pbPlayer.TabStop = false;
            // 
            // btnHeavyAttack
            // 
            this.btnHeavyAttack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHeavyAttack.Location = new System.Drawing.Point(320, 760);
            this.btnHeavyAttack.Name = "btnHeavyAttack";
            this.btnHeavyAttack.Size = new System.Drawing.Size(120, 61);
            this.btnHeavyAttack.TabIndex = 3;
            this.btnHeavyAttack.Text = "Heavy Attack";
            this.btnHeavyAttack.UseVisualStyleBackColor = true;
            this.btnHeavyAttack.Click += new System.EventHandler(this.btnHeavyAttack_Click);
            // 
            // btnAbility
            // 
            this.btnAbility.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbility.Location = new System.Drawing.Point(440, 760);
            this.btnAbility.Name = "btnAbility";
            this.btnAbility.Size = new System.Drawing.Size(120, 61);
            this.btnAbility.TabIndex = 4;
            this.btnAbility.Text = "Ability";
            this.btnAbility.UseVisualStyleBackColor = true;
            this.btnAbility.Click += new System.EventHandler(this.btnAbility_Click);
            // 
            // btnDefense
            // 
            this.btnDefense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefense.Location = new System.Drawing.Point(560, 760);
            this.btnDefense.Name = "btnDefense";
            this.btnDefense.Size = new System.Drawing.Size(120, 61);
            this.btnDefense.TabIndex = 5;
            this.btnDefense.Text = "Defend";
            this.btnDefense.UseVisualStyleBackColor = true;
            this.btnDefense.Click += new System.EventHandler(this.btnDefense_Click);
            // 
            // btnRest
            // 
            this.btnRest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRest.Location = new System.Drawing.Point(680, 760);
            this.btnRest.Name = "btnRest";
            this.btnRest.Size = new System.Drawing.Size(120, 61);
            this.btnRest.TabIndex = 6;
            this.btnRest.Text = "Rest";
            this.btnRest.UseVisualStyleBackColor = true;
            this.btnRest.Click += new System.EventHandler(this.btnRest_Click);
            // 
            // txtShield
            // 
            this.txtShield.Font = new System.Drawing.Font("Verdana Pro", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShield.ForeColor = System.Drawing.Color.DimGray;
            this.txtShield.Location = new System.Drawing.Point(0, 775);
            this.txtShield.Name = "txtShield";
            this.txtShield.Size = new System.Drawing.Size(187, 25);
            this.txtShield.TabIndex = 7;
            this.txtShield.Text = "Shield: 10/10";
            // 
            // txtHealth
            // 
            this.txtHealth.Font = new System.Drawing.Font("Verdana Pro", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHealth.ForeColor = System.Drawing.Color.Red;
            this.txtHealth.Location = new System.Drawing.Point(0, 800);
            this.txtHealth.Name = "txtHealth";
            this.txtHealth.Size = new System.Drawing.Size(187, 25);
            this.txtHealth.TabIndex = 8;
            this.txtHealth.Text = "Health: 10/10";
            // 
            // txtEnemyHealth
            // 
            this.txtEnemyHealth.Font = new System.Drawing.Font("Verdana Pro", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnemyHealth.ForeColor = System.Drawing.Color.Red;
            this.txtEnemyHealth.Location = new System.Drawing.Point(806, 800);
            this.txtEnemyHealth.Name = "txtEnemyHealth";
            this.txtEnemyHealth.Size = new System.Drawing.Size(187, 25);
            this.txtEnemyHealth.TabIndex = 10;
            this.txtEnemyHealth.Text = "Health: 10/10";
            // 
            // txtEnemyShield
            // 
            this.txtEnemyShield.Font = new System.Drawing.Font("Verdana Pro", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnemyShield.ForeColor = System.Drawing.Color.DimGray;
            this.txtEnemyShield.Location = new System.Drawing.Point(806, 775);
            this.txtEnemyShield.Name = "txtEnemyShield";
            this.txtEnemyShield.Size = new System.Drawing.Size(187, 25);
            this.txtEnemyShield.TabIndex = 9;
            this.txtEnemyShield.Text = "Shield: 10/10";
            // 
            // lblPlayerAction
            // 
            this.lblPlayerAction.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerAction.Font = new System.Drawing.Font("Verdana Pro", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerAction.ForeColor = System.Drawing.Color.White;
            this.lblPlayerAction.Location = new System.Drawing.Point(0, 386);
            this.lblPlayerAction.Name = "lblPlayerAction";
            this.lblPlayerAction.Size = new System.Drawing.Size(187, 87);
            this.lblPlayerAction.TabIndex = 11;
            this.lblPlayerAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEnemyAction
            // 
            this.lblEnemyAction.BackColor = System.Drawing.Color.Transparent;
            this.lblEnemyAction.Font = new System.Drawing.Font("Verdana Pro", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnemyAction.ForeColor = System.Drawing.Color.White;
            this.lblEnemyAction.Location = new System.Drawing.Point(785, 386);
            this.lblEnemyAction.Name = "lblEnemyAction";
            this.lblEnemyAction.Size = new System.Drawing.Size(187, 87);
            this.lblEnemyAction.TabIndex = 12;
            this.lblEnemyAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPlayerEnergy
            // 
            this.txtPlayerEnergy.Font = new System.Drawing.Font("Verdana Pro", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayerEnergy.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtPlayerEnergy.Location = new System.Drawing.Point(0, 750);
            this.txtPlayerEnergy.Name = "txtPlayerEnergy";
            this.txtPlayerEnergy.Size = new System.Drawing.Size(187, 25);
            this.txtPlayerEnergy.TabIndex = 13;
            this.txtPlayerEnergy.Text = "Energy: 0/0";
            // 
            // txtEnemyEnergy
            // 
            this.txtEnemyEnergy.Font = new System.Drawing.Font("Verdana Pro", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnemyEnergy.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtEnemyEnergy.Location = new System.Drawing.Point(806, 750);
            this.txtEnemyEnergy.Name = "txtEnemyEnergy";
            this.txtEnemyEnergy.Size = new System.Drawing.Size(187, 25);
            this.txtEnemyEnergy.TabIndex = 14;
            this.txtEnemyEnergy.Text = "Energy: 0/0";
            // 
            // lblWarning
            // 
            this.lblWarning.BackColor = System.Drawing.Color.Transparent;
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(200, 289);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(600, 76);
            this.lblWarning.TabIndex = 15;
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::God_of_War_Sa_Wish_a.Properties.Resources.PixelArtCabin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(984, 831);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.txtEnemyEnergy);
            this.Controls.Add(this.txtPlayerEnergy);
            this.Controls.Add(this.lblEnemyAction);
            this.Controls.Add(this.lblPlayerAction);
            this.Controls.Add(this.txtEnemyHealth);
            this.Controls.Add(this.txtEnemyShield);
            this.Controls.Add(this.txtHealth);
            this.Controls.Add(this.txtShield);
            this.Controls.Add(this.btnRest);
            this.Controls.Add(this.btnDefense);
            this.Controls.Add(this.btnAbility);
            this.Controls.Add(this.btnHeavyAttack);
            this.Controls.Add(this.pbPlayer);
            this.Controls.Add(this.btnLightAttack);
            this.DoubleBuffered = true;
            this.Name = "GameForm";
            this.Text = "God of War";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            this.ResumeLayout(false);
        }
    }
}