using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using MySql.Data.MySqlClient;

namespace ContactPro.forms
{
    public partial class FormDistricts : Office2007Form
    {
        Conn conn = new Conn();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter da = null;
        MySqlCommandBuilder scb = null;
        DataSet ds = null;
        public static DataTable dt;
        public static string FRMENTMODE = "";
        public FormDistricts()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /**
         * -----------------------------------------------*
         * Event Handlers
         * -----------------------------------------------*
         */

        private void btn_new_Click(object sender, EventArgs e)
        {
            labelMode.Text = "Mode: New Entry";
            FRMENTMODE = "New";
            clear();
            txt_name.Focus();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (FRMENTMODE == "New")
            {
                save();
                clear();
                auto();
            }
            else if (FRMENTMODE == "Edit")
            {
                update();
                clear();
                auto();
                txt_name.Focus();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            clear();
            FRMENTMODE = "Edit";
            labelMode.Text = "Mode: Edit Entry";
            txt_code.ReadOnly = false;
            txt_code.BackColor = System.Drawing.Color.White;
            this.txt_code.Focus();
        }

        private void btn_delete_Click_1(object sender, EventArgs e)
        {
            //delete data
            deldata();
            clear();
            districtdata();
            txt_name.Focus();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDistricts_Load(object sender, EventArgs e)
        {
            labelMode.Text = "Mode: New Entry";
            FRMENTMODE = "New";
            clear();
            auto();
            txt_name.Focus();
            districtdata();
        }

        private void FormDistricts_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Quit from this module", "EXIT!! System Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            clear();
            FRMENTMODE = "Edit";
            labelMode.Text = "Mode: Edit Entry";
            ListView.SelectedListViewItemCollection launch = this.listView1.SelectedItems;
            string code = "";
            foreach (ListViewItem item in launch)
            {
                code += item.SubItems[1].Text;
            }
            txt_code.Text = code;

            //get data
            getdata();
        }

        private void txtsrch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.listView1.Focus();
                e.Handled = true;
                this.listView1.Items[0].Selected = true;
            }
        }

        private void txt_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = toolStrip1;
                btn_save.Select();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = toolStrip1;
                btn_new.Select();
                e.Handled = true;
            }
        }

        /**
         * -----------------------------------------------*
         * Functions
         * -----------------------------------------------*
         */

        public void getdata()
        {
            Conn.Open();
            cmd = new MySqlCommand("SELECT id, code, name FROM tbl_district WHERE code = @code", Conn.allcon);
            cmd.Parameters.AddWithValue("@code", txt_code.Text);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["name"].ToString() != "")
                {
                    txt_name.Text = dr["name"].ToString();
                }
                if (dr["code"].ToString() != "")
                {
                    txt_code.Text = dr["code"].ToString();
                }

                btn_delete.Enabled = true;
            }
            Conn.Close();
            ActiveControl = txt_name;
        }

        public void clear()
        {
            num.Text = "";
            txt_name.Text = "";
            txt_code.Text = "";
            auto();
            btn_delete.Enabled = false;
        }

        public void auto()
        {
            Conn.Open();
            int autonum = 0;
            cmd = new MySqlCommand("SELECT MAX(id+0) FROM tbl_district", Conn.allcon);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                try
                {
                    autonum = Int32.Parse(dr[0].ToString());
                }
                catch (FormatException)
                {
                    autonum = 0;
                }
                autonum++;
                num.Text = autonum.ToString();
                String autonumtext = "";
                if (autonum.ToString().Length == 1)
                {
                    autonumtext = "00" + autonum;
                }
                else if (autonum.ToString().Length == 2)
                {
                    autonumtext = "0" + autonum;
                }
                else
                {
                    autonumtext = "" + autonum;
                }
                txt_code.Text = autonumtext;
                dr.Close();
            }
            Conn.Close();
        }

        private void save()
        {
            Conn.Open();
            if (blank() == false)
            {
                return;
            }
            else
            {
                if (FRMENTMODE == "New")
                {
                    cmd = new MySqlCommand("INSERT INTO tbl_district (id, code, name) VALUES (@id, @code, @name)", Conn.allcon);
                    cmd.Parameters.AddWithValue("@id", num.Text);
                    cmd.Parameters.AddWithValue("@code", txt_code.Text);
                    cmd.Parameters.AddWithValue("@name", txt_name.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Code is - " + txt_code.Text, "Data saved successfully");
                    btn_delete.Enabled = false;
                    clear();
                    labelMode.Text = "Mode: New Entry";
                    FRMENTMODE = "New";
                    txtsrch.Text = "";
                    districtdata();

                    ActiveControl = txt_name;
                    txt_name.Focus();
                }
            }
            Conn.Close();
        }

        public void update()
        {
            Conn.Open();
            cmd = new MySqlCommand("UPDATE tbl_district SET name = @name WHERE code = @code", Conn.allcon);

            cmd.Parameters.AddWithValue("@name", txt_name.Text);
            cmd.Parameters.AddWithValue("@code", txt_code.Text);

            cmd.ExecuteNonQuery();
            FRMENTMODE = "New";
            labelMode.Text = "Mode: New Entry";
            Conn.Close();
            MessageBox.Show("Record updated with code - " + txt_code.Text, "Update Success!!");
            districtdata();
            clear();
            ActiveControl = txt_name;
            txt_name.Focus();
        }

        public void deldata()
        {
            Conn.Open();
            DialogResult confirm = MessageBox.Show("Do you want to delete this record?", "Delete!! System Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                cmd = new MySqlCommand("DELETE FROM tbl_district WHERE code = @code", Conn.allcon);
                cmd.Parameters.AddWithValue("@code", txt_code.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Something went wrong...", "Violation Error!!! System Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btn_delete.Enabled = false;
                clear();
                labelMode.Text = "Mode: New Entry";
                FRMENTMODE = "New";
            }
            Conn.Close();
        }

        public void districtdata()
        {
            Conn.Open();
            listView1.Items.Clear();
            listView1.Columns.Clear();
            ds = new DataSet();
            da = new MySqlDataAdapter("SELECT id, code, name FROM tbl_district WHERE name LIKE '" + txtsrch.Text + "%' ORDER BY name;", Conn.allcon);
            da.Fill(ds, "district");
            listView1.Columns.Add("NAME", 170, HorizontalAlignment.Left);
            listView1.Columns.Add("CODE", 70, HorizontalAlignment.Left);

            foreach (DataRow row in ds.Tables["district"].Rows)
            {
                ListViewItem dfc = listView1.Items.Add(row["name"].ToString());
                dfc.SubItems.Add(row["code"].ToString());
            }
            Conn.Close();
        }

        private Boolean blank()
        {
            if (txt_code.Text == "")
            {
                MessageBox.Show("District code cannot be left blank.", "Empty Field!! System Manager");
                txt_code.Focus();
                return false;
            }
            if (txt_name.Text == "")
            {
                MessageBox.Show("District name cannot be left blank.", "Empty Field!! System Manager");
                txt_name.Focus();
                return false;
            }
            return true;
        }
    }
}
