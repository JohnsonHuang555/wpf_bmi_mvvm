using AceEventApplication;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfBMIMvvm
{
    public class CalcViewModel : INotifyPropertyChanged
    {
        #region Public Members

        public event PropertyChangedEventHandler PropertyChanged;

        private double? _height;

        private double? _weight;

        private string _result;

        #endregion

        #region Public Properties

        public double? Height
        {
            get { return _height; }
            set
            {
                if (_height != value)
                {
                    _height = value;
                    RaisePropertyChanged("Height");
                }
            }
        }

        public double? Weight
        {
            get { return _weight; }
            set
            {
                if (_weight != value)
                {
                    _weight = value;
                    RaisePropertyChanged("Weight");
                }
            }
        }

        public string Result
        {
            get { return _result; }
            set
            {
                if (_result != value)
                {
                    _result = value;
                    RaisePropertyChanged("Result");
                }
            }
        }

        #endregion

        #region 初始化

        public CalcViewModel()
        {

        }

        #endregion

        #region Command

        public ICommand CalcCommand { get { return new RelayCommand(Calculate); } }

        public ICommand ResetCommand { get { return new RelayCommand(reset); } }

        #endregion

        #region Methods

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void Calculate()
        {
            double bmi = 0.0;
            string result = string.Empty;

            bmi = Convert.ToDouble(Weight) / (Convert.ToDouble(Height) * Convert.ToDouble(Height));

            bmi = Math.Round(bmi * 10000);

            if (bmi < 18.5)
                result = "你太輕了吧";
            else if (18.5 <= bmi && bmi < 24.0)
                result = "正常，繼續保持";
            else if (24.0 >= bmi)
                result = "痾... 該減肥了吧";
            else
                result = "你是不是哪裡有問題?";

            Result = "你的BMI為" + bmi + "\n" + result;
        }

        private void reset()
        {
            Result = "";
            Height = null;
            Weight = null;
        }

        #endregion
    }
}
