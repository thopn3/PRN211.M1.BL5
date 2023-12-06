using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Topic2_WorkingEF.Models;

namespace Topic2_WorkingEF
{
    public partial class FrmMovies : Form
    {
        public FrmMovies()
        {
            InitializeComponent();
        }

        private void ReloadMovies()
        {
            dgvMovies.Columns.Clear();
            try
            {
                using (var db = new PE_PRN_Fall2023B1Context())
                {
                    cbDirector.DataSource = db.Directors.ToList();
                    cbDirector.ValueMember = "Id";
                    cbDirector.DisplayMember = "Name";

                    var movies = db.Movies.Select(m => new { Id = m.Id, Title = m.Title, Year = m.Year, Desc = m.Description, Director = m.Director.Name }).ToList();
                    if (movies != null)
                    {
                        // Tắt tính năng tự động sinh cột trên dgvMovies
                        dgvMovies.AutoGenerateColumns = false;
                        // Binding 'movies' to dgvMovies
                        dgvMovies.DataSource = movies;

                        // Thêm các cột vào dgvMovies
                        var cSelect = new DataGridViewCheckBoxColumn();
                        cSelect.HeaderText = "Select";
                        cSelect.Name = "cSelect";
                        dgvMovies.Columns.Add(cSelect);

                        var cId = new DataGridViewTextBoxColumn();
                        cId.HeaderText = "Movie Id";
                        cId.Name = "cId";
                        cId.DataPropertyName = "Id";
                        dgvMovies.Columns.Add(cId);

                        var cTitle = new DataGridViewTextBoxColumn();
                        cTitle.HeaderText = "Movie Title";
                        cTitle.Name = "cTitle";
                        cTitle.DataPropertyName = "Title";
                        dgvMovies.Columns.Add(cTitle);

                        var cYear = new DataGridViewTextBoxColumn();
                        cYear.HeaderText = "Movie Year";
                        cYear.Name = "cYear";
                        cYear.DataPropertyName = "Year";
                        dgvMovies.Columns.Add(cYear);

                        var cDirector = new DataGridViewTextBoxColumn();
                        cDirector.HeaderText = "Director";
                        cDirector.Name = "cDirector";
                        cDirector.DataPropertyName = "Director";
                        dgvMovies.Columns.Add(cDirector);

                        var cEdit = new DataGridViewButtonColumn();
                        cEdit.HeaderText = "Edit";
                        cEdit.Name = "cEdit";
                        cEdit.Text = "Update";
                        cEdit.UseColumnTextForButtonValue = true;
                        dgvMovies.Columns.Add(cEdit);

                        var cDelete = new DataGridViewButtonColumn();
                        cDelete.HeaderText = "Delete";
                        cDelete.Name = "cDelete";
                        cDelete.Text = "Delete";
                        cDelete.UseColumnTextForButtonValue = true;
                        dgvMovies.Columns.Add(cDelete);

                    }
                    else
                    {
                        MessageBox.Show("Data is empty.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmMovies_Load(object sender, EventArgs e)
        {
            ReloadMovies();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new PE_PRN_Fall2023B1Context())
                {
                    // Lấy dữ liệu từ các controls trên Form
                    string title = txtTitle.Text.Trim();
                    int year = Convert.ToInt32(txtYear.Value);
                    string desc = txtDescription.Text.Trim();
                    int directorId = (int)cbDirector.SelectedValue;

                    string msg = "";
                    if (title.Length > 0)
                    {
                        if (db.Movies.FirstOrDefault(m => m.Title.Equals(title)) != null)
                        {
                            msg += "This movie title exist. Re-Enter a new Movie title!\n";
                        }
                    }
                    else
                    {
                        msg += "Title is required.\n";
                    }

                    // Kiểm tra hợp lệ của dữ liệu
                    if (msg.Length > 0)
                    {
                        MessageBox.Show(msg);
                    }
                    else
                    {
                        // Đóng gói đối tượng kiểu Movie
                        var newMovie = new Movie() { Title = title, Year = year, DirectorId = directorId, Description = desc };

                        // Lưu dữ liệu xuống DB
                        db.Movies.Add(newMovie);
                        if (db.SaveChanges() > 0)
                        {
                            MessageBox.Show("Add new success.");
                            ReloadMovies();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvMovies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "cEdit")
            {
                // Update
                int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["cId"].Value);
                //MessageBox.Show("Update: " + id);
                FrmUpdate fUpdate = new FrmUpdate(id);
                fUpdate.Show();
            }

            if (dgv.Columns[e.ColumnIndex].Name == "cDelete")
            {
                // Delete
                // Update
                int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["cId"].Value);
                //MessageBox.Show("Delete: " + id);
                using (var db = new PE_PRN_Fall2023B1Context())
                {
                    var movie = db.Movies.SingleOrDefault(m=>m.Id == id);
                    if(movie != null)
                    {
                        if(MessageBox.Show("Do you want delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            db.Movies.Remove(movie);
                            db.SaveChanges();
                            MessageBox.Show("Delete success.");
                            ReloadMovies();
                        }
                    }
                }
            }
        }
    }
}
