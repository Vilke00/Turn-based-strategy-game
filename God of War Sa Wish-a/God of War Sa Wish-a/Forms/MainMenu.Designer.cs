using System.ComponentModel;

namespace God_of_War_Sa_Wish_a
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.btnGame = new System.Windows.Forms.Button();
            this.btnLoot = new System.Windows.Forms.Button();
            this.lblStage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGame
            // 
            this.btnGame.Font = new System.Drawing.Font("Rockwell", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGame.Location = new System.Drawing.Point(425, 295);
            this.btnGame.Name = "btnGame";
            this.btnGame.Size = new System.Drawing.Size(150, 75);
            this.btnGame.TabIndex = 0;
            this.btnGame.Text = "Fight";
            this.btnGame.UseVisualStyleBackColor = true;
            this.btnGame.Click += new System.EventHandler(this.btnGame_Click);
            // 
            // btnLoot
            // 
            this.btnLoot.Font = new System.Drawing.Font("Rockwell", 21.75F, System.Drawing.FontStyle.Bold);
            this.btnLoot.Location = new System.Drawing.Point(425, 380);
            this.btnLoot.Name = "btnLoot";
            this.btnLoot.Size = new System.Drawing.Size(150, 75);
            this.btnLoot.TabIndex = 1;
            this.btnLoot.Text = "Loot";
            this.btnLoot.UseVisualStyleBackColor = true;
            this.btnLoot.Click += new System.EventHandler(this.btnLoot_Click);
            // 
            // lblStage
            // 
            this.lblStage.BackColor = System.Drawing.Color.Transparent;
            this.lblStage.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStage.ForeColor = System.Drawing.Color.Red;
            this.lblStage.Location = new System.Drawing.Point(385, 177);
            this.lblStage.Name = "lblStage";
            this.lblStage.Size = new System.Drawing.Size(230, 46);
            this.lblStage.TabIndex = 2;
            this.lblStage.Text = "Stage 1-1";
            this.lblStage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::God_of_War_Sa_Wish_a.Properties.Resources.BackgroundFilter;
            this.ClientSize = new System.Drawing.Size(984, 711);
            this.Controls.Add(this.lblStage);
            this.Controls.Add(this.btnLoot);
            this.Controls.Add(this.btnGame);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblStage;

        private System.Windows.Forms.Button btnGame;
        private System.Windows.Forms.Button btnLoot;

        #endregion
    }
}