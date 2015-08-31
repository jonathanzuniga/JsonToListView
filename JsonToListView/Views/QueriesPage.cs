using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace JsonToListView
{
	public class QueriesPage : ContentPage
	{
		ListView listView;
		Label label;

		public QueriesPage ()
		{
			label = new Label {
				Text = "Queries",
				Font = Font.BoldSystemFontOfSize(NamedSize.Large)
			};

			var button = new Button { Text = "Get queries" };
			button.Clicked += async (sender, e) => {
				var sv = new RestService();
				var qs = await sv.GetQueriesAsync();

				Xamarin.Forms.Device.BeginInvokeOnMainThread(() => {
					if (qs != null) {
						Debug.WriteLine("found " + qs.Length + " queries");
						label.Text = qs.Length + " queries";
						listView.ItemsSource = qs;
					}
				});
			};

			listView = new ListView ();
			listView.ItemTemplate = new DataTemplate(typeof(TextCell));
			listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Text");
			listView.ItemSelected += (sender, e) => {
				var qq = (Query)e.SelectedItem;

				DisplayAlert("Query info", qq.ToString(), "OK", null);
			};

			Content = new StackLayout {
				Padding = new Thickness (0, 20, 0, 0),
				Children = {
					label,
					button,
					listView
				}
			};
		}
	}
}
