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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using System.Drawing;


namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public List<Student> ListaStudentow { get; set; }
        public List<Grades> ListaOcen { get; set; }

        public Student student;
        public MainWindow()
        {

            ListaStudentow = new List<Student>()
             {
                 new Student(){imie="Jan", nazwisko = "Kowalski", NrIndeksu = 1234, wydzial = "KIS", ocena = 4},
                 new Student(){imie="Anna", nazwisko = "Nowak", NrIndeksu = 4321, wydzial = "KIS",ocena = 2},
                 new Student(){imie="Michał", nazwisko = "Jacek", NrIndeksu = 34562, wydzial = "KIS",ocena = 5},

             };

            InitializeComponent();

            dgStudent.Columns.Add(new DataGridTextColumn() { Header = "Imię", Binding = new Binding("imie") });
            dgStudent.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("nazwisko") });
            dgStudent.Columns.Add(new DataGridTextColumn() { Header = "Numer Indeksu", Binding = new Binding("NrIndeksu") });
            dgStudent.Columns.Add(new DataGridTextColumn() { Header = "Wydział", Binding = new Binding("wydzial") });
            dgStudent.Columns.Add(new DataGridTextColumn() { Header = "Ocena", Binding = new Binding("ocena") });


            dgStudent.AutoGenerateColumns = false;
            var binding = new Binding();
            binding.Source = ListaStudentow;
            dgStudent.SetBinding(DataGrid.ItemsSourceProperty, binding);


            ListaOcen = new List<Grades>()
              {
                  new Grades() { ocena = 4},
                  new Grades() { ocena = 2},
                  new Grades() { ocena = 5},

              };



        }

        private void AddButon_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Window1();
            if (dialog.ShowDialog() == true)
            {
                ListaStudentow.Add(dialog.student);
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (dgStudent.SelectedItem is Student)
                ListaStudentow.Remove((Student)dgStudent.SelectedItem);
            dgStudent.Items.Refresh();
        }
    }


    public class Grades
    {
        public int ocena { get; set; }

        public Grades(int ocena)
        {
            this.ocena = ocena;

        }
        public Grades()
        : this(0)
        {

        }

    }

    public class Student
    {


        public string imie { get; set; }
        public string nazwisko { get; set; }
        public int NrIndeksu { get; set; }
        public string wydzial { get; set; }

        public int ocena { get; set; }


        public Student(string imie, string nazwisko, int NrIndeksu, string wydzial)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.NrIndeksu = NrIndeksu;
            this.wydzial = wydzial;
            this.ocena = ocena;
        }
        public Student()
            : this("", "", 0, "")
        {

        }

    }




}










