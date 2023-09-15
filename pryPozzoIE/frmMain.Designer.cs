namespace pryPozzoIE
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gestiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroProeedor = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoReportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proovedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuActivo = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUsuarioMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDateMenu = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestiónToolStripMenuItem,
            this.listadoReportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gestiónToolStripMenuItem
            // 
            this.gestiónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proveedoresToolStripMenuItem});
            this.gestiónToolStripMenuItem.Name = "gestiónToolStripMenuItem";
            this.gestiónToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.gestiónToolStripMenuItem.Text = "Gestión";
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroProeedor});
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.proveedoresToolStripMenuItem.Text = "Proveedor";
            //this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
            // 
            // registroProeedor
            // 
            this.registroProeedor.Name = "registroProeedor";
            this.registroProeedor.Size = new System.Drawing.Size(255, 26);
            this.registroProeedor.Text = "Registro de proveedores";
            this.registroProeedor.Click += new System.EventHandler(this.activosToolStripMenuItem_Click);
            // 
            // listadoReportesToolStripMenuItem
            // 
            this.listadoReportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proovedoresToolStripMenuItem});
            this.listadoReportesToolStripMenuItem.Name = "listadoReportesToolStripMenuItem";
            this.listadoReportesToolStripMenuItem.Size = new System.Drawing.Size(144, 24);
            this.listadoReportesToolStripMenuItem.Text = "Listado / Reportes";
            // 
            // proovedoresToolStripMenuItem
            // 
            this.proovedoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuActivo});
            this.proovedoresToolStripMenuItem.Name = "proovedoresToolStripMenuItem";
            this.proovedoresToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.proovedoresToolStripMenuItem.Text = "Proovedores";
            // 
            // menuActivo
            // 
            this.menuActivo.Name = "menuActivo";
            this.menuActivo.Size = new System.Drawing.Size(140, 26);
            this.menuActivo.Text = "Activos";
            this.menuActivo.Click += new System.EventHandler(this.activosToolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuarioMain,
            this.lblUserTitle,
            this.lblDateMenu});
            this.statusStrip1.Location = new System.Drawing.Point(0, 528);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(19, 0, 1, 0);
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(1067, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUsuarioMain
            // 
            this.lblUsuarioMain.Name = "lblUsuarioMain";
            this.lblUsuarioMain.Size = new System.Drawing.Size(38, 20);
            this.lblUsuarioMain.Text = "User";
            // 
            // lblUserTitle
            // 
            this.lblUserTitle.Name = "lblUserTitle";
            this.lblUserTitle.Size = new System.Drawing.Size(41, 20);
            this.lblUserTitle.Text = ":User";
            //this.lblUserTitle.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // lblDateMenu
            // 
            this.lblDateMenu.Name = "lblDateMenu";
            this.lblDateMenu.Size = new System.Drawing.Size(0, 20);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gestiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroProeedor;
        private System.Windows.Forms.ToolStripMenuItem listadoReportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proovedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuActivo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuarioMain;
        private System.Windows.Forms.ToolStripStatusLabel lblDateMenu;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel lblUserTitle;
    }
}

