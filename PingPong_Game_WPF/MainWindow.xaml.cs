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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PingPong_Game_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _angle = 155;
        private double _speed = 5;
        private int _padSpeed = 7;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _ball;
            RightPad.DataContext = _rightPad;
            LeftPad.DataContext = _leftPad;
            Ball.DataContext = _ball;
            label4.DataContext = _rightPad;

            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Start();
            timer.Tick += _timer_Tick;
        }

       
        void _timer_Tick(object sender, EventArgs e)
        {
            if (_ball.Y <= 0) _angle = _angle + (180 - 2 * _angle);
            if (_ball.Y >= MainCanvas.ActualHeight - 20) _angle = _angle + (180 - 2 * _angle);

            if (CheckCollision())
            {
                ChangeAngle();
                ChangeDirection();
            }
            double radians = (Math.PI / 180) * _angle;
            Vector vector = new Vector { X = Math.Sin(radians), Y = -Math.Cos(radians) };
            _ball.X += vector.X * _speed;
            _ball.Y += vector.Y * _speed;

            if (_ball.X >= 790)
            {
                _ball.LeftResult += 1;
                GameReset();
            }
            if (_ball.X <= 5)
            {
                _ball.RightResult += 1;
                GameReset();
            }
        }

        private void GameReset()
        {
            _ball.Y = 210;
            _ball.X = 380;
        }

        private void ChangeAngle()
        {
            if (_ball.MovingRight == true) _angle = 270 - ((_ball.Y + 10) - (_rightPad.YPosition + 40));
            else if (_ball.MovingRight == false) _angle = 90 + ((_ball.Y + 10) - (_leftPad.YPosition + 40));
        }

        private void ChangeDirection()
        {
            _ball.MovingRight = !_ball.MovingRight;
        }

        private bool CheckCollision()
        {          
            if (_ball.MovingRight)
                return _ball.X >= 760 && (_ball.Y > _rightPad.YPosition - 20 && _ball.Y < _rightPad.YPosition + 80);
            else
                return _ball.X <= 20 && (_ball.Y > _leftPad.YPosition - 20 && _ball.Y < _leftPad.YPosition + 80);
          
        }


        readonly BallController _ball = new BallController { X = 380, Y = 210, MovingRight = true };

        readonly UserRectengleConntroller _leftPad = new UserRectengleConntroller { YPosition = 90 };
        readonly UserRectengleConntroller _rightPad = new UserRectengleConntroller { YPosition = 70 };


        private void MainWindow_OnKeyDown(object sender, KeyboardEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.W)) _leftPad.YPosition -= _padSpeed;
            if (Keyboard.IsKeyDown(Key.S)) _leftPad.YPosition += _padSpeed;
            if (Keyboard.IsKeyDown(Key.Up)) _rightPad.YPosition -= _padSpeed;
            if (Keyboard.IsKeyDown(Key.Down)) _rightPad.YPosition += _padSpeed;

        }
    }
}
