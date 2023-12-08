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

        List<Categories> _categories;

        Tasks selectedItem;
        Categories selectedCategory;


        public MainWindow()
        {
            InitializeComponent();
            Preload();

            cmbCategories.ItemsSource = _categories;

            //lvTasks.ItemsSource = _tasks;

            //rtbDisplay.Text = _tasks[0].DisplayInformation();



        } // main window

        //Tasks Homework = new Tasks(false, "homework", true, true, "Programming GA");

        private void lvTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int selectedIndex = lvTasks.SelectedIndex;

            selectedItem = selectedCategory.Tasks[0];



            //selectedItem = _tasks[selectedIndex];


            if (selectedItem != null)
            {
                rtbDisplay.Text = selectedItem.DisplayInformation();


            }




        }


        public void Preload()
        {

            _categories = new List<Categories>();

            // Index 0
            _categories.Add(new Categories("Training Mode"));
            _categories[0].AddItem(new Tasks(false, "Practice Basic Moves", true, true, "Master fundamental moves for your character"));
            _categories[0].AddItem(new Tasks(false, "learn combos", true, true, "practice and memorize effective combos"));
            _categories[0].AddItem(new Tasks(false, "anti-air training", true, true, "improve anti-air reactions and consistency"));
            _categories[0].AddItem(new Tasks(false, "blocking practice", true, true, "enhance defensive skills and blocking"));
            _categories[0].AddItem(new Tasks(false, "tech throws", true, true, "practice throw teching and throw baits"));
            _categories[0].AddItem(new Tasks(false, "footsies training", true, true, "improve spacing and footsies in neutral"));
            _categories[0].AddItem(new Tasks(false, "punish training", true, true, "learn and practice punishing opponent mistakes"));
            _categories[0].AddItem(new Tasks(false, "execution practice", true, true, "refine execution of special moves and combos"));
            _categories[0].AddItem(new Tasks(false, "frame trap training", true, true, "master frame traps and pressure tactics"));
            _categories[0].AddItem(new Tasks(false, "reversal timing", true, true, "practice safe and effective reversals"));
            _categories[0].AddItem(new Tasks(false, "adaptability training", true, true, "develop adaptability to different playstyles"));
            _categories[0].AddItem(new Tasks(false, "learn advanced techniques", true, true, "master advanced character-specific techniques"));




            // Index 1
            _categories.Add(new Categories("Vod Review"));
            _categories[1].AddItem(new Tasks(false, "study frame data", true, true, "understand frame advantage and disadvantage"));
            _categories[1].AddItem(new Tasks(false, "character matchups", true, true, "study and learn matchups against other characters"));
            _categories[1].AddItem(new Tasks(false, "watch pro matches", true, true, "analyze matches of top street fighter players"));
            _categories[1].AddItem(new Tasks(false, "study your replays", true, true, "review and analyze your own gameplay"));

            // Index 2
            _categories.Add(new Categories("Perspective"));
            _categories[2].AddItem(new Tasks(false, "participate in local tournaments", true, true, "gain tournament experience"));
            _categories[2].AddItem(new Tasks(false, "mindset and mental toughness", true, true, "develop a strong competitive mindset"));
            _categories[2].AddItem(new Tasks(false, "networking with players", true, true, "connect with other players for practice and advice"));
            _categories[2].AddItem(new Tasks(false, "stay updated on patch changes", true, true, "keep track of game updates and changes"));



            //_tasks = new list<tasks>()
            //{



            //};
        }// preload

        private void cmbCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // getting the selected index of the category
            int ctgIndex = cmbCategories.SelectedIndex;

            // Getting the selected Category
            selectedCategory = _categories[ctgIndex];

            // assigning the Task ti the list view
            lvTasks.ItemsSource = selectedCategory.Tasks;

        }// cmbCategories

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string newCategory = txtCategory.Text.Trim();

            if (!string.IsNullOrEmpty(newCategory))
            {
                // Add the new category to the existing collection
                _categories.Add(new Categories(newCategory));

                // Refresh the ComboBox by resetting its ItemsSource
                cmbCategories.ItemsSource = null;  // Resetting the ItemsSource
                cmbCategories.ItemsSource = _categories;  // Setting it back to the updated collection

                // Clear the TextBox for the next input
                txtCategory.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a category name.");
            }
        }

        private void btnAddToList_Click(object sender, RoutedEventArgs e)
        {
            string newTask = txtTask.Text.Trim();
            string newDescription;

            TextRange textRange = new TextRange(rtbDescription.ContentStart, rtbDescription.ContentEnd);
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                textRange.Save(ms, DataFormats.Text);
                newDescription = ms.ToArray().Length == 0 ? string.Empty : System.Text.Encoding.Default.GetString(ms.ToArray());
            }

            newDescription = newDescription.Trim();
            bool highImportance = cbHigh.IsChecked ?? false;
            bool timeSensitive = cbTime.IsChecked ?? false;
            bool completed = rdbComplete.IsChecked ?? false;

            if (!string.IsNullOrEmpty(newTask))
            {
                // Add the new task to the selected category
                selectedCategory?.AddItem(new Tasks(completed, newTask, highImportance, timeSensitive, newDescription));

                // Refresh the ListView by resetting its ItemsSource
                lvTasks.ItemsSource = null;
                lvTasks.ItemsSource = selectedCategory?.Tasks;

                // Clear the input controls for the next input
                txtTask.Clear();

                cbHigh.IsChecked = false;
                cbTime.IsChecked = false;
                rdbComplete.IsChecked = false;
                rdbNotComplete.IsChecked = false;
            }
            else
            {
                MessageBox.Show("Please enter a task name.");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lvTasks.SelectedItems.Count > 0)
            {
                foreach (var selectedItem in lvTasks.SelectedItems)
                {
                    if (selectedItem is Tasks selectedTask)
                    {
                        // Update task properties based on user input
                        selectedTask.Name = txtTask.Text.Trim();

                        // Get the new description from the RichTextBox
                        string newDescription = new TextRange(rtbDescription.ContentStart, rtbDescription.ContentEnd).Text.Trim();
                        selectedTask.Description = newDescription;

                        // Get the values of checkboxes and radio buttons
                        cbHigh.IsChecked.GetValueOrDefault();
                        cbTime.IsChecked.GetValueOrDefault();
                        rdbComplete.IsChecked.GetValueOrDefault();
                    }
                }

                // Refresh the ListView by resetting its ItemsSource
                lvTasks.ItemsSource = null;
                lvTasks.ItemsSource = selectedCategory?.Tasks;

                // Clear input controls for the next input
                txtTask.Clear();

                cbHigh.IsChecked = false;
                cbTime.IsChecked = false;
                rdbComplete.IsChecked = false;
                rdbNotComplete.IsChecked = false;
            }
            else
            {
                MessageBox.Show("Please select a task to update.");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            // Clear the selected item in the ListView
            lvTasks.SelectedIndex = -1;

            // Clear input controls
            txtTask.Clear();
            
            cbHigh.IsChecked = false;
            cbTime.IsChecked = false;
            rdbComplete.IsChecked = false;
            rdbNotComplete.IsChecked = false;
        }
    }
}
