﻿using System;
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

namespace WpfApp1
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        bool isDataDirty = false;
        public MyWindow myWin { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            lbl.Content = "Добрый день!"; 
            setBut.IsEnabled = false; 
            retBut.IsEnabled = false;
        }

        private void setBut_Click(object sender, RoutedEventArgs e)
        {
            System.IO.StreamWriter sw = null;
            try
            {
                sw = new System.IO.StreamWriter("username.txt");
                sw.WriteLine(setText.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
            retBut.IsEnabled = true;
            isDataDirty = false;
        }

        private void retBut_Click(object sender, RoutedEventArgs e)
        {
            System.IO.StreamReader sr = null;
            try
            {
                using (sr = new System.IO.StreamReader("username.txt"))
                    retLabel.Content = "Приветствую Вас, уважаемый " + sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        private void setText_TextChanged(object sender, TextChangedEventArgs e)
        {
            setBut.IsEnabled = true;
            isDataDirty = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            { 
                if (this.isDataDirty) 
                { 
                    string msg = "Данные были изменены, но не сохранены!\nЗакрыть окно без сохранения?"; 
                    MessageBoxResult result = MessageBox.Show(msg, "Контроль данных", 
                    MessageBoxButton.YesNo, MessageBoxImage.Warning); 
                    if (result == MessageBoxResult.No) 
                    { 
                        e.Cancel = true;
                        Hide();
                    } 

                } 
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void New_Win_Click(object sender, RoutedEventArgs e)
        {
            if (myWin == null) 
                myWin = new MyWindow();
            myWin.Owner = this;
            var location = New_Win.PointToScreen(new Point(0, 0));
            myWin.Top = location.Y;
            myWin.Left = location.X + New_Win.Width;
            myWin.Show();
            
        }
        
    }
}
