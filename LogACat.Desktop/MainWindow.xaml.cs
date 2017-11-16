using LogACat.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;

namespace LogACat.Desktop
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		IDateTimeProvider _dateTimeProvider = new DateTimeProvider();

		public MainWindow()
		{
			InitializeComponent();

			// TODO: Remove testing...
			var node = new TreeViewItem() { Header = "Ett" };
			node.Items.Add(new TreeViewItem() { Header = "Två" });
			mediaTreeView.Items.Add(node);

			var directories = new[]
			{
				Directory.Create("Temp", null, _dateTimeProvider),
				Directory.Create("Apa", null, _dateTimeProvider),
				Directory.Create("Kaka", null, _dateTimeProvider),
				Directory.Create("Hoho jaja", null, _dateTimeProvider)
			};
			directoryListView.ItemsSource = directories;
		}

		private void MenuItem_ExitClick(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
