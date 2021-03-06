﻿using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using whr_wpf.Model;

namespace whr_wpf
{
	/// <summary>
	/// MainMenuPage.xaml の相互作用ロジック
	/// </summary>
	public partial class MainMenuPage : Page
	{
		public MainMenuPage()
		{
			InitializeComponent();

			Loaded += MainMenuPage_Loaded;
		}

		private void MainMenuPage_Loaded(object sender, RoutedEventArgs e)
		{
			SetVersionInfo();
		}

		private void SetVersionInfo()
		{
			//自分自身のAssemblyを取得
			Assembly asm = Assembly.GetExecutingAssembly();
			//バージョンの取得
			System.Version ver = asm.GetName().Version;
			Version.Content = "ver." + ver.ToString();
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			ApplicationUtil.ForceExit();
		}

		private void MenuExit_Click(object sender, RoutedEventArgs e)
		{
			ApplicationUtil.ForceExit();
		}

		private void NewStart_Click(object sender, RoutedEventArgs e)
		{
			// Pageインスタンスを渡して遷移
			var page = new DifficultyLevelSelectPage(new GameInfo());
			NavigationService.Navigate(page);
		}

		private void ContinueStart_Click(object sender, RoutedEventArgs e)
		{
			GameInfo info = (GameInfo)ApplicationUtil.LoadData();
			var page = new GamePage(info);
			NavigationService.Navigate(page);
		}
	}
}
