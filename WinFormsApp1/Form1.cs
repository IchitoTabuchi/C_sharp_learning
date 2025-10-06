using System.Diagnostics;

namespace WinFormsApp1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			StartPosition = FormStartPosition.CenterScreen;
		}

		// ラムダなし
		private void button1_Click_1(object sender, EventArgs e)
		{
			var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };

			var result = new List<string>();
			foreach (var val in values)
			{
				if (val.Length >= 3)
				{
					result.Add(val);
				}

			}

			System.Diagnostics.Debug.WriteLine(string.Join(",", result));

			var result2 = GetValue1(values);
			System.Diagnostics.Debug.WriteLine(string.Join(",", result2));
		}

		private string[] GetValue1(string[] values)
		{


			var result = new List<string>();
			foreach (var val in values)
			{
				if (val.Length >= 3)
				{
					result.Add(val);
				}

			}

			return result.ToArray();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
			var result = GetValue2(values, 4);
			System.Diagnostics.Debug.WriteLine(string.Join(",", result));
		}

		private string[] GetValue2(string[] values, int len)
		{

			var result = new List<string>();
			foreach (var val in values)
			{
				if (val.Length >= len)
				{
					result.Add(val);
				}

			}

			return result.ToArray();
		}



		// デリゲート (delegate)
		private void button3_Click(object sender, EventArgs e)
		{
			var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
			var result = GetValue3(values, Shiki1);
			System.Diagnostics.Debug.WriteLine(string.Join(",", result));
		}

		delegate bool LenCheck(string val);

		private string[] GetValue3(string[] values, LenCheck lenCheck)
		{

			var result = new List<string>();
			foreach (var val in values)
			{
				if (lenCheck(val))
				{
					result.Add(val);
				}

			}

			return result.ToArray();
		}

		private bool Shiki1(string value)
		{
			return value.Length == 3;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
			var result = GetValue3(values, Shiki2);
			System.Diagnostics.Debug.WriteLine(string.Join(",", result));
		}

		private bool Shiki2(string value)
		{
			return value.Length >= 4;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
			var result = GetValue5(values, 3, Shiki3);
			System.Diagnostics.Debug.WriteLine(string.Join(",", result));
		}

		private string[] GetValue5(string[] values, int len, LenCheck5 lenCheck)
		{

			var result = new List<string>();
			foreach (var val in values)
			{
				if (lenCheck(val, len))
				{
					result.Add(val);
				}

			}

			return result.ToArray();
		}

		delegate bool LenCheck5(string value, int len);

		private bool Shiki3(string value, int len)
		{
			return value.Length == len;
		}

		private bool Shiki4(string value, int len)
		{
			return value.Length >= len;
		}

		// 匿名メソッド



		private void button6_Click(object sender, EventArgs e)
		{
			var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
			var result = GetValue3(values, delegate (string value) { return value.Length == 3; });
			System.Diagnostics.Debug.WriteLine(string.Join(",", result));
		}

		private void button7_Click(object sender, EventArgs e)
		{
			var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
			var result = GetValue3(values, delegate (string value) { return value.Length >= 4; });
			System.Diagnostics.Debug.WriteLine(string.Join(",", result));
		}

		// プレディケート (Predicate)
		// 戻り値は bool、引数は1つ
		//delegate bool LenCheck(string val);

		private void button8_Click(object sender, EventArgs e)
		{
			var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };


			var result = GetValue8(values, delegate (string value) { return value.Length == 3; });


			System.Diagnostics.Debug.WriteLine(string.Join(",", result));
		}

		private string[] GetValue8(string[] values, Predicate<string> predicate)
		{

			var result = new List<string>();
			foreach (var val in values)
			{
				if (predicate(val))
				{
					result.Add(val);
				}

			}

			return result.ToArray();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };

			// 匿名メソッド
			var result = GetValue8(values, delegate (string value) { return value.Length == 3; });

			System.Diagnostics.Debug.WriteLine("匿名メソッド" + string.Join(",", result));

			// ラムダ式 パターン1
			var result2 = GetValue8(values, (value) => { return value.Length == 3; });

			// ラムダ式 パターン2
			var result3 = GetValue8(values, value => { return value.Length == 3; });

			// ラムダ式 パターン3
			var result4 = GetValue8(values, value => value.Length == 3);
			var result5 = GetValue8(values, value => value.Length > 3);

			System.Diagnostics.Debug.WriteLine("ラムダ式" + string.Join(",", result4));
		}

		private void button10_Click(object sender, EventArgs e)
		{
			var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
			var result = GetValue10(values, 3, (value, len) => value.Length >= len);
		}

		private string[] GetValue10(string[] values, int len, Func<string, int, bool> lenCheck)
		{

			var result = new List<string>();
			foreach (var val in values)
			{
				if (lenCheck(val, len))
				{
					result.Add(val);
				}

			}

			return result.ToArray();
		}

		private void button11_Click(object sender, EventArgs e)
		{
			var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
			var result = GetValue10(values, 2, (value, len) =>
			{
				if (value[0] == 'E')
				{
					return value.Length >= len;
				}
				return false;
			});
			System.Diagnostics.Debug.WriteLine(string.Join(",", result));
		}

		private void button12_Click(object sender, EventArgs e)
		{
			GetData(DoConsole);
			GetData(DoText);
		}

		private void DoConsole(int value)
		{
			System.Diagnostics.Debug.WriteLine(value + "%");
		}


		private void DoText(int value)
		{
			this.Text = value + "%";
		}

		private List<string> GetData(Action<int> progressAction)
		{
			var result = new List<string>();
			for (int i = 1; i <= 5; i++)
			{
				result.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:ff"));
				System.Threading.Thread.Sleep(100);
				progressAction(i * 20);
			}
			return result;
		}

		private void button13_Click(object sender, EventArgs e)
		{
			GetData(value => System.Diagnostics.Debug.WriteLine(value + "%"));
			GetData(value => this.Text = value + "%");
		}

		private void button14_Click(object sender, EventArgs e)
		{
			GetData14(Console14);
		}

		private void Console14()
		{
			System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:ff"));
		}


		private List<string> GetData14(Action progressAction)
		{
			var result = new List<string>();
			for (int i = 1; i <= 5; i++)
			{
				result.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:ff"));
				System.Threading.Thread.Sleep(100);
				progressAction();
			}
			return result;
		}

		private void button15_Click(object sender, EventArgs e)
		{
			GetData14(() => System.Diagnostics.Debug.WriteLine("AAA"));
		}

		private void button16_Click(object sender, EventArgs e)
		{
			var values = new List<string> { "ABCDE", "AAAA", "BBBB", "CCCC", "DDDD" };

			var result = values.Find(x => x.Contains("B"));
			System.Diagnostics.Debug.WriteLine(string.Join(",", result));

			var result2 = values.FindAll(x => x.Contains("B"));
			System.Diagnostics.Debug.WriteLine(string.Join(",", result2));

			var result3 = values.Exists(x => x.Contains("B"));
			System.Diagnostics.Debug.WriteLine(string.Join(",", result3));

			var result4 = values.Where(x => x.Contains("B"));
			System.Diagnostics.Debug.WriteLine(string.Join(",", result4));

			// Where は配列でも使える。FindAllと挙動は同じだがこちらはList限定。
			var result5 = values.Where(x => x.Contains("B"));
			values.Add("EEEB");
			// 遅延実行される（EEEBの追加が反映される）
			System.Diagnostics.Debug.WriteLine(string.Join(",", result5));

			var result6 = values.Where(x => x.Contains("B")).ToList();
			values.Add("EEEB");
			// 即時実行される（EEEBの追加が反映されない）
			System.Diagnostics.Debug.WriteLine(string.Join(",", result6));

			// Anyは配列でも使える。Existsと挙動は同じだがこちらはList限定。
			var result7 = values.Any(x => x.Contains("B"));
			System.Diagnostics.Debug.WriteLine(string.Join(",", result7));
		}

		private void button17_Click(object sender, EventArgs e)
		{
			var products = new List<Product>();
			products.Add(new Product(1, "p1"));
			products.Add(new Product(2, "p2"));
			products.Add(new Product(3, "p31"));

			var result = products.Find(x => x.ProductId == 2);
			System.Diagnostics.Debug.WriteLine("result1:" + string.Join(",", result.ProductName));

			var result2 = products.FindAll(x => x.ProductName.Contains("1"));
			foreach (var item in result2)
			{
				System.Diagnostics.Debug.WriteLine("result2:" + string.Join(",", item.ProductName));
			}

			var result3 = products.Exists(x => x.ProductId == 2);
			System.Diagnostics.Debug.WriteLine("result1:" + string.Join(",", result3));
		}
	}

	public class Product
	{
		public Product(int productId, string productName)
		{
			ProductId = productId;
			ProductName = productName;
		}

		public int ProductId { get; set; }
		public string ProductName { get; set; }
	}
}