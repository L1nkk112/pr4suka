using System.Windows.Forms;

namespace WinFormsApp12
{
    public partial class Form1 : Form
    {
        List<Airplane<string, DateTime>> airplane = new List<Airplane<string, DateTime>>();
        ErrorProvider errorProvider = new ErrorProvider();
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Short;
        }
        private async void AddApplication()
        {
            if (uint.TryParse(txtFlightNumber.Text, out uint airplaneNumber) &&
                !string.IsNullOrEmpty(txtPassangerName.Text) &&
                !string.IsNullOrEmpty(txtFlightNumber.Text))
            {
                Airplane<string, DateTime> newAirplane = new Airplane<string, DateTime>(txtDestination.Text, txtPassangerName.Text,txtFlightNumber.Text, dateTimePicker1.Value);
                airplane.Add(newAirplane);
                UpdateAirplaneInformation();
            }
            else
            {
                errorProvider.SetError(txtFlightNumber, "Введите корректные значения для номера рейса.");
                await Task.Delay(2000);
                errorProvider.SetError(txtFlightNumber, "");
                errorProvider.SetError(txtPassangerName, "Введите корректные значения для имени пассажира.");
                await Task.Delay(2000);
                errorProvider.SetError(txtPassangerName, "");
                errorProvider.SetError(txtDestination, "");
                errorProvider.SetError(txtDestination, "Введите корректный пункт назначения.");
                await Task.Delay(2000);
                errorProvider.SetError(txtDestination, "");
            }
        }
        private void UpdateAirplaneInformation()
        {
            txtApplications.Clear();
            foreach (Airplane<string, DateTime> b in airplane)
            {
                string ApplicationsInfo = $"Номер рейса: {b.FlightNumber}\r\nПассажир: {b.PassangerName}\r\nПункт назначения: {b.Destination}\r\nЖелаемая дата вылета: {b.DepartureDate}\r\n";
                txtApplications.AppendText(ApplicationsInfo + Environment.NewLine);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddAplication_Click(object sender, EventArgs e)
        {
            AddApplication();
        }

        private void btnRemoveApplication_Click(object sender, EventArgs e)
        {
            txtApplications.Clear();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtApplications.Clear();
            txtDestination.Clear();
            txtFlightNumber.Clear();
            txtPassangerName.Clear();
            airplane.Clear();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnClose_Click(sender, e);
        }

        private void txtApplications_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFlightNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}