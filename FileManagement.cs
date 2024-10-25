using Dragablz;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Wpf;
using System.Windows.Input;
using System.IO;
using System;

namespace CatWaterCodes_IDE {
    static internal class FileManagement {

        public static void SaveFile(string path, string content) {
            if (File.Exists(path)) {
                File.WriteAllText(path, content);
            }

            else {
                WriteToNewFile(content);
            }
        }
        public static void WriteToNewFile(string content) {
            SaveFileDialog saveFile = new SaveFileDialog();

            if(saveFile.ShowDialog() != true) {
                return;
            }

            File.WriteAllText(saveFile.FileName, content);
        }

        public static void CreateEmptyFile(Window main) {
            
            TabItem scriptTab = CreateTab(main);
            TextBox tb = new TextBox();
            tb.VerticalScrollBarVisibility = ScrollBarVisibility.Visible; tb.AcceptsReturn = true; tb.AcceptsTab = true; tb.Text = " a";
            scriptTab.Content = tb;
            scriptTab.IsSelected = true;
        }
        public static void OpenWebsiteInNewTab(Window main, string url="https://google.com", string name="browser") {
            TabItem browserTab = CreateTab(main);
            browserTab.Header = name;
            WebView2 browser = new WebView2();
            Uri address = new Uri(url);
            browser.Source = address;
            browserTab.Content = browser;
            
        }

        public static TabItem CreateTab(Window main) {
            TabablzControl tabCo = (TabablzControl)main.FindName("InitialTabablzControl");
            TabItem newTab = new TabItem();
            newTab.Header = "<null>*"; 
            tabCo.Items.Add(newTab);
            //tabCo.MouseDown += new MouseButtonEventHandler(MainWindow.TabClicked);
            return newTab;
        }
    }
}
