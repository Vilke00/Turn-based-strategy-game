namespace God_of_War_Sa_Wish_a
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

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
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(200, 289);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(600, 76);
            this.lblWarning.TabIndex = 15;
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
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
            this.Name = "Form1";
            this.Text = "God of War";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblWarning;

        private System.Windows.Forms.Label txtEnemyEnergy;

        private System.Windows.Forms.Label txtPlayerEnergy;

        private System.Windows.Forms.Label lblPlayerAction;

        private System.Windows.Forms.Label lblEnemyAction;

        private System.Windows.Forms.Label txtEnemyHealth;
        private System.Windows.Forms.Label txtEnemyShield;

        private System.Windows.Forms.Label txtShield;

        private System.Windows.Forms.Button btnAbility;
        private System.Windows.Forms.Button btnDefense;
        private System.Windows.Forms.Button btnRest;

        private System.Windows.Forms.Button btnHeavyAttack;

        private System.Windows.Forms.Label txtHealth;

        private System.Windows.Forms.PictureBox pbPlayer;

        private System.Windows.Forms.Button btnLightAttack;

        #endregion
    }
}