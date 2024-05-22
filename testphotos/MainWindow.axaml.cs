using System;
using Avalonia.Controls;
using testphotos.Classes;
using testphotos.Usercontrols;

namespace testphotos
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var contentControl = this.FindControl<ContentControl>("ContentControl") ?? throw new InvalidOperationException("ContentControl not found");
            NavigationManager.Initialize(contentControl);
            ShowUserControl();
        }

        private void ShowUserControl()
        {
            var contentControl = this.FindControl<ContentControl>("ContentControl") ?? throw new InvalidOperationException("ContentControl not found");
            NavigationManager.NavigateTo(new CustomMapControl());
        }
    }
}