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

            ThreadStart backRef = new ThreadStart(callBackThread);
          

            Thread backThread = new Thread(backRef);
            backThread.Start();

            
        }

        public void callBackThread()
        {


            do
            {
                try
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        numText.Text = (int.Parse(numText.Text) + 1).ToString();
                    });
                } catch (TaskCanceledException e)
                {
                    Console.WriteLine(e);
                }

                Thread.Sleep(50);
            } while (!genStop);
            
        }

    }
}
