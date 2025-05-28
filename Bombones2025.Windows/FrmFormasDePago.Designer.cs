namespace Bombones2025.Windows
{
    partial class FrmFormasDePago
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            toolStrip1 = new ToolStrip();
            dgvFormasDePago = new DataGridView();
            btnNuevo = new ToolStripButton();
            btnBorrar = new ToolStripButton();
            btnEditar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnFiltrar = new ToolStripButton();
            btnRefresh = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnPrint = new ToolStripButton();
            btnCerrar = new ToolStripButton();
            FormaDePagoId = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFormasDePago).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(dgvFormasDePago);
            splitContainer1.Panel1.Controls.Add(toolStrip1);
            splitContainer1.Size = new Size(700, 338);
            splitContainer1.SplitterDistance = 268;
            splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNuevo, btnBorrar, btnEditar, toolStripSeparator1, btnFiltrar, btnRefresh, toolStripSeparator2, btnPrint, btnCerrar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(700, 62);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // dgvFormasDePago
            // 
            dgvFormasDePago.AllowUserToAddRows = false;
            dgvFormasDePago.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = Color.Silver;
            dgvFormasDePago.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvFormasDePago.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFormasDePago.Columns.AddRange(new DataGridViewColumn[] { FormaDePagoId, Descripcion });
            dgvFormasDePago.Dock = DockStyle.Fill;
            dgvFormasDePago.Location = new Point(0, 62);
            dgvFormasDePago.Name = "dgvFormasDePago";
            dgvFormasDePago.ReadOnly = true;
            dgvFormasDePago.RowHeadersVisible = false;
            dgvFormasDePago.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFormasDePago.Size = new Size(700, 206);
            dgvFormasDePago.TabIndex = 1;
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
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 62);
            // 
            // btnFiltrar
            // 
            btnFiltrar.Image = Properties.Resources.FILTRO40;
            btnFiltrar.ImageScaling = ToolStripItemImageScaling.None;
            btnFiltrar.ImageTransparentColor = Color.Magenta;
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(54, 59);
            btnFiltrar.Text = "FILTRAR";
            btnFiltrar.TextImageRelation = TextImageRelation.ImageAboveText;
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
            // 
            // FormaDePagoId
            // 
            FormaDePagoId.HeaderText = "FormaDePagoId";
            FormaDePagoId.Name = "FormaDePagoId";
            FormaDePagoId.ReadOnly = true;
            FormaDePagoId.Visible = false;
            // 
            // Descripcion
            // 
            Descripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Descripcion.HeaderText = "Descripcion";
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            // 
            // FrmFormasDePago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(splitContainer1);
            Name = "FrmFormasDePago";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmFormasDePago";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFormasDePago).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dgvFormasDePago;
        private ToolStrip toolStrip1;
        private DataGridViewTextBoxColumn FormaDePagoId;
        private DataGridViewTextBoxColumn Descripcion;
        private ToolStripButton btnNuevo;
        private ToolStripButton btnBorrar;
        private ToolStripButton btnEditar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnFiltrar;
        private ToolStripButton btnRefresh;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnPrint;
        private ToolStripButton btnCerrar;
    }
}