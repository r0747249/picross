using System;
using System.Windows;
using System.Windows.Data;
using PiCross;
using System.Globalization;
using ViewModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Media;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class SquareConverter : IValueConverter
    {
        public object Filled { get; set; }
        public object Empty { get; set; }
        public object Unknown { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var square = (Square)value;
            if (square == Square.EMPTY)
                return Empty;
            else if (square == Square.FILLED)
                return Filled;
            else
                return Unknown;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ConstraintsConverter : IValueConverter
    {
        public object Satisfied { get; set; }
        public object Unsatisfied { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Satisfied : Unsatisfied;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string[] dimensions = value.ToString().Split(',');
            return dimensions[0].Split('[')[1] + "×" + dimensions[1].Split(']')[0].Trim();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class Navigator : INotifyPropertyChanged
    {
        private Screen currentScreen;

        public Navigator()
        {
            this.currentScreen = new IntroScreen(this);
        }

        public Screen CurrentScreen
        {
            get
            {
                return this.currentScreen;
            }
            set
            {
                this.currentScreen = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentScreen)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public abstract class Screen
    {
        protected readonly Navigator navigator;

        protected Screen(Navigator navigator)
        {
            this.navigator = navigator;
        }

        protected void SwitchTo(Screen screen)
        {
            this.navigator.CurrentScreen = screen;
        }
    }

    public class IntroScreen : Screen
    {
        public IntroScreen(Navigator navigator) : base(navigator)
        {
            this.GoToMenu = new EnabledCommand(() => SwitchTo(new MenuScreen(navigator)));
        }

        public ICommand GoToMenu { get; }
    }

    public class MenuScreen : Screen
    {
        public MenuViewModel MenuViewModel { get; }

        public MenuScreen(Navigator navigator) : base(navigator)
        {
            this.GoToIntro = new EnabledCommand(() => SwitchTo(new IntroScreen(navigator)));
            this.ScreenSwitcherFunction = (puzzle) => SwitchTo(new PuzzleScreen(navigator, puzzle));
            this.MenuViewModel = new MenuViewModel(ScreenSwitcherFunction);
        }

        public Action<Puzzle> ScreenSwitcherFunction { get; }

        public ICommand GoToIntro { get; }
    }

    public class PuzzleScreen : Screen
    {
        public PuzzleViewModel PuzzleViewModel { get; }

        public PuzzleScreen(Navigator navigator, Puzzle puzzle) : base(navigator)
        {
            this.GoToMenu = new EnabledCommand(() => SwitchTo(new MenuScreen(navigator)));
            this.PuzzleViewModel = new PuzzleViewModel(puzzle);
            PuzzleViewModel.IsSolved.ValueChanged += IsSolved_ValueChanged;
        }

        private void IsSolved_ValueChanged()
        {
            PuzzleViewModel.IsSolved_ValueChanged();
            SoundPlayer soundPlayer = new SoundPlayer(@"Clapping_sound.wav");
            soundPlayer.Play();
            MessageBox.Show("Puzzle solved in " + PuzzleViewModel.ElapsedTime.Value + "!", "Resolved");
            soundPlayer.Stop();
        }

        public ICommand GoToMenu { get; }
    }
}
