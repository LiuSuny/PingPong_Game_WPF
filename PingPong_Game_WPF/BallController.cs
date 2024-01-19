using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong_Game_WPF
{
    public class BallController : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double _x;
        private double _y;
        private bool _movingRight;
        private int _leftResult;
        private int _rightResult;

        public double X
        {
            get =>_x; 
            set
            {
                _x = value;
                OnPropertyChanged("X");
            }
        }

        public double Y
        {
            get=> _y; 
            set
            {
                _y = value;
                OnPropertyChanged("Y");
            }
        }

        public bool MovingRight
        {
            get => _movingRight; 
            set
            {
                _movingRight = value;
                OnPropertyChanged("MovingRight");
            }
        }

        public int LeftResult
        {
            get => _leftResult; 
            set
            {
                _leftResult = value;
                OnPropertyChanged("LeftResult");
            }
        }

        public int RightResult
        {
            get => _rightResult; 
            set
            {
                _rightResult = value;
                OnPropertyChanged("RightResult");
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
