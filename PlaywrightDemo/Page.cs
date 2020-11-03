using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace PlaywrightDemo
{
    public static class Links
    {
        public static string AjaxData = "//a[text()='AJAX Data']";
        public static string DyanmicID = "//a[text()='Dynamic ID']";
        public static string DynamicTable = "//a[text()='Dynamic Table']";
        public static string ProgressBar = "//a[text()='Progress Bar']";
        public static string Scrollbars = "//a[text()='Scrollbars']";
        public static string Visibility = "//a[text()='Visibility']";
        public static string MouseOver = "//a[text()='Mouse Over']";

    }

    public static class ScrollBars
    {
        public static string TargetButton = "#hidingButton";
    }

    public static class ProgressBar
    {    
        public static string TargetValue = "#progressBar[aria-valuenow='75']";
        public static string Timer = "#result";
        public static string StartButton = "#startButton";
        public static string StopButton = ("#stopButton");      
    }

    public static class DynamicTable
    {
        public static string Headers = "//span[text()='CPU']/..";
        public static string ComparisonText = ".bg-warning";

        public static string ChromeRowValue(int columnNumber) => $"//span[text()='Chrome']/../span[{columnNumber}]";
    }

    public static class MouseOver
    {
        public static string Link = "a[title='Click me']";
        public static string ClickCount = "#clickCount";
    }
}
