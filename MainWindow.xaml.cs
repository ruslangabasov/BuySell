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
using System.Data.Entity;
using BuySell.Models;

namespace BuySell
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KupiProdaiDBEntities db;
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            try
            {
                db = new KupiProdaiDBEntities();
                db.tWorkers.Load();
                dtSpotsman.ItemsSource = db.tWorkers.Local.ToBindingList();
            }
            catch
            {
                MessageBox.Show("Ошибка");
                db.Dispose();
            }

        }

        private void DtSpotsman_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (dtSpotsman.SelectedItems.Count > 0)
            {
                tWorker sportsman = dtSpotsman.SelectedItem as tWorker;
            }
        }

        private void DtSpotsman_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Ошибка");
                db.Dispose();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dtSpotsman.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < dtSpotsman.SelectedItems.Count; i++)
                    {
                        tWorker tWorker = dtSpotsman.SelectedItems[i] as tWorker;
                        if (tWorker != null)
                        {
                            db.tWorkers.Remove(tWorker);
                        }
                    }
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка");
                db.Dispose();
                LoadData();
            }
        }


        //private void BtnEdit_Click(object sender, RoutedEventArgs e)
        //{
        //    if (dtSpotsman.SelectedItems.Count > 0)
        //    {
        //        tWorker tWorker = dtSpotsman.SelectedItem as tWorker;
        //        if (tWorker == null)
        //            return;
        //        WindowEdit windowEdit = new WindowEdit(tWorker, db);
        //        windowEdit.ShowDialog();
        //        db.Dispose();
        //        LoadData();

        //    }

        //}
    }
}
