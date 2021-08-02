using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using MCViewer.Api;
using Newtonsoft.Json;

namespace BrowserSwitchDemo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private IServiceProvider _provider;

		private MCViewerResponse _response;

		public MainWindow()
		{
			_provider = GetServiceProvider();
			InitializeComponent();
			Loaded += MainWindow_LoadedAsync;

		}

		// Event handlers may be async void.
		private async void MainWindow_LoadedAsync(object sender, RoutedEventArgs e)
		{
			var payload = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "payload.json"));
			var payloadObj = JsonConvert.DeserializeObject<MCViewerRequest>(payload);
			_response = await _provider.GetRequiredService<MCViewerClient>().RequestAsync(payloadObj);
			btn_browserCompatible.IsEnabled = true;
			btn_wv2.IsEnabled = true;
		}

		private void btn_browserCompatible_Click(object sender, RoutedEventArgs e)
		{
			browser_compatible.Visibility = Visibility.Visible;
			browser_wv2.Visibility = Visibility.Hidden;

			browser_compatible.Navigate(_response.ViewUrl);
		}

		private void btn_wv2_Click(object sender, RoutedEventArgs e)
		{
			browser_compatible.Visibility = Visibility.Hidden;
			browser_wv2.Visibility = Visibility.Visible;
			browser_wv2.CoreWebView2.Navigate(_response.ViewUrl.ToString());
		}

		private void browser_compatible_Initialized(object sender, EventArgs e)
		{
			//browser_compatible.deb
		}

		private void browser_wv2_Initialized(object sender, EventArgs e)
		{
			browser_wv2.EnsureCoreWebView2Async();
		}

		private static IServiceProvider GetServiceProvider()
		{
			var serviceProvider = new ServiceCollection()
				.AddMCViewer(new Uri("https://mc.2ba.nl")); // register MCViewerClient with DependancyInjection

			return serviceProvider.BuildServiceProvider();
		}
	}
}
