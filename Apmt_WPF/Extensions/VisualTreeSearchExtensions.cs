using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Apmt_WPF.Extensions
{
    public static class VisualTreeSearchExtensions
    {
        public static IEnumerable<ContentControl> FindNavigationTargetByName(DependencyObject parent, string targetName)
        {
            if (parent == null) yield break;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is ContentControl cc && cc.Name == targetName)
                {
                    yield return cc;
                }
                foreach (var item in FindNavigationTargetByName(child, targetName))
                {
                    yield return item;
                }
            }
        }
    }
}
