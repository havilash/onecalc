using System.Data;
using org.matheval;

using OneCalc.Models;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace OneCalc.ViewModels
{
    public class CalculatorViewModel : BaseViewModel
    {
        DataTable dt = new DataTable();

        private string displayCalculation = "0";
        private string displayResult = "0";
        public string DisplayCalculation 
        { 
            get => displayCalculation;
            set
            {
                if (displayCalculation == value)
                    return;
                displayCalculation = value;
                OnPropertyChanged();
            }
        }
        public string DisplayResult
        { 
            get => displayResult;
            set
            {
                if (displayResult == value)
                    return;
                displayResult = value;
                OnPropertyChanged();
            }
        }


        ArrayList calculation = new();
        ArrayList evalCalculation = new();

        const int MaxCalcLength = 12;

        public ObservableCollection<Operator> Operators { get; set; } = new() {
            new Operator {Symbol = "2nd"},
            new Operator {Symbol = "π"},
            new Operator {Symbol = "e"},
            new Operator {Symbol = "C"},
            new Operator {Symbol = "⌫"},

            new Operator {Symbol = "x²"},
            new Operator {Symbol = "1/x"},
            new Operator {Symbol = "|x|"},
            new Operator {Symbol = "exp"},
            new Operator {Symbol = "mod"},

            new Operator {Symbol = "√x"},
            new Operator {Symbol = "("},
            new Operator {Symbol = ")"},
            new Operator {Symbol = "n!"},
            new Operator {Symbol = "÷"},

            new Operator {Symbol = "xʸ"},
            new Operator {Symbol = "7"},
            new Operator {Symbol = "8"},
            new Operator {Symbol = "9"},
            new Operator {Symbol = "×"},

            new Operator {Symbol = "10^x"},
            new Operator {Symbol = "4"},
            new Operator {Symbol = "5"},
            new Operator {Symbol = "6"},
            new Operator {Symbol = "-"},

            new Operator {Symbol = "log"},
            new Operator {Symbol = "1"},
            new Operator {Symbol = "2"},
            new Operator {Symbol = "3"},
            new Operator {Symbol = "+"},

            new Operator {Symbol = "ln"},
            new Operator {Symbol = "±"},
            new Operator {Symbol = "0"},
            new Operator {Symbol = "."},
            new Operator {Symbol = "="},
        };

        //public ICommand OnOperatorButtonClickedCommand { get; private set; }

        public CalculatorViewModel()
        {
            //OnOperatorButtonClickedCommand = new Command(OnOperatorButtonClicked);
        }

        
        public void OnOperatorButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            String symbol = button.Text;

            switch (symbol)
            {
                case "=":
                    DisplayResult = EvaluateCalculation(string.Join("", evalCalculation.ToArray()));
                    DisplayResult = DisplayResult == "" ? "error" : DisplayResult;
                    break;
                case "π":
                    SetExpression("π", "pi");
                    break;
                case "e":
                    SetExpression("e", "e");
                    break;
                case "C":
                    evalCalculation.Clear();
                    calculation.Clear();
                    DisplayResult = "0";
                    break;
                case "⌫":
                    if (evalCalculation.Count > 0)
                    {
                        evalCalculation.RemoveAt(evalCalculation.Count - 1);
                        calculation.RemoveAt(calculation.Count - 1);
                    }
                    break;
                case "x²":
                    SetXExpression("({0})^2", "({0})^2");
                    break;
                case "1/x":
                    SetXExpression("1/({0})", "1/({0})");
                    break;
                case "|x|":
                    SetXExpression("|{0}|", "abs({0})");
                    break;
                case "exp":
                    SetExpression("*10^", "*10^");
                    break;
                case "mod":
                    SetExpression("%", "%");
                    break;
                case "√x":
                    SetXExpression("√({0})", "sqrt({0})");
                    break;
                case "(":
                    SetExpression("(", "(");
                    break;
                case ")":
                    SetExpression(")", ")");
                    break;
                case "n!":
                    SetXExpression("{0}!", "fact({0})");
                    break;
                case "÷":
                    SetExpression("/", "/");
                    break;
                case "xʸ":
                    SetExpression("^", "^");
                    break;
                case "7":
                    SetExpression("7", "7");
                    break;
                case "8":
                    SetExpression("8", "8");
                    break;
                case "9":
                    SetExpression("9", "9");
                    break;
                case "×":
                    SetExpression("*", "*");
                    break;
                case "10^x":
                    SetExpression("10^x", "10^x");
                    break;
                case "4":
                    SetExpression("4", "4");
                    break;
                case "5":
                    SetExpression("5", "5");
                    break;
                case "6":
                    SetExpression("6", "6");
                    break;
                case "-":
                    SetExpression("-", "-");
                    break;
                case "log":
                    SetXExpression("log({0})", "log10({0})");
                    break;
                case "1":
                    SetExpression("1", "1");
                    break;
                case "2":
                    SetExpression("2", "2");
                    break;
                case "3":
                    SetExpression("3", "3");
                    break;
                case "+":
                    SetExpression("+", "+");
                    break;
                case "ln":
                    SetXExpression("ln({0})", "ln({0})");
                    break;
                case "±":
                    if (evalCalculation.Count > 0)
                    {
                        string s = (string)evalCalculation[evalCalculation.Count - 1];
                        if (s[0] == '-')
                        {
                            evalCalculation[evalCalculation.Count - 1] = s.Remove(0, 1);
                            s = (string)calculation[evalCalculation.Count - 1];
                            calculation[calculation.Count - 1] = s.Remove(0, 1);
                        } else
                        {
                            SetXExpression("-{0}", "-{0}");
                        }
                    }
                    break;
                case "0":
                    SetExpression("0", "0");
                    break;
                case ".":
                    SetExpression(".", ".");
                    break;
            }

            DisplayCalculation = (calculation.Count == 0) ? "0" : string.Join("", calculation.ToArray());
        }

        public string EvaluateCalculation(string input)
        {
            try
            {
                Expression expression = new Expression(input);
                object output = expression.Eval();

                return output.ToString();
            } catch(Exception ex)
            {
                return "";
            }
            //await DisplayAlert("Eval", $"{input} = {output.ToString()}", "OK");
            
        }

        void SetExpression(string exp, string evalExp)
        {
            evalCalculation.Add(evalExp);
            calculation.Add(exp);
        }

        void SetXExpression(string exp, string evalExp)
        {
            if (calculation.Count > 0)
            {
                string s = (string)evalCalculation[evalCalculation.Count - 1];
                evalCalculation.RemoveAt(evalCalculation.Count - 1);
                evalCalculation.Add(string.Format(evalExp, s));

                s = (string)calculation[calculation.Count - 1];
                calculation.RemoveAt(calculation.Count - 1);
                calculation.Add(string.Format(exp, s));
            }
        }


    }
}
