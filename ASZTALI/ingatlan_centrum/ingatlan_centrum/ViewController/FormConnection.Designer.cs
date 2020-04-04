namespace IngatlanCentrum.ViewController
{
    partial class FormConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConnection));
            this.comboBoxSzerverTipus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxSzerverTipus
            // 
            this.comboBoxSzerverTipus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSzerverTipus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxSzerverTipus.FormattingEnabled = true;
            this.comboBoxSzerverTipus.Items.AddRange(new object[] {
            "otthoni",
            "iskolai"});
            this.comboBoxSzerverTipus.Location = new System.Drawing.Point(12, 12);
            this.comboBoxSzerverTipus.Name = "comboBoxSzerverTipus";
            this.comboBoxSzerverTipus.Size = new System.Drawing.Size(412, 39);
            this.comboBoxSzerverTipus.TabIndex = 0;
            this.comboBoxSzerverTipus.SelectedIndexChanged += new System.EventHandler(this.comboBoxSzerverTipus_SelectedIndexChanged);
            // 
            // FormConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 64);
            this.Controls.Add(this.comboBoxSzerverTipus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Válasszon szerver kapcsolódási típust...";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSzerverTipus;
    }
}