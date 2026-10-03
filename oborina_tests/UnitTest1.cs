using Microsoft.VisualStudio.TestTools.UnitTesting;
using OborinaLibrary1;
using System;

namespace oborina_tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void Add_Test()
		{
			Assert.AreEqual(5, Calc.Add(2, 3));
		}

		[TestMethod]
		public void Sub_Test()
		{
			Assert.AreEqual(1, Calc.Sub(3, 2));
		}

		[TestMethod]
		public void Mul_Test()
		{
			Assert.AreEqual(6, Calc.Mul(2, 3));
		}

		[TestMethod]
		public void Div_Test()
		{
			Assert.AreEqual(2, Calc.Div(6, 3));
		}

		[TestMethod]
		public void Pow_Test()
		{
			Assert.AreEqual(8, Calc.Pow(2, 3));
		}

		[TestMethod]
		public void Div_By_Zero_Test()
		{
			try
			{
				Calc.Div(5, 0);
				Assert.Fail("Ожидалось исключение");
			}
			catch (DivideByZeroException ex)
			{
				StringAssert.Contains(ex.Message, "Деление на ноль");
			}
		}
	}
}
