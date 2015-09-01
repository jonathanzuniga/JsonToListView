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
			label = new Label { Text = "Queries" };

			listView = new ListView ();
			listView.ItemTemplate = new DataTemplate(typeof(TextCell));
			listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Text");
			listView.ItemSelected += (sender, e) => {
				var qq = (RelatedTopic)e.SelectedItem;

				Device.OpenUri(new Uri(qq.FirstURL));
			};

			Content = new StackLayout {
				Padding = new Thickness (16, 20, 16, 0),
				Children = {
					label,
					listView
				}
			};
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			try {
				var sv = new RestService();
				// Activate/show spinner here.
				var qs = await sv.GetQueriesAsync();

				Xamarin.Forms.Device.BeginInvokeOnMainThread(() => {
					if (qs != null) {
						Debug.WriteLine("Found " + qs.Length + " queries.");
						label.Text = qs.Length + " queries";
						listView.ItemsSource = qs;
					}
				});

				// Inactivate/hide spinner here.
			}
			catch (Exception exception) {
				await this.DisplayAlert("Error", exception.Message, "OK");
			}
		}
	}
}
