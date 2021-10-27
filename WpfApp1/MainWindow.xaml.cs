using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApp1 {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        BackgroundWorker work = new BackgroundWorker();
        public MainWindow( ) {
            InitializeComponent();
            work.DoWork += WorkDoWork;
            work.ProgressChanged += WorkProgressChanged;

            work.WorkerReportsProgress = true;
        }

        private void WorkProgressChanged(object sender, ProgressChangedEventArgs e) {
            //throw new NotImplementedException();
            pbCount.Value = e.ProgressPercentage;
        }

        private void WorkDoWork(object sender, DoWorkEventArgs e) {
            //throw new NotImplementedException();         
            for (int i = 0; i < 100; i++) {
                Thread.Sleep(100);      //задержка
                work.ReportProgress(i);  //итерации
                if (work.CancellationPending)
                    break;
                if (i == 99) {
                    for (i = 99; i > 0; i--) {
                        Thread.Sleep(100);      //задержка
                        work.ReportProgress(i);
                        if (work.CancellationPending)
                            break;
                    }
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)     //start
        {
            work.RunWorkerAsync();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)   //stop
        {
            work.WorkerSupportsCancellation = true;
            if (work.IsBusy) work.CancelAsync();
            //work.Abort();
        }
    }
}
