using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPF_MVVM.Models.Decanat;

namespace WPF_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GroupsCollection_OnFilter(object sender, FilterEventArgs e)
        {
            // если item не является группой
            if (!(e.Item is Group group)) return;

            if (group.Name is null) return;

            var filterText = GroupNameFilterText.Text;
            if (filterText.Length == 0) return;


            if (group.Name.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            if (group.Description != null && group.Description.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;

            e.Accepted = false;
        }

        private void OnGroupsFilterTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            var collection = (CollectionViewSource)textBox.FindResource("GroupsCollection");
            collection.View.Refresh();
        }
    }
}
