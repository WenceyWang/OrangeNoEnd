using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace OrangeNoEnd
{


	/// <summary>
	/// 可独立使用或用于导航至 Frame 内部的空白页。
	/// </summary>
	/// 
	public sealed partial class MainPage : Page
	{
		ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

		#region Settings
		List<int> SettingOfCursor = new List<int>();
		List<int> SettingOfPrimary = new List<int>();
		List<int> SettingOfFarm = new List<int>();
		List<int> SettingOfMine = new List<int>();
		List<int> SettingOfLaboratory = new List<int>();
		List<int> SettingOfSpaceCraft = new List<int>();
		List<int> SettingOfReactor = new List<int>();
		List<int> SettingOfML = new List<int>();
		#endregion

		#region Timers
		DispatcherTimer TimerForCursor = new DispatcherTimer();
		DispatcherTimer TimerForPrimary = new DispatcherTimer();
		DispatcherTimer TimerForFarm = new DispatcherTimer();
		DispatcherTimer TimerForMine = new DispatcherTimer();
		DispatcherTimer TimerForLaboratory = new DispatcherTimer();
		DispatcherTimer TimerForSpaceCraft = new DispatcherTimer();
		DispatcherTimer TimerForReactor = new DispatcherTimer();
		DispatcherTimer TimerForML = new DispatcherTimer();

		DispatcherTimer TimerForCleanEvent = new DispatcherTimer();
		#endregion

		public MainPage()
		{
			this.InitializeComponent();

			#region SetStartValue
			//if (localSettings.Values["GameIsStart"]==null)
			{
				SetStartValue();
				localSettings.Values["GameIsStart"] = true;
			}
			#endregion

			#region SetTimer
			TimerForCleanEvent.Interval = new TimeSpan(0, 0, 1);
			TimerForCleanEvent.Tick += TimerForCleanEvent_Tick;
			TimerForCursor.Interval = new TimeSpan(0, 0, 1);
			TimerForCursor.Tick += TimerForCursor_Tick;
			TimerForPrimary.Interval = new TimeSpan(0, 0, 1);
			TimerForPrimary.Tick += TimerForPrimy_Tick;
			
			#endregion

			#region StartTimer
			TimerForPrimary.Start();
			TimerForCursor.Start();
			#endregion

		}
		void SetStartValue()
		{
			localSettings.Values["Oranges"] = Convert.ToString(0);
			localSettings.Values["NumberOfCursor"] = 0;
			localSettings.Values["NumberOfPrimary"] = 0;
			localSettings.Values["NumberOfFarm"] = 0;
			localSettings.Values["NumberOfMine"] = 0;
			localSettings.Values["NumberOfLaboratory"] = 0;
			localSettings.Values["NumberOfSpaceCraft"] = 0;
			localSettings.Values["NumberOfReactor"] = 0;
			localSettings.Values["NumberOfML"] = 0;
			localSettings.Values["LevelOfRush"] = 1;
			localSettings.Values["LevelOfCursor"] = 1;
			localSettings.Values["LevelOfPrimary"] = 1;
			localSettings.Values["LevelOfFarm"] = 1;
			localSettings.Values["LevelOfMine"] = 1;
			localSettings.Values["LevelOfLaboratory"] = 1;
			localSettings.Values["LevelOfSpaceCraft"] = 1;
			localSettings.Values["LevelOfReactor"] = 1;
			localSettings.Values["LevelOfML"] = 1;
			localSettings.Values["TimeOfSetNumberOfOrange"] = 500;
		}

		decimal NumberOfOrange
		{
			get
			{
				return Convert.ToDecimal(localSettings.Values["NumberOfOrange"]);
			}
			set
			{
				NumberOfOrangeOut.Text = value.ToString();
				localSettings.Values["NumberOfOrange"] = value.ToString();
			}
		}

		int NumberOfCursor
		{
			get
			{
				return Convert.ToInt32(localSettings.Values["NumberOfCursor"]);
			}
			set
			{
				NumberOfCursorOut.Text = value.ToString();
				localSettings.Values["NumberOfCursor"] = value;
			}
		}

		int NumberOfPrimary
		{
			get
			{
				return Convert.ToInt32(localSettings.Values["NumberOfPrimary"]);
			}
			set
			{
				NumberOfPrimaryOut.Text = value.ToString();
				localSettings.Values["NumberOfPrimary"] = value;
			}
		}

		int NumberOfFarm
		{
			get
			{
				return Convert.ToInt32(localSettings.Values["NumberOfFarm"]);
			}
			set
			{
				NumberOfFarmOut.Text = value.ToString();
				localSettings.Values["NumberOfFarm"] = value;
			}
		}

		int NumberOfMine
		{
			get
			{
				return Convert.ToInt32(localSettings.Values["NumberOfMine"]);
			}
			set
			{
				NumberOfMineOut.Text = value.ToString();
				localSettings.Values["NumberOfMine"] = value;
			}
		}

		int NumberOfLaboratory
		{
			get
			{
				return Convert.ToInt32(localSettings.Values["NumberOfLaboratory"]);
			}
			set
			{
				NumberOfLaboratoryOut.Text = value.ToString();
				localSettings.Values["NumberOfLaboratory"] = value;
			}
		}

		int NumberOfSpaceCraft
		{
			get
			{
				return Convert.ToInt32(localSettings.Values["NumberOfSpaceCraft"]);
			}
			set
			{
				//NumberOfSpaceCraftOut.Text = value.ToString();
				localSettings.Values["NumberOfSpaceCraft"] = value;
			}
		}

		int NumberOfRactor
		{
			get
			{
				return Convert.ToInt32(localSettings.Values["NumberOfRactor"]);
			}
			set
			{
				//NumberOfRactorOut.Text = value.ToString();
				localSettings.Values["NumberOfRactor"] = value;
			}
		}

		int NumberOfML
		{
			get
			{
				return Convert.ToInt32(localSettings.Values["NumberOfML"]);
			}
			set
			{
				//NumberOfMLOut.Text = value.ToString();
				localSettings.Values["NumberOfML"] = value;
			}
		}

		int LevelOfCursor
		{
			get
			{
				return Convert.ToInt32(localSettings.Values["LevelOfCursor"]);
			}
			set
			{
				//LevelOfCursorOut.Text = value.ToString();
				localSettings.Values["LevelOfCursor"] = value;
			}
		}

		int LevelOfPrimary
		{
			get
			{
				return Convert.ToInt32(localSettings.Values["LevelOfPrimary"]);
			}
			set
			{
				//LevelOfPrimaryOut.Text = value.ToString();
				localSettings.Values["LevelOfPrimary"] = value;
			}
		}

		int LevelOfFarm
		{
			get
			{
				return Convert.ToInt32(localSettings.Values["LevelOfFarm"]);
			}
			set
			{
				//LevelOfFarmOut.Text = value.ToString();
				localSettings.Values["LevelOfFarm"] = value;
			}
		}

		int LevelOfMine
		{
			get
			{
				return Convert.ToInt32(localSettings.Values["LevelOfMine"]);
			}
			set
			{
				//LevelOfMineOut.Text = value.ToString();
				localSettings.Values["LevelOfMine"] = value;
			}
		}

		int LevelOfLaboratory
		{
			get
			{
				return Convert.ToInt32(localSettings.Values["LevelOfLaboratory"]);
			}
			set
			{
				//LevelOfLaboratoryOut.Text = value.ToString();
				localSettings.Values["LevelOfLaboratory"] = value;
			}
		}

		int LevelOfSpaceCraft
		{
			get
			{
				return Convert.ToInt32(localSettings.Values["LevelOfSpaceCraft"]);
			}
			set
			{
				//LevelOfSpaceCraftOut.Text = value.ToString();
				localSettings.Values["LevelOfSpaceCraft"] = value;
			}
		}

		int LevelOfRactor
		{
			get
			{
				return Convert.ToInt32(localSettings.Values["LevelOfRactor"]);
			}
			set
			{
				//LevelOfRactorOut.Text = value.ToString();
				localSettings.Values["LevelOfRactor"] = value;
			}
		}

		int LevelOfML
		{
			get
			{
				return Convert.ToInt32(localSettings.Values["LevelOfML"]);
			}
			set
			{
				//LevelOfMLOut.Text = value.ToString();
				localSettings.Values["LevelOfML"] = value;
			}
		}

		public void ShowEvent(string text)
		{
			TBEvent.Text = text;
			TimerForCleanEvent.Start();
		}

		public void UpdateTheNumberOfOranges()
		{
			NumberOfOrangeOut.Text = (string)localSettings.Values["Oranges"];
		}

	

		void TimerForCursor_Tick(object sender, object e)
		{
			NumberOfOrange+=LevelOfCursor;
			ShowEvent(localSettings.Values["LevelOfCursor"].ToString() + "个橘子从树上掉了下来~~~");
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
			UpdateTheNumberOfOranges();
		}


		private void BRush_PointerEntered(object sender, PointerRoutedEventArgs e)
		{
			TBInfo.Text = "摇晃橘子树~~橘子可能会从树上掉下来，每次摇树会掉下" + localSettings.Values["LevelOfRush"].ToString() + "个橘子";
		}

		private void _PointerExited(object sender, PointerRoutedEventArgs e)
		{
			TBInfo.Text = "";
		}

		private void BRush_Click(object sender, RoutedEventArgs e)
		{
			NumberOfOrange++;
			ShowEvent(localSettings.Values["LevelOfRush"].ToString() + "个橘子从树上掉了下来~~~");
		}

	}
}
