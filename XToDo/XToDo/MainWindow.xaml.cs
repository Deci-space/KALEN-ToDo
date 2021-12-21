using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using XToDo.pages;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace XToDo
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void NavigationView_OnLoaded(object sender, RoutedEventArgs e)
        {
            //Load ToDoList from User Data
            NavigationView.MenuItems.Add(new NavigationViewItem
            {
                Content = "Sample",
                Icon = new SymbolIcon((Symbol)0xF1AD),
                Tag = "Sample"
            });

            // NavigationView doesn't load any page by default, so load home page.
            NavigationView.SelectedItem = NavigationView.MenuItems[0];

        }

        private void NavigationView_OnSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected == true)
            {
                ContentFrame.Navigate(typeof(pages.SettingsPage), null, args.RecommendedNavigationTransitionInfo);
            }
            else if (args.SelectedItemContainer != null)
            {
                if (args.SelectedItemContainer.Tag.ToString() == "HomePage")
                {
                    ContentFrame.Navigate(typeof(pages.HomePage), null, args.RecommendedNavigationTransitionInfo);
                }
            }
        }


        private void ContentFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            NavigationView.IsBackEnabled = ContentFrame.CanGoBack;

            NavigationView.Header = ((NavigationViewItem)NavigationView.SelectedItem).Content.ToString();
        }
    }
}
