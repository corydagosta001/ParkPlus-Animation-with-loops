using System;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Threading;
using Animation.Model;
namespace Animation.views
{
    /// <summary>
    /// Interaction logic for right.xaml
    /// </summary>
    public partial class right : UserControl
    {
        private Boolean loopForever = true;
        private double leftStartPos;
        private double TopPos;
        public right()
        {
            InitializeComponent();
            leftStartPos = RightArrow.Margin.Left;
            TopPos = RightArrow.Margin.Top;
            
        }

        private void rWin_Loaded(object sender, RoutedEventArgs e)
        {
             MoveImageStart();
        }

        public async void MoveImageStart()
        {
            await Task.Run(() =>
            {
                if (loopForever == true)
                {
                    Dispatcher.Invoke(() =>
                    {
                        MoveImage();
                    });
                    Thread.Sleep(Directions.speed);
                    MoveImageStart();
                }
            });
        }

        public void MoveImage()
        {
            double ua = RightArrow.Margin.Left + 1;
            if (RightArrow.Margin.Left >= 190)
            {
                RightArrow.Margin = new Thickness(leftStartPos, TopPos, 0, 0);
            }
            else
            {
                RightArrow.Margin = new Thickness(ua, TopPos, 0, 0);
            }
        }
    }
}
