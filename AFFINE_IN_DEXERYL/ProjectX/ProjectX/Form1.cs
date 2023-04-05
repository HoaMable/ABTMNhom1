using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region Bat dau he ma affine
        //Bắt sự kiện cho tab AFFINE      
        private void Affine_btnBrowerBanro_Click(object sender, EventArgs e) //Button Chọn file bản rõ
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader file = new StreamReader(open.FileName);
                Affine_txtBanro.Text = file.ReadToEnd();
                file.Close();
            }
        }

        private void Affine_btnSaveBanro_Click(object sender, EventArgs e) //Button Lưu file bản rõ
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(save.FileName);
                file.Write(Affine_txtBanro.Text);
                file.Close();
            }
        }

        private void Affine_btnBrowerBanma_Click(object sender, EventArgs e)//Button chọn file bản mã
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader file = new StreamReader(open.FileName);
                Affine_txtBanma.Text = file.ReadToEnd();
                file.Close();
            }
        }

        private void Affine_btnSaveBanma_Click(object sender, EventArgs e)//Button lưu file bản mã
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(save.FileName);
                file.Write(Affine_txtBanma.Text);
                file.Close();
            }
        }

        private void Affine_btnClear_Click(object sender, EventArgs e)//Button Clear affine
        {
            Affine_txtBanma.Text = " ";
            Affine_txtBanro.Text = " ";
            Affine_txtKhoaAbanma.Text = " ";
            Affine_txtKhoaAbanro.Text = " ";
            Affine_txtKhoaBbanma.Text = " ";
            Affine_txtKhoaBbanro.Text = " ";
        }

        private void Affine_btnMahoa_Click(object sender, EventArgs e)//Button mã hóa Affine
        {
            try
            {
                int keya = Convert.ToInt32(Affine_txtKhoaAbanro.Text);
                int keyb = Convert.ToInt32(Affine_txtKhoaBbanro.Text);
                if (keya >= 224 || keyb >= 224 || keya < 0 || keyb < 0 )
                {
                    MessageBox.Show("Giá trị khóa không được vượt quá không gian Z(224)", "Error =.=!");
                    Affine_txtBanro.Text = "";
                    Affine_txtKhoaAbanro.Text = "";
                    Affine_txtKhoaBbanro.Text = "";
                }

                int usc = Affine.USCLN(keya, Affine.P.Length);
                if (usc != 1)
                {
                    MessageBox.Show("Hệ số a= " + keya + " không phù hợp.\nNhập khóa a sao cho USCLN(a,224)=1", "Error =.=!");
                    Affine_txtBanro.Text = "";
                    Affine_txtKhoaAbanro.Text = "";
                    Affine_txtKhoaBbanro.Text = "";
                }
                
                Affine_txtBanma.Text = Affine.Mahoa(Affine_txtBanro.Text, keya, keyb);
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại khóa(Nhập số nguyên)!", "Error =.=! "); 
                Affine_txtBanro.Text = "";
                Affine_txtKhoaAbanro.Text = "";
                Affine_txtKhoaBbanro.Text = "";
            }                                       
        }

        private void Affine_btnGiaima_Click(object sender, EventArgs e)//Button giải mã Affine
        {
            try
            {
                int keya = Convert.ToInt32(Affine_txtKhoaAbanma.Text);
                int keyb = Convert.ToInt32(Affine_txtKhoaBbanma.Text);
                if (keya >= 224 || keyb >= 224 || keya < 0 || keyb < 0)
                {
                    MessageBox.Show("Giá trị khóa không được vượt quá không gian Z(224)", "Error =.=!");
                    Affine_txtBanma.Text = "";
                    Affine_txtKhoaAbanma.Text = "";
                    Affine_txtKhoaBbanma.Text = "";
                }

                int usc = Affine.USCLN(keya, Affine.P.Length);
                if (usc != 1)
                {
                    MessageBox.Show("Hệ số a= " + keya + " không phù hợp.\nNhập khóa a sao cho USCLN(a,224)=1", "Error =.=!");
                    Affine_txtBanma.Text = "";
                    Affine_txtKhoaAbanma.Text = "";
                    Affine_txtKhoaBbanma.Text = "";
                }

                Affine_txtBanro.Text = Affine.Giaima(Affine_txtBanma.Text, keya, keyb);
            }

            catch (Exception)
            {
                MessageBox.Show("Nhập lại khóa(Nhập số nguyên)!", "Error =.=! ");
                Affine_txtBanro.Text = "";
                Affine_txtKhoaAbanro.Text = "";
                Affine_txtKhoaBbanro.Text = "";
            }
        }
        #endregion
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
