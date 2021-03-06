﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media.Imaging;
using whr_wpf.Util;

namespace whr_wpf.Model
{
	/// <summary>
	/// ゲーム状態保持クラス
	/// </summary>
	[Serializable()]
	public partial class GameInfo : INotifyPropertyChanged
	{
		protected void OnPropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		public event PropertyChangedEventHandler PropertyChanged;

		public GameInfo()
		{
		}

		/// <summary>
		/// 難易度
		/// </summary>
		public DifficultyLevelEnum? Difficulty { get; set; } = null;

		/// <summary>
		/// モード
		/// </summary>
		public ModeEnum? Mode { get; set; } = null;

		/// <summary>
		/// シナリオバージョン
		/// </summary>
		public int ScenerioVersion { get; private set; }

		/// <summary>
		/// 基礎とする年
		/// </summary>
		public int BasicYear { get; private set; }

		/// <summary>
		/// 乗客数動態
		/// </summary>
		public SeasonEnum Season { get; private set; }

		/// <summary>
		/// 蒸気機関車 使用制限開始年 styear
		/// </summary>
		public int SteamYear { get; private set; }

		/// <summary>
		/// 貨物動態
		/// </summary>
		public KamotsuEnum Kamotu { get; private set; }

		/// <summary>
		/// kmあたりの運賃 km
		/// </summary>
		public int FarePerKm { get; private set; }

		/// <summary>
		/// 乗車数　基準を100とする乗車数の倍率 rpm
		/// </summary>
		public int Rpm { get; private set; }

		/// <summary>
		/// 路線作成費　基準を100とする路線作成費の倍率。維持費にも影響 linemc
		/// </summary>
		public int LineMakeCost { get; private set; }

		/// <summary>
		/// 技術開発費　基準を100とする技術開発費の倍率 tecc
		/// </summary>
		public int TechCost { get; private set; }

		/// <summary>
		/// 人口上昇倍率 uppeo
		/// </summary>
		public int UpperPopulation { get; private set; }

		/// <summary>
		/// 上限人口 maxpp
		/// </summary>
		public int MaxPopulation { get; private set; }

		/// <summary>
		/// マップ数 最初は使わない
		/// </summary>
		public int Maps { get; private set; }

		/// <summary>
		/// 情報表示位置
		/// </summary>
		public InfoPosiEnum InfoPosi { get; private set; }

		/// <summary>
		/// 政府補助金 開始年 hojo
		/// </summary>
		public int HojoStartYear { get; private set; }

		/// <summary>
		/// 政府補助金 終了年 hojo
		/// </summary>
		public int HojoEndYear { get; private set; }

		/// <summary>
		/// 政府補助金 金額(10万単位) hojo
		/// </summary>
		public int HojoAmount { get; private set; }

		/// <summary>
		/// 戦時モード定義
		/// </summary>
		public List<WarMode> warModeList;

		/// <summary>
		/// 所持金 10万単位
		/// </summary>
		public long Money
		{
			get => money; private set
			{
				money = value;
				OnPropertyChanged(nameof(Money));
			}
		}
		private long money = 5000000;

		/// <summary>
		/// 年
		/// </summary>
		public int Year { get; private set; } = 1880;

		/// <summary>
		/// 月
		/// </summary>
		public int Month { get; private set; } = 1;

		/// <summary>
		/// 週
		/// </summary>
		public int Week { get; private set; } = 1;

		/// <summary>
		/// ゲームオーバー年
		/// </summary>
		public int MYear { get; private set; }

		/// <summary>
		/// 総人口
		/// </summary>
		public int Ap { get; private set; } = 0;

		/// <summary>
		/// モード
		/// </summary>
		public List<Mode> modes = new List<Mode>();

		/// <summary>
		/// 編成
		/// </summary>
		public List<IComposition> compositions = new List<IComposition>();

		/// <summary>
		/// 車両
		/// </summary>
		public List<Car> vehicles = new List<Car>();


		/// <summary>
		/// 路線
		/// </summary>
		public List<Line> lines = new List<Line>();

		/// <summary>
		/// 運転系統
		/// </summary>
		public List<KeitoDiagram> diagrams = new List<KeitoDiagram>();

		/// <summary>
		/// 駅
		/// </summary>
		public List<Station> stations = new List<Station>();

		/// <summary>
		/// その週の収入
		/// </summary>
		public int income;

		/// <summary>
		/// その週の支出
		/// </summary>
		public int outlay;

		/// <summary>
		/// 背景の地図
		/// </summary>
		public BitmapImage map;

		/// <summary>
		/// 駅名を表示するか(未実装)
		/// </summary>
		public bool nameShown;

		/// <summary>
		/// 最後に見た運転系統
		/// </summary>
		public KeitoDiagram lastSeenKeito;

		/// <summary>
		/// 最後に見た路線
		/// </summary>
		public Line lastSeenLine;

		/// <summary>
		/// 現在の戦時モード
		/// </summary>
		public WarMode modss = null;

		/// <summary>
		/// 蒸気機関の限界スピード
		/// </summary>
		public int genkaiJoki = 40;

		/// <summary>
		/// 電気モーターの限界スピード
		/// </summary>
		public int genkaiDenki;

		/// <summary>
		/// 気動車の限界スピード
		/// </summary>
		public int genkaiKidosha;

		/// <summary>
		/// リニアの限界スピード
		/// </summary>
		public int genkaiLinear;

		//追加する許容路線本数 gky
		public int genkaikyoyo;

		//新企画技術開発
		public bool isDevelopedCarTiltPendulum; //振り子式車体傾斜装置
		public bool isDevelopedBlockingSignal; //閉塞信号
		public bool isDevelopedFreeGauge; //フリーゲージ
		public bool isDevelopedDualSeat; //デュアルシート
		public bool isDevelopedRichCross; //豪華クロスシート
		public bool isDevelopedRetructableLong; //収納式ロングシート
		public bool isDevelopedConvertibleCross; //転換クロスシート
		public bool isDevelopedAutoGate; //自動改札機
		public bool isDevelopedDynamicSignal; //動的信号
		public bool isDevelopedMachineTilt; //機械式車体傾斜装置

		/// <summary>
		/// 毎週投資額
		/// </summary>
		public InvestmentAmount weeklyInvestment;

		/// <summary>
		/// 累計投資額
		/// </summary>
		public InvestmentAmountAccumulated AccumulatedInvest;

		/// <summary>
		/// 乗り継ぎ
		/// </summary>
		List<Longway> longwayList;

		private static Random Rnd() => new Random();

		/// <summary>
		/// 経済動向
		/// </summary>
		double[] economyTrends = { Rnd().Next(0, 360), Rnd().Next(0, 360), Rnd().Next(0, 360), Rnd().Next(0, 360) };

		/// <summary>
		/// 経済動向指数計算
		/// </summary>
		/// <returns></returns>
		public int CalcEconomicIndex()
		{
			double amplitude = 256 * 3; //上限下限の幅の具合
			double baseIndex = economyTrends
				.Select(angle => Math.Cos(angle * (Math.PI / 180)))
				.Select(cosine => ((cosine * amplitude) + 10000) / 100)
				.Aggregate((kari1, kari2) => kari1 * kari2);
			baseIndex /= 1000000;

			int adjustVal = 0;
			switch (Difficulty)
			{
				case DifficultyLevelEnum.VeryEasy:
					adjustVal = 5;
					break;
				case DifficultyLevelEnum.Easy:
					adjustVal = 2;
					break;
				case DifficultyLevelEnum.Hard:
					adjustVal = -2;
					break;
				case DifficultyLevelEnum.VeryHard:
					adjustVal = -5;
					break;
			}
			return (int)baseIndex + adjustVal;
		}

		/// <summary>
		/// お金を消費
		/// </summary>
		/// <param name="amount">消費資金</param>
		public void SpendMoney(long amount)
		{
			if (Money < amount) { throw new MoneyShortException("お金が足りません"); }
			Money -= amount;
		}

		/// <summary>
		/// 蒸気機関車が新規使用/開発可能か
		/// </summary>
		/// <returns></returns>
		public bool IsSteamAvailable() => Year < SteamYear;

		/// <summary>
		/// 振り子を用いることが可能か
		/// </summary>
		public bool CanUsePendulum() => isDevelopedCarTiltPendulum && !isDevelopedMachineTilt;

		/// <summary>
		/// 車両購入コスト計算
		/// </summary>
		/// <param name="bestSpeed"></param>
		/// <param name="power"></param>
		/// <param name="gauge"></param>
		/// <param name="seat"></param>
		/// <param name="tilt"></param>
		/// <returns></returns>
		public int CalcPurchaseVehicleCost(int bestSpeed, PowerEnum power, CarGaugeEnum gauge, SeatEnum seat, CarTiltEnum tilt) =>
			LogicUtil.CalcPurchaseCarCost(bestSpeed, power, gauge, seat, tilt, genkaiLinear, genkaiJoki, genkaiDenki, genkaiKidosha);

		/// <summary>
		/// 車両開発コスト計算
		/// </summary>
		/// <param name="bestSpeed"></param>
		/// <param name="power"></param>
		/// <param name="gauge"></param>
		/// <param name="seat"></param>
		/// <param name="tilt"></param>
		/// <returns></returns>
		public int CalcDevelopVehicleCost(int bestSpeed, PowerEnum power, CarGaugeEnum gauge, SeatEnum seat, CarTiltEnum tilt) =>
			LogicUtil.CalcPurchaseCarCost(bestSpeed, power, gauge, seat, tilt, genkaiLinear, genkaiJoki, genkaiDenki, genkaiKidosha) * 10;

		/// <summary>
		/// 戦時モード
		/// </summary>
		public class WarMode
		{
			/// <summary>
			/// 戦争開始年
			/// </summary>
			public int StartYear;

			/// <summary>
			/// 戦争終了年
			/// </summary>
			public int EndYear;

			/// <summary>
			/// 貨物増加指数(通常時100)
			/// </summary>
			public int kamotsuIndex;

			/// <summary>
			/// 貨物量に指数を掛ける
			/// </summary>
			/// <param name="kamotsuAmount"></param>
			/// <returns></returns>
			public int MultiplyKamotsu(int kamotsuAmount) => kamotsuAmount * kamotsuIndex / 100;

			/// <summary>
			/// 戦時モードのリストを生成
			/// </summary>
			/// <param name="warModeStringList">戦時モードの文字列リスト</param>
			/// <returns></returns>
			public static List<WarMode> CreateWarModeList(List<string> warModeStringList)
			{
				return warModeStringList.Select(warmodeStr =>
				{
					var arr = warmodeStr.Split(',');
					return new WarMode
					{
						StartYear = int.Parse(arr[0]),
						EndYear = int.Parse(arr[1]),
						kamotsuIndex = int.Parse(arr[2]),
					};
				}).ToList();
			}
		}
	}

}
