namespace Demo_QLDSV
{
    partial class MainForm
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
            this.btnStudent = new System.Windows.Forms.Button();
            this.btnClass = new System.Windows.Forms.Button();
            this.btnSubject = new System.Windows.Forms.Button();
            this.btnFee = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStudent
            // 
            this.btnStudent.Location = new System.Drawing.Point(108, 38);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Size = new System.Drawing.Size(155, 67);
            this.btnStudent.TabIndex = 0;
            this.btnStudent.Text = "Quan ly sinh vien";
            this.btnStudent.UseVisualStyleBackColor = true;
            this.btnStudent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onBtnStudentPress);
            // 
            // btnClass
            // 
            this.btnClass.Location = new System.Drawing.Point(343, 38);
            this.btnClass.Name = "btnClass";
            this.btnClass.Size = new System.Drawing.Size(155, 67);
            this.btnClass.TabIndex = 1;
            this.btnClass.Text = "Quan ly lop";
            this.btnClass.UseVisualStyleBackColor = true;
            // 
            // btnSubject
            // 
            this.btnSubject.Location = new System.Drawing.Point(108, 146);
            this.btnSubject.Name = "btnSubject";
            this.btnSubject.Size = new System.Drawing.Size(155, 67);
            this.btnSubject.TabIndex = 2;
            this.btnSubject.Text = "Quan ly mon hoc";
            this.btnSubject.UseVisualStyleBackColor = true;
            this.btnSubject.MouseClick += new System.Windows.Forms.MouseEventHandler(this.onbtnSubjectPress);
            // 
            // btnFee
            // 
            this.btnFee.Location = new System.Drawing.Point(343, 146);
            this.btnFee.Name = "btnFee";
            this.btnFee.Size = new System.Drawing.Size(155, 67);
            this.btnFee.TabIndex = 3;
            this.btnFee.Text = "Quan ly hoc phi";
            this.btnFee.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(596, 209);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(92, 47);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Dang xuat";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 268);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnFee);
            this.Controls.Add(this.btnSubject);
            this.Controls.Add(this.btnClass);
            this.Controls.Add(this.btnStudent);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStudent;
        private System.Windows.Forms.Button btnClass;
        private System.Windows.Forms.Button btnSubject;
        private System.Windows.Forms.Button btnFee;
        private System.Windows.Forms.Button btnLogout;
    }
}