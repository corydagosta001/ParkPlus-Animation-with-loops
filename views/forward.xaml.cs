
using System;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Threading;
using Animation.Model;
namespace Animation.views
{
    public partial class forward : UserControl
    {
        private Boolean loopForever = true;
        private double topStartPos;
        private double leftPos;
        public forward()
        {
            InitializeComponent();
            topStartPos = UpArrow.Margin.Top;
            leftPos = UpArrow.Margin.Left; 
        }

        private void fWin_Loaded(object sender, RoutedEventArgs e)
        {
            MoveImageStart();
        }

        public async void MoveImageStart()
        {
            await Task.Run(()=>
            { 
                if(loopForever == true)
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
            double ua = UpArrow.Margin.Top - 1;
            if (UpArrow.Margin.Top <= ForwardGrid.Margin.Top + 15)
            {
               UpArrow.Margin = new Thickness(leftPos, topStartPos, 0, 0);
            }
            else
            {
                UpArrow.Margin = new Thickness(leftPos, ua, 0, 0);
            } 
        }
    }
}
