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


namespace Helixoft.MultiLineSearch.Gui
{
    /// <summary>
    /// Interaction logic for MultilineSearchControl.xaml
    /// </summary>
    public partial class MultilineSearchControl : UserControl
    {

        #region "Events"

        /// <summary>
        /// Occurs before the control is canceled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <remarks>The Canceling event occurs as the control is being canceled with Cancel button.
        /// When a control is canceled, its parent form is closed.
        /// To cancel the closure of a form, set the Cancel property
        /// of the <see cref="CancelEventArgs"/> passed to your event handler to true.</remarks>
        public event EventHandler<CancelEventArgs> Canceling;


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
        /// Initializes the control with specified options.
        /// </summary>
        /// <param name="options"></param>
        /// <remarks></remarks>
        public void SetOptions(MultilineSearchControlOptions options)
        {
        }


        /// <summary>
        /// Gets control options.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public MultilineSearchControlOptions GetOptions()
        {
            MultilineSearchControlOptions options = new MultilineSearchControlOptions();

            return options;
        }

















        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentUICulture, "We are inside {0}.button1_Click()", this.ToString()),
                            "My Tool Window");

        }
    }
}