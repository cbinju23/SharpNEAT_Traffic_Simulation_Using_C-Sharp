﻿using NEATDrive_WPF.DrivingScripts;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace NEATDrive_WPF
{
    /// <summary>
    /// Interaction logic for ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : Window
    {
        readonly Storyboard fadeInPreview;

        DriveManager driveManager;

        public ConfigurationWindow()
        {
            InitializeComponent();

            DisableOnStart();
            fadeInPreview = (Storyboard)FindResource("PreviewPageAnim");
            fadeInPreview.Begin();
            

        }

        #region Activation Methods
        void EnableSimGrid(bool enable)
        {
            if (enable)
            {
                SimGrid.Visibility = Visibility.Visible;
            }
            else
            {
                SimGrid.Visibility = Visibility.Hidden;
            }

        }
        #endregion

        #region Enable These
        static void EnableOnStart()
        {

        }
        #endregion

        #region Disable These
        void DisableOnStart()
        {
            EnableSimGrid(false);
        }

        #endregion

        #region On Config Window Events
        private void ConfigurationWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// On Configuration Window is Loaded
            /// </summary>
            
            fadeInPreview.Begin();
            DisableOnStart();
        }
        #endregion

        #region Menu Bar Events
        void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        #endregion

        #region Left Side Options Bar Events
        private void HomeButton_Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        #endregion

        #region Right Side Options Bar Events

        private void Start_Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EnableSimGrid(true);
            ApplicationManager.instance?.FocusCanvas(SimulationCanvas);
            driveManager = new(this);
            /*if (driveManager.isSimStart())
            {*/
            driveManager.InitTimer();
                
            driveManager.StartSim();
            
            
        }

        internal void SimLoop(object? sender, EventArgs e)
        {
            driveManager.UpdateCarPosition();
        }

        #endregion

        #region Window Sim Controls
        private void ConfigurationWindow1_KeyDown(object sender, KeyEventArgs e)
        {
            driveManager.DirectionalDrivePress(e);

        }
        private void ConfigurationWindow1_KeyUp(object sender, KeyEventArgs e)
        {
            driveManager.DirectionalDriveRelease(e);

        }


        #endregion

        
    }
}
