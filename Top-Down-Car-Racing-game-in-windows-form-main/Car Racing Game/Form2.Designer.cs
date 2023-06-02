
namespace Car_Racing_Game_MOO_ICT
{
    partial class Form2
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
            this.Single_Player = new System.Windows.Forms.Button();
            this.BackGround = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BackGround)).BeginInit();
            this.SuspendLayout();
            // 
            // Single_Player
            // 
            this.Single_Player.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Single_Player.BackgroundImage = global::Car_Racing_Game_MOO_ICT.Properties.Resources.Back;
            this.Single_Player.Location = new System.Drawing.Point(457, 325);
            this.Single_Player.Name = "Single_Player";
            this.Single_Player.Size = new System.Drawing.Size(175, 65);
            this.Single_Player.TabIndex = 6;
            this.Single_Player.Text = "Play";
            this.Single_Player.UseVisualStyleBackColor = false;
            this.Single_Player.Click += new System.EventHandler(this.Single_Player_Click);
            // 
            // BackGround
            // 
            this.BackGround.Image = global::Car_Racing_Game_MOO_ICT.Properties.Resources.Back;
            this.BackGround.Location = new System.Drawing.Point(-8, -9);
            this.BackGround.Margin = new System.Windows.Forms.Padding(4);
            this.BackGround.Name = "BackGround";
            this.BackGround.Size = new System.Drawing.Size(1126, 799);
            this.BackGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BackGround.TabIndex = 5;
            this.BackGround.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 789);
            this.Controls.Add(this.Single_Player);
            this.Controls.Add(this.BackGround);
            this.Name = "Form2";
            this.Text = "Car Race Game";
            ((System.ComponentModel.ISupportInitialize)(this.BackGround)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BackGround;
        private System.Windows.Forms.Button Single_Player;
    }
}