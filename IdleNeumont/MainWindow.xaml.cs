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
        private bool genStop = false;

        double score = 0;
        private double multiplier = 1.0;
        private double baseIncrement = 1.0;

        public MainWindow()
        {
            InitializeComponent();
            
            // TIMER TimeSpan SYNTAX -> (Days, Hours, Minutes, Seconds, Milliseconds)
            timer.Interval = new TimeSpan(0,0,0,1,300);
            // WHEN INTERVAL -> RUN loadStart
            timer.Tick += loadStart;

            timer.Start();
            startSound.Play();


          
            // FUK THIS TIMER SHIT I SHALL JUST USE THREAD.SLEEP - I WILL FIX ALL THIS TO MAKE IT NICER AND USE THREAD.SLEEP (MARTIN)


        }

        // GAME METHOD REEE
        private void Game()
        {

            // Thread creaton stuff
            ThreadStart backRef = new ThreadStart(callBackThread);
            Thread backThread = new Thread(backRef);
            backThread.Start();



        }



        


        // CREATE SOUNDS -> DIRECTORY MANAGEMENT FOR RELATIVE FILEPATH
        System.Media.SoundPlayer startSound = new System.Media.SoundPlayer(((Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName) + @"\IdleNeumont\Resources\startup.wav"));

        // CREATE BRUSHES/UI CHANGES 
        ImageBrush gameBackground = new ImageBrush(new BitmapImage(new Uri(((Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName) + @"\IdleNeumont\Resources\Background.png"))));
       

        // CREATE TIMER
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

        int sleeptime = 500;

        // SECOND THREAD FOR BACKGROUND
        public void callBackThread()
        {

            do
            {
                // IDLE KNOWLEDGE
                Action action = () =>
                {
                    score = (score + (baseIncrement * multiplier));
                    txtKnowledgeNum.Text = score.ToString();
                }; Dispatcher.BeginInvoke(action);

                Thread.Sleep(sleeptime);
            } while (!genStop);
                
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
            timer.Interval = new TimeSpan(0, 0, 0, 2, 0);
            timer.Tick += loadingTime;
            timer.Start();
        }

        private void loadingTime(object sender, EventArgs e)
        {
            // Blanking Load Window 
            chaoticStart.Visibility = Visibility.Collapsed;
            neumontStart.Visibility = Visibility.Collapsed;
            stackStart.Visibility = Visibility.Collapsed;

            // Background -> White
            this.Background = Brushes.White;

            // Menu -> Visible
            mainMenu.Visibility = Visibility.Visible;
            
            // Run the actual game xd
           
        }

        private void btn_Quit(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Settings(object sender, RoutedEventArgs e)
        {

        }

        private void btn_LoadGame(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Newgame(object sender, RoutedEventArgs e)
        {
            
            timer.Stop();
            mainMenu.Visibility = Visibility.Collapsed;
            gameWindow.Visibility = Visibility.Visible;
            this.Background = gameBackground;
        }
        //local variables for states
       
        
        private void btn_Study(object sender, RoutedEventArgs e)
        {
            score = (score + 2);
            txtKnowledgeNum.Text = score.ToString();
        }

        private void btn_Zoom(object sender, RoutedEventArgs e)
        {
            Game();
            int purchase = 100;
            if(score <= purchase)
            {
                sleeptime -= 100;
                purchase += 100;
            }

        }

        private void btn_Homework(object sender, RoutedEventArgs e)
        {

        }
    }
}
