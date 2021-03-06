﻿using System.Text;
using System.Windows.Input;
using whr_wpf.Model;
using whr_wpf.View.Info;

namespace whr_wpf.ViewModel.Info
{
	/// <summary>
	/// ゲーム情報表示VM
	/// </summary>
	public class InfoViewModel : ViewModelBase
	{
		public InfoViewModel(GameInfo gameInfo, InfoWindow window)
		{
			this.gameInfo = gameInfo;
			this.window = window;

			Close = new CloseCommand(this);
		}

		GameInfo gameInfo;
		public ICommand Close { get; set; }

		/// <summary>
		/// ウィンドウ内に表示する文字列
		/// </summary>
		public string InfoStr
		{
			get
			{
				StringBuilder text = new StringBuilder();
				text.Append($"難易度　{gameInfo.Difficulty?.ToName() ?? "(なし)"}\n");
				text.Append($"経済動向指数　{gameInfo.CalcEconomicIndex()}\n");
				text.Append($"○開発可能最高速度\n");
				text.Append($"蒸気機関車　{gameInfo.genkaiJoki}km/h\n");
				text.Append($"電車　{gameInfo.genkaiDenki}km/h\n");
				text.Append($"ディーゼル　{gameInfo.genkaiKidosha}km/h\n");
				text.Append($"リニア　{gameInfo.genkaiLinear}km/h\n");
				text.Append($"○開発済み技術\n");
				if (gameInfo.isDevelopedCarTiltPendulum) { text.Append("振り子式車体傾斜装置\n"); }
				if (gameInfo.isDevelopedMachineTilt) { text.Append("機械式車体傾斜装置\n"); }
				if (gameInfo.isDevelopedBlockingSignal) { text.Append("閉塞信号\n"); }
				if (gameInfo.isDevelopedDynamicSignal) { text.Append("移動閉塞信号\n"); }
				if (gameInfo.isDevelopedAutoGate) { text.Append("自動改札機\n"); }
				if (gameInfo.isDevelopedFreeGauge) { text.Append("フリーゲージトレイン\n"); }
				if (gameInfo.isDevelopedDualSeat) { text.Append("デュアルシート\n"); }
				if (gameInfo.isDevelopedRichCross) { text.Append("豪華クロスシート\n"); }
				if (gameInfo.isDevelopedRetructableLong) { text.Append("収納式ロングシート\n"); }
				if (gameInfo.isDevelopedConvertibleCross) { text.Append("転換クロスシート\n"); }
				return text.ToString();
			}
		}

		class CloseCommand : CommandBase
		{
			InfoViewModel vm;
			public CloseCommand(InfoViewModel vm) => this.vm = vm;
			public override bool CanExecute(object parameter) => true;
			public override void Execute(object parameter) => vm.window.Close();
		}
	}
}
