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
    public partial class FormMembership : Office2007Form
    {
        Conn conn = new Conn();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter da = null;
        MySqlCommandBuilder scb = null;
        DataSet ds = null;
        public static DataTable dt;
        public static string FRMENTMODE = "";

        public FormMembership()
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

        private void FormMembership_Load(object sender, EventArgs e)
        {
            labelMode.Text = "Mode: New Entry";
            FRMENTMODE = "New";
            clear();
            auto();
            txtName.Focus();
            memdata();

            //load districts, constituencies and panchayats into combobox
            getDistricts();
            getConstituencies();
            getPanchayats();
        }

        private void FormMembership_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btn_new_Click(object sender, EventArgs e)
        {
            labelMode.Text = "Mode: New Entry";
            FRMENTMODE = "New";
            clear();
            txtName.Focus();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (FRMENTMODE == "New")
            {
                save();
            }
            else if (FRMENTMODE == "Edit")
            {
                update();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            clear();
            FRMENTMODE = "Edit";
            labelMode.Text = "Mode: Edit Entry";
            txtCode.ReadOnly = false;
            txtCode.BackColor = System.Drawing.Color.White;
            this.txtCode.Focus();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            //delete data
            deldata();
            clear();
            memdata();
            txtName.Focus();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {

        }

        private void btnClear1_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {

        }

        private void btnClear2_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse3_Click(object sender, EventArgs e)
        {

        }

        private void btnClear3_Click(object sender, EventArgs e)
        {

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

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDOB.Focus();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = toolStrip1;
                btn_new.Select();
                e.Handled = true;
            }
        }

        private void txtDOB_KeyDown(object sender, KeyEventArgs e)
        {
            //intenionally left blank
        }

        private void txtFatherName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbGender.Focus();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                txtDOB.Focus();
                e.Handled = true;
            }
        }

        private void cmbGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                txtAddress1.Focus();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                txtFatherName.Focus();
                e.Handled = true;
            }
        }

        private void txtAddress1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress2.Focus();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                cmbGender.Focus();
                e.Handled = true;
            }
        }

        private void txtAddress2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCity.Focus();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                txtAddress1.Focus();
                e.Handled = true;
            }
        }

        private void txtCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbDistrict.Focus();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                txtAddress2.Focus();
                e.Handled = true;
            }
        }

        private void cmbDistrict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                cmbPanchayat.Focus();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                txtCity.Focus();
                e.Handled = true;
            }
        }

        private void cmbPanchayat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                cmbConst.Focus();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                cmbDistrict.Focus();
                e.Handled = true;
            }
        }

        private void cmbConst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                txtMobile.Focus();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                cmbPanchayat.Focus();
                e.Handled = true;
            }
        }

        private void txtMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ActiveControl = toolStrip1;
                btn_save.Select();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                cmbConst.Focus();
                e.Handled = true;
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
            txtCode.Text = code;

            //get data
            getdata();
        }

        /**
         * -----------------------------------------------*
         * Functions/Methods
         * -----------------------------------------------*
         */

        public void getdata()
        {
            cmd = new MySqlCommand("SELECT * FROM tbl_membership WHERE code = @code;", Conn.allcon);
            cmd.Parameters.AddWithValue("@code", txtCode.Text);
            Conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["person_name"].ToString() != "")
                {
                    txtName.Text = dr["person_name"].ToString();
                }
                if (dr["code"].ToString() != "")
                {
                    txtCode.Text = dr["code"].ToString();
                }
                if (dr["dob"].ToString() != "")
                {
                    txtDOB.Text = dr["dob"].ToString();
                }
                if (dr["father_name"].ToString() != "")
                {
                    txtFatherName.Text = dr["father_name"].ToString();
                }
                if (dr["gender"].ToString() != "")
                {
                    cmbGender.Text = dr["gender"].ToString();
                }
                if (dr["add1"].ToString() != "")
                {
                    txtAddress1.Text = dr["add1"].ToString();
                }
                if (dr["add2"].ToString() != "")
                {
                    txtAddress2.Text = dr["add2"].ToString();
                }
                if (dr["dob"].ToString() != "")
                {
                    txtDOB.Text = dr["dob"].ToString();
                }
                if (dr["dob"].ToString() != "")
                {
                    txtDOB.Text = dr["dob"].ToString();
                }
                if (dr["dob"].ToString() != "")
                {
                    txtDOB.Text = dr["dob"].ToString();
                }
                if (dr["dob"].ToString() != "")
                {
                    txtDOB.Text = dr["dob"].ToString();
                }
                if (dr["dob"].ToString() != "")
                {
                    txtDOB.Text = dr["dob"].ToString();
                }

                btn_delete.Enabled = true;
            }
            Conn.Close();
            ActiveControl = txtName;
        }

        public void clear()
        {
            num.Text = "";
            txtName.Text = "";
            txtCode.Text = "";
            txtDOB.Text = "";
            txtFatherName.Text = "";
            cmbGender.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtCity.Text = "";
            cmbDistrict.SelectedValue = "0";
            cmbPanchayat.SelectedValue = "0";
            cmbConst.SelectedValue = "0";
            txtMobile.Text = "";
            auto();
            btn_delete.Enabled = false;
        }

        public void auto()
        {
            Conn.Open();
            int autonum = 0;
            cmd = new MySqlCommand("SELECT MAX(id+0) FROM tbl_membership", Conn.allcon);
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
                txtCode.Text = autonumtext;
                dr.Close();
            }
            Conn.Close();
        }

        public void getDistricts()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("CALL getDistricts();", Conn.allcon);
            Conn.Open();

            //Fill the DataTable with records from Table.
            DataTable dt = new DataTable();
            da.Fill(dt);

            //Insert the Default Item to DataTable.
            DataRow row = dt.NewRow();
            row[1] = 0;
            row[0] = "Please select";
            dt.Rows.InsertAt(row, 0);

            cmbDistrict.DataSource = dt;
            cmbDistrict.DisplayMember = "name";
            cmbDistrict.ValueMember = "code";
        }

        public void getConstituencies()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("CALL getConstituencies();", Conn.allcon);
            Conn.Open();

            //Fill the DataTable with records from Table.
            DataTable dt = new DataTable();
            da.Fill(dt);

            //Insert the Default Item to DataTable.
            DataRow row = dt.NewRow();
            row[1] = 0;
            row[0] = "Please select";
            dt.Rows.InsertAt(row, 0);

            //Assign DataTable as DataSource.
            cmbConst.DataSource = dt;
            cmbConst.DisplayMember = "name";
            cmbConst.ValueMember = "code";
        }

        public void getPanchayats()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("CALL getPanchayats();", Conn.allcon);
            Conn.Open();

            //Fill the DataTable with records from Table.
            DataTable dt = new DataTable();
            da.Fill(dt);

            //Insert the Default Item to DataTable.
            DataRow row = dt.NewRow();
            row[1] = 0;
            row[0] = "Please select";
            dt.Rows.InsertAt(row, 0);

            //Assign DataTable as DataSource.
            cmbPanchayat.DataSource = dt;
            cmbPanchayat.DisplayMember = "name";
            cmbPanchayat.ValueMember = "code";
        }

        public string getDistName(String code)
        {
            String name = "";
            MySqlCommand cmd = new MySqlCommand("CALL getDistrictName(@code)", Conn.allcon);
            cmd.Parameters.AddWithValue("@code", code);
            try
            {
                Conn.Open();
                name = (String)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Conn.Close();
            return name;
        }
        public string getPanchaytName(String code)
        {
            String name = "";
            MySqlCommand cmd = new MySqlCommand("CALL getPanchayatName(@code)", Conn.allcon);
            cmd.Parameters.AddWithValue("@code", code);
            try
            {
                Conn.Open();
                name = (String)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Conn.Close();
            return name;
        }

        public string getConstituencyName(String code)
        {
            String name = "";
            MySqlCommand cmd = new MySqlCommand("CALL getConstituencyName(@code)", Conn.allcon);
            cmd.Parameters.AddWithValue("@code", code);
            try
            {
                Conn.Open();
                name = (String)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Conn.Close();
            return name;
        }

        private void save()
        {
            if (blank() == false)
            {
                return;
            }
            else
            {
                if (FRMENTMODE == "New")
                {
                    cmd = new MySqlCommand("INSERT INTO contactpro.tbl_membership(id, code, person_name, dob, father_name, gender, add1, add2, city, district_code, district, panchayat_code, panchayat, const_code, const, mobile) VALUES (@id, @code, @person_name, @dob, @father_name, @gender, @add1, @add2, @city, @district_code, @district, @panchayat_code, @panchayat, @const_code, @const, @mobile);", Conn.allcon);
                    cmd.Parameters.AddWithValue("@id", num.Text);
                    cmd.Parameters.AddWithValue("@code", txtCode.Text);
                    cmd.Parameters.AddWithValue("@person_name", txtName.Text);
                    String mysqldob = Convert.ToDateTime(txtDOB.Text).ToString("yyyy-MM-dd");
                    //Console.WriteLine(mysqldob);
                    cmd.Parameters.AddWithValue("@dob", mysqldob);
                    cmd.Parameters.AddWithValue("@father_name", txtFatherName.Text);
                    cmd.Parameters.AddWithValue("@gender", cmbGender.Text);
                    cmd.Parameters.AddWithValue("@add1", txtAddress1.Text);
                    cmd.Parameters.AddWithValue("@add2", txtAddress2.Text);
                    cmd.Parameters.AddWithValue("@city", txtCity.Text);

                    String distCode = cmbDistrict.SelectedValue.ToString();
                    String distName = getDistName(distCode);
                    cmd.Parameters.AddWithValue("@district_code", distCode);
                    cmd.Parameters.AddWithValue("@district", distName);

                    String panchayatCode = cmbPanchayat.SelectedValue.ToString();
                    String panchayatName = getPanchaytName(panchayatCode);
                    cmd.Parameters.AddWithValue("@panchayat_code", panchayatCode);
                    cmd.Parameters.AddWithValue("@panchayat", panchayatName);

                    String constCode = cmbConst.SelectedValue.ToString();
                    String constName = getConstituencyName(constCode);
                    cmd.Parameters.AddWithValue("@const_code", constCode);
                    cmd.Parameters.AddWithValue("@const", constName);

                    cmd.Parameters.AddWithValue("@mobile", txtMobile.Text);

                    Conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Code is - " + txtCode.Text, "Data saved successfully");
                    btn_delete.Enabled = false;
                    clear();
                    labelMode.Text = "Mode: New Entry";
                    FRMENTMODE = "New";
                    txtsrch.Text = "";
                    memdata();
                    auto();
                    ActiveControl = txtName;
                    txtName.Focus();
                }
            }
            Conn.Close();
        }

        public void update()
        {
            Conn.Open();
            cmd = new MySqlCommand("UPDATE tbl_membership SET name = @name WHERE code = @code", Conn.allcon);

            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@code", txtCode.Text);

            cmd.ExecuteNonQuery();
            FRMENTMODE = "New";
            labelMode.Text = "Mode: New Entry";
            Conn.Close();
            MessageBox.Show("Record updated with code - " + txtCode.Text, "Update Success!!");
            memdata();
            clear();
            auto();
            ActiveControl = txtName;
            txtName.Focus();
        }

        public void deldata()
        {
            Conn.Open();
            DialogResult confirm = MessageBox.Show("Do you want to delete this record?", "Delete!! System Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                cmd = new MySqlCommand("DELETE FROM tbl_membership WHERE code = @code", Conn.allcon);
                cmd.Parameters.AddWithValue("@code", txtCode.Text);
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

        public void memdata()
        {
            Conn.Open();
            listView1.Items.Clear();
            listView1.Columns.Clear();
            ds = new DataSet();
            da = new MySqlDataAdapter("SELECT id, code, person_name, dob, father_name, gender, add1, add2, city, district_code, district, panchayat_code, panchayat, const_code, const, mobile FROM tbl_membership WHERE person_name LIKE '" + txtsrch.Text + "%' ORDER BY person_name;", Conn.allcon);
            da.Fill(ds, "district");
            listView1.Columns.Add("NAME", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("CODE", 55, HorizontalAlignment.Left);
            listView1.Columns.Add("DOB", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("FATHERNAME", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("GENDER", 70, HorizontalAlignment.Left);
            listView1.Columns.Add("ADDRESS1", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("ADDRESS2", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("DISTRICT", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("PANCHAYAT", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("CONSTITUENCY", 110, HorizontalAlignment.Left);
            listView1.Columns.Add("MOBILENO", 100, HorizontalAlignment.Left);

            foreach (DataRow row in ds.Tables["district"].Rows)
            {
                ListViewItem dfc = listView1.Items.Add(row["person_name"].ToString());
                dfc.SubItems.Add(row["code"].ToString());
                dfc.SubItems.Add(DateTime.Parse(row["dob"].ToString()).ToShortDateString());
                dfc.SubItems.Add(row["father_name"].ToString());
                dfc.SubItems.Add(row["gender"].ToString());
                dfc.SubItems.Add(row["add1"].ToString());
                dfc.SubItems.Add(row["add2"].ToString());
                dfc.SubItems.Add(row["city"].ToString());
                dfc.SubItems.Add(row["district"].ToString());
                dfc.SubItems.Add(row["panchayat"].ToString());
                dfc.SubItems.Add(row["const"].ToString());
                dfc.SubItems.Add(row["mobile"].ToString());
            }
            Conn.Close();
        }

        private Boolean blank()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Code cannot be left blank.", "Empty Field!! System Manager");
                txtCode.Focus();
                return false;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Person name cannot be left blank.", "Empty Field!! System Manager");
                txtName.Focus();
                return false;
            }
            if (txtDOB.Text == "")
            {
                MessageBox.Show("Date of Birth cannot be left blank.", "Empty Field!! System Manager");
                txtDOB.Focus();
                return false;
            }
            if (txtFatherName.Text == "")
            {
                MessageBox.Show("Father's name cannot be left blank.", "Empty Field!! System Manager");
                txtFatherName.Focus();
                return false;
            }
            if (cmbGender.Text == "")
            {
                MessageBox.Show("Gender cannot be left blank.", "Empty Field!! System Manager");
                cmbGender.Focus();
                return false;
            }
            if (txtAddress1.Text == "")
            {
                MessageBox.Show("Address Line 1 field cannot be left blank.", "Empty Field!! System Manager");
                txtAddress1.Focus();
                return false;
            }
            if (txtCity.Text == "")
            {
                MessageBox.Show("City cannot be left blank.", "Empty Field!! System Manager");
                txtCity.Focus();
                return false;
            }
            if (cmbDistrict.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("District cannot be left blank.", "Empty Field!! System Manager");
                cmbDistrict.Focus();
                return false;
            }
            if (cmbPanchayat.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Panchayat field cannot be left blank.", "Empty Field!! System Manager");
                cmbPanchayat.Focus();
                return false;
            }
            if (cmbConst.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Constituency field cannot be left blank.", "Empty Field!! System Manager");
                cmbConst.Focus();
                return false;
            }
            if (txtMobile.Text == "")
            {
                MessageBox.Show("Mobile field cannot be left blank.", "Empty Field!! System Manager");
                txtMobile.Focus();
                return false;
            }
            return true;
        }
    }
}
