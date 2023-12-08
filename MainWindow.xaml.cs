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

namespace DavidAbarca_Prog2_Final
{
    // Section 1 : Name Example
    // David Abarca
    // 12.7.2023
    // Programming 2 Final

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Tasks> _tasks;


        public MainWindow()
        {
            InitializeComponent();
            Preload();

            lvTasks.ItemsSource = _tasks;

            rtbDisplay.Text = _tasks[0].DisplayInformation();



        } // main window

            //Tasks Homework = new Tasks(false, "homework", true, true, "Programming GA");

            
        

        public void Preload()
        {
            _tasks = new List<Tasks>()
            {
                 new Tasks(false, "Practice Basic Moves", true, true, "Master fundamental moves for your character"),
                new Tasks(false, "Learn Combos", true, true, "Practice and memorize effective combos"),
                new Tasks(false, "Study Frame Data", true, true, "Understand frame advantage and disadvantage"),
                new Tasks(false, "Character Matchups", true, true, "Study and learn matchups against other characters"),
                new Tasks(false, "Anti-Air Training", true, true, "Improve anti-air reactions and consistency"),
                new Tasks(false, "Blocking Practice", true, true, "Enhance defensive skills and blocking"),
                new Tasks(false, "Tech Throws", true, true, "Practice throw teching and throw baits"),
                new Tasks(false, "Footsies Training", true, true, "Improve spacing and footsies in neutral"),
                new Tasks(false, "Punish Training", true, true, "Learn and practice punishing opponent mistakes"),
                new Tasks(false, "Execution Practice", true, true, "Refine execution of special moves and combos"),
                new Tasks(false, "Watch Pro Matches", true, true, "Analyze matches of top Street Fighter players"),
                new Tasks(false, "Frame Trap Training", true, true, "Master frame traps and pressure tactics"),
                new Tasks(false, "Reversal Timing", true, true, "Practice safe and effective reversals"),
                new Tasks(false, "Adaptability Training", true, true, "Develop adaptability to different playstyles"),
                new Tasks(false, "Participate in Local Tournaments", true, true, "Gain tournament experience"),
                new Tasks(false, "Study Your Replays", true, true, "Review and analyze your own gameplay"),
                new Tasks(false, "Learn Advanced Techniques", true, true, "Master advanced character-specific techniques"),
                new Tasks(false, "Mindset and Mental Toughness", true, true, "Develop a strong competitive mindset"),
                new Tasks(false, "Networking with Players", true, true, "Connect with other players for practice and advice"),
                new Tasks(false, "Stay Updated on Patch Changes", true, true, "Keep track of game updates and changes")
            };
        }// preload



    }
}
