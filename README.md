CodedUI.jQueryExtensions
========================

CodedUI.jQueryExtensions is a simple set of extension methods for the Microsoft.VisualStudio.TestTools.UITesting.BrowserWindow class. It will allow you to select things in the page under test by jQuery selector. This saves having to use the clunky ways of selecting elements that CodedUI supplies by default.

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
CodedUI.jQueryExtensions will automatticaly include a jQuery script into the page if one does not already exist.

What configuration does it require?
-----------------------------------

When the CodedUI.jQueryExtensions nuget package is added to a project, a <appSetting> key will be added automatically.

```xml
<add key="CodedUI.JQueryExtensions.jQuerySrc" value="//code.jquery.com/jquery-latest.min.js" />
```

This is the URL of the jQuery that you would like CodedUI.jQueryExtensions to include if jQuery is not already included on that page. By default it uses the latest version of jQuery available from their CDN. You may wish to change this URL to a specific version. The version of jQuery is loaded from the URL will be attched to window.CodedUI.jQueryExtensions.jQuery using jQuery.noConflict().
