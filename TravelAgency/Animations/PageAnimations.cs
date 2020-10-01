using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace TravelAgency
{
    /// <summary>
    /// Helpers to animate pages in specific way
    /// </summary>
    public static class PageAnimations
    {
        /// <summary>
        /// Slides a page in from the right
        /// </summary>
        /// <param name="page">The page to animate</param>
        /// <param name="seconds">The time the animation take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideFromRight(seconds, page.WindowWidth);

            //Add fade in animation
            sb.AddFadeIn(seconds);

            // Start animating
            sb.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides a page out to the left
        /// </summary>
        /// <param name="page">The page to animate</param>
        /// <param name="seconds">The time the animation take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideToLeft(seconds, page.WindowWidth);

            //Add fade in animation
            sb.AddFadeOut(seconds);

            // Start animating
            sb.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides a page in from the bottom
        /// </summary>
        /// <param name="page">The page to animate</param>
        /// <param name="seconds">The time the animation take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromBottom(this Page page, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideFromBottom(seconds, page.WindowHeight);

            //Add fade in animation
            sb.AddFadeIn(seconds);

            // Start animating
            sb.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides a page out to the bottom
        /// </summary>
        /// <param name="page">The page to animate</param>
        /// <param name="seconds">The time the animation take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToUpwards(this Page page, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideToUpwards(seconds, page.WindowHeight);

            //Add fade in animation
            sb.AddFadeOut(seconds);

            // Start animating
            sb.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }
    }
}
