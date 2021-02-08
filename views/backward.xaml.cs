using System;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Threading;
using Animation.Model;
namespace Animation.views
{

    public partial class backward : UserControl
    {
        private Boolean loopForever = true;
        private double bottomStartPos;
        private double leftPos;

        public backward()
        {
            InitializeComponent();
            bottomStartPos = BackArrow.Margin.Top;
            leftPos = BackArrow.Margin.Left;
        }

        private void bWin_Loaded(object sender, RoutedEventArgs e)
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
            double ua = BackArrow.Margin.Top + 1;
            if (BackArrow.Margin.Top >= 190)
            {
                BackArrow.Margin = new Thickness(leftPos, bottomStartPos, 0, 0);
            }
            else
            {
                BackArrow.Margin = new Thickness(leftPos, ua, 0, 0);
            }
        }
    }

}
