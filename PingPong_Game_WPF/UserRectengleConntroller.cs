using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong_Game_WPF
{
    /// <summary>
    /// pad
    /// </summary>
    public class UserRectengleConntroller : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _y_Position;

        public int YPosition
        {
            get =>_y_Position;
            set
            {

                _y_Position = value;
                OnPropertyChanged("YPosition");
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
