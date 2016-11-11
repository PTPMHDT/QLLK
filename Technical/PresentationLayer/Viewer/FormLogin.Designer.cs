namespace PresentationLayer
{
    partial class formLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLogin));
            this.textID = new DevExpress.XtraEditors.TextEdit();
            this.textPass = new DevExpress.XtraEditors.TextEdit();
            this.labelID = new DevExpress.XtraEditors.LabelControl();
            this.labelPass = new DevExpress.XtraEditors.LabelControl();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPass.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textID
            // 
            this.textID.Location = new System.Drawing.Point(145, 46);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(180, 20);
            this.textID.TabIndex = 1;
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(145, 82);
            this.textPass.Name = "textPass";
            this.textPass.Properties.UseSystemPasswordChar = true;
            this.textPass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textPass.Size = new System.Drawing.Size(180, 20);
            this.textPass.TabIndex = 2;
            // 
            // labelID
            // 
            this.labelID.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelID.Location = new System.Drawing.Point(28, 49);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(85, 13);
            this.labelID.TabIndex = 1;
            this.labelID.Text = "Tên Đăng Nhập";
            // 
            // labelPass
            // 
            this.labelPass.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelPass.Location = new System.Drawing.Point(28, 85);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(53, 13);
            this.labelPass.TabIndex = 1;
            this.labelPass.Text = "Mật Khẩu";
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.Appearance.Options.UseForeColor = true;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.ImageIndex = -3;
            this.btnLogin.Location = new System.Drawing.Point(220, 122);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(105, 36);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Đăng Nhập";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageIndex = -3;
            this.btnCancel.Location = new System.Drawing.Point(145, 122);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 36);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // formLogin
            // 
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 183);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.textPass);
            this.Controls.Add(this.textID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formLogin";
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.formLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPass.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textID;
        private DevExpress.XtraEditors.TextEdit textPass;
        private DevExpress.XtraEditors.LabelControl labelID;
        private DevExpress.XtraEditors.LabelControl labelPass;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}