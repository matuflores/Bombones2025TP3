namespace Bombones2025.Windows
{
    partial class FrmFrutosSecosAE
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
            textBoxFrutoSeco = new TextBox();
            labelFrutoSeco = new Label();
            btnCancel = new Button();
            btnOk = new Button();
            SuspendLayout();
            // 
            // textBoxFrutoSeco
            // 
            textBoxFrutoSeco.Location = new Point(183, 25);
            textBoxFrutoSeco.Margin = new Padding(3, 2, 3, 2);
            textBoxFrutoSeco.Name = "textBoxFrutoSeco";
            textBoxFrutoSeco.Size = new Size(258, 23);
            textBoxFrutoSeco.TabIndex = 7;
            // 
            // labelFrutoSeco
            // 
            labelFrutoSeco.AutoSize = true;
            labelFrutoSeco.Location = new Point(89, 27);
            labelFrutoSeco.Name = "labelFrutoSeco";
            labelFrutoSeco.Size = new Size(66, 15);
            labelFrutoSeco.TabIndex = 6;
            labelFrutoSeco.Text = "Fruto Seco:";
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
            // 
            // FrmFrutosSecosAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 156);
            Controls.Add(textBoxFrutoSeco);
            Controls.Add(labelFrutoSeco);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Name = "FrmFrutosSecosAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmFrutosSecosAE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxFrutoSeco;
        private Label labelFrutoSeco;
        private Button btnCancel;
        private Button btnOk;
    }
}