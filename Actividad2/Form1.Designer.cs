namespace Actividad2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BtnCatalogo = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnCargar = new System.Windows.Forms.Button();
            this.BtnAbout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnCatalogo
            // 
            this.BtnCatalogo.BackColor = System.Drawing.Color.DarkViolet;
            this.BtnCatalogo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnCatalogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCatalogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCatalogo.Location = new System.Drawing.Point(632, 463);
            this.BtnCatalogo.Name = "BtnCatalogo";
            this.BtnCatalogo.Size = new System.Drawing.Size(122, 51);
            this.BtnCatalogo.TabIndex = 1;
            this.BtnCatalogo.Text = "CATALOGO";
            this.BtnCatalogo.UseVisualStyleBackColor = false;
            this.BtnCatalogo.Click += new System.EventHandler(this.BtnCatalogo_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.DarkViolet;
            this.BtnExit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.Location = new System.Drawing.Point(770, 520);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(122, 51);
            this.BtnExit.TabIndex = 2;
            this.BtnExit.Text = "EXIT";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnCargar
            // 
            this.BtnCargar.BackColor = System.Drawing.Color.DarkViolet;
            this.BtnCargar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCargar.Location = new System.Drawing.Point(770, 463);
            this.BtnCargar.Name = "BtnCargar";
            this.BtnCargar.Size = new System.Drawing.Size(122, 51);
            this.BtnCargar.TabIndex = 3;
            this.BtnCargar.Text = "CARGAR ARTICULO";
            this.BtnCargar.UseVisualStyleBackColor = false;
            this.BtnCargar.Click += new System.EventHandler(this.BtnCargar_Click);
            // 
            // BtnAbout
            // 
            this.BtnAbout.BackColor = System.Drawing.Color.DarkViolet;
            this.BtnAbout.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAbout.Location = new System.Drawing.Point(632, 520);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(122, 51);
            this.BtnAbout.TabIndex = 4;
            this.BtnAbout.Text = "ABOUT";
            this.BtnAbout.UseVisualStyleBackColor = false;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(969, 587);
            this.Controls.Add(this.BtnAbout);
            this.Controls.Add(this.BtnCargar);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnCatalogo);
            this.Name = "Form1";
            this.Text = "FormPrincipal";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnCatalogo;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnCargar;
        private System.Windows.Forms.Button BtnAbout;
    }
}

