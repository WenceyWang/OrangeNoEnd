using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace OrangeNoEnd
{


	/// <summary>
	/// 可独立使用或用于导航至 Frame 内部的空白页。
	/// </summary>
	/// 
	public sealed partial class MainPage : Page
	{
		List<int> SettingOfCursor = new List<int>();
		List<int> SettingOfPrimary = new List<int>();
		List<int> SettingOfFarm = new List<int>();
		List<int> SettingOfMine = new List<int>();
		List<int> SettingOfLaboratory = new List<int>();
		List<int> SettingOfSpaceCraft = new List<int>();
		List<int> SettingOfReactor = new List<int>();
		List<int> SettingOfML = new List<int>();

		ApplicationDataContainer LocalSettings = ApplicationData.Current.LocalSettings;

		DispatcherTimer TimerForCursor = new DispatcherTimer();
		DispatcherTimer TimerForPrimary = new DispatcherTimer();
		DispatcherTimer TimerForFarm = new DispatcherTimer();
		DispatcherTimer TimerForMine = new DispatcherTimer();
		DispatcherTimer TimerForLaboratory = new DispatcherTimer();
		DispatcherTimer TimerForSpaceCraft = new DispatcherTimer();
		DispatcherTimer TimerForReactor = new DispatcherTimer();
		DispatcherTimer TimerForML = new DispatcherTimer();

		DispatcherTimer TimerForCleanEvent = new DispatcherTimer();
		DispatcherTimer TimerForSetNumberOfOrange = new DispatcherTimer();



		public MainPage()
		{
			this.InitializeComponent();

			SettingOfCursor.Add(1);

			if (LocalSettings.Values["Oranges"] == null)
			{
				LocalSettings.Values["Oranges"] = Convert.ToString(0); ;
			}
			if (LocalSettings.Values["LevelOfRush"] == null)
			{
				LocalSettings.Values["LevelOfRush"] = 1;
			}
			if (LocalSettings.Values["NumberOfCursor"] == null)
			{
				LocalSettings.Values["NumberOfCursor"] = 0;
			}
			if (LocalSettings.Values["NumberOfPrimary"] == null)
			{
				LocalSettings.Values["NumberOfPrimary"] = 0;
			}
			if (LocalSettings.Values["NumberOfFarm"] == null)
			{
				LocalSettings.Values["NumberOfFarm"] = 0;
			}
			if (LocalSettings.Values["NumberOfMine"] == null)
			{
				LocalSettings.Values["NumberOfMine"] = 0;
			}
			if (LocalSettings.Values["NumberOfLaboratory"] == null)
			{
				LocalSettings.Values["NumberOfLaboratory"] = 0;
			}
			if (LocalSettings.Values["NumberOfSpaceCraft"] == null)
			{
				LocalSettings.Values["NumberOfSpaceCraft"] = 0;
			}
			if (LocalSettings.Values["NumberOfReactor"] == null)
			{
				LocalSettings.Values["NumberOfReactor"] = 0;
			}
			if (LocalSettings.Values["NumberOfML"] == null)
			{
				LocalSettings.Values["NumberOfML"] = 0;
			}
			if (LocalSettings.Values["TimeOfSetNumberOfOrange"] == null)
			{
				LocalSettings.Values["TimeOfSetNumberOfOrange"] = 500;
			}
			TimerForCleanEvent.Interval = new TimeSpan(0, 0, 1);
			TimerForCleanEvent.Tick += TimerForCleanEvent_Tick;
			TimerForCursor.Interval = new TimeSpan(0, 0, 10);
			TimerForCursor.Tick += TimerForCursor_Tick;
			TimerForPrimary.Interval = new TimeSpan(0, 0, 1);
			TimerForPrimary.Tick += TimerForPrimy_Tick;
			TimerForSetNumberOfOrange.Interval = new TimeSpan(0, 0, 0, 0, (int)LocalSettings.Values["TimeOfSetNumberOfOrange"]);
			TimerForSetNumberOfOrange.Tick += TimerForSetNumberOfOrange_Tick;
			TimerForSetNumberOfOrange_Tick(new object(), new object());
			TimerForPrimary.Start();
			TimerForCursor.Start();
			TimerForSetNumberOfOrange.Start();
		}

		void TimerForSetNumberOfOrange_Tick(object sender, object e)
		{
			NumberOfOrangeOut.Text = (string)LocalSettings.Values["Oranges"];
			SpeedOfOrangeIncrease.Text = "橘子的增速：" + Convert.ToString((SettingOfCursor[0] / TimerForCursor.Interval.TotalSeconds)) + "个/s";
		}

		void TimerForCursor_Tick(object sender, object e)
		{
			LocalSettings.Values["Oranges"] = Convert.ToString(Convert.ToDecimal((string)LocalSettings.Values["Oranges"]) + SettingOfCursor[0]);
			TBEvent.Text = "指针帮你点了一下";
			TimerForCleanEvent.Start();
		}

		void TimerForCleanEvent_Tick(object sender, object e)
		{
			TBEvent.Text = "";
			TimerForCleanEvent.Stop();
		}

		void TimerForPrimy_Tick(object sender, object e)
		{
		}

		private void NumberOfOrangeOut_Loaded(object sender, RoutedEventArgs e)
		{
			NumberOfOrangeOut.Text = LocalSettings.Values["Oranges"].ToString();
		}


		private void BRush_PointerEntered(object sender, PointerRoutedEventArgs e)
		{
			TBInfo.Text = "摇晃橘子树~~橘子可能会从树上掉下来，每次摇树会掉下" + LocalSettings.Values["LevelOfRush"].ToString() + "个橘子";
		}

		private void _PointerExited(object sender, PointerRoutedEventArgs e)
		{
			TBInfo.Text = "";
		}

		private void BRush_Click(object sender, RoutedEventArgs e)
		{
			LocalSettings.Values["Oranges"] = Convert.ToString(Convert.ToDecimal(LocalSettings.Values["Oranges"].ToString()) + (int)LocalSettings.Values["LevelOfRush"]);
			TBEvent.Text = LocalSettings.Values["LevelOfRush"].ToString() + "个橘子从树上掉了下来~~~";
			TimerForCleanEvent.Start();
		}

	}
}
