## Version history
Version 3.3
(11\. December 2021)

* FIX: In VS 2022, the Quick Find/Replace box was not populated with the correct text and settings. Find/Replace in Files worked fine.

Version 3.2
(10\. November 2021)

* CHANGE: The default keyboard shortcut for “Multiline Find/Replace” was Ctrl+Alt+F but it was not applied because this shortcut was already taken by “F# Interactive”. So, the new default shortcut is **Ctrl+M, Ctrl+F**.

Version 3.1
(9\. November 2021)

* FIX: The regression issue from version 3.0 when button icons were not visible and clicking on “Load” button caused a crash.

Version 3.0
(8\. November 2021)

* NEW: Added support for **VS 2022**.
* CHANGE: Removed support for **VS 2013 and VS 2015**. Only VS 2022, 2019 and 2017 are supported now.

Version 2.5
(4\. March 2021)

* FIX: Find/Replace in files didn't work in **Visual Studio 2019 version 16.9 and higher**.

Version 2.4
(22\. April 2020)

*   FIX: The extension now works also in **Visual Studio 2019 version 16.5 and higher** which uses the **new implementation of Find/Replace in files**.

Version 2.3
(11\. May 2019)

*   FIX: The extension couldn't be installed in Visual Studio 2019 version 16.1 and higher.
*   FIX: The TAB character couldn't be entered in the Find and Replace text boxes. Even when it was pasted, it was converted to a space character.

Version 2.2  
(16\. April 2019)

*   NEW: Added support for **Visual Studio 2019**.
*   NEW: You can **save** an unlimited number of **your search settings** and re-use them anytime later.

Version 2.1  
(16\. January 2017)

*   FIX: After filling in the fields in the multiline search/replace dialog and pressing any of the buttons, the standard search/replace dialog appears. When this happened for the first time, its Find what field was incorrectly populated with the selected text from the editor, instead of the generated regex. This only occurred if it was set in Tools - Options - Environment - Find and Replace. This problem only occurred in version 2.0\.
*   FIX: If the replace text contained $, double $$ was inserted sometimes.

Version 2.0  
(23\. November 2016)

*   NEW: Added support for **Visual Studio 2017**.
*   NEW: **Theme colors** in VS are respected. For example, if the Dark theme is applied in VS.
*   CHANGE: **Removed** support for **Visual Studio 2005, 2008, 2010 and 2012**. Only 2013, 2015 and 2017 are supported now. This allows for better VS integration and installation.
*   CHANGE: The extension is now installed via VSIX installer, instead of MSI. Now you can easily add, remove or update the extension directly from VS. **I you have installed version 1.6 or earlier, uninstall it first from Start - Programs and Features.**

Version 1.6  
_(18\. December 2014)_

*   NEW: Added support for **Visual Studio 2015**.
*   NEW: Added support for **high DPI (Retina) screens**.

Version 1.5  
_(11\. June 2014)_

*   NEW: Added new find options: **Ignore leading whitespaces**, **Ignore trailing whitespaces**, **Ignore all whitespaces**. This way you have more flexibility with indented text, inline multiple whitespaces, etc. See the help for more details.
*   NEW: Added a short help (user guide).
*   NEW: Added automatic checking for new versions. This can be set in the options.
*   NEW: Added options under Tools/Options, Environment - Multiline Find and Replace.
*   CHANGE: Improved resizing. You can now drag the splitter and resize **Find what** and **Replace with** text boxes.
*   FIX: Ctrl+A in **Find what** and **Replace with** text boxes didn't work.

Version 1.4  
_(6\. April 2014)_

*   CHANGE: The multiline search/replace dialog is no longer modal. Now it is **modeless tool window** which can be sized and docked as any other VS tool window.
*   FIX: In VS 2012 and 2013, the "\" character in the **Replace with** field was incorrectly escaped to regex as "\\". That produced double backslash in replaced text. So if you wanted to replace with e.g. "C:\MyFolder\root\nextLevel\test", you got "C:\\MyFolder\\root\\nextLevel\\test".
*   FIX: In VS 2012 and 2013, if you replaced a string with an empty string (you wanted to delete the string), the extension produced "\9" in **Replace with** field.While this produces an empty text in VS 2005-2010, it doesn't work in newer versions. In VS 2012 and 2013, the "$+" is used now. Unfortunatelly, it's not possible to pre-populate the **Replace with** field directly with an empty text because VS automatically inserts the last used value from the history. That's why such a hack is needed.

Version 1.3  
_(28\. March 2014)_

*   FIX: Correct regex newline composition in VS 2010 **Replace with** field. When **Replace with** field contained a newline, an extra "r" character was appended at the end of line. Only VS 2010 was affected, it worked fine in all other VS versions.

Version 1.2  
_(14\. March 2014)_

*   **Find what** is automatically populated with text from the editor, if it is set in Tools - Options - Environment - Find and Replace.
*   Correct regex newline composition in VS 2010 and higher. Unlike in previous VS versions, \n is not enough in VS 2010+.

Version 1.1  
_(3\. March 2014)_

*   This extension was converted from my popular [**Multiline Search and Replace** macro](http://www.helixoft.com/blog/multiline-search-and-replace-in-visual-studio.html) which didn't work in VS 2012 and higher. I didn't add any new functionality to it.
