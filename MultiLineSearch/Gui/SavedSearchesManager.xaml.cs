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
using System.Windows.Shapes;
using Helixoft.MultiLineSearch.Settings;
using System.Collections.ObjectModel;

namespace Helixoft.MultiLineSearch.Gui
{
    /// <summary>
    /// Interaction logic for SavedSearchesManager.xaml
    /// </summary>
    public partial class SavedSearchesManager : Window
    {
        public SavedSearchesManager()
        {
            InitializeComponent();

            DataContext = this;

            // Need to initialize this, otherwise you get a null exception
            _SearchListBinding = new ObservableCollection<SavedSearch>();
        }


        ///// <summary>
        ///// Gets or sets the list of saved searches.
        ///// </summary>
        ///// <value></value>
        //public SavedSearchList SearchList
        //{
        //    get { return (SavedSearchList)GetValue(SearchListProperty); }
        //    set { SetValue(SearchListProperty, value); }
        //}
        //// Using a DependencyProperty as the backing store for SearchList.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SearchListProperty =
        //    DependencyProperty.Register("SearchList", typeof(SavedSearchList), typeof(SavedSearchesManager), new PropertyMetadata(new SavedSearchList()));


        /// <summary>
        /// Gets or sets the list of saved searches.
        /// </summary>
        /// <value></value>
        public SavedSearchList SearchList
        {
            get { return new SavedSearchList(_SearchListBinding.ToList()) ; }
            set { _SearchListBinding = new ObservableCollection<SavedSearch>(value); }
        }



        private ObservableCollection<SavedSearch> _SearchListBinding = new ObservableCollection<SavedSearch>();
        public ObservableCollection<SavedSearch> SearchListBinding { get { return _SearchListBinding; } }


        private SavedSearch _SelectedSearch;
        /// <summary>
        /// Gets the search selected by the user from the list.
        /// </summary>
        /// <value></value>
        public SavedSearch SelectedSearch {
            get
            {
                return _SelectedSearch;
            }
        }


        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = SearchesList.SelectedIndex;
            if (selectedIndex >= 0)
            {
                SearchListBinding.RemoveAt(selectedIndex);
            }
        }


        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSelectedSearch();
            this.DialogResult = true;
        }


        private void SearchesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SetSelectedSearch();
            this.DialogResult = true;
            this.Close();
        }


        private void SetSelectedSearch()
        {
            int selectedIndex = SearchesList.SelectedIndex;
            if (selectedIndex >= 0)
            {
                this._SelectedSearch = SearchListBinding[selectedIndex];
            }
            else
            {
                this._SelectedSearch = null;
            }
        }


    }
}
