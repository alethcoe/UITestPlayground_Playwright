using PlaywrightSharp;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PlaywrightDemo
{
    public class TestPlayground : BaseTest, IDisposable
    {
        public TestPlayground()
        {
            if (Browser == null)
            {
                Browser = Task.Run(() => GetBrowserAsync()).Result;
            }
        }

        public void Dispose()
        {
            page?.CloseAsync();
        }


        [Fact]
        public async Task ClickHidingButton()
        {
            var context = await Browser.NewContextAsync();
            page = await context.NewPageAsync();
            await page.GoToAsync(_PageUrl);
            await page.ClickAsync(Links.Scrollbars);
            await page.ClickAsync(ScrollBars.TargetButton);

        }

        [Fact]
        public async Task WaitForProgress()
        {
            var context = await Browser.NewContextAsync();
            page = await context.NewPageAsync();
            await page.GoToAsync(_PageUrl);
            await page.ClickAsync(Links.ProgressBar);
            await page.ClickAsync(ProgressBar.StartButton);
            await page.GetInnerTextAsync(ProgressBar.TargetValue);
            await page.ClickAsync(ProgressBar.StopButton);
            var outcome = await page.GetInnerTextAsync(ProgressBar.Timer);

        }


        [Fact]
        public async Task DynamicTableTest()
        {
            var context = await Browser.NewContextAsync();
            page = await context.NewPageAsync();
            await page.GoToAsync(_PageUrl);
            await page.ClickAsync(Links.DynamicTable);

            var columns = await page.GetInnerHtmlAsync(DynamicTable.Headers);
            int CPUColumnNumber = GetColumnNumber(columns);

            var ChromeCPUText = await page.GetInnerTextAsync(DynamicTable.ChromeRowValue(CPUColumnNumber));
            var ComparisonText = await page.GetInnerTextAsync(DynamicTable.ComparisonText);
            Assert.Equal(ComparisonText, $"Chrome CPU: {ChromeCPUText}");

        }

        private int GetColumnNumber(string columns)
        {
            var headings = columns.Split('>');
            for (int i = 3; i < headings.Length; i++)
            {
                if (headings[i].StartsWith("CPU"))
                {
                    return ((i + 1) / 2);
                }
            }

            return -1;
        }



        [Fact]
        public async Task MouseOverExample()
        {
            var context = await Browser.NewContextAsync();
            page = await context.NewPageAsync();
            await page.GoToAsync(_PageUrl);
            await page.ClickAsync(Links.MouseOver);
            await page.ClickAsync(MouseOver.Link);

            //have to exit the element to be able to click Link again
            await page.HoverAsync(MouseOver.ClickCount);
            await page.ClickAsync(MouseOver.Link);
            var clickCount = await page.GetInnerTextAsync(MouseOver.ClickCount);
            Assert.Equal("2", clickCount);
         

        }

    }
}
