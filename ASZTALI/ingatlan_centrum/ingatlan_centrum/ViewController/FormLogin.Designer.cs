namespace IngatlanCentrum.ViewController
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.labelUgynokAzonosito = new System.Windows.Forms.Label();
            this.AgentPassword = new System.Windows.Forms.Label();
            this.textBoxUgynokAzonosito = new System.Windows.Forms.TextBox();
            this.textBoxUgynokJelszo = new System.Windows.Forms.TextBox();
            this.comboBoxKiszolgalo = new System.Windows.Forms.ComboBox();
            this.labelKiszolgalo = new System.Windows.Forms.Label();
            this.buttonBelepes = new System.Windows.Forms.Button();
            this.buttonKilepes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUgynokAzonosito
            // 
            this.labelUgynokAzonosito.AutoSize = true;
            this.labelUgynokAzonosito.Location = new System.Drawing.Point(92, 80);
            this.labelUgynokAzonosito.Name = "labelUgynokAzonosito";
            this.labelUgynokAzonosito.Size = new System.Drawing.Size(94, 13);
            this.labelUgynokAzonosito.TabIndex = 0;
            this.labelUgynokAzonosito.Text = "Ügynök azonosító";
            // 
            // AgentPassword
            // 
            this.AgentPassword.AutoSize = true;
            this.AgentPassword.Location = new System.Drawing.Point(150, 106);
            this.AgentPassword.Name = "AgentPassword";
            this.AgentPassword.Size = new System.Drawing.Size(36, 13);
            this.AgentPassword.TabIndex = 1;
            this.AgentPassword.Text = "Jelszó";
            // 
            // textBoxUgynokAzonosito
            // 
            this.textBoxUgynokAzonosito.Location = new System.Drawing.Point(192, 77);
            this.textBoxUgynokAzonosito.Name = "textBoxUgynokAzonosito";
            this.textBoxUgynokAzonosito.Size = new System.Drawing.Size(276, 20);
            this.textBoxUgynokAzonosito.TabIndex = 2;
            // 
            // textBoxUgynokJelszo
            // 
            this.textBoxUgynokJelszo.Location = new System.Drawing.Point(192, 103);
            this.textBoxUgynokJelszo.Name = "textBoxUgynokJelszo";
            this.textBoxUgynokJelszo.PasswordChar = '*';
            this.textBoxUgynokJelszo.Size = new System.Drawing.Size(276, 20);
            this.textBoxUgynokJelszo.TabIndex = 3;
            // 
            // comboBoxKiszolgalo
            // 
            this.comboBoxKiszolgalo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKiszolgalo.FormattingEnabled = true;
            this.comboBoxKiszolgalo.Items.AddRange(new object[] {
            "otthoni",
            "iskolai"});
            this.comboBoxKiszolgalo.Location = new System.Drawing.Point(192, 129);
            this.comboBoxKiszolgalo.Name = "comboBoxKiszolgalo";
            this.comboBoxKiszolgalo.Size = new System.Drawing.Size(276, 21);
            this.comboBoxKiszolgalo.TabIndex = 4;
            // 
            // labelKiszolgalo
            // 
            this.labelKiszolgalo.AutoSize = true;
            this.labelKiszolgalo.Location = new System.Drawing.Point(99, 132);
            this.labelKiszolgalo.Name = "labelKiszolgalo";
            this.labelKiszolgalo.Size = new System.Drawing.Size(87, 13);
            this.labelKiszolgalo.TabIndex = 5;
            this.labelKiszolgalo.Text = "Kiszolgáló típusa";
            // 
            // buttonBelepes
            // 
            this.buttonBelepes.Location = new System.Drawing.Point(192, 156);
            this.buttonBelepes.Name = "buttonBelepes";
            this.buttonBelepes.Size = new System.Drawing.Size(276, 23);
            this.buttonBelepes.TabIndex = 6;
            this.buttonBelepes.Text = "Belépés";
            this.buttonBelepes.UseVisualStyleBackColor = true;
            this.buttonBelepes.Click += new System.EventHandler(this.buttonBelepes_Click);
            // 
            // buttonKilepes
            // 
            this.buttonKilepes.Location = new System.Drawing.Point(192, 185);
            this.buttonKilepes.Name = "buttonKilepes";
            this.buttonKilepes.Size = new System.Drawing.Size(276, 23);
            this.buttonKilepes.TabIndex = 8;
            this.buttonKilepes.Text = "Kilépés";
            this.buttonKilepes.UseVisualStyleBackColor = true;
            this.buttonKilepes.Click += new System.EventHandler(this.buttonKilepes_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 310);
            this.ControlBox = false;
            this.Controls.Add(this.buttonKilepes);
            this.Controls.Add(this.buttonBelepes);
            this.Controls.Add(this.labelKiszolgalo);
            this.Controls.Add(this.comboBoxKiszolgalo);
            this.Controls.Add(this.textBoxUgynokJelszo);
            this.Controls.Add(this.textBoxUgynokAzonosito);
            this.Controls.Add(this.AgentPassword);
            this.Controls.Add(this.labelUgynokAzonosito);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ügynök azonosítás | IngatlanCentrum";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelUgynokAzonosito;
        private System.Windows.Forms.Label AgentPassword;
        private System.Windows.Forms.TextBox textBoxUgynokAzonosito;
        private System.Windows.Forms.TextBox textBoxUgynokJelszo;
        private System.Windows.Forms.ComboBox comboBoxKiszolgalo;
        private System.Windows.Forms.Label labelKiszolgalo;
        private System.Windows.Forms.Button buttonBelepes;
        private System.Windows.Forms.Button buttonKilepes;
    }
}