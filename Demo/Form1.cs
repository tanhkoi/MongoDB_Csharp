using System;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Driver;

namespace Demo
{
    public partial class Form1 : Form
    {
        private IMongoCollection<SinhVien> collection;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("mydb");
            collection = database.GetCollection<SinhVien>("mycollection");

            loadData();
        }

        public void loadData()
        {
            var filter = Builders<SinhVien>.Filter.Empty;
            var sinhVienList = collection.Find(filter).ToList();

            dgvSinhVienList.DataSource = sinhVienList;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            var sinhVien = new SinhVien
            {
                hoTen = txtHoTen.Text,
                MSSV = Int32.Parse(txtMSSV.Text),
                noiSong = txtNoiSong.Text
            };

            collection.InsertOne(sinhVien);
            loadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var filter = Builders<SinhVien>.Filter.Eq(a => a.MSSV, Int32.Parse(txtMSSV.Text));
            var update = Builders<SinhVien>.Update.Set(a => a.hoTen, txtHoTen.Text).Set(a => a.noiSong, txtNoiSong.Text);

            collection.UpdateOne(filter, update);
            loadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var filter = Builders<SinhVien>.Filter.Eq(a => a.MSSV, Int32.Parse(txtMSSV.Text));
            collection.DeleteOne(filter);

            loadData();
        }

    }
}
