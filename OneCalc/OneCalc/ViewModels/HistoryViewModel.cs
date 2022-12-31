using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneCalc.Models;

namespace OneCalc.ViewModels
{
    class HistoryViewModel : BaseViewModel
    {
        public DateTime SelectedDate { get; set; }
        public ObservableCollection<HistoryModel> History { get; set; } = new ObservableCollection<HistoryModel>
        {
            new HistoryModel
            {
                Calculation = "500 / 8",
                Result = "62.5",
                CalcDateTime = DateTime.Now,
            },
            new HistoryModel
            {
                Calculation = "500 / 8",
                Result = "62.5",
                CalcDateTime = DateTime.Now,
            }
        };

    }
}
