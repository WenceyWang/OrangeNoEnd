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

		#region Datas
		List<long> RiseOfRushData = new List<long>();
		List<double> RiseOfCursorData = new List<double>();
		List<long> RiseOfPrimaryData = new List<long>();
		List<long> RiseOfFarmData = new List<long>();
		List<long> RiseOfMineData = new List<long>();
		List<long> RiseOfLaboratoryData = new List<long>();
		List<long> RiseOfSpaceCraftData = new List<long>();
		List<long> RiseOfReactorData = new List<long>();
		List<long> RiseOfMLData = new List<long>();


		#endregion

		#region Timers
		DispatcherTimer Timers = new DispatcherTimer();

		DispatcherTimer TimerForCleanEvent = new DispatcherTimer();
		#endregion

		public MainPage()
		{
			this.InitializeComponent();
			#region SetStartValue
			RiseOfRushData.Add(1);
			RiseOfCursorData.Add(0.1);
			RiseOfPrimaryData.Add(2);
			RiseOfFarmData.Add(50);
			RiseOfMineData.Add(2000);
			RiseOfLaboratoryData.Add(100000);
			RiseOfSpaceCraftData.Add(50000000);
			RiseOfReactorData.Add(700000000);
			RiseOfMLData.Add(101010101010101010);

			//if (localSettings.Values["GameIsStart"]==null)
			{
				SetStartValue();
				localSettings.Values["GameIsStart"] = true;
			}
			#endregion

			#region SetTimer
			TimerForCleanEvent.Interval = new TimeSpan(0, 0, 1);
			TimerForCleanEvent.Tick += TimerForCleanEvent_Tick;
			Timers.Interval = new TimeSpan(0, 0, 0, 0, 50);
			Timers.Tick += Timers_Tick;
			#endregion

			#region StartTimer
			Timers.Start();
			#endregion

		}



		void SetStartValue()
		{
			NumberOfOrange = 0m;
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
				localSettings.Values["NumberOfOrange"] = value.ToString();
				NumberOfOrangeOut.Text = decimal.Floor(value).ToString();
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
				localSettings.Values["NumberOfCursor"] = value;
				NumberOfCursorOut.Text = value.ToString();
				PriceOfCursorOut.Text = PriceOfCursor.ToString();
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
				localSettings.Values["NumberOfPrimary"] = value;
				NumberOfPrimaryOut.Text = value.ToString();
				PriceOfPrimaryOut.Text = PriceOfPrimary.ToString();
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
				localSettings.Values["NumberOfFarm"] = value;
				NumberOfFarmOut.Text = value.ToString();
				PriceOfFarmOut.Text = PriceOfFarm.ToString();
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
				localSettings.Values["NumberOfMine"] = value;
				NumberOfMineOut.Text = value.ToString();
				PriceOfMineOut.Text = PriceOfMine.ToString();
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
				localSettings.Values["NumberOfLaboratory"] = value;
				NumberOfLaboratoryOut.Text = value.ToString();
				PriceOfLaboratoryOut.Text = PriceOfLaboratory.ToString();
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
				localSettings.Values["NumberOfSpaceCraft"] = value;
				NumberOfSpaceCraftOut.Text = value.ToString();
				PriceOfSpaceCraftOut.Text = PriceOfSpaceCraft.ToString();
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
				localSettings.Values["NumberOfReactor"] = value;
				NumberOfMLOut.Text = value.ToString();
				PriceOfMLOut.Text = PriceOfML.ToString();
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
				return RiseOfRushData[LevelOfRush];
			}
		}
		double RiseOfCursor
		{
			get
			{
				return RiseOfCursorData[LevelOfCursor];
			}
		}
		long RiseOfPrimary
		{
			get
			{
				return RiseOfPrimaryData[LevelOfPrimary];
			}
		}
		long RiseOfFarm
		{
			get
			{
				return RiseOfFarmData[LevelOfFarm];
			}
		}
		long RiseOfMine
		{
			get
			{
				return RiseOfMineData[LevelOfMine];
			}
		}
		long RiseOfLaboratory
		{
			get
			{
				return RiseOfLaboratoryData[LevelOfLaboratory];
			}
		}
		long RiseOfSpaceCraft
		{
			get
			{
				return RiseOfSpaceCraftData[LevelOfSpaceCraft];
			}
		}
		long RiseOfReactor
		{
			get
			{
				return RiseOfReactorData[LevelOfReactor];
			}
		}
		long RiseOfML
		{
			get
			{
				return RiseOfMLData[LevelOfML];
			}
		}
		#endregion

		#region PriceOf

		decimal PriceOfCursor
		{
			get
			{
				return (decimal)(10 +  (Math.Pow(NumberOfCursor, 2)));
			}
		}

		decimal PriceOfPrimary
		{
			get
			{
				return (decimal)(10 +  (Math.Pow(NumberOfPrimary, 3)));
			}
		}

		decimal PriceOfFarm
		{
			get
			{
				return (decimal)(10 +  (Math.Pow(NumberOfFarm, 4)));
			}
		}

		decimal PriceOfMine
		{
			get
			{
				return (decimal)(10 + 1 * (Math.Pow(NumberOfMine, 5)));
			}
		}

		decimal PriceOfLaboratory
		{
			get
			{
				return (decimal)(10 + 1 * (Math.Pow(NumberOfLaboratory, 6)));
			}
		}

		decimal PriceOfSpaceCraft
		{
			get
			{
				return (decimal)(10 + (Math.Pow(NumberOfSpaceCraft, 7)));
			}
		}

		decimal PriceOfReactor
		{
			get
			{
				return (decimal)(10 + (Math.Pow(NumberOfReactor, 8)));
			}
		}

		decimal PriceOfML
		{
			get
			{
				return (decimal)(10 + (Math.Pow(NumberOfML, 100)));
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
			NumberOfOrange += (decimal)(SpeedOfOrangeRise * (Timers.Interval.TotalMilliseconds / 1000));
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

		private void _PointerExited(object sender, object e)
		{
			TBInfo.Text = "";
		}

		private void BRush_Click(object sender, RoutedEventArgs e)
		{
			NumberOfOrange += RiseOfRush;
			ShowEvent(RiseOfRush.ToString() + "个橘子从树上掉了下来~~~");
		}

		private void Buy1Cursor_Click(object sender, object e)
		{
			if (NumberOfOrange >= PriceOfCursor)
			{
				NumberOfOrange -= PriceOfCursor;
				NumberOfCursor++;
			}

		}


	}
}
