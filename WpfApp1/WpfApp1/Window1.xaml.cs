using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;


namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Student student;
        public Grades ocena;
        public Window1(Student student = null)
        {
            InitializeComponent();
            if (student != null)
            {
                tbImie1.Text = student.imie;
                tbNazwisko.Text = student.nazwisko;
                tbNrIndeksu.Text = student.NrIndeksu.ToString();
                tbWydzial.Text = student.wydzial;

            }
            this.student = student ?? new Student();

        }


        public Window1()
        {
            InitializeComponent();
        }

        private void bOK_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(tbImie1.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbNazwisko.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbWydzial.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbNrIndeksu.Text, @"^[0-9]{1,12}$"))
            {
                MessageBox.Show("Podane błędne dane.");
                return;
            }
            student.imie = tbImie1.Text;
            student.nazwisko = tbNazwisko.Text;
            student.NrIndeksu = int.Parse(tbNrIndeksu.Text);
            student.wydzial = tbWydzial.Text;

            this.DialogResult = true;
        }

    }
}
