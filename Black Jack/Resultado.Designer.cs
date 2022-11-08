namespace Black_Jack
{
    partial class Resultado
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
            this.carta5 = new System.Windows.Forms.PictureBox();
            this.carta4 = new System.Windows.Forms.PictureBox();
            this.carta3 = new System.Windows.Forms.PictureBox();
            this.carta2 = new System.Windows.Forms.PictureBox();
            this.carta1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.carta5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta1)).BeginInit();
            this.SuspendLayout();
            // 
            // carta5
            // 
            this.carta5.Location = new System.Drawing.Point(532, 90);
            this.carta5.Margin = new System.Windows.Forms.Padding(2);
            this.carta5.Name = "carta5";
            this.carta5.Size = new System.Drawing.Size(124, 183);
            this.carta5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carta5.TabIndex = 4;
            this.carta5.TabStop = false;
            // 
            // carta4
            // 
            this.carta4.Location = new System.Drawing.Point(404, 90);
            this.carta4.Margin = new System.Windows.Forms.Padding(2);
            this.carta4.Name = "carta4";
            this.carta4.Size = new System.Drawing.Size(123, 183);
            this.carta4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carta4.TabIndex = 3;
            this.carta4.TabStop = false;
            // 
            // carta3
            // 
            this.carta3.Location = new System.Drawing.Point(280, 90);
            this.carta3.Margin = new System.Windows.Forms.Padding(2);
            this.carta3.Name = "carta3";
            this.carta3.Size = new System.Drawing.Size(119, 183);
            this.carta3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carta3.TabIndex = 2;
            this.carta3.TabStop = false;
            // 
            // carta2
            // 
            this.carta2.Location = new System.Drawing.Point(157, 90);
            this.carta2.Margin = new System.Windows.Forms.Padding(2);
            this.carta2.Name = "carta2";
            this.carta2.Size = new System.Drawing.Size(119, 183);
            this.carta2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carta2.TabIndex = 1;
            this.carta2.TabStop = false;
            // 
            // carta1
            // 
            this.carta1.Location = new System.Drawing.Point(36, 90);
            this.carta1.Margin = new System.Windows.Forms.Padding(2);
            this.carta1.Name = "carta1";
            this.carta1.Size = new System.Drawing.Size(116, 183);
            this.carta1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carta1.TabIndex = 0;
            this.carta1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(216, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ganador : ";
            // 
            // Resultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(712, 415);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.carta5);
            this.Controls.Add(this.carta4);
            this.Controls.Add(this.carta3);
            this.Controls.Add(this.carta2);
            this.Controls.Add(this.carta1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Resultado";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Resultado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.carta5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox carta1;
        private System.Windows.Forms.PictureBox carta2;
        private System.Windows.Forms.PictureBox carta3;
        private System.Windows.Forms.PictureBox carta4;
        private System.Windows.Forms.PictureBox carta5;
        private System.Windows.Forms.Label label1;
    }
}