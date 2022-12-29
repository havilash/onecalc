using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using OneCalc.Views;

namespace OneCalc.ViewModels
{
    public class InfoViewModel : BaseViewModel
    {
        public string Version { get; set; } = typeof(System.Object).Assembly.GetName().Version.ToString();

        public InfoViewModel()
        {

        }

    }
}
