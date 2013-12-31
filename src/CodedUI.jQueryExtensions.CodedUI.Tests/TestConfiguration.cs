using System;
using System.ComponentModel.Composition;
using Microsoft.Services.TestTools.UITesting.Html;

namespace CodedUI.jQueryExtensions.CodedUI.Tests
{
    [Export(typeof (IWebUITestConfiguration))]
    public class TestConfiguration : IWebUITestConfiguration
    {
        public Uri GetBaseUri(string name)
        {
            return new Uri("http://localhost:8080");
        }
    }
}