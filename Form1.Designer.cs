namespace EslestirmeOyunuIkiKisilik
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Tasarımcısı tarafından üretilen kod

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlKartlar = new Panel();
            pnlBilgi = new Panel();
            lblOyuncu1Skor = new Label();
            lblOyuncu2Skor = new Label();
            lblSiradakiOyuncu = new Label();
            btnYeniOyun = new Button();
            tmrKartGizle = new System.Windows.Forms.Timer(components);
            pnlBilgi.SuspendLayout();
            SuspendLayout();
            // 
            // pnlKartlar
            // 
            pnlKartlar.BackColor = Color.FromArgb(220, 220, 220);
            pnlKartlar.Location = new Point(20, 20);
            pnlKartlar.Name = "pnlKartlar";
            pnlKartlar.Size = new Size(760, 660);
            pnlKartlar.TabIndex = 0;
            // 
            // pnlBilgi
            // 
            pnlBilgi.BackColor = Color.FromArgb(200, 200, 200);
            pnlBilgi.Controls.Add(lblOyuncu1Skor);
            pnlBilgi.Controls.Add(lblOyuncu2Skor);
            pnlBilgi.Controls.Add(lblSiradakiOyuncu);
            pnlBilgi.Controls.Add(btnYeniOyun);
            pnlBilgi.Location = new Point(800, 20);
            pnlBilgi.Name = "pnlBilgi";
            pnlBilgi.Size = new Size(180, 660);
            pnlBilgi.TabIndex = 1;
            // 
            // lblOyuncu1Skor
            // 
            lblOyuncu1Skor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblOyuncu1Skor.ForeColor = Color.Navy;
            lblOyuncu1Skor.Location = new Point(10, 20);
            lblOyuncu1Skor.Name = "lblOyuncu1Skor";
            lblOyuncu1Skor.Size = new Size(160, 30);
            lblOyuncu1Skor.TabIndex = 0;
            lblOyuncu1Skor.Text = "Oyuncu 1: 0";
            // 
            // lblOyuncu2Skor
            // 
            lblOyuncu2Skor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblOyuncu2Skor.ForeColor = Color.Maroon;
            lblOyuncu2Skor.Location = new Point(10, 60);
            lblOyuncu2Skor.Name = "lblOyuncu2Skor";
            lblOyuncu2Skor.Size = new Size(160, 30);
            lblOyuncu2Skor.TabIndex = 1;
            lblOyuncu2Skor.Text = "Oyuncu 2: 0";
            // 
            // lblSiradakiOyuncu
            // 
            lblSiradakiOyuncu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSiradakiOyuncu.ForeColor = Color.Green;
            lblSiradakiOyuncu.Location = new Point(10, 120);
            lblSiradakiOyuncu.Name = "lblSiradakiOyuncu";
            lblSiradakiOyuncu.Size = new Size(160, 30);
            lblSiradakiOyuncu.TabIndex = 2;
            lblSiradakiOyuncu.Text = "Sıra: Oyuncu 1";
            // 
            // btnYeniOyun
            // 
            btnYeniOyun.BackColor = Color.FromArgb(100, 180, 100);
            btnYeniOyun.Cursor = Cursors.Hand;
            btnYeniOyun.FlatStyle = FlatStyle.Flat;
            btnYeniOyun.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnYeniOyun.ForeColor = Color.White;
            btnYeniOyun.Location = new Point(20, 580);
            btnYeniOyun.Name = "btnYeniOyun";
            btnYeniOyun.Size = new Size(140, 40);
            btnYeniOyun.TabIndex = 3;
            btnYeniOyun.Text = "Yeni Oyun";
            btnYeniOyun.UseVisualStyleBackColor = false;
            btnYeniOyun.Click += btnYeniOyun_Tiklama;
            // 
            // tmrKartGizle
            // 
            tmrKartGizle.Interval = 1000;
            tmrKartGizle.Tick += zmyKartGizleme_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(1000, 700);
            Controls.Add(pnlKartlar);
            Controls.Add(pnlBilgi);
            Font = new Font("Segoe UI", 9F);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "İki Kişilik Eşleştirme Oyunu";
            pnlBilgi.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlKartlar;
        private System.Windows.Forms.Panel pnlBilgi;
        private System.Windows.Forms.Label lblOyuncu1Skor;
        private System.Windows.Forms.Label lblOyuncu2Skor;
        private System.Windows.Forms.Label lblSiradakiOyuncu;
        private System.Windows.Forms.Button btnYeniOyun;
        private System.Windows.Forms.Timer tmrKartGizle;
    }
}
