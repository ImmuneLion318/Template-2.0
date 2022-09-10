using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;

namespace Interface
{
    public partial class App : Application
    {
        public App()
        {
            Startup += (Object, Event) =>
            {
                if (!Debugger.IsAttached)
                    MessageBox.Show("Interface By -> ImmuneLion318#0001", "Interface Credits", MessageBoxButton.OK, MessageBoxImage.Information);
            };
        }
    }
}
