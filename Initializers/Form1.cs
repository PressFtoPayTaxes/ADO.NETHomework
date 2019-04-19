using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Initializers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var cities = new List<City>();

            using (var context = new DataContext())
            {
                cities = context.Cities.ToList();
            }

            citiesComboBox.DataSource = cities;
            citiesComboBox.DisplayMember = "Name";
            citiesComboBox.ValueMember = "Name";

        }

        private void citiesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "citiesAndNumbersSet.Cities". При необходимости она может быть перемещена или удалена.
            this.citiesTableAdapter.Fill(this.citiesAndNumbersSet.Cities);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Initializers_DataContextDataSet.Cities". При необходимости она может быть перемещена или удалена.
            this.citiesTableAdapter.Fill(citiesAndNumbersSet.Cities);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.citiesTableAdapter.Fill(citiesAndNumbersSet.Cities);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void addingButton_Click(object sender, EventArgs e)
        {
            string cityName = citiesComboBox.Text;
            string name = nameTextBox.Text;
            string phoneNumber = phoneTextBox.Text;

            if (name != string.Empty && phoneNumber != string.Empty)
            {
                List<City> city;
                using (var context = new DataContext())
                {
                    city = context.Cities.Where(cityVariable => cityVariable.Name == cityName).ToList();
                    context.PhoneNumbers.Add(new PhoneNumber
                    {
                        FullName = name,
                        Number = phoneNumber,
                        City = city[0]
                    });
                    context.SaveChanges();
                }
                
                Close();
            }


        }
    }
}
