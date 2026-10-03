using System;
using System.Globalization;

namespace OborinaLibrary1
{
	public static class Calc
	{
		public static double Add(double a, double b) => a + b;
		public static double Sub(double a, double b) => a - b;
		public static double Mul(double a, double b) => a * b;

		public static double Div(double a, double b)
		{
			if (b == 0)
				throw new DivideByZeroException("Деление на ноль невозможно");
			return a / b;
		}

		public static double Pow(double a, double b) => Math.Pow(a, b);

		public static double EvaluateExpression(string input)
		{
			input = input.Replace(" ", "");
			return ParseAddSubtract(ref input);
		}

		private static double ParseAddSubtract(ref string s)
		{
			double result = ParseMulDiv(ref s);

			while (s.Length > 0)
			{
				if (s[0] == '+')
				{
					s = s.Substring(1);
					result += ParseMulDiv(ref s);
				}
				else if (s[0] == '-')
				{
					s = s.Substring(1);
					result -= ParseMulDiv(ref s);
				}
				else break;
			}

			return result;
		}

		private static double ParseMulDiv(ref string s)
		{
			double result = ParsePower(ref s);

			while (s.Length > 0)
			{
				if (s[0] == '*')
				{
					s = s.Substring(1);
					result *= ParsePower(ref s);
				}
				else if (s[0] == '/')
				{
					s = s.Substring(1);
					double divisor = ParsePower(ref s);
					result = Div(result, divisor);
				}
				else break;
			}

			return result;
		}

		private static double ParsePower(ref string s)
		{
			double left = ParseUnary(ref s);

			if (s.Length > 0 && s[0] == '^')
			{
				s = s.Substring(1);
				double right = ParsePower(ref s); 
				left = Pow(left, right);
			}

			return left;
		}

		private static double ParseUnary(ref string s)
		{
			if (s.Length > 0 && s[0] == '-')
			{
				s = s.Substring(1);
				return -ParseUnary(ref s);
			}

			return ParseParentheses(ref s);
		}

		private static double ParseParentheses(ref string s)
		{
			if (s.Length > 0 && s[0] == '(')
			{
				s = s.Substring(1);
				double result = ParseAddSubtract(ref s);

				if (s.Length == 0 || s[0] != ')')
					throw new Exception("Ошибка скобок");

				s = s.Substring(1);
				return result;
			}

			return ParseNumber(ref s);
		}

		private static double ParseNumber(ref string s)
		{
			int i = 0;
			while (i < s.Length && (char.IsDigit(s[i]) || s[i] == '.'))
				i++;

			if (i == 0)
				throw new Exception("Ошибка числа");

			string number = s.Substring(0, i);
			s = s.Substring(i);

			return double.Parse(number, CultureInfo.InvariantCulture);
		}
	}
}