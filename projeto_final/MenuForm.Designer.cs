namespace projeto_final
{
    partial class frmPrincipal
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
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnRelatorios = new System.Windows.Forms.Button();
            this.btnVendas = new System.Windows.Forms.Button();
            this.btnProdutos = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnListarPordutos = new System.Windows.Forms.Button();
            this.btnNovoCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(334, 168);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(148, 78);
            this.btnClientes.TabIndex = 1;
            this.btnClientes.Text = "Listar Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnRelatorios
            // 
            this.btnRelatorios.Location = new System.Drawing.Point(334, 336);
            this.btnRelatorios.Name = "btnRelatorios";
            this.btnRelatorios.Size = new System.Drawing.Size(148, 78);
            this.btnRelatorios.TabIndex = 2;
            this.btnRelatorios.Text = "Relatórios";
            this.btnRelatorios.UseVisualStyleBackColor = true;
            // 
            // btnVendas
            // 
            this.btnVendas.Location = new System.Drawing.Point(180, 336);
            this.btnVendas.Name = "btnVendas";
            this.btnVendas.Size = new System.Drawing.Size(148, 78);
            this.btnVendas.TabIndex = 3;
            this.btnVendas.Text = "Nova Venda";
            this.btnVendas.UseVisualStyleBackColor = true;
            // 
            // btnProdutos
            // 
            this.btnProdutos.Location = new System.Drawing.Point(180, 84);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(148, 78);
            this.btnProdutos.TabIndex = 4;
            this.btnProdutos.Text = "Novo Produto";
            this.btnProdutos.UseVisualStyleBackColor = true;
            this.btnProdutos.Click += new System.EventHandler(this.btnProdutos_Click);
            // 
            // menu
            // 
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(800, 24);
            this.menu.TabIndex = 5;
            this.menu.Text = "menuStrip1";
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(180, 252);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(302, 78);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnListarPordutos
            // 
            this.btnListarPordutos.Location = new System.Drawing.Point(334, 84);
            this.btnListarPordutos.Name = "btnListarPordutos";
            this.btnListarPordutos.Size = new System.Drawing.Size(148, 78);
            this.btnListarPordutos.TabIndex = 7;
            this.btnListarPordutos.Text = "Listar Produtos";
            this.btnListarPordutos.UseVisualStyleBackColor = true;
            this.btnListarPordutos.Click += new System.EventHandler(this.btnListarPordutos_Click);
            // 
            // btnNovoCliente
            // 
            this.btnNovoCliente.Location = new System.Drawing.Point(180, 168);
            this.btnNovoCliente.Name = "btnNovoCliente";
            this.btnNovoCliente.Size = new System.Drawing.Size(148, 78);
            this.btnNovoCliente.TabIndex = 8;
            this.btnNovoCliente.Text = "Novo Cliente";
            this.btnNovoCliente.UseVisualStyleBackColor = true;
            this.btnNovoCliente.Click += new System.EventHandler(this.btnNovoCliente_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNovoCliente);
            this.Controls.Add(this.btnListarPordutos);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnProdutos);
            this.Controls.Add(this.btnVendas);
            this.Controls.Add(this.btnRelatorios);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projeto Final";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnRelatorios;
        private System.Windows.Forms.Button btnVendas;
        private System.Windows.Forms.Button btnProdutos;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnListarPordutos;
        private System.Windows.Forms.Button btnNovoCliente;
    }
}

