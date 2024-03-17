using System.Text;
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

namespace gyak03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _BackgroundName = "background.jpg";
        string[] _ImageNames = {"grabowski.jpg","kukori.jpg","kuldonc.jpg", "vili.jpg"};
        BitmapImage _biBackground;
        BitmapImage[] _biImages = new BitmapImage[8];
        Image[] _imImages;
        Random rnd = new Random();
        private DispatcherTimer _dt;
        private string imgPath = @"C:\\Users\\hokia\\Desktop\\vizprog_gyak03\\Images\\";

        public MainWindow()
        {
            _biBackground = new();
            InitializeComponent();
            _imImages = new Image[] {im10, im11, im12, im13,
                                     im20, im21, im22, im23 };
            _dt = new DispatcherTimer {
                Interval = new TimeSpan(0,0,0,0, 3000),
                IsEnabled = false
            };
            _dt.Tick += _dt_Tick;
            LoadImages();
            ShowImages();
            _dt.Start();
        }

        private void ShowImages()
        {
            for(int i = 0; i < 8; i++)
            {
                _imImages[i].Source = _biImages[i];
            }
        }

        private void LoadImages()
        {
            try
            {
 
            _biBackground = new BitmapImage(new Uri(imgPath + _BackgroundName, UriKind.RelativeOrAbsolute));
                for(int i = 0; i < 4; i++)
                {
                    _biImages[i] = new BitmapImage(new Uri(imgPath + _ImageNames[i], UriKind.RelativeOrAbsolute));
                    _biImages[i + 4] = _biImages[i];
                }

            } catch(Exception e)
            {
                MessageBox.Show(e.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void _dt_Tick(object? sender, EventArgs e)
        {
            ShowBackground();
            _dt.Stop();
        }

        private void ShowBackground()
        {
            for(int i = 0; i < 8; i++)
            {
                _imImages[i].Source = _biBackground;
            }
        }
    }
}