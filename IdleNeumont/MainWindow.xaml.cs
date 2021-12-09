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
using System.Windows.Threading;

namespace IdleNeumont
{
   
    public partial class MainWindow : Window
    {
        // Don't worry about this
        private bool genStop = false;
        private bool gameEnd = false;

        private double score = 98;
        private double multiplier = 1.0;
        private double baseIncrement = 0.0;
        private double clickIncrement = 10.0;



        // Purchase Values
        int[] purchaseValues = new int[10];

       
        
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
            // Purchase Values Dictionary + Defaults

            // Zoom -- [0] Default -> 150
            purchaseValues[0] = 150;
            // Homework -- [1] Default -> 50
            purchaseValues[1] = 50;
            // Class -- [2] Default -> 700
            purchaseValues[2] = 700;
            // Group Work -- [3] Default -> 450
            purchaseValues[3] = 450;
            //projects --[4] Defult -> 2000
            purchaseValues[4] = 2000;
            //tuotring --[5] Default ->850
            purchaseValues[5] = 850;


            genStop = true;

            // Thread creaton stuff
            ThreadStart backRef = new ThreadStart(callBackThread);
            Thread backThread = new Thread(backRef);
            backThread.Start();

           

        }



        


        // CREATE SOUNDS -> DIRECTORY MANAGEMENT FOR RELATIVE FILEPATH
        System.Media.SoundPlayer startSound = new System.Media.SoundPlayer(((Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName) + @"\IdleNeumont\Resources\startup.wav"));
        System.Media.SoundPlayer backgroundSound = new System.Media.SoundPlayer(((Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName) + @"\IdleNeumont\Resources\background.wav"));

        // CREATE BRUSHES/UI CHANGES 
        ImageBrush gameBackground = new ImageBrush(new BitmapImage(new Uri(((Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName) + @"\IdleNeumont\Resources\Background.png"))));
       

        // CREATE TIMER
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

        // SECOND THREAD FOR BACKGROUND
        private void callBackThread()
        {    
            do
            {

                if (genStop == true)
                {
                    do
                    {
                                      
                                score += baseIncrement * multiplier;

                                this.Dispatcher.Invoke(DispatcherPriority.Normal,
                                    (ThreadStart)delegate ()
                                    {
                                        txtKnowledgeNum.Text = score.ToString();
                                    }
                                    );

                                Thread.Sleep(1000);
                        
                    } while (!genStop);
                }

            } while (!gameEnd);
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
            timer.Stop();
            chaoticStart.Visibility = Visibility.Collapsed;
            neumontStart.Visibility = Visibility.Collapsed;
            stackStart.Visibility = Visibility.Collapsed;

            // Background -> White
            this.Background = Brushes.White;

            // Menu -> Visible
            mainMenu.Visibility = Visibility.Visible;

            backgroundSound.PlayLooping();
            
           
        }

        private void btn_Quit(object sender, RoutedEventArgs e)
        {

            Close();

        }

        private void btn_Settings(object sender, RoutedEventArgs e)
        {

            settingsWindow.Visibility = Visibility.Visible;
            mainMenu.Visibility = Visibility.Collapsed;

        }

        private void btn_LoadGame(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Newgame(object sender, RoutedEventArgs e)
        {
            
            
            mainMenu.Visibility = Visibility.Collapsed;
            gameWindow.Visibility = Visibility.Visible;
            this.Background = gameBackground;
           
            Game();
        }
        //local variables for states
       
        
        private void btn_Study(object sender, RoutedEventArgs e)
        {
            score += clickIncrement;
            txtKnowledgeNum.Text = score.ToString();
        }

        private void btn_Zoom(object sender, RoutedEventArgs e)
        {
            
            if(score >= purchaseValues[0])
            {
              
                score -= purchaseValues[0];

                purchaseValues[0] = purchaseValues[0] + 105;

                zoomCostTxt.Text = purchaseValues[0].ToString();

                baseIncrement += 1;

                txtKnowledgeNum.Text = score.ToString();

                classBtn.Visibility = Visibility.Visible;
                classCostTxt.Visibility = Visibility.Visible;
            }



        }

        private void btn_Homework(object sender, RoutedEventArgs e)
        {
            
            if (score >= purchaseValues[1])
            {

                score -= purchaseValues[1];

                purchaseValues[1] = purchaseValues[1] + 60;

                homeworkCostTxt.Text = purchaseValues[1].ToString();

                clickIncrement += 1;

                txtKnowledgeNum.Text = score.ToString();

                groupBtn.Visibility = Visibility.Visible;
                groupCostTxt.Visibility = Visibility.Visible;
            }
        }

        private void btn_Class(object sender, RoutedEventArgs e)
        {
      
            if (score >= purchaseValues[2])
            {

                score -= purchaseValues[2];

                purchaseValues[2] = purchaseValues[2] + 650;

                classCostTxt.Text = purchaseValues[2].ToString();

                baseIncrement += 3;

                txtKnowledgeNum.Text = score.ToString();

                tutorBtn.Visibility = Visibility.Visible;
                tutorCostTxt.Visibility = Visibility.Visible;
            }
        }

        private void btn_GroupWork(object sender, RoutedEventArgs e)
        {
        
            if (score >= purchaseValues[3])
            {

                score -= purchaseValues[3];

                purchaseValues[3] = purchaseValues[3] + 400;

                groupCostTxt.Text = purchaseValues[3].ToString();

                clickIncrement += 3;

                txtKnowledgeNum.Text = score.ToString();

                projectBtn.Visibility = Visibility.Visible;
                projectCostTxt.Visibility = Visibility.Visible;
            }
        }
        private void btn_projects(object sender, RoutedEventArgs e)
        {
            if(score >= purchaseValues[5])
            {
                score -= purchaseValues[5];
                purchaseValues[5] = purchaseValues[5] + 750;
                projectCostTxt.Text = purchaseValues[5].ToString();
                clickIncrement = +5;
                txtKnowledgeNum.Text = score.ToString();
            }
        }

        private void btn_Tutoring(object sender, RoutedEventArgs e)
        {

            if (score >= purchaseValues[4])
            {

                score -= purchaseValues[4];

                purchaseValues[4] = purchaseValues[4] + 750;

                tutorCostTxt.Text = purchaseValues[4].ToString();

                baseIncrement += 5;

                txtKnowledgeNum.Text = score.ToString();
            }
        }

        private void btn_Menu(object sender, RoutedEventArgs e)
        {
    
            settingsWindow.Visibility = Visibility.Collapsed;
            mainMenu.Visibility = Visibility.Visible;
        }
    }
}
