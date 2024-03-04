﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Social_Media
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public ObservableCollection<Post> posts { get; set; }
        public Post currentPost = null;
        public Friend currentFriend { get; set; }

        public ViewModel ViewModel;

        public MainWindow MainWindow { get; set; }
        public UserControl2(ViewModel currentViewModel, MainWindow mainWindow)
        {
            InitializeComponent();
            MIUredi.IsEnabled = false;
            MIOdtrani.IsEnabled = false;
            ViewModel = currentViewModel;
            DataContext = currentViewModel;

            MainWindow = mainWindow;

            if (Properties.Settings.Default.UserName != null)
            {
                TBUserName.Text = Properties.Settings.Default.UserName;
                TBUserSurname.Text = Properties.Settings.Default.UserSurname;
                TBUserDesc.Text = Properties.Settings.Default.UserDesc;
                TBUserSchool.Text = Properties.Settings.Default.UserSchool;
                TBUserLocation.Text = Properties.Settings.Default.UserLocation;
            }
            MainWindow = mainWindow;
        }

        private void ListView_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            currentPost = (Post)LVPosts.SelectedItem;
            MessageBox.Show(currentPost.Content);

        }

        private void LVPosts_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentPost = (Post)LVPosts.SelectedItem;
            //ViewModel.SelectedContent = currentPost.Content;
            ViewModel.SelectedPost = currentPost;
            if (currentPost == null)
            {
                MIUredi.IsEnabled = false;
                MIOdtrani.IsEnabled = false;
            }
            else
            {
                MIOdtrani.IsEnabled = true;
                MIUredi.IsEnabled = true;
            }
        }

        private void MIIzhod_Click(object sender, RoutedEventArgs e)
        {
            Console.Write("Exit");
            System.Environment.Exit(1);
        }

        private void LVFriends_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentFriend = (Friend)LVFriends.SelectedItem;
            ViewModel.SelectedFriend = currentFriend;
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.UserName = TBUserName.Text;
            Properties.Settings.Default.UserSurname = TBUserSurname.Text;
            Properties.Settings.Default.UserDesc = TBUserDesc.Text;
            Properties.Settings.Default.UserSchool = TBUserSchool.Text;
            Properties.Settings.Default.UserLocation = TBUserLocation.Text;
            Properties.Settings.Default.Save();
        }

        private void MIPrivzeta_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Content = new UserControl1(ViewModel, MainWindow);
        }
    }
}
