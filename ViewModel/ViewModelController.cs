using System.Windows;
using System.ComponentModel;
using Animation.views;
using System.IO;
using Animation.Model;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Input;
using Animation.Event_Classes;
namespace Animation.ViewModel
{
    class ViewModelController : INotifyPropertyChanged
    {
        private object _currentView;
        private object _forward;
        private object _backward;
        private object _right;
        private object _left;
        private object _startAgain;
        private string _displayedLogo;
        private string _displayArrow;
        private string _logo;
        private string _arrow;
        private string _continue = "true";
        private string _userInstructions;

        public ViewModelController()
        {
            _forward = new forward();
            _backward = new backward();
            _right = new right();
            _left = new left();
            _startAgain = new StartAgain();
            _logo = "Park Plug Logo.png";
            Directions.FillList(_forward,"Drive Forward", "UpArrow", _backward, "Drive Backward", "DownArrow", _right, "Move Right", "RightArrow", _left, "Move Left", "LeftArrow");
            LoopMethod();
        }


        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }

        public string UserInstructions
        {
            get { return _userInstructions; }
            set
            {
                _userInstructions = value;
                OnPropertyChanged("UserInstructions");
            }
        }

        public string DisplayedLogo
        {
            get
            {
                _displayedLogo = Directory.GetCurrentDirectory() + "\\images\\" + _logo;
                return _displayedLogo;
            }
        }

        public string DisplayedArrow
        {
            get
            {
                _displayArrow = Directory.GetCurrentDirectory() + "\\images\\" + _arrow + ".png";
                return _displayArrow;
            }
            set
            {
                _arrow = value;
                OnPropertyChanged("DisplayArrow");
            }
        }

        public ICommand PlayAnimationLoopAgain
        {
            get { return new DelegateCommand(setup); }
        }

        private void setup()
        {
            Directions.speed = Directions.speed * 2;
            LoopMethod();
        }

        private async void LoopMethod()
        {
            await Task.Run(() =>
            {
                loopThroughViews();
                UserInstructions = "";
                CurrentView = _startAgain;
            });
        }

        private void loopThroughViews()
        {
            foreach (var i in Directions.ArrowList)
            {
                _arrow = i.Image;
                UserInstructions = i.Instructions;
                CurrentView = i.Direction;
                Thread.Sleep(5000);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
