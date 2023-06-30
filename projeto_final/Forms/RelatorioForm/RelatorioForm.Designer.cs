namespace projeto_final.Forms.RelatorioForm
{
    partial class RelatorioForm
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
            this.Pesquisar = new System.Windows.Forms.Button();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.gridVendas = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalItens = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSair = new System.Windows.Forms.Button();
            this.gridProdutosVendidos = new System.Windows.Forms.DataGridView();
            this.p_cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.QuantidadeVendas = new System.Windows.Forms.Label();
            this.lblQuantidadeVendas = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridVendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutosVendidos)).BeginInit();
            this.SuspendLayout();
            // 
            // Pesquisar
            // 
            this.Pesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Pesquisar.Location = new System.Drawing.Point(864, 45);
            this.Pesquisar.Margin = new System.Windows.Forms.Padding(6);
            this.Pesquisar.Name = "Pesquisar";
            this.Pesquisar.Size = new System.Drawing.Size(181, 44);
            this.Pesquisar.TabIndex = 0;
            this.Pesquisar.Text = "Pesquisar";
            this.Pesquisar.UseVisualStyleBackColor = true;
            this.Pesquisar.Click += new System.EventHandler(this.Pesquisar_Click);
            // 
            // dtpInicial
            // 
            this.dtpInicial.Location = new System.Drawing.Point(16, 51);
            this.dtpInicial.Margin = new System.Windows.Forms.Padding(6);
            this.dtpInicial.Name = "dtpInicial";
            this.dtpInicial.Size = new System.Drawing.Size(328, 29);
            this.dtpInicial.TabIndex = 2;
            this.dtpInicial.Value = new System.DateTime(2023, 6, 29, 0, 0, 0, 0);
            // 
            // dtpFinal
            // 
            this.dtpFinal.Location = new System.Drawing.Point(373, 51);
            this.dtpFinal.Margin = new System.Windows.Forms.Padding(6);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(330, 29);
            this.dtpFinal.TabIndex = 3;
            this.dtpFinal.Value = new System.DateTime(2023, 6, 29, 0, 0, 0, 0);
            // 
            // gridVendas
            // 
            this.gridVendas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.NomeCliente,
            this.TotalItens,
            this.SubTotal,
            this.Desconto,
            this.ValorTotal,
            this.Situacao,
            this.Editar});
            this.gridVendas.Location = new System.Drawing.Point(20, 198);
            this.gridVendas.Margin = new System.Windows.Forms.Padding(6);
            this.gridVendas.MultiSelect = false;
            this.gridVendas.Name = "gridVendas";
            this.gridVendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridVendas.Size = new System.Drawing.Size(1335, 161);
            this.gridVendas.TabIndex = 4;
            this.gridVendas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridVendas_CellContentClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            // 
            // NomeCliente
            // 
            this.NomeCliente.DataPropertyName = "NomeCliente";
            this.NomeCliente.HeaderText = "Cliente";
            this.NomeCliente.Name = "NomeCliente";
            // 
            // TotalItens
            // 
            this.TotalItens.DataPropertyName = "TotalItens";
            this.TotalItens.HeaderText = "Total de Itens";
            this.TotalItens.Name = "TotalItens";
            // 
            // SubTotal
            // 
            this.SubTotal.DataPropertyName = "SubTotal";
            this.SubTotal.HeaderText = "Sub-Total";
            this.SubTotal.Name = "SubTotal";
            // 
            // Desconto
            // 
            this.Desconto.DataPropertyName = "Desconto";
            this.Desconto.HeaderText = "Desconto";
            this.Desconto.Name = "Desconto";
            // 
            // ValorTotal
            // 
            this.ValorTotal.DataPropertyName = "ValorTotal";
            this.ValorTotal.HeaderText = "Valor Total";
            this.ValorTotal.Name = "ValorTotal";
            // 
            // Situacao
            // 
            this.Situacao.DataPropertyName = "Situacao";
            this.Situacao.HeaderText = "Situação";
            this.Situacao.Name = "Situacao";
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            this.Editar.Text = "Editar";
            this.Editar.UseColumnTextForButtonValue = true;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSair.Location = new System.Drawing.Point(1057, 45);
            this.btnSair.Margin = new System.Windows.Forms.Padding(6);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(165, 44);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // gridProdutosVendidos
            // 
            this.gridProdutosVendidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridProdutosVendidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProdutosVendidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.p_cod,
            this.Descricao,
            this.p_quantidade});
            this.gridProdutosVendidos.Location = new System.Drawing.Point(19, 431);
            this.gridProdutosVendidos.Margin = new System.Windows.Forms.Padding(6);
            this.gridProdutosVendidos.Name = "gridProdutosVendidos";
            this.gridProdutosVendidos.Size = new System.Drawing.Size(1336, 196);
            this.gridProdutosVendidos.TabIndex = 6;
            // 
            // p_cod
            // 
            this.p_cod.DataPropertyName = "Codigo";
            this.p_cod.HeaderText = "Código";
            this.p_cod.Name = "p_cod";
            // 
            // Descricao
            // 
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            // 
            // p_quantidade
            // 
            this.p_quantidade.DataPropertyName = "Quantidade";
            this.p_quantidade.HeaderText = "Quantidade";
            this.p_quantidade.Name = "p_quantidade";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 401);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Vendas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 168);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "10 Produtos Mais Vendidos";
            // 
            // QuantidadeVendas
            // 
            this.QuantidadeVendas.AutoSize = true;
            this.QuantidadeVendas.Location = new System.Drawing.Point(541, 401);
            this.QuantidadeVendas.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.QuantidadeVendas.Name = "QuantidadeVendas";
            this.QuantidadeVendas.Size = new System.Drawing.Size(205, 24);
            this.QuantidadeVendas.TabIndex = 9;
            this.QuantidadeVendas.Text = "Quantidade de Vendas";
            this.QuantidadeVendas.Click += new System.EventHandler(this.QuantidadeVendas_Click);
            // 
            // lblQuantidadeVendas
            // 
            this.lblQuantidadeVendas.AutoSize = true;
            this.lblQuantidadeVendas.Location = new System.Drawing.Point(768, 401);
            this.lblQuantidadeVendas.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblQuantidadeVendas.Name = "lblQuantidadeVendas";
            this.lblQuantidadeVendas.Size = new System.Drawing.Size(0, 24);
            this.lblQuantidadeVendas.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(953, 401);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Valor total";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(1072, 401);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 24);
            this.lblTotal.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 24);
            this.label3.TabIndex = 13;
            this.label3.Text = "Data Inicial";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 24);
            this.label4.TabIndex = 14;
            this.label4.Text = "Data Final";
            // 
            // RelatorioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 642);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblQuantidadeVendas);
            this.Controls.Add(this.QuantidadeVendas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridProdutosVendidos);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.dtpFinal);
            this.Controls.Add(this.dtpInicial);
            this.Controls.Add(this.Pesquisar);
            this.Controls.Add(this.gridVendas);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "RelatorioForm";
            this.Text = "RelatorioMenu";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RelatorioMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridVendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutosVendidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Pesquisar;
        private System.Windows.Forms.DateTimePicker dtpInicial;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.DataGridView gridVendas;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DataGridView gridProdutosVendidos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label QuantidadeVendas;
        private System.Windows.Forms.Label lblQuantidadeVendas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalItens;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Situacao;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}