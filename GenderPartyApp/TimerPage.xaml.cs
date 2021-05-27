using System;
using System.Collections.Generic;
using System.Media;
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

namespace GenderPartyApp
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class TimerPage : Page
    {
        DispatcherTimer _timer;
        TimeSpan _time;
        public TimerPage(string response_string)
        {
            InitializeComponent();
            SoundPlayer player = new SoundPlayer(System.AppDomain.CurrentDomain.BaseDirectory + "src/clock-ticking.wav");
            
            response_string = response_string.ToUpper();
            _time = TimeSpan.FromSeconds(10);
            player.Play();
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                timer.Text = _time.Seconds.ToString();            
                if (_time == TimeSpan.Zero) {
                    _timer.Stop();
                    player.Stop();
                    if (response_string == "МАЛЬЧИК" || response_string == "BOY") NavigationService.Navigate(new BoyPage());
                    else
                        NavigationService.Navigate(new GirlPage());
                } 
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();
            
            //resp.Text = response_string;

        }
    }
}
