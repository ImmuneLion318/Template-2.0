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
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Xml;
using Newtonsoft.Json;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Highlighting;
using Interface.Interfaces;
using Interface.Static;

namespace Interface
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            /* Modify Config Json And Post Online Then Reference The Link */

            using (var Http = new WebClient { Proxy = null })
            {
                //Data.InterfaceData Info = JsonConvert.DeserializeObject<Data.InterfaceData>
                //    (Http.DownloadString("")); /* Site Config File */

                //if (Manager.Version != Info.Version)
                //{
                //    /* Version Mismatch */
                //    Process.GetCurrentProcess().Kill();
                //}

                Editor.Options.EnableEmailHyperlinks = false;
                Editor.Options.EnableHyperlinks = false;

                using (var TextReader = new XmlTextReader(Http.OpenRead("https://raw.githubusercontent.com/ImmuneLion318/Editor-Syntax/Entry/Syntax/Dark.xshd")))
                    Editor.SyntaxHighlighting = HighlightingLoader.Load(TextReader, HighlightingManager.Instance);
            }
        }

        private void MouseHandle(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e) => Process.GetCurrentProcess().Kill();

        private void MaximizeBtn_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Maximized;

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
    }
}
