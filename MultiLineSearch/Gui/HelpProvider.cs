using System.Windows;

using System.Windows.Forms;

using System.Windows.Input;

using System.Windows.Media;

namespace Helixoft.MultiLineSearch.Gui
{

    public static class HelpProvider
    {

        #region Fields

        /// <summary>
        /// Help keyword dependency property. 
        /// </summary>
        /// <remarks>This property can be attached to an object such as a window or a textbox, and 
        /// can be retrieved when the user presses F1 and used to display context sensitive help.</remarks>
        public static readonly DependencyProperty HelpKeywordProperty =
            DependencyProperty.RegisterAttached("HelpKeyword", typeof(string), typeof(HelpProvider),
                 new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.Inherits));


        /// <summary>
        /// Help navigator dependency property. 
        /// </summary>
        /// <remarks>This property can be attached to an object such as a window or a textbox, and 
        /// can be retrieved when the user presses F1 and used to display context sensitive help.</remarks>
        public static readonly DependencyProperty HelpNavigatorProperty =
            DependencyProperty.RegisterAttached("HelpNavigator", typeof(HelpNavigator), typeof(HelpProvider),
                                                new FrameworkPropertyMetadata(HelpNavigator.TableOfContents, FrameworkPropertyMetadataOptions.Inherits));


        /// <summary>
        /// Show help dependency property. 
        /// </summary>
        /// <remarks>This property can be attached to an object such as a window or a textbox, and 
        /// can be retrieved when the user presses F1 and used to display context sensitive help.</remarks>
        public static readonly DependencyProperty ShowHelpProperty =
            DependencyProperty.RegisterAttached("ShowHelp", typeof(bool), typeof(HelpProvider),
                new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.Inherits));

        #endregion


        #region Properties

        private static string _HelpNamespace = null;
        /// <summary>
        /// Gets or sets a value specifying the name of the Help file associated with this HelpProvider object.
        /// </summary>
        public static string HelpNamespace
        {
            get { return _HelpNamespace; }
            set { _HelpNamespace = value; }
        }


        private static bool _HelpEnabled = false;
        /// <summary>
        /// Gets or sets a value indicating whether help showing is globally enabled.
        /// </summary>
        public static bool HelpEnabled
        {
            get { return _HelpEnabled; }
            set { _HelpEnabled = value; }
        }


        private static string _NotFoundTopic = null;
        /// <summary>
        /// Gets or sets the "Not found" topic name.
        /// </summary>
        /// <value>May be null.</value>
        /// <remarks></remarks>
        public static string NotFoundTopic
        {
            get { return _NotFoundTopic; }
            set { _NotFoundTopic = value; }
        }

        #endregion


        /// <summary>
        /// Static constructor that adds a command binding to Application.Help, binding it to 
        /// the CanExecute and Executed methods of this class. 
        /// </summary>
        /// <remarks>With this in place, when the user presses F1 our help will be invoked.</remarks>
        static HelpProvider()
        {
            CommandManager.RegisterClassCommandBinding(
                typeof(FrameworkElement),
                new CommandBinding(
                    ApplicationCommands.Help,
                    new ExecutedRoutedEventHandler(OnHelpExecuted),
                    new CanExecuteRoutedEventHandler(OnHelpCanExecute)));
        }


        #region Public Methods

        #region HelpKeyword

        /// <summary>
        /// Getter for <see cref="HelpKeywordProperty"/>. Get a help keyword that's attached to an object. 
        /// </summary>
        /// <param name="obj">The object that the help keyword is attached to.</param>
        /// <returns>The help keyword.</returns>
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static string GetHelpKeyword(DependencyObject obj)
        {
            return (string)obj.GetValue(HelpKeywordProperty);
        }

        /// <summary>
        /// Setter for <see cref="HelpKeywordProperty"/>. Attach a help keyword value to an object. 
        /// </summary>
        /// <param name="obj">The object to which to attach the help keyword.</param>
        /// <param name="value">The value of the help keyword.</param>
        public static void SetHelpKeyword(DependencyObject obj, string value)
        {
            obj.SetValue(HelpKeywordProperty, value);
        }

        #endregion

        #region HelpNavigator

        /// <summary>
        /// Getter for <see cref="HelpNavigatorProperty"/>. Get a help navigator that's attached to an object. 
        /// </summary>
        /// <param name="obj">The object that the help navigator is attached to.</param>
        /// <returns>The help navigator.</returns>
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static HelpNavigator GetHelpNavigator(DependencyObject obj)
        {
            return (HelpNavigator)obj.GetValue(HelpNavigatorProperty);
        }


        /// <summary>
        /// Setter for <see cref="HelpNavigatorProperty"/>. Attach a help navigator value to an object. 
        /// </summary>
        /// <param name="obj">The object to which to attach the help navigator.</param>
        /// <param name="value">The value of the help navigator.</param>
        public static void SetHelpNavigator(DependencyObject obj, HelpNavigator value)
        {
            obj.SetValue(HelpNavigatorProperty, value);
        }

        #endregion

        #region ShowHelp

        /// <summary>
        /// Getter for <see cref="GetShowHelpProperty"/>.
        /// </summary>
        /// <param name="obj">The object that the property is attached to.</param>
        /// <returns>Value indicating whether to show the help.</returns>
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static bool GetShowHelp(DependencyObject obj)
        {
            return (bool)obj.GetValue(ShowHelpProperty);
        }


        /// <summary>
        /// Getter for <see cref="GetShowHelpProperty"/>.
        /// </summary>
        /// <param name="obj">The object that the property is attached to.</param>
        /// <param name="value">Value indicating whether to show the help.</param>
        public static void SetShowHelp(DependencyObject obj, bool value)
        {
            obj.SetValue(ShowHelpProperty, value);
        }

        #endregion


        /// <summary>
        /// Shows the help for specified control.
        /// </summary>
        /// <param name="sender"></param>
        public static void ShowHelp(object sender)
        {
            bool eHandled = false;

            DependencyObject ctl = GetHelpTargetControl(sender as DependencyObject);
            if (ctl != null && GetShowHelp(ctl))
            {
                string parameter = GetHelpKeyword(ctl);
                HelpNavigator command = GetHelpNavigator(ctl);
                if (!eHandled && !string.IsNullOrEmpty(HelpNamespace))
                {
                    if (!string.IsNullOrEmpty(parameter))
                    {
                        Help.ShowHelp(null, HelpNamespace, command, parameter);
                        eHandled = true;
                    }
                    if (!eHandled)
                    {
                        Help.ShowHelp(null, HelpNamespace, command);
                        eHandled = true;
                    }
                }

                if (!eHandled && !string.IsNullOrEmpty(HelpNamespace))
                {
                    Help.ShowHelp(null, HelpNamespace);
                    eHandled = true;
                }
            }
            else if (HelpEnabled)
            {
                if (!string.IsNullOrEmpty(NotFoundTopic))
                    Help.ShowHelp(null, HelpNamespace, NotFoundTopic);
                else
                    Help.ShowHelp(null, HelpNamespace);
                eHandled = true;
            }
        }

        #endregion



        private static void OnHelpCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CanExecuteHelp((DependencyObject)sender) || HelpEnabled;
        }


        private static bool CanExecuteHelp(DependencyObject sender)
        {
            if (sender != null)
            {
                if (GetShowHelp(sender))
                    return true;
                return CanExecuteHelp(VisualTreeHelper.GetParent(sender));
            }
            return false;
        }


        private static DependencyObject GetHelpTargetControl(DependencyObject sender)
        {
            if (sender != null)
            {
                if (GetShowHelp(sender))
                    return sender;
                return GetHelpTargetControl(VisualTreeHelper.GetParent(sender));
            }
            return null;
        }


        /// <summary>
        /// Shows the correct help.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnHelpExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            DependencyObject ctl = GetHelpTargetControl(sender as DependencyObject);
            if (ctl != null && GetShowHelp(ctl))
            {
                string parameter = GetHelpKeyword(ctl);
                HelpNavigator command = GetHelpNavigator(ctl);
                if (!e.Handled && !string.IsNullOrEmpty(HelpNamespace))
                {
                    if (!string.IsNullOrEmpty(parameter))
                    {
                        Help.ShowHelp(null, HelpNamespace, command, parameter);
                        e.Handled = true;
                    }
                    if (!e.Handled)
                    {
                        Help.ShowHelp(null, HelpNamespace, command);
                        e.Handled = true;
                    }
                }

                if (!e.Handled && !string.IsNullOrEmpty(HelpNamespace))
                {
                    Help.ShowHelp(null, HelpNamespace);
                    e.Handled = true;
                }
            }
            else if (HelpEnabled)
            {
                if (!string.IsNullOrEmpty(NotFoundTopic))
                    Help.ShowHelp(null, HelpNamespace, NotFoundTopic);
                else
                    Help.ShowHelp(null, HelpNamespace);
                e.Handled = true;
            }
        }

 
    }

}