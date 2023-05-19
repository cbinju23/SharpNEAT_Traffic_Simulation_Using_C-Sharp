﻿using NEATDrive_WPF.DrivingScripts;
using System.Windows;

namespace NEATDrive_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (ApplicationManager.instance == null)
            {
                ApplicationManager.instance = new();
            }
            if (RoadManager.instance == null)
            {
                RoadManager.instance = new();
            }
            if (SimulationManager.instance == null)
            {
                SimulationManager.instance = new();
            }
            if (SaveManager.instance == null)
            {
                SaveManager.instance = new();
            }

        }
    }
}
