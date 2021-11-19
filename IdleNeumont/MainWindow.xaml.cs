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
using System.Media;
using System.IO;

namespace IdleNeumont
{
   
    public partial class MainWindow : Window
    {
        // Don't worry about this
        bool genStop = false;

        public MainWindow()
        {
            InitializeComponent();

            
            // TIMER TimeSpan SYNTAX -> (Days, Hours, Minutes, Seconds, Milliseconds)
            timer.Interval = new TimeSpan(0,0,0,1,300);
            // WHEN INTERVAL -> RUN loadStart
            timer.Tick += loadStart;

            timer.Start();
            startSound.Play();


            // Thread creaton stuff
            ThreadStart backRef = new ThreadStart(callBackThread);
            Thread backThread = new Thread(backRef);
            backThread.Start();



        }


        //

        
        // CREATE SOUND -> DIRECTORY MANAGEMENT FOR RELATIVE FILEPATH
        System.Media.SoundPlayer startSound = new System.Media.SoundPlayer(((Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName) + @"\IdleNeumont\Resources\startup.wav"));
           
        // CREATE TIMER
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();


        // SECOND THREAD FOR BACKGROUND
        public void callBackThread()
        {
                // THIS IS EXAMPLE OF OWNERSHIP SHARE/ TRANSFER 
/*             
                Action action = () =>
                {
                  
                };
                Dispatcher.BeginInvoke(action);
*/               
                
        }



        // WEIRD TIMER SHIT
        private void loadStart(object sender, EventArgs e)
        {
            // Stop timer To Run
            timer.Stop();

            // Load Main Start Page
            stackStart.Visibility = Visibility.Visible;

            // Load Neumont Img
            neumontStart.Visibility = Visibility.Visible;
            
            // New Timer Shit
            timer.Interval = new TimeSpan(0, 0, 0, 2, 200);
            timer.Tick += chaosStart;
            timer.Start();
        }

        // WEIRD TIMER SHIT 2 ELECTRIC BOOGALOO
        private void chaosStart(object sender, EventArgs e)
        {

            // Stop thing to run thing bla bla bla
            timer.Stop();

            // Load Text Img
            chaoticStart.Visibility = Visibility.Visible;

            // Another timer shit
           // timer.Interval = new TimeSpan(0, 0, 0, 2, 0);
           // timer.Tick += buttonStart;
           // timer.Start();
        }


       
        
        
    }
}
