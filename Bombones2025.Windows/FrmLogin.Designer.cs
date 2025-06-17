namespace Bombones2025.Windows
{
    partial class FrmLogin
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
            textBoxUsuario = new TextBox();
            labelRelleno = new Label();
            btnCancel = new Button();
            btnOk = new Button();
            textBoxClave = new TextBox();
            label1 = new Label();
            pictureBox = new PictureBox();
            errorProviderLogin = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderLogin).BeginInit();
            SuspendLayout();
            // 
            // textBoxUsuario
            // 
            textBoxUsuario.Location = new Point(134, 37);
            textBoxUsuario.Margin = new Padding(3, 2, 3, 2);
            textBoxUsuario.Name = "textBoxUsuario";
            textBoxUsuario.Size = new Size(258, 23);
            textBoxUsuario.TabIndex = 0;
            textBoxUsuario.Text = "admin";
            // 
            // labelRelleno
            // 
            labelRelleno.AutoSize = true;
            labelRelleno.Location = new Point(40, 39);
            labelRelleno.Name = "labelRelleno";
            labelRelleno.Size = new Size(50, 15);
            labelRelleno.TabIndex = 10;
            labelRelleno.Text = "Usuario:";
            // 
            // btnCancel
            // 
            btnCancel.Image = Properties.Resources.CANCEL40;
            btnCancel.Location = new Point(307, 117);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 69);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "CANCELAR";
            btnCancel.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Image = Properties.Resources.OK40;
            btnOk.Location = new Point(40, 117);
            btnOk.Margin = new Padding(3, 2, 3, 2);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(85, 69);
            btnOk.TabIndex = 2;
            btnOk.Text = "OK";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // textBoxClave
            // 
            textBoxClave.Location = new Point(134, 79);
            textBoxClave.Margin = new Padding(3, 2, 3, 2);
            textBoxClave.Name = "textBoxClave";
            textBoxClave.Size = new Size(258, 23);
            textBoxClave.TabIndex = 1;
            textBoxClave.Text = "admin123";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 81);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 12;
            label1.Text = "Clave:";
            // 
            // pictureBox
            // 
            pictureBox.BackgroundImageLayout = ImageLayout.None;
            pictureBox.Image = Properties.Resources.PASS100;
            pictureBox.InitialImage = Properties.Resources.PASS100;
            pictureBox.Location = new Point(438, 56);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(133, 130);
            pictureBox.TabIndex = 14;
            pictureBox.TabStop = false;
            // 
            // errorProviderLogin
            // 
            errorProviderLogin.ContainerControl = this;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(583, 251);
            ControlBox = false;
            Controls.Add(pictureBox);
            Controls.Add(textBoxClave);
            Controls.Add(label1);
            Controls.Add(textBoxUsuario);
            Controls.Add(labelRelleno);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            MinimumSize = new Size(599, 267);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LOGIN";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderLogin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxUsuario;
        private Label labelRelleno;
        private Button btnCancel;
        private Button btnOk;
        private TextBox textBoxClave;
        private Label label1;
        private PictureBox pictureBox;
        private ErrorProvider errorProviderLogin;
    }
}