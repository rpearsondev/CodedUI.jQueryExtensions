CodedUI.jQueryExtensions
========================

CodedUI.jQueryExtensions is a simple set of extension methods for the Microsoft.VisualStudio.TestTools.UITesting.BrowserWindow class. It will allows you to select things in the page under test using jQuery selectors.

[CodedUI.jQueryExtensions NuGet package](https://www.nuget.org/packages/CodedUI.jQueryExtensions/)

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
CodedUI.jQueryExtensions will automatically include a jQuery script into the page if one does not already exist.

What configuration does it require?
-----------------------------------

When the CodedUI.jQueryExtensions nuget package is added to a project, a <appSetting> key will be added automatically to the app.config.

```xml
<add key="CodedUI.JQueryExtensions.jQuerySrc" value="//code.jquery.com/jquery-latest.min.js" />
```

This is the URL of the jQuery script that you would like CodedUI.jQueryExtensions to include if jQuery is not already included on that page. By default it uses the latest version of jQuery available from their CDN. You may wish to change this URL to a specific version. The version of jQuery that is loaded from the URL will be attached to window.CodedUI.jQueryExtensions.jQuery using jQuery.noConflict().


Can I use it with Visual Studio 2010, 2012, 2013 ?
----------------------------------------------

It will work with Visual Studio 2012 and 2013. 

How do I use it?
----------------

###Selecting li's from a ul with an id
```csharp
public IEnumerable<HtmlControl> GetLiElements()
{
	return Browser.JQuerySelect<HtmlControl>("#multipleElementsTest li");
}
```

###Waiting for an element to exist on a page
```csharp
public bool WaitForDivToExist()
{
	return Browser.JQueryWaitForExists("#divExistAfter5SecondsTest");
}
```

