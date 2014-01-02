CodedUI.jQueryExtensions
========================

CodedUI.jQueryExtensions is a simple set of extension methods for the Microsoft.VisualStudio.TestTools.UITesting.BrowserWindow class. It will allows you to select things in the page under test using jQuery selectors.

What does it give me?
---------------------

#Methods

```csharp
public static IEnumerable<T> JQuerySelect<T>(this BrowserWindow window, string selector)
```

```csharp
public static bool JQueryExists(this BrowserWindow window, string selector)
```

```csharp
public static bool JQueryWaitForExists(this BrowserWindow window, string selector)
```

```csharp
public static bool JQueryWaitForExists(this BrowserWindow window, string selector, int timeoutMilliSeconds)
```

#Features
CodedUI.jQueryExtensions will automaticaly include a jQuery script into the page if one does not already exist.

What configuration does it require?
-----------------------------------

When the CodedUI.jQueryExtensions nuget package is added to a project, a <appSetting> key will be added automatically to the app.comfig.

```xml
<add key="CodedUI.JQueryExtensions.jQuerySrc" value="//code.jquery.com/jquery-latest.min.js" />
```

This is the URL of the jQuery  script that you would like CodedUI.jQueryExtensions to include if jQuery is not already included on that page. By default it uses the latest version of jQuery available from their CDN. You may wish to change this URL to a specific version. The version of jQuery that is loaded from the URL will be attached to window.CodedUI.jQueryExtensions.jQuery using jQuery.noConflict().


Can I use it with Visual Studio 2012 and 2013?
-------------------------------------

It will only currently work on with Visual Studio 2013. This is because 2012 and 2013 ship with different versions fo the Microsoft.VisualStudio.TestTools.UITesting assembly. The current nuget package references the 2013 version. This may be rectified in the next version of the nuget to be released.
