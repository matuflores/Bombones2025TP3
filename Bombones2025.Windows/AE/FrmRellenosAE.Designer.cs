namespace Bombones2025.Windows
{
    partial class FrmRellenosAE
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
            textBoxRelleno = new TextBox();
            labelRelleno = new Label();
            btnCancel = new Button();
            btnOk = new Button();
            errorProviderRellenoAE = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProviderRellenoAE).BeginInit();
            SuspendLayout();
            // 
            // textBoxRelleno
            // 
            textBoxRelleno.Location = new Point(183, 25);
            textBoxRelleno.Margin = new Padding(3, 2, 3, 2);
            textBoxRelleno.Name = "textBoxRelleno";
            textBoxRelleno.Size = new Size(258, 23);
            textBoxRelleno.TabIndex = 7;
            // 
            // labelRelleno
            // 
            labelRelleno.AutoSize = true;
            labelRelleno.Location = new Point(89, 27);
            labelRelleno.Name = "labelRelleno";
            labelRelleno.Size = new Size(49, 15);
            labelRelleno.TabIndex = 6;
            labelRelleno.Text = "Relleno:";
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
            // errorProviderRellenoAE
            // 
            errorProviderRellenoAE.ContainerControl = this;
            // 
            // FrmRellenosAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 156);
            Controls.Add(textBoxRelleno);
            Controls.Add(labelRelleno);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Name = "FrmRellenosAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmRellenosAE";
            ((System.ComponentModel.ISupportInitialize)errorProviderRellenoAE).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxRelleno;
        private Label labelRelleno;
        private Button btnCancel;
        private Button btnOk;
        private ErrorProvider errorProviderRellenoAE;
    }
}