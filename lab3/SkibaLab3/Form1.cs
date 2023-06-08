namespace SkibaLab3
{
    public partial class FioTransformer : Form
    {
        public FioTransformer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_fio_Click(object sender, EventArgs e)
        {
            string father = text_father.Text;
            string name = text_name.Text;
            string surname = text_surname.Text;
            string fio = CreateFioInitials(surname, name, father);
            text_out.Text = fio;
        }
    }
}