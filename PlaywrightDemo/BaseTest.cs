using PlaywrightSharp;
using System.Threading.Tasks;

namespace PlaywrightDemo
{
    public class BaseTest
    {
        public IBrowser Browser;
        internal string _PageUrl = "http://www.uitestingplayground.com/";

        internal async Task<IBrowser> GetBrowserAsync()
        {
            await Playwright.InstallAsync();
            var playwright = await Playwright.CreateAsync();
            return await playwright.Chromium.LaunchAsync(headless: true);
        }

        public IPage page;
    }
}
