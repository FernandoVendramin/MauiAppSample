using System;

namespace MauiAppSample.Models
{
	public class FlyoutPageItem
	{
        public FlyoutPageItem(string title, string iconSource, Type targetType)
        {
            Title = title;
            IconSource = iconSource;
            TargetType = targetType;
        }

        public string Title { get; set; }

		public string IconSource { get; set; }

		public Type TargetType { get; set; }
	}
}
