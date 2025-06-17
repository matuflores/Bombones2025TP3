namespace Bombones2025.Windows.AE
{
    partial class FrmFormasDePagoAE
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
            textBoxFormaPago = new TextBox();
            labelChocolate = new Label();
            btnCancel = new Button();
            btnOk = new Button();
            errorProviderFormaDePago = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProviderFormaDePago).BeginInit();
            SuspendLayout();
            // 
            // textBoxFormaPago
            // 
            textBoxFormaPago.Location = new Point(183, 25);
            textBoxFormaPago.Margin = new Padding(3, 2, 3, 2);
            textBoxFormaPago.Name = "textBoxFormaPago";
            textBoxFormaPago.Size = new Size(258, 23);
            textBoxFormaPago.TabIndex = 15;
            // 
            // labelChocolate
            // 
            labelChocolate.AutoSize = true;
            labelChocolate.Location = new Point(89, 27);
            labelChocolate.Name = "labelChocolate";
            labelChocolate.Size = new Size(90, 15);
            labelChocolate.TabIndex = 14;
            labelChocolate.Text = "Forma de Pago:";
            // 
            // btnCancel
            // 
            btnCancel.Image = Properties.Resources.CANCEL40;
            btnCancel.Location = new Point(356, 63);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 69);
            btnCancel.TabIndex = 13;
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
            btnOk.TabIndex = 12;
            btnOk.Text = "OK";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click_1;
            // 
            // errorProviderFormaDePago
            // 
            errorProviderFormaDePago.ContainerControl = this;
            // 
            // FrmFormasDePagoAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 156);
            Controls.Add(textBoxFormaPago);
            Controls.Add(labelChocolate);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Name = "FrmFormasDePagoAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmFormasDePagoAE";
            ((System.ComponentModel.ISupportInitialize)errorProviderFormaDePago).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxFormaPago;
        private Label labelChocolate;
        private Button btnCancel;
        private Button btnOk;
        private ErrorProvider errorProviderFormaDePago;
    }
}