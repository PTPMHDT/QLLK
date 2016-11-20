namespace PresentationLayer.Viewer
{
    partial class AddNhaCungCap
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
            this.btn_Thoat = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Luu = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txt_SoDT = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_TenNCC = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_maNCC = new DevExpress.XtraEditors.TextEdit();
            this.txt_DiaChi = new DevExpress.XtraEditors.MemoEdit();
            this.txt_Ghichu = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SoDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TenNCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_maNCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Ghichu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(443, 237);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(75, 32);
            this.btn_Thoat.TabIndex = 9;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // btn_Luu
            // 
            this.btn_Luu.Location = new System.Drawing.Point(524, 237);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(75, 32);
            this.btn_Luu.TabIndex = 8;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.txt_SoDT);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txt_TenNCC);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txt_maNCC);
            this.groupControl1.Controls.Add(this.txt_DiaChi);
            this.groupControl1.Controls.Add(this.txt_Ghichu);
            this.groupControl1.Location = new System.Drawing.Point(1, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(598, 228);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Thêm thông tin nhà cung cấp mới";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(304, 72);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 13);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Mô tả :";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(304, 35);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(83, 13);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "Số điện thoại(*) :";
            // 
            // txt_SoDT
            // 
            this.txt_SoDT.Location = new System.Drawing.Point(402, 32);
            this.txt_SoDT.Name = "txt_SoDT";
            this.txt_SoDT.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txt_SoDT.Properties.Mask.EditMask = " \\d\\d\\d\\d\\d-\\d\\d\\d-\\d\\d\\d";
            this.txt_SoDT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.txt_SoDT.Size = new System.Drawing.Size(173, 20);
            this.txt_SoDT.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(7, 108);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(39, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Địa chỉ :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Tên NCC(*):";
            // 
            // txt_TenNCC
            // 
            this.txt_TenNCC.Location = new System.Drawing.Point(104, 68);
            this.txt_TenNCC.Name = "txt_TenNCC";
            this.txt_TenNCC.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txt_TenNCC.Size = new System.Drawing.Size(173, 20);
            this.txt_TenNCC.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Mã NCC :";
            // 
            // txt_maNCC
            // 
            this.txt_maNCC.Location = new System.Drawing.Point(104, 32);
            this.txt_maNCC.Name = "txt_maNCC";
            this.txt_maNCC.Properties.AllowFocused = false;
            this.txt_maNCC.Size = new System.Drawing.Size(100, 20);
            this.txt_maNCC.TabIndex = 0;
            // 
            // txt_DiaChi
            // 
            this.txt_DiaChi.Location = new System.Drawing.Point(104, 105);
            this.txt_DiaChi.Name = "txt_DiaChi";
            this.txt_DiaChi.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_DiaChi.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.txt_DiaChi.Size = new System.Drawing.Size(173, 92);
            this.txt_DiaChi.TabIndex = 2;
            // 
            // txt_Ghichu
            // 
            this.txt_Ghichu.Location = new System.Drawing.Point(402, 69);
            this.txt_Ghichu.Name = "txt_Ghichu";
            this.txt_Ghichu.Size = new System.Drawing.Size(173, 128);
            this.txt_Ghichu.TabIndex = 5;
            // 
            // AddNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 276);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.groupControl1);
            this.Name = "AddNhaCungCap";
            this.Load += new System.EventHandler(this.AddNhaCungCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SoDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TenNCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_maNCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Ghichu.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_Thoat;
        private DevExpress.XtraEditors.SimpleButton btn_Luu;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txt_SoDT;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_TenNCC;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_maNCC;
        private DevExpress.XtraEditors.MemoEdit txt_DiaChi;
        private DevExpress.XtraEditors.MemoEdit txt_Ghichu;
    }
}