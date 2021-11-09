using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Helixoft.MultiLineSearch.SearchReplace;
using System.ComponentModel;
using System.Diagnostics;
using swf = System.Windows.Forms;
using System.Windows.Interop;
using Helixoft.MultiLineSearch.Settings;


namespace Helixoft.MultiLineSearch.Gui
{
    /// <summary>
    /// Interaction logic for MultilineSearchControl.xaml
    /// </summary>
    public partial class MultilineSearchControl : UserControl
    {

        /// <summary>
        /// Gets or sets all saved searches.
        /// </summary>
        /// <value></value>
        private SavedSearchList SavedSearches;


        #region "Events"

        /// <summary>
        /// Occurs before the search is executed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <remarks>This event occurs before the control executes a search
        /// initiated with any of the search buttons.
        /// You can change the search parameters by modifying properties
        /// of the <see cref="BeforeSearchEventArgs"/> passed to your event handler.
        /// To cancel the search, set the Cancel property
        /// of the <see cref="BeforeSearchEventArgs"/> passed to your event handler to true.</remarks>
        public event EventHandler<BeforeSearchEventArgs> BeforeSearch;


        /// <summary>
        /// Occurs after the search is executed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <remarks>This event occurs after the control executes a search
        /// initiated with any of the search buttons.
        /// </remarks>
        public event EventHandler<AfterSearchEventArgs> AfterSearch;

        #endregion


        #region "Properties"

        /// <summary>
        /// Gets or sets a search provider.
        /// </summary>
        /// <value>If set to null, the search replace operations will not be performed.</value>
        public ISearchReplaceProvider SearchProvider
        {
            get { return (ISearchReplaceProvider)GetValue(SearchProviderProperty); }
            set { SetValue(SearchProviderProperty, value); }
        }
        // Using a DependencyProperty as the backing store for SearchProvider.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchProviderProperty =
            DependencyProperty.Register("SearchProvider", typeof(ISearchReplaceProvider), typeof(MultilineSearchControl), new PropertyMetadata(null));


        /// <summary>Sets search and replace options for this dialog.</summary>
        /// <value>The value also specifies which button was pressed.</value>
        /// <remarks>Setting this value creates a copy of the supplied value
        /// so that it couldn't be modified from outside.</remarks>
        public FindReplaceOptions SearchOptions
        {
            get { return (FindReplaceOptions)GetValue(SearchOptionsProperty); }
            set {
                if (value == null)
                {
                    throw new NullReferenceException("value");
                }
                value = value.Clone();
                SetValue(SearchOptionsProperty, value); }
        }
        // Using a DependencyProperty as the backing store for SearchOptions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchOptionsProperty =
            DependencyProperty.Register("SearchOptions", typeof(FindReplaceOptions), typeof(MultilineSearchControl), new PropertyMetadata(new FindReplaceOptions()));


        /// <summary>
        /// Gets or sets a plain multiline text to be searched.
        /// </summary>
        public string FindText
        {
            get { return (string)GetValue(FindTextProperty); }
            set { SetValue(FindTextProperty, value); }
        }
        // Using a DependencyProperty as the backing store for FindText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FindTextProperty =
            DependencyProperty.Register("FindText", typeof(string), typeof(MultilineSearchControl), new PropertyMetadata(""));


        ///<summary>Gets plain multiline replace text.</summary>
        ///<value></value>
        public string ReplaceText
        {
            get { return (string)GetValue(ReplaceTextProperty); }
        }
        // Using a DependencyProperty as the backing store for ReplaceText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReplaceTextProperty =
            DependencyProperty.Register("ReplaceText", typeof(string), typeof(MultilineSearchControl), new PropertyMetadata(""));


        #endregion

        public MultilineSearchControl()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Initialize the control.
        /// </summary>
        /// <remarks></remarks>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            // set a help file
            try
            {
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(path), "MultiLineSearch.chm");
                HelpProvider.HelpNamespace = path;
                HelpProvider.HelpEnabled = true;
            }
            catch (Exception)
            {
            }
        }




        /// <summary>
        /// Initializes the control with specified options.
        /// </summary>
        /// <param name="options"></param>
        /// <remarks></remarks>
        public void SetOptions(MultilineSearchControlOptions options)
        {
            this.expander.IsExpanded = !options.IsFindOptionsCollapsed;

            // Just a note:
            // This control need not to be in final size now.
            // this.Height may be NaN, which is not a problem. We can set % heights now.
            // The control will be then correctly resized by window frame later.

            GridLength h = new GridLength(options.SplitterPosition, GridUnitType.Star);
            this.FindGridRow.Height = h;
            h = new GridLength(100-options.SplitterPosition, GridUnitType.Star);
            this.ReplaceGridRow.Height = h;
            this.SavedSearches = options.SavedSearches;
        }


        /// <summary>
        /// Gets control options.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public MultilineSearchControlOptions GetOptions()
        {
            MultilineSearchControlOptions options = new MultilineSearchControlOptions();
            options.IsFindOptionsCollapsed = !this.expander.IsExpanded;
            double heightPerc = 100 * this.FindGridRow.Height.Value / (this.FindGridRow.Height.Value  + this.ReplaceGridRow.Height.Value);
            options.SplitterPosition = Convert.ToInt32(heightPerc);
            options.SavedSearches = this.SavedSearches;

            return options;
        }


        /// <summary>
        /// Shows the F1 help for a specified control.
        /// </summary>
        /// <param name="control"></param>
        /// <remarks></remarks>
        private void ShowF1Help(UIElement control)
        {
            if (!string.IsNullOrEmpty(HelpProvider.HelpNamespace))
            {
                HelpProvider.ShowHelp(control);
            }
        }


        /// <summary>
        /// Closes the owner window of this control.
        /// </summary>
        private void CloseWindow()
        {
            try
            {
                Window.GetWindow(this).Close();
            }
            catch (Exception)
            {
            }
        }


        /// <summary>
        /// Raises the <see cref="BeforeSearch"/> event.
        /// </summary>
        /// <param name="e"></param>
        /// <remarks></remarks>
        protected virtual void OnBeforeSearch(BeforeSearchEventArgs e)
        {
            if (BeforeSearch != null)
            {
                BeforeSearch(this, e);
            }
        }


        /// <summary>
        /// Raises the <see cref="AfterSearch"/> event.
        /// </summary>
        /// <param name="e"></param>
        /// <remarks></remarks>
        protected virtual void OnAfterSearch(AfterSearchEventArgs e)
        {
            if (AfterSearch != null)
            {
                AfterSearch(this, e);
            }
        }


        #region "Search, replace, regex"

        /// <summary>
        /// Executes a search/replace and raises appropriate events.
        /// </summary>
        /// <remarks></remarks>
        private void ExecuteSearchReplace()
        {
            BeforeSearchEventArgs args1 = new BeforeSearchEventArgs(this.SearchOptions, this.FindText, this.ReplaceText);
            OnBeforeSearch(args1);

            if (this.SearchProvider == null)
            {
                args1.Cancel = true;
            }
            if (!args1.Cancel)
            {
                this.SearchProvider.ExecSearchReplace(this.SearchOptions, this.FindText, this.ReplaceText);

                AfterSearchEventArgs args2 = new AfterSearchEventArgs(this.SearchOptions, this.FindText, this.ReplaceText);
                OnAfterSearch(args2);
            }
        }

        #endregion


        #region Event handlers


        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
                e.Handled = true;
            }
            catch (Exception)
            {
            }
        }


        private void HelpIgnoreWs_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ShowF1Help(sender as UIElement);
            }
            catch (Exception)
            {
            }
        }


        /// <summary>
        /// Let the control process ESC.
        /// </summary>
        private void MultilineSearchControl1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.Key )
                {
                    case Key.Escape:
                        CloseWindow();
                        break;
                    //case Key.F1:
                    //    ShowF1Help(sender as UIElement);
                    //    break;
                    default:
                        break;
                }

            }
            catch (Exception)
            {
            }
        }


        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchOptions.SearchKind = FindReplaceKind.Find;
                ExecuteSearchReplace();
            }
            catch (Exception)
            {
            }
        }


        private void FindInFilesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchOptions.SearchKind = FindReplaceKind.FindInFiles;
                ExecuteSearchReplace();
            }
            catch (Exception)
            {
            }
        }

        private void ReplaceBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchOptions.SearchKind = FindReplaceKind.Replace;
                ExecuteSearchReplace();
            }
            catch (Exception)
            {
            }
        }

        private void ReplaceInFilesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchOptions.SearchKind = FindReplaceKind.ReplaceInFiles;
                ExecuteSearchReplace();
            }
            catch (Exception)
            {
            }
        }


        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var searchesDlg = new SavedSearchesManager();
                searchesDlg.SearchList = this.SavedSearches;
                searchesDlg.ShowDialog();
                if (searchesDlg.DialogResult.HasValue && searchesDlg.DialogResult.Value)
                {
                    // save searches, some could be possible deleted
                    this.SavedSearches = searchesDlg.SearchList;

                    // apply loaded search
                    var s = searchesDlg.SelectedSearch;
                    if (s != null)
                    {
                        this.FindBox.Text = s.FindText;
                        this.ReplaceBox.Text = s.ReplaceWith;
                        this.CheckBoxIgnoreLeadWs.IsChecked = s.IgnoreLeadingWs;
                        this.CheckBoxIgnoreTrailWs.IsChecked = s.IgnoreTrailingWs;
                        this.CheckBoxIgnoreAllWs.IsChecked = s.IgnoreAllWs;
                    }
                }
            }
            catch (Exception)
            {
                //throw;
            }
        }


        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var inputBox = new InputBox("New search name:", "Enter name");
                if (inputBox.ShowDialog() == true)
                {
                    if (!string.IsNullOrEmpty(inputBox.Answer))
                    {
                        var newSearch = new SavedSearch();
                        newSearch.Name = inputBox.Answer;
                        newSearch.FindText = this.FindText;
                        newSearch.ReplaceWith = this.ReplaceText;
                        newSearch.IgnoreLeadingWs = this.SearchOptions.IgnoreLeadingWhitespaces;
                        newSearch.IgnoreTrailingWs = this.SearchOptions.IgnoreTrailingWhitespaces;
                        newSearch.IgnoreAllWs = this.SearchOptions.IgnoreAllWhitespaces;

                        int existingIndex = this.SavedSearches.FindIndex(s => s.Name == newSearch.Name);
                        if (existingIndex >= 0)
                        {
                            var dlgres = System.Windows.MessageBox.Show($"A search with the name \"{newSearch.Name}\" already exists.\n\nOverwrite?", "Name exists", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (dlgres == MessageBoxResult.Yes)
                            {
                                this.SavedSearches[existingIndex] = newSearch;
                            }
                        }
                        else
                        {
                            this.SavedSearches.Add(newSearch);
                        }
                    }
                }
            }
            catch (Exception)
            {
                //throw;
            }
        }


        #endregion

    }
}