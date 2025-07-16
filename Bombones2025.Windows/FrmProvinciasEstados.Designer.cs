namespace Bombones2025.Windows
{
    partial class FrmProvinciasEstados
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            dgvProvEst = new DataGridView();
            ProvinciaEstadoId = new DataGridViewTextBoxColumn();
            NombreProvinciaEstado = new DataGridViewTextBoxColumn();
            Pais = new DataGridViewTextBoxColumn();
            toolStrip1 = new ToolStrip();
            btnNuevo = new ToolStripButton();
            btnBorrar = new ToolStripButton();
            btnEditar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnFiltrar = new ToolStripDropDownButton();
            textoToolStripMenuItem = new ToolStripMenuItem();
            paisToolStripMenuItem = new ToolStripMenuItem();
            btnRefresh = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnPrint = new ToolStripButton();
            btnCerrar = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProvEst).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvProvEst);
            splitContainer1.Panel1.Controls.Add(toolStrip1);
            splitContainer1.Size = new Size(700, 338);
            splitContainer1.SplitterDistance = 282;
            splitContainer1.TabIndex = 0;
            // 
            // dgvProvEst
            // 
            dgvProvEst.AllowUserToAddRows = false;
            dgvProvEst.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.Silver;
            dgvProvEst.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProvEst.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProvEst.Columns.AddRange(new DataGridViewColumn[] { ProvinciaEstadoId, NombreProvinciaEstado, Pais });
            dgvProvEst.Dock = DockStyle.Fill;
            dgvProvEst.Location = new Point(0, 62);
            dgvProvEst.Margin = new Padding(3, 2, 3, 2);
            dgvProvEst.Name = "dgvProvEst";
            dgvProvEst.ReadOnly = true;
            dgvProvEst.RowHeadersVisible = false;
            dgvProvEst.RowHeadersWidth = 51;
            dgvProvEst.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProvEst.Size = new Size(700, 220);
            dgvProvEst.TabIndex = 2;
            // 
            // ProvinciaEstadoId
            // 
            ProvinciaEstadoId.HeaderText = "ProvinciaEstadoId";
            ProvinciaEstadoId.MinimumWidth = 6;
            ProvinciaEstadoId.Name = "ProvinciaEstadoId";
            ProvinciaEstadoId.ReadOnly = true;
            ProvinciaEstadoId.Visible = false;
            ProvinciaEstadoId.Width = 125;
            // 
            // NombreProvinciaEstado
            // 
            NombreProvinciaEstado.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NombreProvinciaEstado.HeaderText = "Provincia/Estado";
            NombreProvinciaEstado.MinimumWidth = 6;
            NombreProvinciaEstado.Name = "NombreProvinciaEstado";
            NombreProvinciaEstado.ReadOnly = true;
            // 
            // Pais
            // 
            Pais.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Pais.HeaderText = "Pais";
            Pais.Name = "Pais";
            Pais.ReadOnly = true;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNuevo, btnBorrar, btnEditar, toolStripSeparator1, btnFiltrar, btnRefresh, toolStripSeparator2, btnPrint, btnCerrar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(700, 62);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnNuevo
            // 
            btnNuevo.Image = Properties.Resources.NEW40;
            btnNuevo.ImageScaling = ToolStripItemImageScaling.None;
            btnNuevo.ImageTransparentColor = Color.Magenta;
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(50, 59);
            btnNuevo.Text = "NUEVO";
            btnNuevo.TextImageRelation = TextImageRelation.ImageAboveText;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Image = Properties.Resources.DELETE40;
            btnBorrar.ImageScaling = ToolStripItemImageScaling.None;
            btnBorrar.ImageTransparentColor = Color.Magenta;
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(56, 59);
            btnBorrar.Text = "BORRAR";
            btnBorrar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Image = Properties.Resources.EDIT40;
            btnEditar.ImageScaling = ToolStripItemImageScaling.None;
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(49, 59);
            btnEditar.Text = "EDITAR";
            btnEditar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEditar.Click += btnEditar_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 62);
            // 
            // btnFiltrar
            // 
            btnFiltrar.DropDownItems.AddRange(new ToolStripItem[] { textoToolStripMenuItem, paisToolStripMenuItem });
            btnFiltrar.Image = Properties.Resources.FILTRO40;
            btnFiltrar.ImageScaling = ToolStripItemImageScaling.None;
            btnFiltrar.ImageTransparentColor = Color.Magenta;
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(63, 59);
            btnFiltrar.Text = "FILTRAR";
            btnFiltrar.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // textoToolStripMenuItem
            // 
            textoToolStripMenuItem.Name = "textoToolStripMenuItem";
            textoToolStripMenuItem.Size = new Size(102, 22);
            textoToolStripMenuItem.Text = "Texto";
            textoToolStripMenuItem.Click += textoToolStripMenuItem_Click;
            // 
            // paisToolStripMenuItem
            // 
            paisToolStripMenuItem.Name = "paisToolStripMenuItem";
            paisToolStripMenuItem.Size = new Size(102, 22);
            paisToolStripMenuItem.Text = "Pais";
            paisToolStripMenuItem.Click += paisToolStripMenuItem_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Image = Properties.Resources.REFRESH40;
            btnRefresh.ImageScaling = ToolStripItemImageScaling.None;
            btnRefresh.ImageTransparentColor = Color.Magenta;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(58, 59);
            btnRefresh.Text = "REFRESH";
            btnRefresh.TextImageRelation = TextImageRelation.ImageAboveText;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 62);
            // 
            // btnPrint
            // 
            btnPrint.Image = Properties.Resources.PRINT40;
            btnPrint.ImageScaling = ToolStripItemImageScaling.None;
            btnPrint.ImageTransparentColor = Color.Magenta;
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(44, 59);
            btnPrint.Text = "PRINT";
            btnPrint.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // btnCerrar
            // 
            btnCerrar.Image = Properties.Resources.CLOSE40;
            btnCerrar.ImageScaling = ToolStripItemImageScaling.None;
            btnCerrar.ImageTransparentColor = Color.Magenta;
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(54, 59);
            btnCerrar.Text = "CERRAR";
            btnCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FrmProvinciasEstados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(splitContainer1);
            Name = "FrmProvinciasEstados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Provincias Estados";
            Load += FrmProvinciasEstados_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProvEst).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ToolStrip toolStrip1;
        private ToolStripButton btnNuevo;
        private ToolStripButton btnBorrar;
        private ToolStripButton btnEditar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnRefresh;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnPrint;
        private ToolStripButton btnCerrar;
        private DataGridView dgvProvEst;
        private DataGridViewTextBoxColumn ProvinciaEstadoId;
        private DataGridViewTextBoxColumn NombreProvinciaEstado;
        private DataGridViewTextBoxColumn Pais;
        private ToolStripDropDownButton btnFiltrar;
        private ToolStripMenuItem textoToolStripMenuItem;
        private ToolStripMenuItem paisToolStripMenuItem;
    }
}