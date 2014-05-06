using System.Diagnostics;
using System.IO;
using System.Reflection;
using CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Pages;
using Microsoft.Services.TestTools.UITesting.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUIjQuery.jQueryExtensions.CodedUI.Tests
{
    public abstract class AbstractPageTest
    {
        private static Process _hostedWebsite;

        public static void StartWebserver(TestContext context)
        {
            string filePath = Path.GetFullPath(
                Path.Combine(
                // ReSharper disable once AssignNullToNotNullAttribute
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "../../../CodedUI.jQueryExtensions.WebsiteHost/bin/Debug/CodedUI.jQueryExtensions.WebsiteHost.exe"));

            var processStartInfo = new ProcessStartInfo(filePath);
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardInput = true;
            _hostedWebsite = Process.Start(processStartInfo);
        }

        public static void StopWebserver()
        {
            using (StreamWriter writer = _hostedWebsite.StandardInput)
            {
                writer.WriteLine("Finish");
            }
        }
    }
}