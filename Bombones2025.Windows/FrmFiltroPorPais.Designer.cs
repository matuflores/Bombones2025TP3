namespace Bombones2025.Windows
{
    partial class FrmFiltroPorPais
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
            labelPais = new Label();
            btnCancel = new Button();
            btnOk = new Button();
            cbPaises = new ComboBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // labelPais
            // 
            labelPais.AutoSize = true;
            labelPais.Location = new Point(89, 28);
            labelPais.Name = "labelPais";
            labelPais.Size = new Size(42, 15);
            labelPais.TabIndex = 10;
            labelPais.Text = "Paises:";
            // 
            // btnCancel
            // 
            btnCancel.Image = Properties.Resources.CANCEL40;
            btnCancel.Location = new Point(356, 63);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 69);
            btnCancel.TabIndex = 9;
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
            btnOk.TabIndex = 8;
            btnOk.Text = "OK";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // cbPaises
            // 
            cbPaises.FormattingEnabled = true;
            cbPaises.Location = new Point(179, 25);
            cbPaises.Name = "cbPaises";
            cbPaises.Size = new Size(262, 23);
            cbPaises.TabIndex = 11;
            cbPaises.SelectedIndexChanged += cbPaises_SelectedIndexChanged;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmFiltroPorPais
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 156);
            Controls.Add(cbPaises);
            Controls.Add(labelPais);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Name = "FrmFiltroPorPais";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmFiltroPorPais";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPais;
        private Button btnCancel;
        private Button btnOk;
        private ComboBox cbPaises;
        private ErrorProvider errorProvider1;
    }
}