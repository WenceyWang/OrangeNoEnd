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
		List<long> SettingOfRush = new List<long>();
		List<double> SettingOfCursor = new List<double>();
		List<long> SettingOfPrimary = new List<long>();
		List<long> SettingOfFarm = new List<long>();
		List<long> SettingOfMine = new List<long>();
		List<long> SettingOfLaboratory = new List<long>();
		List<long> SettingOfSpaceCraft = new List<long>();
		List<long> SettingOfReactor = new List<long>();
		List<long> SettingOfML = new List<long>();
		#endregion

		#region Timers
		DispatcherTimer Timers = new DispatcherTimer();

		DispatcherTimer TimerForCleanEvent = new DispatcherTimer();
		#endregion

		public MainPage()
		{
			this.InitializeComponent();
			#region SetStartValue
			SettingOfRush.Add(1);
			SettingOfCursor.Add(0.1);
			SettingOfPrimary.Add(2);
			SettingOfFarm.Add(50);
			SettingOfMine.Add(2000);
			SettingOfLaboratory.Add(100000);
			SettingOfSpaceCraft.Add(30000000);
			SettingOfReactor.Add(1000000000);
			SettingOfML.Add(10101010);

			//if (localSettings.Values["GameIsStart"]==null)
			{
				SetStartValue();
				localSettings.Values["GameIsStart"] = true;
			}
			#endregion

			#region SetTimer
			TimerForCleanEvent.Interval = new TimeSpan(0, 0, 1);
			TimerForCleanEvent.Tick += TimerForCleanEvent_Tick;
			Timers.Interval = new TimeSpan(0, 0, 0,0,50);
			Timers.Tick += Timers_Tick;
			#endregion

			#region StartTimer
			Timers.Start();
			#endregion

		}



		void SetStartValue()
		{
			NumberOfOrange = 100000m;//= 
			NumberOfCursor = NumberOfPrimary = NumberOfFarm = NumberOfMine = NumberOfLaboratory = NumberOfSpaceCraft = NumberOfReactor = NumberOfML = 0;
			LevelOfRush = LevelOfCursor = LevelOfPrimary = LevelOfFarm = LevelOfMine = LevelOfLaboratory = LevelOfSpaceCraft = LevelOfReactor = LevelOfML = 0;
		}

		#region Of

		#region NumberOf
		decimal NumberOfOrange
		{
			get
			{
				return Convert.ToDecimal(localSettings.Values["NumberOfOrange"]);
			}
			set
			{
				NumberOfOrangeOut.Text = decimal.Floor(value).ToString();
				localSettings.Values["NumberOfOrange"] = value.ToString();
				SpeedOfOrangeRiseOut.Text = SpeedOfOrangeRise.ToString();
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
				NumberOfSpaceCraftOut.Text = value.ToString();
				localSettings.Values["NumberOfSpaceCraft"] = value;
			}
		}
		int NumberOfReactor
		{
			get
			{
				return Convert.ToInt32(localSettings.Values["NumberOfReactor"]);
			}
			set
			{
				NumberOfReactorOut.Text = value.ToString();
				localSettings.Values["NumberOfReactor"] = value;
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
				NumberOfMLOut.Text = value.ToString();
				localSettings.Values["NumberOfML"] = value;
			}
		}
		#endregion

		#region LevelOf
		int LevelOfRush
		{
			get
			{
				return Convert.ToInt32(localSettings.Values["LevelOfRush"]);
			}
			set
			{
				localSettings.Values["LevelOfRush"] = value;
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
				LevelOfCursorOut.Text = value.ToString();
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
				LevelOfPrimaryOut.Text = value.ToString();
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
				LevelOfFarmOut.Text = value.ToString();
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
				LevelOfMineOut.Text = value.ToString();
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
				LevelOfLaboratoryOut.Text = value.ToString();
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
				LevelOfSpaceCraftOut.Text = value.ToString();
				localSettings.Values["LevelOfSpaceCraft"] = value;
			}
		}
		int LevelOfReactor
		{
			get
			{
				return Convert.ToInt32(localSettings.Values["LevelOfReactor"]);
			}
			set
			{
				LevelOfReactorOut.Text = value.ToString();
				localSettings.Values["LevelOfReactor"] = value;
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
				LevelOfMLOut.Text = value.ToString();
				localSettings.Values["LevelOfML"] = value;
			}
		}
		#endregion

		#region RiseOf
		long RiseOfRush
		{
			get
			{
				return SettingOfRush[LevelOfRush];
			}
		}
		double RiseOfCursor
		{
			get
			{
				return SettingOfCursor[LevelOfCursor];
			}
		}
		long RiseOfPrimary
		{
			get
			{
				return SettingOfPrimary[LevelOfPrimary];
			}
		}
		long RiseOfFarm
		{
			get
			{
				return SettingOfFarm[LevelOfFarm];
			}
		}
		long RiseOfMine
		{
			get
			{
				return SettingOfMine[LevelOfMine];
			}
		}
		long RiseOfLaboratory
		{
			get
			{
				return SettingOfLaboratory[LevelOfLaboratory];
			}
		}
		long RiseOfSpaceCraft
		{
			get
			{
				return SettingOfSpaceCraft[LevelOfSpaceCraft];
			}
		}
		long RiseOfReactor
		{
			get
			{
				return SettingOfReactor[LevelOfReactor];
			}
		}
		long RiseOfML
		{
			get
			{
				return SettingOfML[LevelOfML];
			}
		}
		#endregion

		double SpeedOfOrangeRise
		{
			get
			{
				return RiseOfCursor * NumberOfCursor + RiseOfPrimary * NumberOfPrimary + RiseOfFarm * NumberOfFarm + RiseOfMine * NumberOfMine + RiseOfLaboratory * NumberOfLaboratory + RiseOfSpaceCraft * NumberOfSpaceCraft + RiseOfReactor * NumberOfReactor + RiseOfML * NumberOfML;
			}
		}

		#endregion

		void Timers_Tick(object sender, object e)
		{
			NumberOfOrange += (decimal)(SpeedOfOrangeRise*(Timers.Interval.TotalMilliseconds/1000));
		}
		public void ShowEvent(string text)
		{
			TBEvent.Text = text;
			TimerForCleanEvent.Start();
		}

		void TimerForCleanEvent_Tick(object sender, object e)
		{
			TBEvent.Text = "";
			TimerForCleanEvent.Stop();
		}

		private void NumberOfOrangeOut_Loaded(object sender, RoutedEventArgs e)
		{

		}

		private void BRush_PointerEntered(object sender, PointerRoutedEventArgs e)
		{
			TBInfo.Text = "摇晃橘子树~~橘子可能会从树上掉下来，每次摇树会掉下" + RiseOfRush + "个橘子";
		}

		private void _PointerExited(object sender, PointerRoutedEventArgs e)
		{
			TBInfo.Text = "";
		}

		private void BRush_Click(object sender, RoutedEventArgs e)
		{
			NumberOfOrange += RiseOfRush;
			ShowEvent(RiseOfRush.ToString() + "个橘子从树上掉了下来~~~");
		}
	}
}
