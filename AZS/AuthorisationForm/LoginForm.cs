using App;
using UI;

namespace AZS
{
    public partial class LoginForm : Form
    {
        DB db = new();
        public LoginForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(216, 216, 216);
        }

        private void entryButton_Click_1(object sender, EventArgs e)
        {
            int num;
            string password = passwordField.Text.Trim();
            try
            {
                num = int.Parse(numField.Text.Trim());
            }
            catch
            {
                MessageBox.Show("¬ведены некорректные данные");
                return;
            }

            var opers = db.GetOperators();
            var x = 0;
            foreach (var op in opers)
            {
                if (op.BaseId == num && op.Password == password)
                {
                    x = 1;
                    var s = new VehicleBaseForm(num);
                    s.Show();
                }
            }
            if (x == 0) MessageBox.Show("¬ведены неправильные данные");
        }
    }
}