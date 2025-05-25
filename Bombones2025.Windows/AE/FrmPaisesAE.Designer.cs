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
            btnOk.Location = new Point(84, 66);
            btnOk.Margin = new Padding(3, 2, 3, 2);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(85, 69);
            btnOk.TabIndex = 0;
            btnOk.Text = "OK";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Image = Properties.Resources.CANCEL40;
            btnCancel.Location = new Point(351, 66);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 69);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "CANCELAR";
            btnCancel.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // labelPais
            // 
            labelPais.AutoSize = true;
            labelPais.Location = new Point(84, 30);
            labelPais.Name = "labelPais";
            labelPais.Size = new Size(31, 15);
            labelPais.TabIndex = 2;
            labelPais.Text = "Pais:";
            // 
            // textBoxPais
            // 
            textBoxPais.Location = new Point(178, 28);
            textBoxPais.Margin = new Padding(3, 2, 3, 2);
            textBoxPais.Name = "textBoxPais";
            textBoxPais.Size = new Size(258, 23);
            textBoxPais.TabIndex = 3;
            // 
            // FrmPaisesAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 156);
            Controls.Add(textBoxPais);
            Controls.Add(labelPais);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmPaisesAE";
            StartPosition = FormStartPosition.CenterScreen;
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