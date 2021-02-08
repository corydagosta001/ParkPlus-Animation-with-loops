using System;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Threading;
using Animation.Model;
namespace Animation.views
{

    public partial class left : UserControl
    {
        private Boolean loopForever = true;
        private double rightStartPos;
        private double TopPos;
        public left()
        {
            InitializeComponent();
            rightStartPos = LeftArrow.Margin.Left;
            TopPos = LeftArrow.Margin.Top;

        }

        private void lWin_Loaded(object sender, RoutedEventArgs e)
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
            double ua = LeftArrow.Margin.Left - 1;
            if (LeftArrow.Margin.Left <= 20)
            {
                LeftArrow.Margin = new Thickness(rightStartPos, TopPos, 0, 0);
            }
            else
            {
                LeftArrow.Margin = new Thickness(ua, TopPos, 0, 0);
            }
        }
    }
}
