using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using OborinaLibrary1;

namespace OborinaCalculator2PR
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string text = ((Button)sender).Content.ToString();
			tbCommand.Text += text;
		}

		private void Button_Clear_Click(object sender, RoutedEventArgs e)
		{
			tbCommand.Clear();
		}

		private void Button_Backspace_Click(object sender, RoutedEventArgs e)
		{
			if (tbCommand.Text.Length > 0)
				tbCommand.Text = tbCommand.Text.Substring(0, tbCommand.Text.Length - 1);
		}

		private void Button_Equals_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string input = tbCommand.Text;

				int eqIndex = input.LastIndexOf('=');
				if (eqIndex >= 0)
					input = input.Substring(0, eqIndex).Trim();

				double result = Calc.EvaluateExpression(input);

				tbCommand.Text = input + " = " + result.ToString(CultureInfo.InvariantCulture);
			}
			catch (DivideByZeroException ex)
			{
				tbCommand.Text = "Ошибка: " + ex.Message;
			}
			catch (Exception ex)
			{
				tbCommand.Text = "Ошибка: " + ex.Message;
			}
		}
	}
}