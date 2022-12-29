using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OneCalc.Models;

public class Operator : INotifyPropertyChanged
{
    public string symbol;
    public string Symbol
    {
        get
        {
            return this.symbol;
        }
        set
        {
            if (value != this.symbol)
            {
                this.symbol = value;
                NotifyPropertyChanged();
            }
        }
    }

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}