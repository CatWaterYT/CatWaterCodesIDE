using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Dragablz;

namespace CatWaterCodes_IDE {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        static string path = "K:/file.txt";
        //public static TabablzControl selectedTab;

        public MainWindow() {
            InitializeComponent();
            //selectedTab = (TabablzControl)this.FindName("InitialTabablzControl");
            Debug.WriteLine("hello world");
        }

        void NewFileBtn(object sender, RoutedEventArgs e) {
            FileManagement.CreateEmptyFile(this);
        }

        void SaveBtn(object sender, RoutedEventArgs e) {
            TabablzControl tabablzControl = (Dragablz.TabablzControl)this.FindName("MainTabControl");
            TextBox tb = (TextBox)tabablzControl.SelectedContent;
            string content = tb.Text;

            FileManagement.SaveFile(path, content);
        }

        void SaveAsBtn(object sender, RoutedEventArgs e) {
            TabablzControl tabablzControl = (Dragablz.TabablzControl)this.FindName("MainTabControl");
            TextBox tb = (TextBox)tabablzControl.SelectedContent; 
            string content = tb.Text;

            FileManagement.WriteToNewFile(content);
        }

        void NewBrowser(object sender, RoutedEventArgs e) {
            FileManagement.OpenWebsiteInNewTab(this);
        }

        void NewOpenURL(object sender, RoutedEventArgs e) {
            Button clicked = sender as Button;
            string url = clicked.Tag.ToString();
            string name = clicked.Content.ToString();

            FileManagement.OpenWebsiteInNewTab(this, url, name);
        }
        /*public static void TabClicked(object sender, RoutedEventArgs e) {
            TabablzControl clickedTab = sender as TabablzControl;
            Debug.WriteLine("mememe");
            if (clickedTab == selectedTab || clickedTab == null) return;
            selectedTab = clickedTab;
        }*/
    }
}
