using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace WpfApp8 {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        
        public MainWindow( ) {
            InitializeComponent();
        }

        private ObservableCollection<NewKey> obj = new ObservableCollection<NewKey>();

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Escape) {
                obj.Clear();
            }
            obj.Add(new NewKey {
                KeyCode = e.Key.ToString(),
                KeyValue = (int)e.Key,
                KeyStates = e.KeyStates.ToString(),
                KeyChar = e.Key.ToString(),
                SystemKey = e.SystemKey.ToString(),
            });
            DataGrid.ItemsSource = obj;
        }
        private void MainWindow_OnKeyUp(object sender, KeyEventArgs e)
        {
            obj.Add(new NewKey
            {
                KeyCode = e.Key.ToString(),
                KeyValue = (int) e.Key,
                KeyStates = e.KeyStates.ToString(),
                KeyChar = e.Key.ToString(),
                SystemKey = e.SystemKey.ToString(),
            });
            DataGrid.ItemsSource = obj;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.KeyDown += new KeyEventHandler(MainWindow_OnKeyDown);
            this.KeyUp += new KeyEventHandler(MainWindow_OnKeyUp);

        }
    }
}
