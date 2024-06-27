using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EslestirmeOyunuIkiKisilik
{
    public partial class Form1 : Form
    {
        // Oyun parametreleri
        private readonly int izgararaBoyutu = 6; // 6x6'lük bir ızgara
        private readonly int kartBoyutu = 100; // Her kartın piksel cinsinden boyutu
        private readonly int kartMarji = 10; // Kartlar arası boşluk

        // Oyun durumu değişkenleri
        private Button[,] kartButonlari; // Kart butonlarını tutan 2D dizi
        private int[,] kartDegerleri; // Her kartın değerini tutan 2D dizi
        private bool[,] kartCevrildi; // Kartların çevrilip çevrilmediğini tutan 2D dizi
        private int oyuncu1Puan = 0; // Oyuncu 1'in puanı
        private int oyuncu2Puan = 0; // Oyuncu 2'nin puanı
        private int siradakiOyuncu = 1; // Şu anki oyuncuyu tutan değişken
        private Button ilkKart = null; // İlk seçilen kart
        private Button ikinciKart = null; // İkinci seçilen kart
        private readonly Random rastgele = new Random(); // Rastgele sayı üreteci
        private bool tiklamaIzni = true; // Oyuncunun karta tıklayıp tıklayamayacağını kontrol eden bayrak

        public Form1()
        {
            InitializeComponent(); // Form bileşenlerini oluştur
            OyunuBaslat(); // Oyunu başlat
        }

        private void OyunuBaslat()
        {
            // Oyun alanını temizle ve yeni oyun için hazırla
            pnlKartlar.Controls.Clear();
            kartButonlari = new Button[izgararaBoyutu, izgararaBoyutu];
            kartDegerleri = new int[izgararaBoyutu, izgararaBoyutu];
            kartCevrildi = new bool[izgararaBoyutu, izgararaBoyutu];

            // Kart değerlerini oluştur ve karıştır
            List<int> degerler = Enumerable.Range(1, izgararaBoyutu * izgararaBoyutu / 2).SelectMany(i => new[] { i, i }).ToList();
            degerler = degerler.OrderBy(x => rastgele.Next()).ToList();

            // Kartları yerleştir
            for (int i = 0; i < izgararaBoyutu; i++)
            {
                for (int j = 0; j < izgararaBoyutu; j++)
                {
                    kartDegerleri[i, j] = degerler[i * izgararaBoyutu + j];
                    KartButonuOlustur(i, j);
                }
            }

            // Oyun durumunu sıfırla
            oyuncu1Puan = 0;
            oyuncu2Puan = 0;
            siradakiOyuncu = 1;
            tiklamaIzni = true;
            SkorlariGuncelle();
        }

        private void KartButonuOlustur(int satir, int sutun)
        {
            // Yeni bir kart butonu oluştur ve özelliklerini ayarla
            Button btn = new Button
            {
                Size = new Size(kartBoyutu, kartBoyutu),
                Location = new Point(sutun * (kartBoyutu + kartMarji) + kartMarji, satir * (kartBoyutu + kartMarji) + kartMarji),
                Font = new Font("Webdings", 32, FontStyle.Bold),
                Text = "?",
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.LightBlue
            };
            btn.Click += KartButonu_Tiklama; // Tıklama olayını ekle
            kartButonlari[satir, sutun] = btn;
            pnlKartlar.Controls.Add(btn);
        }

        private void KartButonu_Tiklama(object sender, EventArgs e)
        {
            if (!tiklamaIzni) return; // Eğer tıklama izni yoksa, fonksiyondan çık

            Button tiklananButon = (Button)sender;
            int satir = tiklananButon.Location.Y / (kartBoyutu + kartMarji);
            int sutun = tiklananButon.Location.X / (kartBoyutu + kartMarji);

            if (kartCevrildi[satir, sutun]) return; // Eğer kart zaten çevrildiyse, fonksiyondan çık

            KartiCevir(tiklananButon, satir, sutun);

            if (ilkKart == null)
            {
                ilkKart = tiklananButon; // İlk kartı ayarla
            }
            else if (ikinciKart == null && tiklananButon != ilkKart)
            {
                ikinciKart = tiklananButon; // İkinci kartı ayarla
                tiklamaIzni = false; // Tıklamayı geçici olarak devre dışı bırak
                tmrKartGizle.Start(); // Eşleşme kontrolü için zamanlayıcıyı başlat
            }
        }

        private void KartiCevir(Button btn, int satir, int sutun)
        {
            // Kartı çevir ve görsel olarak göster
            btn.Text = KartSembolunuAl(kartDegerleri[satir, sutun]);
            btn.BackColor = Color.White;
            kartCevrildi[satir, sutun] = true;
        }

        private string KartSembolunuAl(int deger)
        {
            // Kart değerine karşılık gelen sembolü döndür
            string[] semboller = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "=","a","b","c","d","e","f" };
            return semboller[deger - 1];
        }

        private void zmyKartGizleme_Tick(object sender, EventArgs e)
        {
            tmrKartGizle.Stop(); // Zamanlayıcıyı durdur
            EslesmeKontrol(); // Eşleşme kontrolünü yap
        }

        private void EslesmeKontrol()
        {
            if (ilkKart.Text == ikinciKart.Text)
            {
                // Eşleşme varsa puan ver ve kartları devre dışı bırak
                if (siradakiOyuncu == 1) oyuncu1Puan++;
                else oyuncu2Puan++;

                ilkKart.Enabled = false;
                ikinciKart.Enabled = false;
            }
            else
            {
                // Eşleşme yoksa kartları geri çevir ve sırayı değiştir
                KartiGeriCevir(ilkKart);
                KartiGeriCevir(ikinciKart);
                siradakiOyuncu = siradakiOyuncu == 1 ? 2 : 1;
            }

            // Oyun durumunu sıfırla
            ilkKart = null;
            ikinciKart = null;
            tiklamaIzni = true;

            SkorlariGuncelle();

            if (OyunBittiMi())
            {
                // Oyun bittiyse kazananı ilan et
                string kazanan = oyuncu1Puan > oyuncu2Puan ? "Oyuncu 1" : (oyuncu2Puan > oyuncu1Puan ? "Oyuncu 2" : "Berabere");
                MessageBox.Show($"Oyun bitti! {kazanan}", "Oyun Sonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void KartiGeriCevir(Button btn)
        {
            // Kartı ters çevir
            btn.Text = "?";
            btn.BackColor = Color.LightBlue;
            int satir = btn.Location.Y / (kartBoyutu + kartMarji);
            int sutun = btn.Location.X / (kartBoyutu + kartMarji);
            kartCevrildi[satir, sutun] = false;
        }

        private bool OyunBittiMi()
        {
            // Tüm kartlar çevrildiyse oyun bitmiştir
            return kartCevrildi.Cast<bool>().All(cevrildi => cevrildi);
        }

        private void SkorlariGuncelle()
        {
            // Skorları ve sıradaki oyuncuyu güncelle
            lblOyuncu1Skor.Text = $"Oyuncu 1: {oyuncu1Puan}";
            lblOyuncu2Skor.Text = $"Oyuncu 2: {oyuncu2Puan}";
            lblSiradakiOyuncu.Text = $"Sıra: Oyuncu {siradakiOyuncu}";
        }

        private void btnYeniOyun_Tiklama(object sender, EventArgs e)
        {
            OyunuBaslat(); // Yeni oyun başlat
        }
    }
}