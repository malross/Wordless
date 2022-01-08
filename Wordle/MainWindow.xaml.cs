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

namespace Wordle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Settings = new Settings();
        }

        public Game Game
        {
            get { return (Game)GetValue(GameProperty); }
            set { SetValue(GameProperty, value); }
        }

        public static readonly DependencyProperty GameProperty = DependencyProperty.Register("Game", typeof(Game), typeof(MainWindow), new PropertyMetadata(null));

        public Settings Settings
        {
            get { return (Settings)GetValue(SettingsProperty); }
            set { SetValue(SettingsProperty, value); }
        }

        public static readonly DependencyProperty SettingsProperty = DependencyProperty.Register("Settings", typeof(Settings), typeof(MainWindow), new PropertyMetadata(null));

        private void NewGame()
        {
            Game = new Game(ChooseWord.OfLength(Settings.WordLength));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }
    }
}
