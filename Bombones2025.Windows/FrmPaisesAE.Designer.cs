namespace Bombones2025.Windows
{
    partial class FrmPaisesAE
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
            btnOk = new Button();
            btnCancel = new Button();
            labelPais = new Label();
            textBoxPais = new TextBox();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Image = Properties.Resources.OK40;
            btnOk.Location = new Point(96, 88);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(97, 80);
            btnOk.TabIndex = 0;
            btnOk.Text = "OK";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Image = Properties.Resources.CANCEL40;
            btnCancel.Location = new Point(401, 88);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(97, 80);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "CANCELAR";
            btnCancel.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // labelPais
            // 
            labelPais.AutoSize = true;
            labelPais.Location = new Point(96, 40);
            labelPais.Name = "labelPais";
            labelPais.Size = new Size(34, 20);
            labelPais.TabIndex = 2;
            labelPais.Text = "Pais";
            // 
            // textBoxPais
            // 
            textBoxPais.Location = new Point(204, 37);
            textBoxPais.Name = "textBoxPais";
            textBoxPais.Size = new Size(294, 27);
            textBoxPais.TabIndex = 3;
            // 
            // FrmPaisesAE
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(607, 201);
            Controls.Add(textBoxPais);
            Controls.Add(labelPais);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Name = "FrmPaisesAE";
            Text = "FrmPaisesAE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOk;
        private Button btnCancel;
        private Label labelPais;
        private TextBox textBoxPais;
    }
}