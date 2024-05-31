/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oto_Tamir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}*/



using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Oto_Tamir
{
    public partial class MainForm : Form
    {
        private string connectionString = "server=.\\SQLEXPRESS; Initial Catalog=oto_tamircisi;Integrated Security=True";

        // Dinamik olarak yüklenecek kontrolleri tanımlayın
        private DataGridView dataGridViewMusteriler;
        private Button btnEkle;
        private Button btnGuncelle;
        private Button btnSil;
        private TextBox txtTCNo;
        private TextBox txtAd;
        private TextBox txtSoyad;
        private TextBox txtTelefonNo;
        private TextBox txtEmail;
        private TextBox txtAdres;
        private TextBox txtNotlar;
        private Label lblTCNo;
        private Label lblAd;
        private Label lblSoyad;
        private Label lblTelefonNo;
        private Label lblEmail;
        private Label lblAdres;
        private Label lblNotlar;

        private DataGridView dataGridViewTedarikciler;
        private Button btnTedarikciEkle;
        private Button btnTedarikciGuncelle;
        private Button btnTedarikciSil;
        private TextBox txtTedarikciAdi;
        private TextBox txtIletisimKisi;
        private TextBox txtTedarikciTelefonNo;
        private TextBox txtTedarikciEmail;
        private TextBox txtTedarikciAdres;
        private Label lblTedarikciAdi;
        private Label lblIletisimKisi;
        private Label lblTedarikciTelefonNo;
        private Label lblTedarikciEmail;
        private Label lblTedarikciAdres;

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem müşterilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tedarikçilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elemanlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem araçlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem işlemlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ürünlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borçlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alacaklarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gelirGiderToolStripMenuItem;

        private TextBox txtArama;
        private Button btnArama;
        private RichTextBox rtbNotlar;
        private RichTextBox rtbTedarikciAdres;
        private TextBox txtTedarikciArama;
        private Button btnTedarikciArama;
        private DataGridView dataGridViewElemanlar;
        private TextBox txtElemanArama;
        private Button btnElemanArama;
        private TextBox txtElemanTCNo;
        private TextBox txtElemanAd;
        private TextBox txtElemanSoyad;
        private TextBox txtElemanTelefonNo;
        private TextBox txtElemanEmail;
        private TextBox txtElemanPozisyon;
        private TextBox txtElemanMaas;
        private TextBox txtElemanAvans;
        private RichTextBox rtbElemanNotlar;
        private Button btnElemanEkle;
        private Button btnElemanGuncelle;
        private Button btnElemanSil;

        private DataGridView dataGridViewAraclar;
        private TextBox txtAracArama;
        private Button btnAracArama;
        private TextBox txtAracMusteriID;
        private TextBox txtAracTCNo;
        private TextBox txtAracMarka;
        private TextBox txtAracModel;
        private TextBox txtAracYil;
        private TextBox txtAracPlaka;
        private TextBox txtAracSaseNo;
        private TextBox txtAracRenk;
        private TextBox txtAracKM;
        private TextBox txtAracYakit;
        private Button btnAracEkle;
        private Button btnAracGuncelle;
        private Button btnAracSil;

        private DataGridView dataGridViewIslemler;
        private TextBox txtIslemArama;
        private Button btnIslemArama;
        private TextBox txtIslemAracID;
        private TextBox txtIslemElemanID;
        private DateTimePicker dtpIslemTarihi;
        private TextBox txtIslemAciklama;
        private TextBox txtIslemMaliyet;
        private RichTextBox rtbIslemNotlar;
        private Button btnIslemEkle;
        private Button btnIslemGuncelle;
        private Button btnIslemSil;
        private DataGridView dataGridViewIslemParcalari;
        private Button btnParcaEkle;
        private Button btnParcaSil;

        private DataGridView dataGridViewUrunler;
        private TextBox txtUrunArama;
        private Button btnUrunArama;
        private TextBox txtUrunAdi;
        private TextBox txtUrunKategori;
        private TextBox txtUrunFiyat;
        private TextBox txtUrunTedarikciID;
        private DateTimePicker dtpUrunTarih;
        private Button btnUrunEkle;
        private Button btnUrunGuncelle;
        private Button btnUrunSil;

        private DataGridView dataGridViewStok;
        private TextBox txtStokArama;
        private Button btnStokArama;
        private TextBox txtStokUrunID;
        private TextBox txtStokMiktar;
        private Button btnStokEkle;
        private Button btnStokGuncelle;
        private Button btnStokSil;

        private DataGridView dataGridViewBorclar;
        private TextBox txtBorcArama;
        private Button btnBorcArama;
        private TextBox txtBorcMusteriID;
        private TextBox txtBorcTutar;
        private DateTimePicker dtpBorcVadeTarihi;
        private CheckBox chkBorcOdenmeDurumu;
        private DateTimePicker dtpBorcTarih;
        private Button btnBorcEkle;
        private Button btnBorcGuncelle;
        private Button btnBorcSil;


        private DataGridView dataGridViewAlacaklar;
        private TextBox txtAlacakArama;
        private Button btnAlacakArama;
        private TextBox txtAlacakMusteriID;
        private TextBox txtAlacakTutar;
        private DateTimePicker dtpAlacakVadeTarihi;
        private CheckBox chkAlacakTahsilatDurumu;
        private DateTimePicker dtpAlacakTarih;
        private Button btnAlacakEkle;
        private Button btnAlacakGuncelle;
        private Button btnAlacakSil;

        private DataGridView dataGridViewGelirGider;
        private TextBox txtGelirGiderArama;
        private Button btnGelirGiderArama;
        private TextBox txtGelirGiderTur;
        private TextBox txtGelirGiderTutar;
        private DateTimePicker dtpGelirGiderTarih;
        private TextBox txtGelirGiderAciklama;
        private Button btnGelirGiderEkle;
        private Button btnGelirGiderGuncelle;
        private Button btnGelirGiderSil;
        private ComboBox cmbElemanlar;
        private ComboBox cmbUrunler;
        private bool isUpdatingComboBox = false;

        private TextBox txtKategori;
        private TextBox txtFiyat;
        private ComboBox cmbTedarikci;

        private TextBox txtAlisFiyat;
        private TextBox txtSatisFiyat;

        private DataGridView dataGridViewUrunAdi;
        private TextBox txtYeniUrunAdi;
        private TextBox txtYeniKategori;
        private Button btnUrunAdiEkle;
        private Button btnUrunAdiGuncelle;
        private Button btnUrunAdiSil;
        // ComboBox declarations
        private ComboBox cmbUrunAdi;
        private TextBox txtParcaMiktar;
        private TextBox txtParcaSatisFiyati;


        public MainForm()
        {
            InitializeComponentHome();
        }

        private void UpdateFormTitle(string menuName)
        {
            this.Text = menuName;
        }


        private void InitializeComponentHome()
        {

            // Form boyut ayarları
            //this.Size = new System.Drawing.Size(1000, 600); // Formun başlangıç boyutu
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new System.Drawing.Size(800, 600); // Formun minimum boyutu


            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.müşterilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tedarikçilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elemanlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.araçlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.işlemlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borçlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alacaklarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gelirGiderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();

            this.dataGridViewUrunAdi = new DataGridView();
            this.txtYeniUrunAdi = new TextBox();
            this.txtYeniKategori = new TextBox();
            this.btnUrunAdiEkle = new Button();
            this.btnUrunAdiGuncelle = new Button();
            this.btnUrunAdiSil = new Button();


            // UrunAdi için gerekli kontroller
            this.dataGridViewUrunAdi.Location = new System.Drawing.Point(10, 300); // Konumu örnek olarak veriyorum
            this.dataGridViewUrunAdi.Size = new System.Drawing.Size(600, 150); // Örnek boyut

            this.txtYeniUrunAdi.Location = new System.Drawing.Point(620, 300); // Örnek konum
            this.txtYeniKategori.Location = new System.Drawing.Point(620, 330); // Örnek konum

            this.btnUrunAdiEkle.Location = new System.Drawing.Point(620, 360); // Örnek konum
            this.btnUrunAdiEkle.Text = "Ürün Adı Ekle";
            this.btnUrunAdiEkle.Click += new System.EventHandler(this.btnUrunAdiEkle_Click);

            this.btnUrunAdiGuncelle.Location = new System.Drawing.Point(620, 390); // Örnek konum
            this.btnUrunAdiGuncelle.Text = "Güncelle";
            this.btnUrunAdiGuncelle.Click += new System.EventHandler(this.btnUrunAdiGuncelle_Click);

            this.btnUrunAdiSil.Location = new System.Drawing.Point(620, 420); // Örnek konum
            this.btnUrunAdiSil.Text = "Sil";
            this.btnUrunAdiSil.Click += new System.EventHandler(this.btnUrunAdiSil_Click);


           
            



            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Size = new System.Drawing.Size(800, 426);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 0;

            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.müşterilerToolStripMenuItem,
                this.tedarikçilerToolStripMenuItem,
                this.elemanlarToolStripMenuItem,
                this.araçlarToolStripMenuItem,
                this.işlemlerToolStripMenuItem,
                this.ürünlerToolStripMenuItem,
                this.stokToolStripMenuItem,
                this.borçlarToolStripMenuItem,
                this.alacaklarToolStripMenuItem,
                this.gelirGiderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";

            this.müşterilerToolStripMenuItem.Name = "müşterilerToolStripMenuItem";
            this.müşterilerToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.müşterilerToolStripMenuItem.Text = "Müşteriler";
            this.müşterilerToolStripMenuItem.Click += new System.EventHandler(this.müşterilerToolStripMenuItem_Click);

            this.tedarikçilerToolStripMenuItem.Name = "tedarikçilerToolStripMenuItem";
            this.tedarikçilerToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.tedarikçilerToolStripMenuItem.Text = "Tedarikçiler";
            this.tedarikçilerToolStripMenuItem.Click += new System.EventHandler(this.tedarikcilerToolStripMenuItem_Click);

            this.elemanlarToolStripMenuItem.Name = "elemanlarToolStripMenuItem";
            this.elemanlarToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.elemanlarToolStripMenuItem.Text = "Elemanlar";
            this.elemanlarToolStripMenuItem.Click += new System.EventHandler(this.elemanlarToolStripMenueItem_Click );


            this.araçlarToolStripMenuItem.Name = "araçlarToolStripMenuItem";
            this.araçlarToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.araçlarToolStripMenuItem.Text = "Araçlar";
            this.araçlarToolStripMenuItem.Click += new System.EventHandler(this.araçlarToolStripMenuItem_Click);


            this.işlemlerToolStripMenuItem.Name = "işlemlerToolStripMenuItem";
            this.işlemlerToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.işlemlerToolStripMenuItem.Text = "İşlemler";
            this.işlemlerToolStripMenuItem.Click += new System.EventHandler(this.işlemlerToolStripMenuItem_Click);

            this.ürünlerToolStripMenuItem.Name = "ürünlerToolStripMenuItem";
            this.ürünlerToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.ürünlerToolStripMenuItem.Text = "Ürünler";
            this.ürünlerToolStripMenuItem.Click += new System.EventHandler(this.ürünlerToolStripMenuItem_Click);

            this.stokToolStripMenuItem.Name = "stokToolStripMenuItem";
            this.stokToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.stokToolStripMenuItem.Text = "Stok";
            this.stokToolStripMenuItem.Click += new System.EventHandler(this.stokToolStripMenuItem_Click);

            this.borçlarToolStripMenuItem.Name = "borçlarToolStripMenuItem";
            this.borçlarToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.borçlarToolStripMenuItem.Text = "Borçlar";
            this.borçlarToolStripMenuItem.Click += new System.EventHandler(this.borçlarToolStripMenuItem_Click);
            

            this.alacaklarToolStripMenuItem.Name = "alacaklarToolStripMenuItem";
            this.alacaklarToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.alacaklarToolStripMenuItem.Text = "Alacaklar";
            this.alacaklarToolStripMenuItem.Click += new System.EventHandler(this.alacaklarToolStripMenuItem_Click);


            this.gelirGiderToolStripMenuItem.Name = "gelirGiderToolStripMenuItem";
            this.gelirGiderToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.gelirGiderToolStripMenuItem.Text = "Gelir/Gider";
            this.gelirGiderToolStripMenuItem.Click += new System.EventHandler(this.gelirGiderToolStripMenuItem_Click);

            // Form ayarları
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Ana Sayfa";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Müşteriler

        private void müşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadMusteriControls();
            UpdateFormTitle("Müşteriler");

        }


        private void LoadMusteriControls()
        {
            ClearControls();

            // DataGridView
            dataGridViewMusteriler = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, // Kolon genişliğini içeriklere göre ayarla
                ReadOnly = true // Veri değiştirilemesin
            };
            dataGridViewMusteriler.SelectionChanged += new System.EventHandler(this.dataGridViewMusteriler_SelectionChanged);
            this.splitContainer1.Panel1.Controls.Add(dataGridViewMusteriler);

            // Arama TextBox
            txtArama = new TextBox
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(200, 20)
            };
            this.splitContainer1.Panel2.Controls.Add(txtArama);

            // Arama Button
            btnArama = new Button
            {
                Location = new System.Drawing.Point(220, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Ara"
            };
            btnArama.Click += new System.EventHandler(this.btnArama_Click);
            this.splitContainer1.Panel2.Controls.Add(btnArama);

            // Diğer butonlar ve kontroller
            btnEkle = new Button
            {
                Location = new System.Drawing.Point(713, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Ekle"
            };
            btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnEkle);

            btnGuncelle = new Button
            {
                Location = new System.Drawing.Point(713, 39),
                Size = new System.Drawing.Size(75, 23),
                Text = "Güncelle"
            };
            btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnGuncelle);

            btnSil = new Button
            {
                Location = new System.Drawing.Point(713, 68),
                Size = new System.Drawing.Size(75, 23),
                Text = "Sil"
            };
            btnSil.Click += new System.EventHandler(this.btnSil_Click);
            this.splitContainer1.Panel2.Controls.Add(btnSil);

            // TextBoxes and Labels
            txtTCNo = new TextBox { Location = new System.Drawing.Point(89, 36), Size = new System.Drawing.Size(100, 20) };
            txtAd = new TextBox { Location = new System.Drawing.Point(89, 62), Size = new System.Drawing.Size(100, 20) };
            txtSoyad = new TextBox { Location = new System.Drawing.Point(89, 88), Size = new System.Drawing.Size(100, 20) };
            txtTelefonNo = new TextBox { Location = new System.Drawing.Point(89, 114), Size = new System.Drawing.Size(100, 20) };
            txtEmail = new TextBox { Location = new System.Drawing.Point(89, 140), Size = new System.Drawing.Size(100, 20) };
            txtAdres = new TextBox { Location = new System.Drawing.Point(89, 166), Size = new System.Drawing.Size(100, 20) };
            rtbNotlar = new RichTextBox { Location = new System.Drawing.Point(89, 192), Size = new System.Drawing.Size(200, 50) };

            lblTCNo = new Label { Location = new System.Drawing.Point(12, 39), Size = new System.Drawing.Size(71, 13), Text = "TC Kimlik No:" };
            lblAd = new Label { Location = new System.Drawing.Point(12, 65), Size = new System.Drawing.Size(23, 13), Text = "Ad:" };
            lblSoyad = new Label { Location = new System.Drawing.Point(12, 91), Size = new System.Drawing.Size(39, 13), Text = "Soyad:" };
            lblTelefonNo = new Label { Location = new System.Drawing.Point(12, 117), Size = new System.Drawing.Size(61, 13), Text = "Telefon No:" };
            lblEmail = new Label { Location = new System.Drawing.Point(12, 143), Size = new System.Drawing.Size(35, 13), Text = "Email:" };
            lblAdres = new Label { Location = new System.Drawing.Point(12, 169), Size = new System.Drawing.Size(37, 13), Text = "Adres:" };
            lblNotlar = new Label { Location = new System.Drawing.Point(12, 195), Size = new System.Drawing.Size(37, 13), Text = "Notlar:" };

            this.splitContainer1.Panel2.Controls.Add(txtTCNo);
            this.splitContainer1.Panel2.Controls.Add(txtAd);
            this.splitContainer1.Panel2.Controls.Add(txtSoyad);
            this.splitContainer1.Panel2.Controls.Add(txtTelefonNo);
            this.splitContainer1.Panel2.Controls.Add(txtEmail);
            this.splitContainer1.Panel2.Controls.Add(txtAdres);
            this.splitContainer1.Panel2.Controls.Add(rtbNotlar);
            this.splitContainer1.Panel2.Controls.Add(lblTCNo);
            this.splitContainer1.Panel2.Controls.Add(lblAd);
            this.splitContainer1.Panel2.Controls.Add(lblSoyad);
            this.splitContainer1.Panel2.Controls.Add(lblTelefonNo);
            this.splitContainer1.Panel2.Controls.Add(lblEmail);
            this.splitContainer1.Panel2.Controls.Add(lblAdres);
            this.splitContainer1.Panel2.Controls.Add(lblNotlar);

            // Müşteri verilerini yükle
            LoadMusteriler();
        }

        private void ClearTextBoxes()
        {
            txtTCNo.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtTelefonNo.Text = "";
            txtEmail.Text = "";
            txtAdres.Text = "";
            rtbNotlar.Text = ""; // RichTextBox için
        }


        private void ClearControls()
        {
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Clear();
        }

        private void LoadMusteriler()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Musteriler";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewMusteriler.DataSource = dataTable;
            }
        }


        private void btnArama_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Musteriler WHERE Ad LIKE @search OR Soyad LIKE @search OR TCNo LIKE @search OR TelefonNo LIKE @search";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + txtArama.Text + "%");
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewMusteriler.DataSource = dataTable;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtTCNo.Text) ||
                string.IsNullOrWhiteSpace(txtAd.Text) ||
                string.IsNullOrWhiteSpace(txtSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtTelefonNo.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtAdres.Text) ||
                string.IsNullOrWhiteSpace(rtbNotlar.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Musteriler (TCNo, Ad, Soyad, TelefonNo, Email, Adres, Notlar) VALUES (@TCNo, @Ad, @Soyad, @TelefonNo, @Email, @Adres, @Notlar)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TCNo", txtTCNo.Text);
                    command.Parameters.AddWithValue("@Ad", txtAd.Text);
                    command.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
                    command.Parameters.AddWithValue("@TelefonNo", txtTelefonNo.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@Adres", txtAdres.Text);
                    command.Parameters.AddWithValue("@Notlar", rtbNotlar.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadMusteriler();
                    ClearTextBoxes();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtTCNo.Text) ||
        string.IsNullOrWhiteSpace(txtAd.Text) ||
        string.IsNullOrWhiteSpace(txtSoyad.Text) ||
        string.IsNullOrWhiteSpace(txtTelefonNo.Text) ||
        string.IsNullOrWhiteSpace(txtEmail.Text) ||
        string.IsNullOrWhiteSpace(txtAdres.Text) ||
        string.IsNullOrWhiteSpace(rtbNotlar.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Musteriler SET TCNo = @TCNo, Ad = @Ad, Soyad = @Soyad, TelefonNo = @TelefonNo, Email = @Email, Adres = @Adres, Notlar = @Notlar WHERE MusteriID = @MusteriID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TCNo", txtTCNo.Text);
                    command.Parameters.AddWithValue("@Ad", txtAd.Text);
                    command.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
                    command.Parameters.AddWithValue("@TelefonNo", txtTelefonNo.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@Adres", txtAdres.Text);
                    command.Parameters.AddWithValue("@Notlar", rtbNotlar.Text);
                    command.Parameters.AddWithValue("@MusteriID", dataGridViewMusteriler.SelectedRows[0].Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadMusteriler();
                    ClearTextBoxes();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Musteriler WHERE MusteriID = @MusteriID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MusteriID", dataGridViewMusteriler.SelectedRows[0].Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadMusteriler();
                    ClearTextBoxes();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewMusteriler_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewMusteriler.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewMusteriler.SelectedRows[0];
                txtTCNo.Text = row.Cells["TCNo"].Value.ToString();
                txtAd.Text = row.Cells["Ad"].Value.ToString();
                txtSoyad.Text = row.Cells["Soyad"].Value.ToString();
                txtTelefonNo.Text = row.Cells["TelefonNo"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtAdres.Text = row.Cells["Adres"].Value.ToString();
                rtbNotlar.Text = row.Cells["Notlar"].Value.ToString(); // RichTextBox için

            }
        }

        // Müşteriler 

        //------------------------------------------------------------------------------------------------------------------------------

        // tedarikçiler
        private void LoadTedarikciControls()
        {
            ClearControls();

            // DataGridView
            dataGridViewTedarikciler = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, // Kolon genişliğini içeriklere göre ayarla
                ReadOnly = true // Veri değiştirilemesin
            };
            dataGridViewTedarikciler.SelectionChanged += new System.EventHandler(this.dataGridViewTedarikciler_SelectionChanged);
            this.splitContainer1.Panel1.Controls.Add(dataGridViewTedarikciler);


            // Arama TextBox
            txtTedarikciArama = new TextBox
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(200, 20)
            };
            this.splitContainer1.Panel2.Controls.Add(txtTedarikciArama);

            // Arama Button
            btnTedarikciArama = new Button
            {
                Location = new System.Drawing.Point(220, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Ara"
            };
            btnTedarikciArama.Click += new System.EventHandler(this.btnTedarikciArama_Click);
            this.splitContainer1.Panel2.Controls.Add(btnTedarikciArama);

            // Diğer butonlar ve kontroller
            btnTedarikciEkle = new Button
            {
                Location = new System.Drawing.Point(713, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Ekle"
            };
            btnTedarikciEkle.Click += new System.EventHandler(this.btnTedarikciEkle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnTedarikciEkle);

            btnTedarikciGuncelle = new Button
            {
                Location = new System.Drawing.Point(713, 39),
                Size = new System.Drawing.Size(75, 23),
                Text = "Güncelle"
            };
            btnTedarikciGuncelle.Click += new System.EventHandler(this.btnTedarikciGuncelle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnTedarikciGuncelle);

            btnTedarikciSil = new Button
            {
                Location = new System.Drawing.Point(713, 68),
                Size = new System.Drawing.Size(75, 23),
                Text = "Sil"
            };
            btnTedarikciSil.Click += new System.EventHandler(this.btnTedarikciSil_Click);
            this.splitContainer1.Panel2.Controls.Add(btnTedarikciSil);

            // TextBoxes and Labels
            txtTedarikciAdi = new TextBox { Location = new System.Drawing.Point(89, 10), Size = new System.Drawing.Size(100, 20) };
            txtIletisimKisi = new TextBox { Location = new System.Drawing.Point(89, 36), Size = new System.Drawing.Size(100, 20) };
            txtTedarikciTelefonNo = new TextBox { Location = new System.Drawing.Point(89, 62), Size = new System.Drawing.Size(100, 20) };
            txtTedarikciEmail = new TextBox { Location = new System.Drawing.Point(89, 88), Size = new System.Drawing.Size(100, 20) };
            rtbTedarikciAdres = new RichTextBox { Location = new System.Drawing.Point(89, 114), Size = new System.Drawing.Size(200, 50) };

            lblTedarikciAdi = new Label { Location = new System.Drawing.Point(12, 13), Size = new System.Drawing.Size(71, 13), Text = "Tedarikçi Adı:" };
            lblIletisimKisi = new Label { Location = new System.Drawing.Point(12, 39), Size = new System.Drawing.Size(61, 13), Text = "İletişim Kişi:" };
            lblTedarikciTelefonNo = new Label { Location = new System.Drawing.Point(12, 65), Size = new System.Drawing.Size(71, 13), Text = "Telefon No:" };
            lblTedarikciEmail = new Label { Location = new System.Drawing.Point(12, 91), Size = new System.Drawing.Size(35, 13), Text = "Email:" };
            lblTedarikciAdres = new Label { Location = new System.Drawing.Point(12, 117), Size = new System.Drawing.Size(37, 13), Text = "Adres:" };

            this.splitContainer1.Panel2.Controls.Add(txtTedarikciAdi);
            this.splitContainer1.Panel2.Controls.Add(txtIletisimKisi);
            this.splitContainer1.Panel2.Controls.Add(txtTedarikciTelefonNo);
            this.splitContainer1.Panel2.Controls.Add(txtTedarikciEmail);
            this.splitContainer1.Panel2.Controls.Add(rtbTedarikciAdres);
            this.splitContainer1.Panel2.Controls.Add(lblTedarikciAdi);
            this.splitContainer1.Panel2.Controls.Add(lblIletisimKisi);
            this.splitContainer1.Panel2.Controls.Add(lblTedarikciTelefonNo);
            this.splitContainer1.Panel2.Controls.Add(lblTedarikciEmail);
            this.splitContainer1.Panel2.Controls.Add(lblTedarikciAdres);

            // Tedarikçi verilerini yükle
            LoadTedarikciler();
        }
        private void LoadTedarikciler()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Tedarikciler";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewTedarikciler.DataSource = dataTable;
            }
        }

        private void tedarikcilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadTedarikciControls();
            UpdateFormTitle("Tedarikçiler");

        }


        private void ClearTedarikciTextBoxes()
        {
            txtTedarikciAdi.Text = "";
            txtIletisimKisi.Text = "";
            txtTedarikciTelefonNo.Text = "";
            txtTedarikciEmail.Text = "";
            rtbTedarikciAdres.Text = ""; // RichTextBox için
        }

        private void btnTedarikciEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTedarikciAdi.Text) ||
        string.IsNullOrWhiteSpace(txtIletisimKisi.Text) ||
        string.IsNullOrWhiteSpace(txtTedarikciTelefonNo.Text) ||
        string.IsNullOrWhiteSpace(txtTedarikciEmail.Text) ||
        string.IsNullOrWhiteSpace(rtbTedarikciAdres.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Tedarikciler (TedarikciAdi, IletisimKisi, TelefonNo, Email, Adres) VALUES (@TedarikciAdi, @IletisimKisi, @TelefonNo, @Email, @Adres)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TedarikciAdi", txtTedarikciAdi.Text);
                    command.Parameters.AddWithValue("@IletisimKisi", txtIletisimKisi.Text);
                    command.Parameters.AddWithValue("@TelefonNo", txtTedarikciTelefonNo.Text);
                    command.Parameters.AddWithValue("@Email", txtTedarikciEmail.Text);
                    command.Parameters.AddWithValue("@Adres", rtbTedarikciAdres.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadTedarikciler();
                    ClearTedarikciTextBoxes();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTedarikciGuncelle_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtTedarikciAdi.Text) ||
       string.IsNullOrWhiteSpace(txtIletisimKisi.Text) ||
       string.IsNullOrWhiteSpace(txtTedarikciTelefonNo.Text) ||
       string.IsNullOrWhiteSpace(txtTedarikciEmail.Text) ||
       string.IsNullOrWhiteSpace(rtbTedarikciAdres.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Tedarikciler SET TedarikciAdi = @TedarikciAdi, IletisimKisi = @IletisimKisi, TelefonNo = @TelefonNo, Email = @Email, Adres = @Adres WHERE TedarikciID = @TedarikciID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TedarikciAdi", txtTedarikciAdi.Text);
                    command.Parameters.AddWithValue("@IletisimKisi", txtIletisimKisi.Text);
                    command.Parameters.AddWithValue("@TelefonNo", txtTedarikciTelefonNo.Text);
                    command.Parameters.AddWithValue("@Email", txtTedarikciEmail.Text);
                    command.Parameters.AddWithValue("@Adres", rtbTedarikciAdres.Text);
                    command.Parameters.AddWithValue("@TedarikciID", dataGridViewTedarikciler.SelectedRows[0].Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadTedarikciler();
                    ClearTedarikciTextBoxes();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTedarikciSil_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Tedarikciler WHERE TedarikciID = @TedarikciID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TedarikciID", dataGridViewTedarikciler.SelectedRows[0].Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadTedarikciler();
                    ClearTedarikciTextBoxes();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnTedarikciArama_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Tedarikciler WHERE TedarikciAdi LIKE @search OR IletisimKisi LIKE @search OR TelefonNo LIKE @search";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + txtTedarikciArama.Text + "%");
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewTedarikciler.DataSource = dataTable;
            }
        }

        private void dataGridViewTedarikciler_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewTedarikciler.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewTedarikciler.SelectedRows[0];
                txtTedarikciAdi.Text = row.Cells["TedarikciAdi"].Value.ToString();
                txtIletisimKisi.Text = row.Cells["IletisimKisi"].Value.ToString();
                txtTedarikciTelefonNo.Text = row.Cells["TelefonNo"].Value.ToString();
                txtTedarikciEmail.Text = row.Cells["Email"].Value.ToString();
                rtbTedarikciAdres.Text = row.Cells["Adres"].Value.ToString(); // RichTextBox için
            }
        }

        // tedarikçiler

        //------------------------------------------------------------------------------------------------------------------------------

        // elemanlar

        private void elemanlarToolStripMenueItem_Click(object sender, EventArgs e)
        {
            LoadElemanControls();
            UpdateFormTitle("Elemanlar");

        }


        private void LoadElemanlar()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Elemanlar";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewElemanlar.DataSource = dataTable;
            }
        }

        private void LoadElemanControls()
        {
            ClearControls();

            // DataGridView
            dataGridViewElemanlar = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, // Kolon genişliğini içeriklere göre ayarla
                ReadOnly = true // Veri değiştirilemesin
            };
            dataGridViewElemanlar.SelectionChanged += new System.EventHandler(this.dataGridViewElemanlar_SelectionChanged);
            this.splitContainer1.Panel1.Controls.Add(dataGridViewElemanlar);

            // Arama TextBox
            txtElemanArama = new TextBox
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(200, 20)
            };
            this.splitContainer1.Panel2.Controls.Add(txtElemanArama);

            // Arama Button
            btnElemanArama = new Button
            {
                Location = new System.Drawing.Point(220, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Ara"
            };
            btnElemanArama.Click += new System.EventHandler(this.btnElemanArama_Click);
            this.splitContainer1.Panel2.Controls.Add(btnElemanArama);

            // Diğer butonlar ve kontroller
            btnElemanEkle = new Button
            {
                Location = new System.Drawing.Point(713, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Ekle"
            };
            btnElemanEkle.Click += new System.EventHandler(this.btnElemanEkle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnElemanEkle);

            btnElemanGuncelle = new Button
            {
                Location = new System.Drawing.Point(713, 39),
                Size = new System.Drawing.Size(75, 23),
                Text = "Güncelle"
            };
            btnElemanGuncelle.Click += new System.EventHandler(this.btnElemanGuncelle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnElemanGuncelle);

            btnElemanSil = new Button
            {
                Location = new System.Drawing.Point(713, 68),
                Size = new System.Drawing.Size(75, 23),
                Text = "Sil"
            };
            btnElemanSil.Click += new System.EventHandler(this.btnElemanSil_Click);
            this.splitContainer1.Panel2.Controls.Add(btnElemanSil);

            // TextBoxes and Labels
            txtElemanTCNo = new TextBox { Location = new System.Drawing.Point(89, 36), Size = new System.Drawing.Size(100, 20) };
            txtElemanAd = new TextBox { Location = new System.Drawing.Point(89, 62), Size = new System.Drawing.Size(100, 20) };
            txtElemanSoyad = new TextBox { Location = new System.Drawing.Point(89, 88), Size = new System.Drawing.Size(100, 20) };
            txtElemanTelefonNo = new TextBox { Location = new System.Drawing.Point(89, 114), Size = new System.Drawing.Size(100, 20) };
            txtElemanEmail = new TextBox { Location = new System.Drawing.Point(89, 140), Size = new System.Drawing.Size(100, 20) };
            txtElemanPozisyon = new TextBox { Location = new System.Drawing.Point(89, 166), Size = new System.Drawing.Size(100, 20) };
            txtElemanMaas = new TextBox { Location = new System.Drawing.Point(89, 192), Size = new System.Drawing.Size(100, 20) };
            txtElemanAvans = new TextBox { Location = new System.Drawing.Point(89, 218), Size = new System.Drawing.Size(100, 20) };
            rtbElemanNotlar = new RichTextBox { Location = new System.Drawing.Point(89, 244), Size = new System.Drawing.Size(200, 50) };

            Label lblTCNo = new Label { Location = new System.Drawing.Point(12, 39), Size = new System.Drawing.Size(71, 13), Text = "TC Kimlik No:" };
            Label lblAd = new Label { Location = new System.Drawing.Point(12, 65), Size = new System.Drawing.Size(23, 13), Text = "Ad:" };
            Label lblSoyad = new Label { Location = new System.Drawing.Point(12, 91), Size = new System.Drawing.Size(39, 13), Text = "Soyad:" };
            Label lblTelefonNo = new Label { Location = new System.Drawing.Point(12, 117), Size = new System.Drawing.Size(61, 13), Text = "Telefon No:" };
            Label lblEmail = new Label { Location = new System.Drawing.Point(12, 143), Size = new System.Drawing.Size(35, 13), Text = "Email:" };
            Label lblPozisyon = new Label { Location = new System.Drawing.Point(12, 169), Size = new System.Drawing.Size(53, 13), Text = "Pozisyon:" };
            Label lblMaas = new Label { Location = new System.Drawing.Point(12, 195), Size = new System.Drawing.Size(35, 13), Text = "Maaş:" };
            Label lblAvans = new Label { Location = new System.Drawing.Point(12, 221), Size = new System.Drawing.Size(41, 13), Text = "Avans:" };
            Label lblNotlar = new Label { Location = new System.Drawing.Point(12, 247), Size = new System.Drawing.Size(37, 13), Text = "Notlar:" };

            this.splitContainer1.Panel2.Controls.Add(txtElemanTCNo);
            this.splitContainer1.Panel2.Controls.Add(txtElemanAd);
            this.splitContainer1.Panel2.Controls.Add(txtElemanSoyad);
            this.splitContainer1.Panel2.Controls.Add(txtElemanTelefonNo);
            this.splitContainer1.Panel2.Controls.Add(txtElemanEmail);
            this.splitContainer1.Panel2.Controls.Add(txtElemanPozisyon);
            this.splitContainer1.Panel2.Controls.Add(txtElemanMaas);
            this.splitContainer1.Panel2.Controls.Add(txtElemanAvans);
            this.splitContainer1.Panel2.Controls.Add(rtbElemanNotlar);

            this.splitContainer1.Panel2.Controls.Add(lblTCNo);
            this.splitContainer1.Panel2.Controls.Add(lblAd);
            this.splitContainer1.Panel2.Controls.Add(lblSoyad);
            this.splitContainer1.Panel2.Controls.Add(lblTelefonNo);
            this.splitContainer1.Panel2.Controls.Add(lblEmail);
            this.splitContainer1.Panel2.Controls.Add(lblPozisyon);
            this.splitContainer1.Panel2.Controls.Add(lblMaas);
            this.splitContainer1.Panel2.Controls.Add(lblAvans);
            this.splitContainer1.Panel2.Controls.Add(lblNotlar);

            // Eleman verilerini yükle
            LoadElemanlar();
        }
        private void btnElemanArama_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Elemanlar WHERE Ad LIKE @search OR Soyad LIKE @search OR TelefonNo LIKE @search";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + txtElemanArama.Text + "%");
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewElemanlar.DataSource = dataTable;
            }
        }

        private void btnElemanEkle_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(txtElemanTCNo.Text) ||
        string.IsNullOrWhiteSpace(txtElemanAd.Text) ||
        string.IsNullOrWhiteSpace(txtElemanSoyad.Text) ||
        string.IsNullOrWhiteSpace(txtElemanTelefonNo.Text) ||
        string.IsNullOrWhiteSpace(txtElemanEmail.Text) ||
        string.IsNullOrWhiteSpace(txtElemanPozisyon.Text) ||
        string.IsNullOrWhiteSpace(txtElemanMaas.Text) ||
        string.IsNullOrWhiteSpace(txtElemanAvans.Text) ||
        string.IsNullOrWhiteSpace(rtbElemanNotlar.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Elemanlar (TCNo, Ad, Soyad, TelefonNo, Email, Pozisyon, Maas, Avans, Notlar) VALUES (@TCNo, @Ad, @Soyad, @TelefonNo, @Email, @Pozisyon, @Maas, @Avans, @Notlar)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TCNo", txtElemanTCNo.Text);
                    command.Parameters.AddWithValue("@Ad", txtElemanAd.Text);
                    command.Parameters.AddWithValue("@Soyad", txtElemanSoyad.Text);
                    command.Parameters.AddWithValue("@TelefonNo", txtElemanTelefonNo.Text);
                    command.Parameters.AddWithValue("@Email", txtElemanEmail.Text);
                    command.Parameters.AddWithValue("@Pozisyon", txtElemanPozisyon.Text);
                    command.Parameters.AddWithValue("@Maas", decimal.Parse(txtElemanMaas.Text)); // Decimal dönüştürme
                    command.Parameters.AddWithValue("@Avans", decimal.Parse(txtElemanAvans.Text)); // Decimal dönüştürme
                    command.Parameters.AddWithValue("@Notlar", rtbElemanNotlar.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadElemanlar();
                    ClearElemanTextBoxes();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen geçerli bir maaş ve avans miktarı giriniz.", "Hatalı Veri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElemanGuncelle_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtElemanTCNo.Text) ||
        string.IsNullOrWhiteSpace(txtElemanAd.Text) ||
        string.IsNullOrWhiteSpace(txtElemanSoyad.Text) ||
        string.IsNullOrWhiteSpace(txtElemanTelefonNo.Text) ||
        string.IsNullOrWhiteSpace(txtElemanEmail.Text) ||
        string.IsNullOrWhiteSpace(txtElemanPozisyon.Text) ||
        string.IsNullOrWhiteSpace(txtElemanMaas.Text) ||
        string.IsNullOrWhiteSpace(txtElemanAvans.Text) ||
        string.IsNullOrWhiteSpace(rtbElemanNotlar.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Elemanlar SET TCNo = @TCNo, Ad = @Ad, Soyad = @Soyad, TelefonNo = @TelefonNo, Email = @Email, Pozisyon = @Pozisyon, Maas = @Maas, Avans = @Avans, Notlar = @Notlar WHERE ElemanID = @ElemanID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TCNo", txtElemanTCNo.Text);
                    command.Parameters.AddWithValue("@Ad", txtElemanAd.Text);
                    command.Parameters.AddWithValue("@Soyad", txtElemanSoyad.Text);
                    command.Parameters.AddWithValue("@TelefonNo", txtElemanTelefonNo.Text);
                    command.Parameters.AddWithValue("@Email", txtElemanEmail.Text);
                    command.Parameters.AddWithValue("@Pozisyon", txtElemanPozisyon.Text);
                    command.Parameters.AddWithValue("@Maas", decimal.Parse(txtElemanMaas.Text)); // Decimal dönüştürme
                    command.Parameters.AddWithValue("@Avans", decimal.Parse(txtElemanAvans.Text)); // Decimal dönüştürme
                    command.Parameters.AddWithValue("@Notlar", rtbElemanNotlar.Text);
                    command.Parameters.AddWithValue("@ElemanID", dataGridViewElemanlar.SelectedRows[0].Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadElemanlar();
                    ClearElemanTextBoxes();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen geçerli bir maaş ve avans miktarı giriniz.", "Hatalı Veri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElemanSil_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Elemanlar WHERE ElemanID = @ElemanID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ElemanID", dataGridViewElemanlar.SelectedRows[0].Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadElemanlar();
                    ClearElemanTextBoxes();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearElemanTextBoxes()
        {
            txtElemanTCNo.Text = "";
            txtElemanAd.Text = "";
            txtElemanSoyad.Text = "";
            txtElemanTelefonNo.Text = "";
            txtElemanEmail.Text = "";
            txtElemanPozisyon.Text = "";
            txtElemanMaas.Text = "";
            txtElemanAvans.Text = "";
            rtbElemanNotlar.Text = ""; // RichTextBox için
        }

        private void dataGridViewElemanlar_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewElemanlar.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewElemanlar.SelectedRows[0];
                txtElemanTCNo.Text = row.Cells["TCNo"].Value.ToString();
                txtElemanAd.Text = row.Cells["Ad"].Value.ToString();
                txtElemanSoyad.Text = row.Cells["Soyad"].Value.ToString();
                txtElemanTelefonNo.Text = row.Cells["TelefonNo"].Value.ToString();
                txtElemanEmail.Text = row.Cells["Email"].Value.ToString();
                txtElemanPozisyon.Text = row.Cells["Pozisyon"].Value.ToString();
                txtElemanMaas.Text = row.Cells["Maas"].Value.ToString();
                txtElemanAvans.Text = row.Cells["Avans"].Value.ToString();
                rtbElemanNotlar.Text = row.Cells["Notlar"].Value.ToString(); // RichTextBox için
            }
        }


        // elemanlar

        //------------------------------------------------------------------------------------------------------------

        //Araçlar


        private void LoadAracControls()
        {
            ClearControls();

            // DataGridView
            dataGridViewAraclar = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, // Kolon genişliğini içeriklere göre ayarla
                ReadOnly = true // Veri değiştirilemesin
            };
            dataGridViewAraclar.SelectionChanged += new System.EventHandler(this.dataGridViewAraclar_SelectionChanged);
            this.splitContainer1.Panel1.Controls.Add(dataGridViewAraclar);

            // Arama TextBox
            txtAracArama = new TextBox
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(200, 20)
            };
            this.splitContainer1.Panel2.Controls.Add(txtAracArama);

            // Arama Button
            btnAracArama = new Button
            {
                Location = new System.Drawing.Point(220, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Ara"
            };
            btnAracArama.Click += new System.EventHandler(this.btnAracArama_Click);
            this.splitContainer1.Panel2.Controls.Add(btnAracArama);

            // Diğer butonlar ve kontroller
            btnAracEkle = new Button
            {
                Location = new System.Drawing.Point(713, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Ekle"
            };
            btnAracEkle.Click += new System.EventHandler(this.btnAracEkle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnAracEkle);

            btnAracGuncelle = new Button
            {
                Location = new System.Drawing.Point(713, 39),
                Size = new System.Drawing.Size(75, 23),
                Text = "Güncelle"
            };
            btnAracGuncelle.Click += new System.EventHandler(this.btnAracGuncelle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnAracGuncelle);

            btnAracSil = new Button
            {
                Location = new System.Drawing.Point(713, 68),
                Size = new System.Drawing.Size(75, 23),
                Text = "Sil"
            };
            btnAracSil.Click += new System.EventHandler(this.btnAracSil_Click);
            this.splitContainer1.Panel2.Controls.Add(btnAracSil);

            // TextBoxes and Labels
            txtAracMusteriID = new TextBox { Location = new System.Drawing.Point(89, 36), Size = new System.Drawing.Size(100, 20) };
            txtAracTCNo = new TextBox { Location = new System.Drawing.Point(89, 62), Size = new System.Drawing.Size(100, 20) };
            txtAracMarka = new TextBox { Location = new System.Drawing.Point(89, 88), Size = new System.Drawing.Size(100, 20) };
            txtAracModel = new TextBox { Location = new System.Drawing.Point(89, 114), Size = new System.Drawing.Size(100, 20) };
            txtAracYil = new TextBox { Location = new System.Drawing.Point(89, 140), Size = new System.Drawing.Size(100, 20) };
            txtAracPlaka = new TextBox { Location = new System.Drawing.Point(89, 166), Size = new System.Drawing.Size(100, 20) };
            txtAracSaseNo = new TextBox { Location = new System.Drawing.Point(89, 192), Size = new System.Drawing.Size(100, 20) };
            txtAracRenk = new TextBox { Location = new System.Drawing.Point(89, 218), Size = new System.Drawing.Size(100, 20) };
            txtAracKM = new TextBox { Location = new System.Drawing.Point(89, 244), Size = new System.Drawing.Size(100, 20) };
            txtAracYakit = new TextBox { Location = new System.Drawing.Point(89, 270), Size = new System.Drawing.Size(100, 20) };

            Label lblMusteriID = new Label { Location = new System.Drawing.Point(12, 39), Size = new System.Drawing.Size(57, 13), Text = "Müşteri ID:" };
            Label lblTCNo = new Label { Location = new System.Drawing.Point(12, 65), Size = new System.Drawing.Size(71, 13), Text = "TC Kimlik No:" };
            Label lblMarka = new Label { Location = new System.Drawing.Point(12, 91), Size = new System.Drawing.Size(40, 13), Text = "Marka:" };
            Label lblModel = new Label { Location = new System.Drawing.Point(12, 117), Size = new System.Drawing.Size(39, 13), Text = "Model:" };
            Label lblYil = new Label { Location = new System.Drawing.Point(12, 143), Size = new System.Drawing.Size(23, 13), Text = "Yıl:" };
            Label lblPlaka = new Label { Location = new System.Drawing.Point(12, 169), Size = new System.Drawing.Size(37, 13), Text = "Plaka:" };
            Label lblSaseNo = new Label { Location = new System.Drawing.Point(12, 195), Size = new System.Drawing.Size(53, 13), Text = "Şase No:" };
            Label lblRenk = new Label { Location = new System.Drawing.Point(12, 221), Size = new System.Drawing.Size(36, 13), Text = "Renk:" };
            Label lblKM = new Label { Location = new System.Drawing.Point(12, 247), Size = new System.Drawing.Size(26, 13), Text = "KM:" };
            Label lblYakit = new Label { Location = new System.Drawing.Point(12, 273), Size = new System.Drawing.Size(34, 13), Text = "Yakıt:" };

            this.splitContainer1.Panel2.Controls.Add(txtAracMusteriID);
            this.splitContainer1.Panel2.Controls.Add(txtAracTCNo);
            this.splitContainer1.Panel2.Controls.Add(txtAracMarka);
            this.splitContainer1.Panel2.Controls.Add(txtAracModel);
            this.splitContainer1.Panel2.Controls.Add(txtAracYil);
            this.splitContainer1.Panel2.Controls.Add(txtAracPlaka);
            this.splitContainer1.Panel2.Controls.Add(txtAracSaseNo);
            this.splitContainer1.Panel2.Controls.Add(txtAracRenk);
            this.splitContainer1.Panel2.Controls.Add(txtAracKM);
            this.splitContainer1.Panel2.Controls.Add(txtAracYakit);

            this.splitContainer1.Panel2.Controls.Add(lblMusteriID);
            this.splitContainer1.Panel2.Controls.Add(lblTCNo);
            this.splitContainer1.Panel2.Controls.Add(lblMarka);
            this.splitContainer1.Panel2.Controls.Add(lblModel);
            this.splitContainer1.Panel2.Controls.Add(lblYil);
            this.splitContainer1.Panel2.Controls.Add(lblPlaka);
            this.splitContainer1.Panel2.Controls.Add(lblSaseNo);
            this.splitContainer1.Panel2.Controls.Add(lblRenk);
            this.splitContainer1.Panel2.Controls.Add(lblKM);
            this.splitContainer1.Panel2.Controls.Add(lblYakit);

            // Araç verilerini yükle
            LoadAraclar();
        }

        private void LoadAraclar()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Araclar";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewAraclar.DataSource = dataTable;
            }
        }

        private void btnAracArama_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Araclar WHERE TCNo LIKE '%' + @search + '%' OR Marka LIKE '%' + @search + '%' OR Plaka LIKE '%' + @search + '%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@search", txtAracArama.Text);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewAraclar.DataSource = dataTable;
            }
        }

       

        private void btnAracEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAracTCNo.Text) ||
                string.IsNullOrWhiteSpace(txtAracMarka.Text) ||
                string.IsNullOrWhiteSpace(txtAracModel.Text) ||
                string.IsNullOrWhiteSpace(txtAracYil.Text) ||
                string.IsNullOrWhiteSpace(txtAracPlaka.Text) ||
                string.IsNullOrWhiteSpace(txtAracSaseNo.Text) ||
                string.IsNullOrWhiteSpace(txtAracRenk.Text) ||
                string.IsNullOrWhiteSpace(txtAracKM.Text) ||
                string.IsNullOrWhiteSpace(txtAracYakit.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string getMusteriIdQuery = "SELECT MusteriID FROM Musteriler WHERE TCNo = @TCNo";
                    SqlCommand getMusteriIdCommand = new SqlCommand(getMusteriIdQuery, connection);
                    getMusteriIdCommand.Parameters.AddWithValue("@TCNo", txtAracTCNo.Text);

                    object result = getMusteriIdCommand.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Girilen TC Kimlik No'ya sahip bir müşteri bulunamadı. Lütfen TC Kimlik Numarasını kontrol edin ve önce müşteriyi ekleyin.", "Hatalı Veri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int musteriID = (int)result;

                    string insertAracQuery = "INSERT INTO Araclar (MusteriID, TCNo, Marka, Model, Yil, Plaka, SaseNo, Renk, KM, Yakit) VALUES (@MusteriID, @TCNo, @Marka, @Model, @Yil, @Plaka, @SaseNo, @Renk, @KM, @Yakit)";
                    SqlCommand insertAracCommand = new SqlCommand(insertAracQuery, connection);
                    insertAracCommand.Parameters.AddWithValue("@MusteriID", musteriID);
                    insertAracCommand.Parameters.AddWithValue("@TCNo", txtAracTCNo.Text);
                    insertAracCommand.Parameters.AddWithValue("@Marka", txtAracMarka.Text);
                    insertAracCommand.Parameters.AddWithValue("@Model", txtAracModel.Text);
                    insertAracCommand.Parameters.AddWithValue("@Yil", int.Parse(txtAracYil.Text));
                    insertAracCommand.Parameters.AddWithValue("@Plaka", txtAracPlaka.Text);
                    insertAracCommand.Parameters.AddWithValue("@SaseNo", txtAracSaseNo.Text);
                    insertAracCommand.Parameters.AddWithValue("@Renk", txtAracRenk.Text);
                    insertAracCommand.Parameters.AddWithValue("@KM", int.Parse(txtAracKM.Text));
                    insertAracCommand.Parameters.AddWithValue("@Yakit", txtAracYakit.Text);

                    insertAracCommand.ExecuteNonQuery();
                    connection.Close();
                    LoadAraclar();
                    ClearAracTextBoxes();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen geçerli bir yıl ve KM giriniz.", "Hatalı Veri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAracGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAracMusteriID.Text) ||
                string.IsNullOrWhiteSpace(txtAracTCNo.Text) ||
                string.IsNullOrWhiteSpace(txtAracMarka.Text) ||
                string.IsNullOrWhiteSpace(txtAracModel.Text) ||
                string.IsNullOrWhiteSpace(txtAracYil.Text) ||
                string.IsNullOrWhiteSpace(txtAracPlaka.Text) ||
                string.IsNullOrWhiteSpace(txtAracSaseNo.Text) ||
                string.IsNullOrWhiteSpace(txtAracRenk.Text) ||
                string.IsNullOrWhiteSpace(txtAracKM.Text) ||
                string.IsNullOrWhiteSpace(txtAracYakit.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Araclar SET MusteriID = @MusteriID, TCNo = @TCNo, Marka = @Marka, Model = @Model, Yil = @Yil, Plaka = @Plaka, SaseNo = @SaseNo, Renk = @Renk, KM = @KM, Yakit = @Yakit WHERE AracID = @AracID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MusteriID", int.Parse(txtAracMusteriID.Text));
                    command.Parameters.AddWithValue("@TCNo", txtAracTCNo.Text);
                    command.Parameters.AddWithValue("@Marka", txtAracMarka.Text);
                    command.Parameters.AddWithValue("@Model", txtAracModel.Text);
                    command.Parameters.AddWithValue("@Yil", int.Parse(txtAracYil.Text));
                    command.Parameters.AddWithValue("@Plaka", txtAracPlaka.Text);
                    command.Parameters.AddWithValue("@SaseNo", txtAracSaseNo.Text);
                    command.Parameters.AddWithValue("@Renk", txtAracRenk.Text);
                    command.Parameters.AddWithValue("@KM", int.Parse(txtAracKM.Text));
                    command.Parameters.AddWithValue("@Yakit", txtAracYakit.Text);
                    command.Parameters.AddWithValue("@AracID", dataGridViewAraclar.SelectedRows[0].Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadAraclar();
                    ClearAracTextBoxes();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen geçerli bir yıl ve KM giriniz.", "Hatalı Veri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAracSil_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Araclar WHERE AracID = @AracID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AracID", dataGridViewAraclar.SelectedRows[0].Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadAraclar();
                    ClearAracTextBoxes();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearAracTextBoxes()
        {
            txtAracMusteriID.Text = "";
            txtAracTCNo.Text = "";
            txtAracMarka.Text = "";
            txtAracModel.Text = "";
            txtAracYil.Text = "";
            txtAracPlaka.Text = "";
            txtAracSaseNo.Text = "";
            txtAracRenk.Text = "";
            txtAracKM.Text = "";
            txtAracYakit.Text = "";
        }

        private void dataGridViewAraclar_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewAraclar.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewAraclar.SelectedRows[0];
                txtAracMusteriID.Text = row.Cells["MusteriID"].Value.ToString();
                txtAracTCNo.Text = row.Cells["TCNo"].Value.ToString();
                txtAracMarka.Text = row.Cells["Marka"].Value.ToString();
                txtAracModel.Text = row.Cells["Model"].Value.ToString();
                txtAracYil.Text = row.Cells["Yil"].Value.ToString();
                txtAracPlaka.Text = row.Cells["Plaka"].Value.ToString();
                txtAracSaseNo.Text = row.Cells["SaseNo"].Value.ToString();
                txtAracRenk.Text = row.Cells["Renk"].Value.ToString();
                txtAracKM.Text = row.Cells["KM"].Value.ToString();
                txtAracYakit.Text = row.Cells["Yakit"].Value.ToString();
            }
        }


        private void araçlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadAracControls();
            UpdateFormTitle("Araçlar");

        }


        //Araçlar

        //------------------------------------------------------------------------------------------------------------------

        // Yapılan işlemler

        private void LoadIslemControls()
        {
            ClearControls();

            // DataGridView for Islemler
            dataGridViewIslemler = new DataGridView
            {
                Dock = DockStyle.Top,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true // Veri değiştirilemesin
            };
            dataGridViewIslemler.SelectionChanged += new System.EventHandler(this.dataGridViewIslemler_SelectionChanged);
            this.splitContainer1.Panel1.Controls.Add(dataGridViewIslemler);

            // DataGridView for IslemParcalari
            dataGridViewIslemParcalari = new DataGridView
            {
                Dock = DockStyle.Bottom,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true // Veri değiştirilemesin
            };
            this.splitContainer1.Panel2.Controls.Add(dataGridViewIslemParcalari);

            // Diğer butonlar ve kontroller
            btnIslemEkle = new Button
            {
                Location = new System.Drawing.Point(713, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Ekle"
            };
            btnIslemEkle.Click += new System.EventHandler(this.btnIslemEkle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnIslemEkle);

            btnIslemGuncelle = new Button
            {
                Location = new System.Drawing.Point(713, 39),
                Size = new System.Drawing.Size(75, 23),
                Text = "Güncelle"
            };
            btnIslemGuncelle.Click += new System.EventHandler(this.btnIslemGuncelle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnIslemGuncelle);

            btnIslemSil = new Button
            {
                Location = new System.Drawing.Point(713, 68),
                Size = new System.Drawing.Size(75, 23),
                Text = "Sil"
            };
            btnIslemSil.Click += new System.EventHandler(this.btnIslemSil_Click);
            this.splitContainer1.Panel2.Controls.Add(btnIslemSil);

            // TextBoxes and Labels for Islem
            txtIslemAracID = new TextBox { Location = new System.Drawing.Point(89, 36), Size = new System.Drawing.Size(100, 20) };
            cmbElemanlar = new ComboBox { Location = new System.Drawing.Point(89, 62), Size = new System.Drawing.Size(200, 20) };
            cmbElemanlar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbElemanlar.AutoCompleteSource = AutoCompleteSource.CustomSource;
            LoadElemanlarIntoComboBox();
            txtIslemAciklama = new TextBox { Location = new System.Drawing.Point(89, 88), Size = new System.Drawing.Size(200, 20) };
            txtIslemMaliyet = new TextBox { Location = new System.Drawing.Point(89, 114), Size = new System.Drawing.Size(100, 20) };
            dtpIslemTarihi = new DateTimePicker { Location = new System.Drawing.Point(89, 140), Size = new System.Drawing.Size(200, 20) };
            rtbIslemNotlar = new RichTextBox { Location = new System.Drawing.Point(89, 166), Size = new System.Drawing.Size(200, 96) };

            Label lblAracID = new Label { Location = new System.Drawing.Point(12, 39), Size = new System.Drawing.Size(50, 13), Text = "Araç ID:" };
            Label lblEleman = new Label { Location = new System.Drawing.Point(12, 65), Size = new System.Drawing.Size(52, 13), Text = "Eleman:" };
            Label lblAciklama = new Label { Location = new System.Drawing.Point(12, 91), Size = new System.Drawing.Size(56, 13), Text = "Açıklama:" };
            Label lblMaliyet = new Label { Location = new System.Drawing.Point(12, 117), Size = new System.Drawing.Size(47, 13), Text = "Maliyet:" };
            Label lblTarih = new Label { Location = new System.Drawing.Point(12, 143), Size = new System.Drawing.Size(35, 13), Text = "Tarih:" };
            Label lblNotlar = new Label { Location = new System.Drawing.Point(12, 169), Size = new System.Drawing.Size(37, 13), Text = "Notlar:" };

            this.splitContainer1.Panel2.Controls.Add(txtIslemAracID);
            this.splitContainer1.Panel2.Controls.Add(cmbElemanlar);
            this.splitContainer1.Panel2.Controls.Add(txtIslemAciklama);
            this.splitContainer1.Panel2.Controls.Add(txtIslemMaliyet);
            this.splitContainer1.Panel2.Controls.Add(dtpIslemTarihi);
            this.splitContainer1.Panel2.Controls.Add(rtbIslemNotlar);

            this.splitContainer1.Panel2.Controls.Add(lblAracID);
            this.splitContainer1.Panel2.Controls.Add(lblEleman);
            this.splitContainer1.Panel2.Controls.Add(lblAciklama);
            this.splitContainer1.Panel2.Controls.Add(lblMaliyet);
            this.splitContainer1.Panel2.Controls.Add(lblTarih);
            this.splitContainer1.Panel2.Controls.Add(lblNotlar);

            // Parça ekleme için TextBox ve Label
            txtParcaMiktar = new TextBox { Location = new System.Drawing.Point(89, 300), Size = new System.Drawing.Size(100, 20) };
            txtParcaSatisFiyati = new TextBox { Location = new System.Drawing.Point(89, 330), Size = new System.Drawing.Size(100, 20) };

            Label lblParcaMiktar = new Label { Location = new System.Drawing.Point(12, 303), Size = new System.Drawing.Size(71, 13), Text = "Parça Miktar:" };
            Label lblParcaSatisFiyati = new Label { Location = new System.Drawing.Point(12, 333), Size = new System.Drawing.Size(71, 13), Text = "Parça Satış Fiyatı:" };

            this.splitContainer1.Panel2.Controls.Add(txtParcaMiktar);
            this.splitContainer1.Panel2.Controls.Add(txtParcaSatisFiyati);
            this.splitContainer1.Panel2.Controls.Add(lblParcaMiktar);
            this.splitContainer1.Panel2.Controls.Add(lblParcaSatisFiyati);

            // Parça ekleme ve silme butonları
            btnParcaEkle = new Button
            {
                Location = new System.Drawing.Point(200, 300),
                Size = new System.Drawing.Size(75, 23),
                Text = "Parça Ekle"
            };
            btnParcaEkle.Click += new System.EventHandler(this.btnParcaEkle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnParcaEkle);

            btnParcaSil = new Button
            {
                Location = new System.Drawing.Point(200, 330),
                Size = new System.Drawing.Size(75, 23),
                Text = "Parça Sil"
            };
            btnParcaSil.Click += new System.EventHandler(this.btnParcaSil_Click);
            this.splitContainer1.Panel2.Controls.Add(btnParcaSil);

            // İşlem verilerini yükle
            LoadIslemler();
        }


        private void LoadIslemParcalari(int islemID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM IslemParcalari WHERE IslemID = @IslemID";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@IslemID", islemID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewIslemParcalari.DataSource = dataTable;
            }
        }

        private void dataGridViewIslemler_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewIslemler.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewIslemler.SelectedRows[0];
                txtIslemAracID.Text = row.Cells["AracID"].Value.ToString();
                cmbElemanlar.SelectedValue = row.Cells["ElemanID"].Value;
                txtIslemAciklama.Text = row.Cells["Aciklama"].Value.ToString();
                txtIslemMaliyet.Text = row.Cells["Maliyet"].Value.ToString();
                dtpIslemTarihi.Value = DateTime.Parse(row.Cells["IslemTarihi"].Value.ToString());
                rtbIslemNotlar.Text = row.Cells["Notlar"].Value.ToString();
                LoadIslemParcalari((int)row.Cells["IslemID"].Value); // Seçili işlem parçasını yükle
            }
        }

        private void btnParcaEkle_Click(object sender, EventArgs e)
        {
            if (cmbUrunler.SelectedValue == null || dataGridViewIslemler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir ürün ve işlem seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int islemID = int.Parse(dataGridViewIslemler.SelectedRows[0].Cells["IslemID"].Value.ToString());
                int urunID = (int)cmbUrunler.SelectedValue;
                int miktar = int.Parse(txtParcaMiktar.Text); // Kullanıcıdan alınan miktar
                decimal satisFiyati = decimal.Parse(txtParcaSatisFiyati.Text); // Kullanıcıdan alınan satış fiyatı

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO IslemParcalari (IslemID, UrunID, Miktar, SatisFiyati) VALUES (@IslemID, @UrunID, @Miktar, @SatisFiyati)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IslemID", islemID);
                    command.Parameters.AddWithValue("@UrunID", urunID);
                    command.Parameters.AddWithValue("@Miktar", miktar);
                    command.Parameters.AddWithValue("@SatisFiyati", satisFiyati);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadIslemParcalari(islemID);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnParcaSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewIslemParcalari.SelectedRows.Count > 0)
            {
                int islemParcaID = int.Parse(dataGridViewIslemParcalari.SelectedRows[0].Cells["IslemParcaID"].Value.ToString());
                int islemID = int.Parse(dataGridViewIslemler.SelectedRows[0].Cells["IslemID"].Value.ToString());

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM IslemParcalari WHERE IslemParcaID = @IslemParcaID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@IslemParcaID", islemParcaID);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        LoadIslemParcalari(islemID);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadUrunlerIntoComboBox(string filter = "")
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT UrunID, UrunAdi FROM Urunler";
                if (!string.IsNullOrEmpty(filter))
                {
                    query += " WHERE UrunAdi LIKE '%' + @filter + '%'";
                }

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                if (!string.IsNullOrEmpty(filter))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@filter", filter);
                }

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                AutoCompleteStringCollection autoCompleteData = new AutoCompleteStringCollection();
                foreach (DataRow row in dataTable.Rows)
                {
                    autoCompleteData.Add(row["UrunAdi"].ToString());
                }

                cmbUrunler.DataSource = dataTable;
                cmbUrunler.DisplayMember = "UrunAdi";
                cmbUrunler.ValueMember = "UrunID";
                cmbUrunler.AutoCompleteCustomSource = autoCompleteData;
            }
        }

        private void cmbUrunler_TextChanged(object sender, EventArgs e)
        {
            string filter = cmbUrunler.Text;
            LoadUrunlerIntoComboBox(filter);
            cmbUrunler.SelectedIndex = -1;
            cmbUrunler.Text = filter;
            cmbUrunler.SelectionStart = filter.Length;
            cmbUrunler.SelectionLength = 0;
        }





        private void LoadElemanlarIntoComboBox(string filter = "")
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ElemanID, CONCAT(Ad, ' ', Soyad) AS AdSoyad FROM Elemanlar";
                if (!string.IsNullOrEmpty(filter))
                {
                    query += " WHERE Ad LIKE '%' + @filter + '%' OR Soyad LIKE '%' + @filter + '%'";
                }

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                if (!string.IsNullOrEmpty(filter))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@filter", filter);
                }

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                AutoCompleteStringCollection autoCompleteData = new AutoCompleteStringCollection();
                foreach (DataRow row in dataTable.Rows)
                {
                    autoCompleteData.Add(row["AdSoyad"].ToString());
                }

                cmbElemanlar.DataSource = dataTable;
                cmbElemanlar.DisplayMember = "AdSoyad";
                cmbElemanlar.ValueMember = "ElemanID";
                cmbElemanlar.AutoCompleteCustomSource = autoCompleteData;
            }
        }

        private void cmbElemanlar_TextChanged(object sender, EventArgs e)
        {
            if (!isUpdatingComboBox)
            {
                string filter = cmbElemanlar.Text;
                LoadElemanlarIntoComboBox(filter);
                cmbElemanlar.SelectedIndex = -1;
                cmbElemanlar.Text = filter;
                cmbElemanlar.SelectionStart = filter.Length;
                cmbElemanlar.SelectionLength = 0;
            }
        }



        private void LoadIslemler()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM YapilanIslemler";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewIslemler.DataSource = dataTable;
            }
        }


        private void btnIslemArama_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM YapilanIslemler WHERE Aciklama LIKE '%' + @search + '%' OR Notlar LIKE '%' + @search + '%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@search", txtIslemArama.Text);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewIslemler.DataSource = dataTable;
            }
        }

        private void btnIslemEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIslemAracID.Text) ||
                cmbElemanlar.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtIslemAciklama.Text) ||
                string.IsNullOrWhiteSpace(txtIslemMaliyet.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO YapilanIslemler (AracID, ElemanID, IslemTarihi, Aciklama, Maliyet, Notlar) VALUES (@AracID, @ElemanID, @IslemTarihi, @Aciklama, @Maliyet, @Notlar)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AracID", int.Parse(txtIslemAracID.Text));
                    command.Parameters.AddWithValue("@ElemanID", cmbElemanlar.SelectedValue);
                    command.Parameters.AddWithValue("@IslemTarihi", dtpIslemTarihi.Value);
                    command.Parameters.AddWithValue("@Aciklama", txtIslemAciklama.Text);
                    command.Parameters.AddWithValue("@Maliyet", decimal.Parse(txtIslemMaliyet.Text));
                    command.Parameters.AddWithValue("@Notlar", rtbIslemNotlar.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadIslemler();
                    ClearIslemTextBoxes();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen geçerli bir maliyet giriniz.", "Hatalı Veri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIslemGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIslemAracID.Text) ||
                cmbElemanlar.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtIslemAciklama.Text) ||
                string.IsNullOrWhiteSpace(txtIslemMaliyet.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE YapilanIslemler SET AracID = @AracID, ElemanID = @ElemanID, IslemTarihi = @IslemTarihi, Aciklama = @Aciklama, Maliyet = @Maliyet, Notlar = @Notlar WHERE IslemID = @IslemID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AracID", int.Parse(txtIslemAracID.Text));
                    command.Parameters.AddWithValue("@ElemanID", cmbElemanlar.SelectedValue);
                    command.Parameters.AddWithValue("@IslemTarihi", dtpIslemTarihi.Value);
                    command.Parameters.AddWithValue("@Aciklama", txtIslemAciklama.Text);
                    command.Parameters.AddWithValue("@Maliyet", decimal.Parse(txtIslemMaliyet.Text));
                    command.Parameters.AddWithValue("@Notlar", rtbIslemNotlar.Text);
                    command.Parameters.AddWithValue("@IslemID", dataGridViewIslemler.SelectedRows[0].Cells["IslemID"].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadIslemler();
                    ClearIslemTextBoxes();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen geçerli bir maliyet giriniz.", "Hatalı Veri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIslemSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewIslemler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz işlemi seçin.", "İşlem Seçin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM YapilanIslemler WHERE IslemID = @IslemID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IslemID", dataGridViewIslemler.SelectedRows[0].Cells["IslemID"].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadIslemler();
                    ClearIslemTextBoxes();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearIslemTextBoxes()
        {
            txtIslemAracID.Text = "";
            cmbElemanlar.SelectedIndex = -1;
            txtIslemAciklama.Text = "";
            txtIslemMaliyet.Text = "";
            dtpIslemTarihi.Value = DateTime.Now;
            rtbIslemNotlar.Text = "";
        }





        private void işlemlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadIslemControls();
            UpdateFormTitle("İşlemler");

        }










        // Yapılan işlemler
        //------------------------------------------------------------------------------------------------------------------

        // Ürünler 





        private void LoadUrunControls()
        {
            ClearControls();

            // DataGridView for Urunler
            dataGridViewUrunler = new DataGridView
            {
                Dock = DockStyle.Top,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true // Veri değiştirilemesin
            };
            dataGridViewUrunler.SelectionChanged += new System.EventHandler(this.dataGridViewUrunler_SelectionChanged);
            this.splitContainer1.Panel1.Controls.Add(dataGridViewUrunler);

            // DataGridView for UrunAdi
            dataGridViewUrunAdi = new DataGridView
            {
                Dock = DockStyle.Bottom,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true // Veri değiştirilemesin
            };
            dataGridViewUrunAdi.SelectionChanged += new System.EventHandler(this.dataGridViewUrunAdi_SelectionChanged);
            this.splitContainer1.Panel2.Controls.Add(dataGridViewUrunAdi);

            // Diğer butonlar ve kontroller
            btnUrunEkle = new Button
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Ekle"
            };
            btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnUrunEkle);

            btnUrunGuncelle = new Button
            {
                Location = new System.Drawing.Point(90, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Güncelle"
            };
            btnUrunGuncelle.Click += new System.EventHandler(this.btnUrunGuncelle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnUrunGuncelle);

            btnUrunSil = new Button
            {
                Location = new System.Drawing.Point(170, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Sil"
            };
            btnUrunSil.Click += new System.EventHandler(this.btnUrunSil_Click);
            this.splitContainer1.Panel2.Controls.Add(btnUrunSil);

            // TextBoxes and Labels for Urunler
            cmbUrunAdi = new ComboBox { Location = new System.Drawing.Point(89, 36), Size = new System.Drawing.Size(200, 20) };
            cmbUrunAdi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbUrunAdi.AutoCompleteSource = AutoCompleteSource.CustomSource;
            LoadUrunAdiIntoComboBox();
            txtKategori = new TextBox { Location = new System.Drawing.Point(89, 62), Size = new System.Drawing.Size(100, 20) };
            txtAlisFiyat = new TextBox { Location = new System.Drawing.Point(89, 88), Size = new System.Drawing.Size(100, 20) };
            txtSatisFiyat = new TextBox { Location = new System.Drawing.Point(89, 114), Size = new System.Drawing.Size(100, 20) };
            cmbTedarikci = new ComboBox { Location = new System.Drawing.Point(89, 140), Size = new System.Drawing.Size(200, 20) };
            cmbTedarikci.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbTedarikci.AutoCompleteSource = AutoCompleteSource.CustomSource;
            LoadTedarikcilerIntoComboBox();
            dtpUrunTarih = new DateTimePicker { Location = new System.Drawing.Point(89, 166), Size = new System.Drawing.Size(200, 20) };

            Label lblUrunAdi = new Label { Location = new System.Drawing.Point(12, 39), Size = new System.Drawing.Size(50, 13), Text = "Ürün Adı:" };
            Label lblKategori = new Label { Location = new System.Drawing.Point(12, 65), Size = new System.Drawing.Size(50, 13), Text = "Kategori:" };
            Label lblAlisFiyat = new Label { Location = new System.Drawing.Point(12, 91), Size = new System.Drawing.Size(50, 13), Text = "Alış Fiyatı:" };
            Label lblSatisFiyat = new Label { Location = new System.Drawing.Point(12, 117), Size = new System.Drawing.Size(50, 13), Text = "Satış Fiyatı:" };
            Label lblTedarikci = new Label { Location = new System.Drawing.Point(12, 143), Size = new System.Drawing.Size(50, 13), Text = "Tedarikçi:" };
            Label lblTarih = new Label { Location = new System.Drawing.Point(12, 169), Size = new System.Drawing.Size(50, 13), Text = "Tarih:" };

            this.splitContainer1.Panel2.Controls.Add(cmbUrunAdi);
            this.splitContainer1.Panel2.Controls.Add(txtKategori);
            this.splitContainer1.Panel2.Controls.Add(txtAlisFiyat);
            this.splitContainer1.Panel2.Controls.Add(txtSatisFiyat);
            this.splitContainer1.Panel2.Controls.Add(cmbTedarikci);
            this.splitContainer1.Panel2.Controls.Add(dtpUrunTarih);

            this.splitContainer1.Panel2.Controls.Add(lblUrunAdi);
            this.splitContainer1.Panel2.Controls.Add(lblKategori);
            this.splitContainer1.Panel2.Controls.Add(lblAlisFiyat);
            this.splitContainer1.Panel2.Controls.Add(lblSatisFiyat);
            this.splitContainer1.Panel2.Controls.Add(lblTedarikci);
            this.splitContainer1.Panel2.Controls.Add(lblTarih);

            // UrunAdi için butonlar ve kontroller
            btnUrunAdiEkle = new Button
            {
                Location = new System.Drawing.Point(10, 300),
                Size = new System.Drawing.Size(75, 23),
                Text = "Ürün Adı Ekle"
            };
            btnUrunAdiEkle.Click += new System.EventHandler(this.btnUrunAdiEkle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnUrunAdiEkle);

            btnUrunAdiGuncelle = new Button
            {
                Location = new System.Drawing.Point(90, 300),
                Size = new System.Drawing.Size(75, 23),
                Text = "Güncelle"
            };
            btnUrunAdiGuncelle.Click += new System.EventHandler(this.btnUrunAdiGuncelle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnUrunAdiGuncelle);

            btnUrunAdiSil = new Button
            {
                Location = new System.Drawing.Point(170, 300),
                Size = new System.Drawing.Size(75, 23),
                Text = "Sil"
            };
            btnUrunAdiSil.Click += new System.EventHandler(this.btnUrunAdiSil_Click);
            this.splitContainer1.Panel2.Controls.Add(btnUrunAdiSil);

            // TextBoxes and Labels for UrunAdi
            txtYeniUrunAdi = new TextBox { Location = new System.Drawing.Point(260, 300), Size = new System.Drawing.Size(100, 20) };
            txtYeniKategori = new TextBox { Location = new System.Drawing.Point(370, 300), Size = new System.Drawing.Size(100, 20) };

            Label lblYeniUrunAdi = new Label { Location = new System.Drawing.Point(270, 280), Size = new System.Drawing.Size(100, 20), Text = "Yeni Ürün Adı:" };
            Label lblYeniKategori = new Label { Location = new System.Drawing.Point(380, 280), Size = new System.Drawing.Size(100, 20), Text = "Yeni Kategori:" };

            this.splitContainer1.Panel2.Controls.Add(txtYeniUrunAdi);
            this.splitContainer1.Panel2.Controls.Add(txtYeniKategori);

            this.splitContainer1.Panel2.Controls.Add(lblYeniUrunAdi);
            this.splitContainer1.Panel2.Controls.Add(lblYeniKategori);

            // Urun verilerini yükle
            LoadUrunler();

            // UrunAdi verilerini yükle
            LoadUrunAdi();
        }





        private void cmbUrunAdi_TextChanged(object sender, EventArgs e)
        {
            if (!isUpdatingComboBox)
            {
                string filter = cmbUrunAdi.Text;
                LoadUrunAdiIntoComboBox(filter);
                cmbUrunAdi.SelectedIndex = -1;
                cmbUrunAdi.Text = filter;
                cmbUrunAdi.SelectionStart = filter.Length;
                cmbUrunAdi.SelectionLength = 0;
            }
        }





        private void LoadUrunAdiIntoComboBox(string filter = "")
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT UrunAdiID, UrunAdi FROM UrunAdi";
                if (!string.IsNullOrEmpty(filter))
                {
                    query += " WHERE UrunAdi LIKE '%' + @filter + '%'";
                }

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                if (!string.IsNullOrEmpty(filter))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@filter", filter);
                }

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                AutoCompleteStringCollection autoCompleteData = new AutoCompleteStringCollection();
                foreach (DataRow row in dataTable.Rows)
                {
                    autoCompleteData.Add(row["UrunAdi"].ToString());
                }

                cmbUrunAdi.DataSource = dataTable;
                cmbUrunAdi.DisplayMember = "UrunAdi";
                cmbUrunAdi.ValueMember = "UrunAdiID";
                cmbUrunAdi.AutoCompleteCustomSource = autoCompleteData;
            }
        }

        private void cmbTedarikci_TextChanged(object sender, EventArgs e)
        {
            if (!isUpdatingComboBox)
            {
                string filter = cmbTedarikci.Text;
                LoadTedarikcilerIntoComboBox(filter);
                cmbTedarikci.SelectedIndex = -1;
                cmbTedarikci.Text = filter;
                cmbTedarikci.SelectionStart = filter.Length;
                cmbTedarikci.SelectionLength = 0;
            }
        }


        private void LoadTedarikcilerIntoComboBox(string filter = "")
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TedarikciID, TedarikciAdi FROM Tedarikciler";
                if (!string.IsNullOrEmpty(filter))
                {
                    query += " WHERE TedarikciAdi LIKE '%' + @filter + '%'";
                }

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                if (!string.IsNullOrEmpty(filter))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@filter", filter);
                }

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                AutoCompleteStringCollection autoCompleteData = new AutoCompleteStringCollection();
                foreach (DataRow row in dataTable.Rows)
                {
                    autoCompleteData.Add(row["TedarikciAdi"].ToString());
                }

                cmbTedarikci.DataSource = dataTable;
                cmbTedarikci.DisplayMember = "TedarikciAdi";
                cmbTedarikci.ValueMember = "TedarikciID";
                cmbTedarikci.AutoCompleteCustomSource = autoCompleteData;
            }
        }



      

        private void LoadUrunler()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Urunler";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewUrunler.DataSource = dataTable;
            }
        }

        private void dataGridViewUrunler_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUrunler.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewUrunler.SelectedRows[0];
                txtUrunAdi.Text = row.Cells["UrunAdi"].Value.ToString();
                txtKategori.Text = row.Cells["Kategori"].Value.ToString();
                txtAlisFiyat.Text = row.Cells["AlisFiyat"].Value.ToString();
                txtSatisFiyat.Text = row.Cells["SatisFiyat"].Value.ToString();
                cmbTedarikci.SelectedValue = row.Cells["TedarikciID"].Value;
                dtpUrunTarih.Value = DateTime.Parse(row.Cells["Tarih"].Value.ToString());
            }
        }





        private void btnUrunArama_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Urunler WHERE UrunAdi LIKE '%' + @search + '%' OR Kategori LIKE '%' + @search + '%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@search", txtUrunArama.Text);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewUrunler.DataSource = dataTable;
            }
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrunAdi.Text) ||
                string.IsNullOrWhiteSpace(txtKategori.Text) ||
                string.IsNullOrWhiteSpace(txtAlisFiyat.Text) ||
                string.IsNullOrWhiteSpace(txtSatisFiyat.Text) ||
                cmbTedarikci.SelectedValue == null)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal alisFiyat, satisFiyat;
            if (!decimal.TryParse(txtAlisFiyat.Text, out alisFiyat) || !decimal.TryParse(txtSatisFiyat.Text, out satisFiyat))
            {
                MessageBox.Show("Lütfen geçerli bir fiyat giriniz.", "Hatalı Veri", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Urunler (UrunAdi, Kategori, AlisFiyat, SatisFiyat, TedarikciID, Tarih) VALUES (@UrunAdi, @Kategori, @AlisFiyat, @SatisFiyat, @TedarikciID, @Tarih)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UrunAdi", txtUrunAdi.Text);
                    command.Parameters.AddWithValue("@Kategori", txtKategori.Text);
                    command.Parameters.AddWithValue("@AlisFiyat", alisFiyat);
                    command.Parameters.AddWithValue("@SatisFiyat", satisFiyat);
                    command.Parameters.AddWithValue("@TedarikciID", cmbTedarikci.SelectedValue);
                    command.Parameters.AddWithValue("@Tarih", dtpUrunTarih.Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadUrunler();
                    ClearUrunTextBoxes();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearUrunTextBoxes()
        {
            txtUrunAdi.Text = "";
            txtKategori.Text = "";
            txtAlisFiyat.Text = "";
            txtSatisFiyat.Text = "";
            cmbTedarikci.SelectedIndex = -1;
            dtpUrunTarih.Value = DateTime.Now;
        }






        private void btnUrunGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridViewUrunler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz ürünü seçin.", "Ürün Seçin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUrunAdi.Text) ||
                string.IsNullOrWhiteSpace(txtKategori.Text) ||
                string.IsNullOrWhiteSpace(txtAlisFiyat.Text) ||
                string.IsNullOrWhiteSpace(txtSatisFiyat.Text) ||
                cmbTedarikci.SelectedValue == null)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal alisFiyat, satisFiyat;
            if (!decimal.TryParse(txtAlisFiyat.Text, out alisFiyat) || !decimal.TryParse(txtSatisFiyat.Text, out satisFiyat))
            {
                MessageBox.Show("Lütfen geçerli bir fiyat giriniz.", "Hatalı Veri", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Urunler SET UrunAdi = @UrunAdi, Kategori = @Kategori, AlisFiyat = @AlisFiyat, SatisFiyat = @SatisFiyat, TedarikciID = @TedarikciID, Tarih = @Tarih WHERE UrunID = @UrunID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UrunAdi", txtUrunAdi.Text);
                    command.Parameters.AddWithValue("@Kategori", txtKategori.Text);
                    command.Parameters.AddWithValue("@AlisFiyat", alisFiyat);
                    command.Parameters.AddWithValue("@SatisFiyat", satisFiyat);
                    command.Parameters.AddWithValue("@TedarikciID", cmbTedarikci.SelectedValue);
                    command.Parameters.AddWithValue("@Tarih", dtpUrunTarih.Value);
                    command.Parameters.AddWithValue("@UrunID", dataGridViewUrunler.SelectedRows[0].Cells["UrunID"].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadUrunler();
                    ClearUrunTextBoxes();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewUrunler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünü seçin.", "Ürün Seçin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Urunler WHERE UrunID = @UrunID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UrunID", dataGridViewUrunler.SelectedRows[0].Cells["UrunID"].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadUrunler();
                    ClearUrunTextBoxes();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUrunControls();
            UpdateFormTitle("Ürünler");

        }


        private void LoadUrunAdi()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM UrunAdi";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewUrunAdi.DataSource = dataTable;
            }
        }
        private void btnUrunAdiEkle_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO UrunAdi (UrunAdi, Kategori) VALUES (@UrunAdi, @Kategori)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UrunAdi", txtYeniUrunAdi.Text);
                    command.Parameters.AddWithValue("@Kategori", txtYeniKategori.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadUrunAdi();
                    ClearUrunAdiTextBoxes();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUrunAdiGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE UrunAdi SET UrunAdi = @UrunAdi, Kategori = @Kategori WHERE UrunAdiID = @UrunAdiID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UrunAdi", txtYeniUrunAdi.Text);
                    command.Parameters.AddWithValue("@Kategori", txtYeniKategori.Text);
                    command.Parameters.AddWithValue("@UrunAdiID", dataGridViewUrunAdi.SelectedRows[0].Cells["UrunAdiID"].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadUrunAdi();
                    ClearUrunAdiTextBoxes();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUrunAdiSil_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM UrunAdi WHERE UrunAdiID = @UrunAdiID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UrunAdiID", dataGridViewUrunAdi.SelectedRows[0].Cells["UrunAdiID"].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadUrunAdi();
                    ClearUrunAdiTextBoxes();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearUrunAdiTextBoxes()
        {
            txtYeniUrunAdi.Text = "";
            txtYeniKategori.Text = "";
        }

      
        private void dataGridViewUrunAdi_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUrunAdi.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewUrunAdi.SelectedRows[0];
                txtYeniUrunAdi.Text = row.Cells["UrunAdi"].Value.ToString();
                txtYeniKategori.Text = row.Cells["Kategori"].Value.ToString();
            }
        }

      








        //Ürünler
        //-------------------------------------------------------------------------------------------------------------------

        //Stok

        private void LoadStokControls()
        {
            ClearControls();

            // DataGridView
            dataGridViewStok = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true // Veri değiştirilemesin
            };
            dataGridViewStok.SelectionChanged += new System.EventHandler(this.dataGridViewStok_SelectionChanged);
            this.splitContainer1.Panel1.Controls.Add(dataGridViewStok);

            // Arama TextBox
            txtStokArama = new TextBox
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(200, 20)
            };
            this.splitContainer1.Panel2.Controls.Add(txtStokArama);

            // Arama Button
            btnStokArama = new Button
            {
                Location = new System.Drawing.Point(220, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Ara"
            };
            btnStokArama.Click += new System.EventHandler(this.btnStokArama_Click);
            this.splitContainer1.Panel2.Controls.Add(btnStokArama);

            // Diğer butonlar ve kontroller
            btnStokEkle = new Button
            {
                Location = new System.Drawing.Point(713, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Ekle"
            };
            btnStokEkle.Click += new System.EventHandler(this.btnStokEkle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnStokEkle);

            btnStokGuncelle = new Button
            {
                Location = new System.Drawing.Point(713, 39),
                Size = new System.Drawing.Size(75, 23),
                Text = "Güncelle"
            };
            btnStokGuncelle.Click += new System.EventHandler(this.btnStokGuncelle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnStokGuncelle);

            btnStokSil = new Button
            {
                Location = new System.Drawing.Point(713, 68),
                Size = new System.Drawing.Size(75, 23),
                Text = "Sil"
            };
            btnStokSil.Click += new System.EventHandler(this.btnStokSil_Click);
            this.splitContainer1.Panel2.Controls.Add(btnStokSil);

            // TextBoxes and Labels
            txtStokUrunID = new TextBox { Location = new System.Drawing.Point(89, 36), Size = new System.Drawing.Size(100, 20) };
            txtStokMiktar = new TextBox { Location = new System.Drawing.Point(89, 62), Size = new System.Drawing.Size(100, 20) };

            Label lblUrunID = new Label { Location = new System.Drawing.Point(12, 39), Size = new System.Drawing.Size(50, 13), Text = "Ürün ID:" };
            Label lblMiktar = new Label { Location = new System.Drawing.Point(12, 65), Size = new System.Drawing.Size(40, 13), Text = "Miktar:" };

            this.splitContainer1.Panel2.Controls.Add(txtStokUrunID);
            this.splitContainer1.Panel2.Controls.Add(txtStokMiktar);
            this.splitContainer1.Panel2.Controls.Add(lblUrunID);
            this.splitContainer1.Panel2.Controls.Add(lblMiktar);

            // Stok verilerini yükle
            LoadStok();
        }

        private void LoadStok()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Stok";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewStok.DataSource = dataTable;
            }
        }

        private void btnStokArama_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Stok WHERE UrunID LIKE '%' + @search + '%' OR Miktar LIKE '%' + @search + '%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@search", txtStokArama.Text);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewStok.DataSource = dataTable;
            }
        }

        private void btnStokEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStokUrunID.Text) ||
                string.IsNullOrWhiteSpace(txtStokMiktar.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Stok (UrunID, Miktar) VALUES (@UrunID, @Miktar)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UrunID", int.Parse(txtStokUrunID.Text));
                    command.Parameters.AddWithValue("@Miktar", int.Parse(txtStokMiktar.Text));
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadStok();
                    ClearStokTextBoxes();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen geçerli bir miktar giriniz.", "Hatalı Veri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStokGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStokUrunID.Text) ||
                string.IsNullOrWhiteSpace(txtStokMiktar.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Stok SET UrunID = @UrunID, Miktar = @Miktar WHERE StokID = @StokID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UrunID", int.Parse(txtStokUrunID.Text));
                    command.Parameters.AddWithValue("@Miktar", int.Parse(txtStokMiktar.Text));
                    command.Parameters.AddWithValue("@StokID", dataGridViewStok.SelectedRows[0].Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadStok();
                    ClearStokTextBoxes();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen geçerli bir miktar giriniz.", "Hatalı Veri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStokSil_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Stok WHERE StokID = @StokID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@StokID", dataGridViewStok.SelectedRows[0].Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadStok();
                    ClearStokTextBoxes();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearStokTextBoxes()
        {
            txtStokUrunID.Text = "";
            txtStokMiktar.Text = "";
        }

        private void dataGridViewStok_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewStok.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewStok.SelectedRows[0];
                txtStokUrunID.Text = row.Cells["UrunID"].Value.ToString();
                txtStokMiktar.Text = row.Cells["Miktar"].Value.ToString();
            }
        }

        private void stokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadStokControls();
            UpdateFormTitle("Stok");

        }




        //Stok
        //-------------------------------------------------------------------------------------------------------------------

        // Borçlar

        private void LoadBorcControls()
        {
            ClearControls();

            // DataGridView
            dataGridViewBorclar = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true // Veri değiştirilemesin
            };
            dataGridViewBorclar.SelectionChanged += new System.EventHandler(this.dataGridViewBorclar_SelectionChanged);
            this.splitContainer1.Panel1.Controls.Add(dataGridViewBorclar);

            // Arama TextBox
            txtBorcArama = new TextBox
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(200, 20)
            };
            this.splitContainer1.Panel2.Controls.Add(txtBorcArama);

            // Arama Button
            btnBorcArama = new Button
            {
                Location = new System.Drawing.Point(220, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Ara"
            };
            btnBorcArama.Click += new System.EventHandler(this.btnBorcArama_Click);
            this.splitContainer1.Panel2.Controls.Add(btnBorcArama);

            // Diğer butonlar ve kontroller
            btnBorcEkle = new Button
            {
                Location = new System.Drawing.Point(713, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Ekle"
            };
            btnBorcEkle.Click += new System.EventHandler(this.btnBorcEkle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnBorcEkle);

            btnBorcGuncelle = new Button
            {
                Location = new System.Drawing.Point(713, 39),
                Size = new System.Drawing.Size(75, 23),
                Text = "Güncelle"
            };
            btnBorcGuncelle.Click += new System.EventHandler(this.btnBorcGuncelle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnBorcGuncelle);

            btnBorcSil = new Button
            {
                Location = new System.Drawing.Point(713, 68),
                Size = new System.Drawing.Size(75, 23),
                Text = "Sil"
            };
            btnBorcSil.Click += new System.EventHandler(this.btnBorcSil_Click);
            this.splitContainer1.Panel2.Controls.Add(btnBorcSil);

            // TextBoxes and Labels
            txtBorcMusteriID = new TextBox { Location = new System.Drawing.Point(89, 36), Size = new System.Drawing.Size(100, 20) };
            txtBorcTutar = new TextBox { Location = new System.Drawing.Point(89, 62), Size = new System.Drawing.Size(100, 20) };
            dtpBorcVadeTarihi = new DateTimePicker { Location = new System.Drawing.Point(89, 88), Size = new System.Drawing.Size(200, 20) };
            chkBorcOdenmeDurumu = new CheckBox { Location = new System.Drawing.Point(89, 114), Text = "Ödenme Durumu" };
            dtpBorcTarih = new DateTimePicker { Location = new System.Drawing.Point(89, 140), Size = new System.Drawing.Size(200, 20) };

            Label lblMusteriID = new Label { Location = new System.Drawing.Point(12, 39), Size = new System.Drawing.Size(57, 13), Text = "Müşteri ID:" };
            Label lblTutar = new Label { Location = new System.Drawing.Point(12, 65), Size = new System.Drawing.Size(34, 13), Text = "Tutar:" };
            Label lblVadeTarihi = new Label { Location = new System.Drawing.Point(12, 91), Size = new System.Drawing.Size(64, 13), Text = "Vade Tarihi:" };
            Label lblTarih = new Label { Location = new System.Drawing.Point(12, 143), Size = new System.Drawing.Size(35, 13), Text = "Tarih:" };

            this.splitContainer1.Panel2.Controls.Add(txtBorcMusteriID);
            this.splitContainer1.Panel2.Controls.Add(txtBorcTutar);
            this.splitContainer1.Panel2.Controls.Add(dtpBorcVadeTarihi);
            this.splitContainer1.Panel2.Controls.Add(chkBorcOdenmeDurumu);
            this.splitContainer1.Panel2.Controls.Add(dtpBorcTarih);

            this.splitContainer1.Panel2.Controls.Add(lblMusteriID);
            this.splitContainer1.Panel2.Controls.Add(lblTutar);
            this.splitContainer1.Panel2.Controls.Add(lblVadeTarihi);
            this.splitContainer1.Panel2.Controls.Add(lblTarih);

            // Borç verilerini yükle
            LoadBorclar();
        }

        private void LoadBorclar()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Borclar";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewBorclar.DataSource = dataTable;
            }
        }

        private void btnBorcArama_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Borclar WHERE MusteriID LIKE '%' + @search + '%' OR Tutar LIKE '%' + @search + '%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@search", txtBorcArama.Text);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewBorclar.DataSource = dataTable;
            }
        }

        private void btnBorcEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBorcMusteriID.Text) ||
                string.IsNullOrWhiteSpace(txtBorcTutar.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Borclar (MusteriID, Tutar, VadeTarihi, OdenmeDurumu, Tarih) VALUES (@MusteriID, @Tutar, @VadeTarihi, @OdenmeDurumu, @Tarih)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MusteriID", int.Parse(txtBorcMusteriID.Text));
                    command.Parameters.AddWithValue("@Tutar", decimal.Parse(txtBorcTutar.Text));
                    command.Parameters.AddWithValue("@VadeTarihi", dtpBorcVadeTarihi.Value);
                    command.Parameters.AddWithValue("@OdenmeDurumu", chkBorcOdenmeDurumu.Checked);
                    command.Parameters.AddWithValue("@Tarih", dtpBorcTarih.Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadBorclar();
                    ClearBorcTextBoxes();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen geçerli bir tutar giriniz.", "Hatalı Veri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorcGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBorcMusteriID.Text) ||
                string.IsNullOrWhiteSpace(txtBorcTutar.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Borclar SET MusteriID = @MusteriID, Tutar = @Tutar, VadeTarihi = @VadeTarihi, OdenmeDurumu = @OdenmeDurumu, Tarih = @Tarih WHERE BorcID = @BorcID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MusteriID", int.Parse(txtBorcMusteriID.Text));
                    command.Parameters.AddWithValue("@Tutar", decimal.Parse(txtBorcTutar.Text));
                    command.Parameters.AddWithValue("@VadeTarihi", dtpBorcVadeTarihi.Value);
                    command.Parameters.AddWithValue("@OdenmeDurumu", chkBorcOdenmeDurumu.Checked);
                    command.Parameters.AddWithValue("@Tarih", dtpBorcTarih.Value);
                    command.Parameters.AddWithValue("@BorcID", dataGridViewBorclar.SelectedRows[0].Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadBorclar();
                    ClearBorcTextBoxes();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen geçerli bir tutar giriniz.", "Hatalı Veri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorcSil_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Borclar WHERE BorcID = @BorcID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BorcID", dataGridViewBorclar.SelectedRows[0].Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadBorclar();
                    ClearBorcTextBoxes();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearBorcTextBoxes()
        {
            txtBorcMusteriID.Text = "";
            txtBorcTutar.Text = "";
            dtpBorcVadeTarihi.Value = DateTime.Now;
            chkBorcOdenmeDurumu.Checked = false;
            dtpBorcTarih.Value = DateTime.Now;
        }

        private void dataGridViewBorclar_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewBorclar.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewBorclar.SelectedRows[0];
                txtBorcMusteriID.Text = row.Cells["MusteriID"].Value.ToString();
                txtBorcTutar.Text = row.Cells["Tutar"].Value.ToString();
                dtpBorcVadeTarihi.Value = DateTime.Parse(row.Cells["VadeTarihi"].Value.ToString());
                chkBorcOdenmeDurumu.Checked = (bool)row.Cells["OdenmeDurumu"].Value;
                dtpBorcTarih.Value = DateTime.Parse(row.Cells["Tarih"].Value.ToString());
            }
        }

        private void borçlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadBorcControls();
            UpdateFormTitle("Borçlar");

        }



        //Borçlar

        //-------------------------------------------------------------------------------------------------------------------

        //Alacak

        private void LoadAlacakControls()
        {
            ClearControls();

            // DataGridView
            dataGridViewAlacaklar = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true // Veri değiştirilemesin
            };
            dataGridViewAlacaklar.SelectionChanged += new System.EventHandler(this.dataGridViewAlacaklar_SelectionChanged);
            this.splitContainer1.Panel1.Controls.Add(dataGridViewAlacaklar);

            // Arama TextBox
            txtAlacakArama = new TextBox
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(200, 20)
            };
            this.splitContainer1.Panel2.Controls.Add(txtAlacakArama);

            // Arama Button
            btnAlacakArama = new Button
            {
                Location = new System.Drawing.Point(220, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Ara"
            };
            btnAlacakArama.Click += new System.EventHandler(this.btnAlacakArama_Click);
            this.splitContainer1.Panel2.Controls.Add(btnAlacakArama);

            // Diğer butonlar ve kontroller
            btnAlacakEkle = new Button
            {
                Location = new System.Drawing.Point(713, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Ekle"
            };
            btnAlacakEkle.Click += new System.EventHandler(this.btnAlacakEkle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnAlacakEkle);

            btnAlacakGuncelle = new Button
            {
                Location = new System.Drawing.Point(713, 39),
                Size = new System.Drawing.Size(75, 23),
                Text = "Güncelle"
            };
            btnAlacakGuncelle.Click += new System.EventHandler(this.btnAlacakGuncelle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnAlacakGuncelle);

            btnAlacakSil = new Button
            {
                Location = new System.Drawing.Point(713, 68),
                Size = new System.Drawing.Size(75, 23),
                Text = "Sil"
            };
            btnAlacakSil.Click += new System.EventHandler(this.btnAlacakSil_Click);
            this.splitContainer1.Panel2.Controls.Add(btnAlacakSil);

            // TextBoxes and Labels
            txtAlacakMusteriID = new TextBox { Location = new System.Drawing.Point(89, 36), Size = new System.Drawing.Size(100, 20) };
            txtAlacakTutar = new TextBox { Location = new System.Drawing.Point(89, 62), Size = new System.Drawing.Size(100, 20) };
            dtpAlacakVadeTarihi = new DateTimePicker { Location = new System.Drawing.Point(89, 88), Size = new System.Drawing.Size(200, 20) };
            chkAlacakTahsilatDurumu = new CheckBox { Location = new System.Drawing.Point(89, 114), Text = "Tahsilat Durumu" };
            dtpAlacakTarih = new DateTimePicker { Location = new System.Drawing.Point(89, 140), Size = new System.Drawing.Size(200, 20) };

            Label lblMusteriID = new Label { Location = new System.Drawing.Point(12, 39), Size = new System.Drawing.Size(57, 13), Text = "Müşteri ID:" };
            Label lblTutar = new Label { Location = new System.Drawing.Point(12, 65), Size = new System.Drawing.Size(34, 13), Text = "Tutar:" };
            Label lblVadeTarihi = new Label { Location = new System.Drawing.Point(12, 91), Size = new System.Drawing.Size(64, 13), Text = "Vade Tarihi:" };
            Label lblTarih = new Label { Location = new System.Drawing.Point(12, 143), Size = new System.Drawing.Size(35, 13), Text = "Tarih:" };

            this.splitContainer1.Panel2.Controls.Add(txtAlacakMusteriID);
            this.splitContainer1.Panel2.Controls.Add(txtAlacakTutar);
            this.splitContainer1.Panel2.Controls.Add(dtpAlacakVadeTarihi);
            this.splitContainer1.Panel2.Controls.Add(chkAlacakTahsilatDurumu);
            this.splitContainer1.Panel2.Controls.Add(dtpAlacakTarih);

            this.splitContainer1.Panel2.Controls.Add(lblMusteriID);
            this.splitContainer1.Panel2.Controls.Add(lblTutar);
            this.splitContainer1.Panel2.Controls.Add(lblVadeTarihi);
            this.splitContainer1.Panel2.Controls.Add(lblTarih);

            // Alacak verilerini yükle
            LoadAlacaklar();
        }

        private void LoadAlacaklar()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Alacaklar";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewAlacaklar.DataSource = dataTable;
            }
        }

        private void btnAlacakArama_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Alacaklar WHERE MusteriID LIKE '%' + @search + '%' OR Tutar LIKE '%' + @search + '%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@search", txtAlacakArama.Text);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewAlacaklar.DataSource = dataTable;
            }
        }

        private void btnAlacakEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAlacakMusteriID.Text) ||
                string.IsNullOrWhiteSpace(txtAlacakTutar.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Alacaklar (MusteriID, Tutar, VadeTarihi, TahsilatDurumu, Tarih) VALUES (@MusteriID, @Tutar, @VadeTarihi, @TahsilatDurumu, @Tarih)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MusteriID", int.Parse(txtAlacakMusteriID.Text));
                    command.Parameters.AddWithValue("@Tutar", decimal.Parse(txtAlacakTutar.Text));
                    command.Parameters.AddWithValue("@VadeTarihi", dtpAlacakVadeTarihi.Value);
                    command.Parameters.AddWithValue("@TahsilatDurumu", chkAlacakTahsilatDurumu.Checked);
                    command.Parameters.AddWithValue("@Tarih", dtpAlacakTarih.Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadAlacaklar();
                    ClearAlacakTextBoxes();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen geçerli bir tutar giriniz.", "Hatalı Veri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlacakGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAlacakMusteriID.Text) ||
                string.IsNullOrWhiteSpace(txtAlacakTutar.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Alacaklar SET MusteriID = @MusteriID, Tutar = @Tutar, VadeTarihi = @VadeTarihi, TahsilatDurumu = @TahsilatDurumu, Tarih = @Tarih WHERE AlacakID = @AlacakID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MusteriID", int.Parse(txtAlacakMusteriID.Text));
                    command.Parameters.AddWithValue("@Tutar", decimal.Parse(txtAlacakTutar.Text));
                    command.Parameters.AddWithValue("@VadeTarihi", dtpAlacakVadeTarihi.Value);
                    command.Parameters.AddWithValue("@TahsilatDurumu", chkAlacakTahsilatDurumu.Checked);
                    command.Parameters.AddWithValue("@Tarih", dtpAlacakTarih.Value);
                    command.Parameters.AddWithValue("@AlacakID", dataGridViewAlacaklar.SelectedRows[0].Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadAlacaklar();
                    ClearAlacakTextBoxes();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen geçerli bir tutar giriniz.", "Hatalı Veri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAlacakSil_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Alacaklar WHERE AlacakID = @AlacakID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AlacakID", dataGridViewAlacaklar.SelectedRows[0].Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadAlacaklar();
                    ClearAlacakTextBoxes();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearAlacakTextBoxes()
        {
            txtAlacakMusteriID.Text = "";
            txtAlacakTutar.Text = "";
            dtpAlacakVadeTarihi.Value = DateTime.Now;
            chkAlacakTahsilatDurumu.Checked = false;
            dtpAlacakTarih.Value = DateTime.Now;
        }

        private void dataGridViewAlacaklar_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewAlacaklar.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewAlacaklar.SelectedRows[0];
                txtAlacakMusteriID.Text = row.Cells["MusteriID"].Value.ToString();
                txtAlacakTutar.Text = row.Cells["Tutar"].Value.ToString();
                dtpAlacakVadeTarihi.Value = DateTime.Parse(row.Cells["VadeTarihi"].Value.ToString());
                chkAlacakTahsilatDurumu.Checked = (bool)row.Cells["TahsilatDurumu"].Value;
                dtpAlacakTarih.Value = DateTime.Parse(row.Cells["Tarih"].Value.ToString());
            }
        }
     
        private void alacaklarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadAlacakControls();
            UpdateFormTitle("Alacaklar");

        }


        //Alacak

        //-------------------------------------------------------------------------------------------------------------------

        //gelir-Gider

        private void LoadGelirGiderControls()
        {
            ClearControls();

            // DataGridView
            dataGridViewGelirGider = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true // Veri değiştirilemesin
            };
            dataGridViewGelirGider.SelectionChanged += new System.EventHandler(this.dataGridViewGelirGider_SelectionChanged);
            this.splitContainer1.Panel1.Controls.Add(dataGridViewGelirGider);

            // Arama TextBox
            txtGelirGiderArama = new TextBox
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(200, 20)
            };
            this.splitContainer1.Panel2.Controls.Add(txtGelirGiderArama);

            // Arama Button
            btnGelirGiderArama = new Button
            {
                Location = new System.Drawing.Point(220, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Ara"
            };
            btnGelirGiderArama.Click += new System.EventHandler(this.btnGelirGiderArama_Click);
            this.splitContainer1.Panel2.Controls.Add(btnGelirGiderArama);

            // Diğer butonlar ve kontroller
            btnGelirGiderEkle = new Button
            {
                Location = new System.Drawing.Point(713, 10),
                Size = new System.Drawing.Size(75, 23),
                Text = "Ekle"
            };
            btnGelirGiderEkle.Click += new System.EventHandler(this.btnGelirGiderEkle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnGelirGiderEkle);

            btnGelirGiderGuncelle = new Button
            {
                Location = new System.Drawing.Point(713, 39),
                Size = new System.Drawing.Size(75, 23),
                Text = "Güncelle"
            };
            btnGelirGiderGuncelle.Click += new System.EventHandler(this.btnGelirGiderGuncelle_Click);
            this.splitContainer1.Panel2.Controls.Add(btnGelirGiderGuncelle);

            btnGelirGiderSil = new Button
            {
                Location = new System.Drawing.Point(713, 68),
                Size = new System.Drawing.Size(75, 23),
                Text = "Sil"
            };
            btnGelirGiderSil.Click += new System.EventHandler(this.btnGelirGiderSil_Click);
            this.splitContainer1.Panel2.Controls.Add(btnGelirGiderSil);

            // TextBoxes and Labels
            txtGelirGiderTur = new TextBox { Location = new System.Drawing.Point(89, 36), Size = new System.Drawing.Size(100, 20) };
            txtGelirGiderTutar = new TextBox { Location = new System.Drawing.Point(89, 62), Size = new System.Drawing.Size(100, 20) };
            dtpGelirGiderTarih = new DateTimePicker { Location = new System.Drawing.Point(89, 88), Size = new System.Drawing.Size(200, 20) };
            txtGelirGiderAciklama = new TextBox { Location = new System.Drawing.Point(89, 114), Size = new System.Drawing.Size(200, 20) };

            Label lblTur = new Label { Location = new System.Drawing.Point(12, 39), Size = new System.Drawing.Size(23, 13), Text = "Tür:" };
            Label lblTutar = new Label { Location = new System.Drawing.Point(12, 65), Size = new System.Drawing.Size(34, 13), Text = "Tutar:" };
            Label lblTarih = new Label { Location = new System.Drawing.Point(12, 91), Size = new System.Drawing.Size(35, 13), Text = "Tarih:" };
            Label lblAciklama = new Label { Location = new System.Drawing.Point(12, 117), Size = new System.Drawing.Size(56, 13), Text = "Açıklama:" };

            this.splitContainer1.Panel2.Controls.Add(txtGelirGiderTur);
            this.splitContainer1.Panel2.Controls.Add(txtGelirGiderTutar);
            this.splitContainer1.Panel2.Controls.Add(dtpGelirGiderTarih);
            this.splitContainer1.Panel2.Controls.Add(txtGelirGiderAciklama);

            this.splitContainer1.Panel2.Controls.Add(lblTur);
            this.splitContainer1.Panel2.Controls.Add(lblTutar);
            this.splitContainer1.Panel2.Controls.Add(lblTarih);
            this.splitContainer1.Panel2.Controls.Add(lblAciklama);

            // Gelir/Gider verilerini yükle
            LoadGelirGider();
        }

        private void LoadGelirGider()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM GelirGider";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewGelirGider.DataSource = dataTable;
            }
        }

        private void btnGelirGiderArama_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM GelirGider WHERE Tur LIKE '%' + @search + '%' OR Aciklama LIKE '%' + @search + '%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@search", txtGelirGiderArama.Text);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewGelirGider.DataSource = dataTable;
            }
        }

        private void btnGelirGiderEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGelirGiderTur.Text) ||
                string.IsNullOrWhiteSpace(txtGelirGiderTutar.Text) ||
                string.IsNullOrWhiteSpace(txtGelirGiderAciklama.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO GelirGider (Tur, Tutar, Tarih, Aciklama) VALUES (@Tur, @Tutar, @Tarih, @Aciklama)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Tur", txtGelirGiderTur.Text);
                    command.Parameters.AddWithValue("@Tutar", decimal.Parse(txtGelirGiderTutar.Text));
                    command.Parameters.AddWithValue("@Tarih", dtpGelirGiderTarih.Value);
                    command.Parameters.AddWithValue("@Aciklama", txtGelirGiderAciklama.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadGelirGider();
                    ClearGelirGiderTextBoxes();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen geçerli bir tutar giriniz.", "Hatalı Veri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGelirGiderGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGelirGiderTur.Text) ||
                string.IsNullOrWhiteSpace(txtGelirGiderTutar.Text) ||
                string.IsNullOrWhiteSpace(txtGelirGiderAciklama.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE GelirGider SET Tur = @Tur, Tutar = @Tutar, Tarih = @Tarih, Aciklama = @Aciklama WHERE GelirGiderID = @GelirGiderID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Tur", txtGelirGiderTur.Text);
                    command.Parameters.AddWithValue("@Tutar", decimal.Parse(txtGelirGiderTutar.Text));
                    command.Parameters.AddWithValue("@Tarih", dtpGelirGiderTarih.Value);
                    command.Parameters.AddWithValue("@Aciklama", txtGelirGiderAciklama.Text);
                    command.Parameters.AddWithValue("@GelirGiderID", dataGridViewGelirGider.SelectedRows[0].Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadGelirGider();
                    ClearGelirGiderTextBoxes();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen geçerli bir tutar giriniz.", "Hatalı Veri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGelirGiderSil_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM GelirGider WHERE GelirGiderID = @GelirGiderID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GelirGiderID", dataGridViewGelirGider.SelectedRows[0].Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadGelirGider();
                    ClearGelirGiderTextBoxes();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearGelirGiderTextBoxes()
        {
            txtGelirGiderTur.Text = "";
            txtGelirGiderTutar.Text = "";
            dtpGelirGiderTarih.Value = DateTime.Now;
            txtGelirGiderAciklama.Text = "";
        }

        private void dataGridViewGelirGider_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewGelirGider.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewGelirGider.SelectedRows[0];
                txtGelirGiderTur.Text = row.Cells["Tur"].Value.ToString();
                txtGelirGiderTutar.Text = row.Cells["Tutar"].Value.ToString();
                dtpGelirGiderTarih.Value = DateTime.Parse(row.Cells["Tarih"].Value.ToString());
                txtGelirGiderAciklama.Text = row.Cells["Aciklama"].Value.ToString();
            }
        }

        private void gelirGiderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGelirGiderControls();
            UpdateFormTitle("Gelir/Gider");

        }



        //gelir-Gider
        //-------------------------------------------------------------------------------------------------------------------


        private void MainForm_Load(object sender, EventArgs e)
        {
            // Formun tam ekran açılması için
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
