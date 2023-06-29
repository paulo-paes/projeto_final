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
            this.btnClientes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClientes.Location = new System.Drawing.Point(653, 168);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(184, 99);
            this.btnClientes.TabIndex = 1;
            this.btnClientes.Text = "Listar Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnRelatorios
            // 
            this.btnRelatorios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRelatorios.Location = new System.Drawing.Point(457, 389);
            this.btnRelatorios.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnRelatorios.Name = "btnRelatorios";
            this.btnRelatorios.Size = new System.Drawing.Size(380, 98);
            this.btnRelatorios.TabIndex = 2;
            this.btnRelatorios.Text = "Relatórios";
            this.btnRelatorios.UseVisualStyleBackColor = true;
            this.btnRelatorios.Click += new System.EventHandler(this.btnRelatorios_Click);
            // 
            // btnVendas
            // 
            this.btnVendas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVendas.Location = new System.Drawing.Point(457, 499);
            this.btnVendas.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnVendas.Name = "btnVendas";
            this.btnVendas.Size = new System.Drawing.Size(380, 98);
            this.btnVendas.TabIndex = 3;
            this.btnVendas.Text = "Nova Venda";
            this.btnVendas.UseVisualStyleBackColor = true;
            this.btnVendas.Click += new System.EventHandler(this.btnVendas_Click);
            // 
            // btnProdutos
            // 
            this.btnProdutos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnProdutos.Location = new System.Drawing.Point(457, 57);
            this.btnProdutos.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(184, 99);
            this.btnProdutos.TabIndex = 4;
            this.btnProdutos.Text = "Novo Produto";
            this.btnProdutos.UseVisualStyleBackColor = true;
            this.btnProdutos.Click += new System.EventHandler(this.btnProdutos_Click);
            // 
            // menu
            // 
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.menu.Size = new System.Drawing.Size(1365, 24);
            this.menu.TabIndex = 5;
            this.menu.Text = "menuStrip1";
            // 
            // btnSair
            // 
            this.btnSair.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSair.Location = new System.Drawing.Point(457, 279);
            this.btnSair.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(380, 98);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnListarPordutos
            // 
            this.btnListarPordutos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnListarPordutos.Location = new System.Drawing.Point(653, 57);
            this.btnListarPordutos.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnListarPordutos.Name = "btnListarPordutos";
            this.btnListarPordutos.Size = new System.Drawing.Size(184, 99);
            this.btnListarPordutos.TabIndex = 7;
            this.btnListarPordutos.Text = "Listar Produtos";
            this.btnListarPordutos.UseVisualStyleBackColor = true;
            this.btnListarPordutos.Click += new System.EventHandler(this.btnListarPordutos_Click);
            // 
            // btnNovoCliente
            // 
            this.btnNovoCliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNovoCliente.Location = new System.Drawing.Point(457, 168);
            this.btnNovoCliente.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnNovoCliente.Name = "btnNovoCliente";
            this.btnNovoCliente.Size = new System.Drawing.Size(184, 99);
            this.btnNovoCliente.TabIndex = 8;
            this.btnNovoCliente.Text = "Novo Cliente";
            this.btnNovoCliente.UseVisualStyleBackColor = true;
            this.btnNovoCliente.Click += new System.EventHandler(this.btnNovoCliente_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 722);
            this.Controls.Add(this.btnNovoCliente);
            this.Controls.Add(this.btnListarPordutos);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnProdutos);
            this.Controls.Add(this.btnVendas);
            this.Controls.Add(this.btnRelatorios);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projeto Final";
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

