namespace Bombones2025.Windows
{
    partial class FrmFiltrar
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
            components = new System.ComponentModel.Container();
            textBoxFiltrar = new TextBox();
            labelPais = new Label();
            btnCancel = new Button();
            btnOk = new Button();
            errorProviderFiltrar = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProviderFiltrar).BeginInit();
            SuspendLayout();
            // 
            // textBoxFiltrar
            // 
            textBoxFiltrar.Location = new Point(212, 25);
            textBoxFiltrar.Margin = new Padding(3, 2, 3, 2);
            textBoxFiltrar.Name = "textBoxFiltrar";
            textBoxFiltrar.Size = new Size(229, 23);
            textBoxFiltrar.TabIndex = 7;
            // 
            // labelPais
            // 
            labelPais.AutoSize = true;
            labelPais.Location = new Point(89, 28);
            labelPais.Name = "labelPais";
            labelPais.Size = new Size(117, 15);
            labelPais.TabIndex = 6;
            labelPais.Text = "Ingrese texto a filtrar:";
            // 
            // btnCancel
            // 
            btnCancel.Image = Properties.Resources.CANCEL40;
            btnCancel.Location = new Point(356, 63);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 69);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "CANCELAR";
            btnCancel.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Image = Properties.Resources.OK40;
            btnOk.Location = new Point(89, 63);
            btnOk.Margin = new Padding(3, 2, 3, 2);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(85, 69);
            btnOk.TabIndex = 4;
            btnOk.Text = "OK";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // errorProviderFiltrar
            // 
            errorProviderFiltrar.ContainerControl = this;
            // 
            // FrmFiltrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 156);
            Controls.Add(textBoxFiltrar);
            Controls.Add(labelPais);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Name = "FrmFiltrar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmFiltrar";
            ((System.ComponentModel.ISupportInitialize)errorProviderFiltrar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxFiltrar;
        private Label labelPais;
        private Button btnCancel;
        private Button btnOk;
        private ErrorProvider errorProviderFiltrar;
    }
}