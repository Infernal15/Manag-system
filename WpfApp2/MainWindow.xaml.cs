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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, KeyValuePair<string, double>> work_list;
        int i;
        public MainWindow()
        {
            work_list = new Dictionary<string, KeyValuePair<string, double>>();
            i = 1;

            InitializeComponent();
            lab_name.Visibility = Visibility.Hidden;
            lab_od.Visibility = Visibility.Hidden;
            lab_p.Visibility = Visibility.Hidden;
            name.Visibility = Visibility.Hidden;
            od.Visibility = Visibility.Hidden;
            price.Visibility = Visibility.Hidden;
            add.Visibility = Visibility.Hidden;
            _return.Visibility = Visibility.Hidden;

            zam.Visibility = Visibility.Hidden;
            list.Visibility = Visibility.Hidden;
            count.Visibility = Visibility.Hidden;
            add_work.Visibility = Visibility.Hidden;
            _return_Copy.Visibility = Visibility.Hidden;
            box.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            zam.Visibility = Visibility.Visible;
            list.Visibility = Visibility.Visible;
            count.Visibility = Visibility.Visible;
            add_work.Visibility = Visibility.Visible;
            _return_Copy.Visibility = Visibility.Visible;
            box.Visibility = Visibility.Visible;

            rah.Visibility = Visibility.Hidden;
            work.Visibility = Visibility.Hidden;
            exit.Visibility = Visibility.Hidden;

            list.Items.Clear();
            foreach(string tmp in work_list.Keys)
            {
                list.Items.Add(tmp);
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                work_list.Add(name.Text, new KeyValuePair<string, double>(od.SelectedItem.ToString(), Convert.ToDouble(price.Text)));
            }
            catch
            {
                MessageBox.Show("error");
                return;
            }
            name.Clear();
            price.Clear();
        }

        private void work_Click(object sender, RoutedEventArgs e)
        {
            lab_name.Visibility = Visibility.Visible;
            lab_od.Visibility = Visibility.Visible;
            lab_p.Visibility = Visibility.Visible;
            name.Visibility = Visibility.Visible;
            od.Visibility = Visibility.Visible;
            price.Visibility = Visibility.Visible;
            add.Visibility = Visibility.Visible;
            _return.Visibility = Visibility.Visible;

            rah.Visibility = Visibility.Hidden;
            work.Visibility = Visibility.Hidden;
            exit.Visibility = Visibility.Hidden;
        }

        private void _return_Click(object sender, RoutedEventArgs e)
        {
            lab_name.Visibility = Visibility.Hidden;
            lab_od.Visibility = Visibility.Hidden;
            lab_p.Visibility = Visibility.Hidden;
            name.Visibility = Visibility.Hidden;
            od.Visibility = Visibility.Hidden;
            price.Visibility = Visibility.Hidden;
            add.Visibility = Visibility.Hidden;
            _return.Visibility = Visibility.Hidden;

            rah.Visibility = Visibility.Visible;
            work.Visibility = Visibility.Visible;
            exit.Visibility = Visibility.Visible;
        }

        private void _return_Copy_Click(object sender, RoutedEventArgs e)
        {
            zam.Visibility = Visibility.Hidden;
            list.Visibility = Visibility.Hidden;
            count.Visibility = Visibility.Hidden;
            add_work.Visibility = Visibility.Hidden;
            _return_Copy.Visibility = Visibility.Hidden;
            box.Visibility = Visibility.Hidden;

            rah.Visibility = Visibility.Visible;
            work.Visibility = Visibility.Visible;
            exit.Visibility = Visibility.Visible;
        }

        private void add_work_Click(object sender, RoutedEventArgs e)
        {
            table.RowGroups[0].Rows.Add(new TableRow());

            table.RowGroups[0].Rows[i].Cells.Add(new TableCell(new Paragraph(new Run(list.SelectedItem.ToString()))));
            table.RowGroups[0].Rows[i].Cells.Add(new TableCell(new Paragraph(new Run(work_list[list.SelectedItem.ToString()].Key))));
            table.RowGroups[0].Rows[i].Cells.Add(new TableCell(new Paragraph(new Run(count.Text))));
            table.RowGroups[0].Rows[i].Cells.Add(new TableCell(new Paragraph(new Run(work_list[list.SelectedItem.ToString()].Value.ToString()))));
            table.RowGroups[0].Rows[i].Cells.Add(new TableCell(new Paragraph(new Run(Convert.ToString(Convert.ToInt32(count.Text)* work_list[list.SelectedItem.ToString()].Value)))));
            i++;
        }
    }
}
