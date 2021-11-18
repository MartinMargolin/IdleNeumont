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
using System.Threading;

namespace IdleNeumont
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
   
    public partial class MainWindow : Window
    {
        bool genStop = false;

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = new TimeSpan(0,0,4);
            timer.Tick += loadStart;
            timer.Start();

            

            ThreadStart backRef = new ThreadStart(callBackThread);
          

            Thread backThread = new Thread(backRef);
            backThread.Start();



        }

         
        // System.Windows.Media.MediaPlayer startSound = new System.Windows.Media.MediaPlayer();    

        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

        public void callBackThread()
        {

/*             
                Action action = () =>
                {
                  
                };
                Dispatcher.BeginInvoke(action);
*/               
                
        }


        private void loadStart(object sender, EventArgs e)
        {
            timer.Stop();
            System.Media.SoundPlayer startSound = new System.Media.SoundPlayer("startup.wav");
            startSound.Play();
            stackStart.Visibility = Visibility.Visible;
            neumontStart.Visibility = Visibility.Visible;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += chaosStart;
            timer.Start();
        }

        private void chaosStart(object sender, EventArgs e)
        {
            timer.Stop();
            chaoticStart.Visibility = Visibility.Visible;
            Playscreen.Visibility = Visibility.Visible;
        }
        private void btnNextScreen(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();
        }
        
    }
}
