namespace Form_Quản_Lý_Danh_Sách_Sinh_Viên
{
    public partial class Form1 : Form
    {
        private List<Student> students = new List<Student>();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = students;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student newStudent = new Student()
            {
                Masinhvien = txtStudentId.Text,
                Tensinhvien = txtName.Text,
                Lop = txtClass.Text
            };
            students.Add(newStudent);
            RefreshGrid();
            ClearInputs();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int index = dataGridView1.CurrentRow.Index;
                students[index].Masinhvien = txtStudentId.Text;
                students[index].Tensinhvien = txtName.Text;
                students[index].Lop = txtClass.Text;
                RefreshGrid();
                ClearInputs();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int index = dataGridView1.CurrentRow.Index;
                students.RemoveAt(index);
                RefreshGrid();
                ClearInputs();
            }
        }
        private void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;
        }
        private void ClearInputs()
        {
            txtStudentId.Clear();
            txtName.Clear();
            txtClass.Clear();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtStudentId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtClass.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }
    }
    public class Student
    {
        public string ?Masinhvien { get; set; }
        public string ?Tensinhvien { get; set; }
        public string ?Lop { get; set; }
    }
}
