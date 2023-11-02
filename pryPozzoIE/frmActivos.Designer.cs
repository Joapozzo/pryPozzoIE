namespace pryPozzoIE
{
    partial class frmActivos
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
            this.rtbContenido = new System.Windows.Forms.RichTextBox();
            this.tvCarpetas = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbContenido
            // 
            this.rtbContenido.Location = new System.Drawing.Point(12, 194);
            this.rtbContenido.Name = "rtbContenido";
            this.rtbContenido.ReadOnly = true;
            this.rtbContenido.Size = new System.Drawing.Size(776, 254);
            this.rtbContenido.TabIndex = 3;
            this.rtbContenido.Text = "";
            // 
            // tvCarpetas
            // 
            this.tvCarpetas.Location = new System.Drawing.Point(12, 24);
            this.tvCarpetas.Name = "tvCarpetas";
            this.tvCarpetas.Size = new System.Drawing.Size(277, 143);
            this.tvCarpetas.TabIndex = 2;
            this.tvCarpetas.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCarpetas_AfterSelect_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(431, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "SELECCIONE UN ARCHIVO";
            // 
            // frmActivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 479);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbContenido);
            this.Controls.Add(this.tvCarpetas);
            this.Name = "frmActivos";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedores-Activos";
            this.Load += new System.EventHandler(this.frmActivos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbContenido;
        private System.Windows.Forms.TreeView tvCarpetas;
        private System.Windows.Forms.Label label1;
    }
}