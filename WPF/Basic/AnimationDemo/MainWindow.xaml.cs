using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AnimationDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnA_Click(object sender, RoutedEventArgs e)
        {
            Storyboard storyboard = new();
            storyboard.Children.Add(CreateDoubleAnimation(btnSampleA1, false, new RepeatBehavior(1), "Width", 30));
            storyboard.Children.Add(CreateDoubleAnimation(btnSampleA2, false, new RepeatBehavior(5), "Height", 30));
            storyboard.Children.Add(CreateDoubleAnimation(btnSampleA3, true, RepeatBehavior.Forever, "Width", 30));
            storyboard.Children.Add(CreateDoubleAnimation(btnSampleA4, true, RepeatBehavior.Forever, "Height", 30));
            storyboard.Begin();
        }
        private Timeline CreateDoubleAnimation(
            UIElement element, bool autoReverse, RepeatBehavior repeatBehavior, string propertyPath, double by)
        {
            DoubleAnimation animation = new()
            {
                From = 0,
                //To = 100,
                // 在按钮本身的宽度上 +- 30
                By = by,
                Duration = TimeSpan.FromSeconds(2),
                RepeatBehavior = repeatBehavior,
                AutoReverse = autoReverse
            };
            Storyboard.SetTarget(animation, element);
            Storyboard.SetTargetProperty(animation, new PropertyPath(propertyPath));
            return animation;
        }

        private void BtnB_Click(object sender, RoutedEventArgs e)
        {
            Storyboard storyboard = new();
            storyboard.Children.Add(
                CreateDoubleAnimation(btnSampleB1, false, new RepeatBehavior(1), "(UIElement.RenderTransform).(TranslateTransform.X)", 30));
            storyboard.Children.Add(
                CreateDoubleAnimation(btnSampleB2, false, new RepeatBehavior(5), "(UIElement.RenderTransform).(TranslateTransform.Y)", 30));
            storyboard.Children.Add(
                CreateDoubleAnimation(btnSampleB3, true, RepeatBehavior.Forever, "(UIElement.RenderTransform).(RotateTransform.Angle)", 360));
            storyboard.Children.Add(
                CreateDoubleAnimation(btnSampleB4, true, RepeatBehavior.Forever, "(UIElement.RenderTransform).(TranslateTransform.X)", 60));
            storyboard.Begin();
        }

        /// <summary>
        /// xaml中未给Button添加 Button.RenderTransform时的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnB2_Click(object sender, RoutedEventArgs e)
        {
            bool isTranslate = false;
            // 支持位移或旋转
            btnSampleB1.RenderTransform =
                isTranslate ? new TranslateTransform(0, 0) : new RotateTransform(0, 0, 0);
            double by = isTranslate ? 30 : 360;
            string propertyPath = isTranslate ?
                "(UIElement.RenderTransform).(TranslateTransform.X)" : "(UIElement.RenderTransform).(RotateTransform.Angle)";
            DoubleAnimation animation = new()
            {
                By = by,
                Duration = TimeSpan.FromSeconds(1),
            };
            Storyboard.SetTarget(animation, btnSampleB1);
            Storyboard.SetTargetProperty(animation, new PropertyPath(propertyPath));
            Storyboard storyboard = new();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            Storyboard storyboard = new();
            storyboard.Children.Add(CreateDoubleAnimation(btnSampleC1, false, new RepeatBehavior(1), "Opacity", 1));
            storyboard.Children.Add(CreateDoubleAnimation(btnSampleC2, false, new RepeatBehavior(5), "Opacity", 1));
            storyboard.Children.Add(CreateDoubleAnimation(btnSampleC3, true, RepeatBehavior.Forever, "Opacity", 1));
            storyboard.Children.Add(CreateDoubleAnimation(btnSampleC4, true, RepeatBehavior.Forever, "Opacity", 1));
            storyboard.Begin();
        }
    }
}