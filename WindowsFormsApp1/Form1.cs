using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			StartPosition = FormStartPosition.CenterScreen;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int[] nums = { 1, 3, 2, 5, 4, 7, 6, 5 };
			foreach (var val in nums) { }

			var result1 = from num in nums where num >= 5 select num;
			Console.WriteLine("result1=" + string.Join(",", result1));


			var result2 = from num in nums where num >= 3 && num <= 5 || num == 7 select num;
			Console.WriteLine("result2=" + string.Join(",", result2));

			var result3 = from num in nums where num >= 3 && num <= 5 || num == 7 orderby num select num;
			Console.WriteLine("result3=" + string.Join(",", result3));


			var result4 = from num in nums where num >= 3 && num <= 5 || num == 7 orderby num descending select num;
			Console.WriteLine("result4=" + string.Join(",", result4));
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string[] values = { "A", "BB", "CCC", "DDDD", "EEEEE", "aBC" };

			var result1 = from s in values select s;
			Console.WriteLine("result1=" + string.Join(",", result1));

			var result2 = from s in values where s.Contains("a") select s;
			Console.WriteLine("result2=" + string.Join(",", result2));

			var result3 = from s in values where s.ToLower().Contains("a") select s;
			Console.WriteLine("result3=" + string.Join(",", result3));

			var result4 = from s in values where s.ToLower().Contains("a") && s.Length > 2 select s;
			Console.WriteLine("result4=" + string.Join(",", result4));

			var result5 = from s in values where s.ToLower().Contains("a") || s.Length > 2 select s;
			Console.WriteLine("result5=" + string.Join(",", result5));
		}

		private void button3_Click(object sender, EventArgs e)
		{
			var products = new List<Product>();
			products.Add(new Product(10, "p10A", 300));
			products.Add(new Product(20, "p20", 300));
			products.Add(new Product(30, "x301A", 200));
			products.Add(new Product(40, "P40", 500));

			var result1 = from p in products where p.ProductName[0] == 'p' select p;

			foreach (var val in result1)
			{
				Console.WriteLine($"result1 id={val.ProductId}, name={val.ProductName}, price={val.Price}");
			}

			var result2 = from p in products where p.ProductName.ToLower()[0] == 'p' select p;

			foreach (var val in result2)
			{
				Console.WriteLine($"result2 id={val.ProductId}, name={val.ProductName}, price={val.Price}");
			}

			//昇順
			var result3 = from p in products where p.ProductName.ToLower()[0] == 'p' orderby p.Price select p;

			foreach (var val in result3)
			{
				Console.WriteLine($"result3 id={val.ProductId}, name={val.ProductName}, price={val.Price}");
			}

			//降順
			var result4 = from p in products where p.ProductName.ToLower()[0] == 'p' orderby p.Price descending select p;

			foreach (var val in result4)
			{
				Console.WriteLine($"result4 id={val.ProductId}, name={val.ProductName}, price={val.Price}");
			}

			//並べ替え複数
			var result5 = from p in products where p.ProductName.ToLower()[0] == 'p' orderby p.Price descending, p.ProductId descending select p;

			foreach (var val in result5)
			{
				Console.WriteLine($"result5 id={val.ProductId}, name={val.ProductName}, price={val.Price}");
			}

			//必要な項目だけ取得
			var result6 = from p in products where p.ProductName.ToLower()[0] == 'p' orderby p.Price descending, p.ProductId descending select p.ProductName;

			foreach (var val in result6)
			{
				Console.WriteLine($"result6 name={val}, ");
			}

			//必要な項目だけ取得 複数パターン
			var result7 = from p in products where p.ProductName.ToLower()[0] == 'p' orderby p.Price descending, p.ProductId descending select new { p.ProductName, p.Price };

			foreach (var val in result7)
			{
				Console.WriteLine($"result7 name={val.ProductName}, price={val.Price}");
			}

			//別名を付ける
			var result8 = from p in products where p.ProductName.ToLower()[0] == 'p' orderby p.Price descending, p.ProductId descending select new { p.ProductName, AAA = p.Price };

			foreach (var val in result8)
			{
				Console.WriteLine($"result8 name={val.ProductName}, price={val.AAA}");
			}

			var result9 = from p in products where p.ProductName.ToLower()[0] == 'p' orderby p.Price descending, p.ProductId descending select new { p.ProductName, AAA = p.Price + "円" };

			foreach (var val in result9)
			{
				Console.WriteLine($"result9 name={val.ProductName}, price={val.AAA}");
			}

			// 別のクラスに置き換える
			var result10 = from p in products where p.ProductName.ToLower()[0] == 'p' orderby p.Price descending, p.ProductId descending select new ProductDto(p.ProductId.ToString(), p.ProductName);

			foreach (var val in result10)
			{
				Console.WriteLine($"result10 {val}");
			}

			// 別のクラスに置き換える
			var result11 = from p in products where p.ProductName.ToLower()[0] == 'p' orderby p.Price descending, p.ProductId descending select new ProductDto(p);

			foreach (var val in result11)
			{
				Console.WriteLine($"result11 {val}");
			}

			var result12 = from p in products where p.ProductName.ToLower()[0] == 'p' orderby p.Price descending, p.ProductId descending select new ProductEntity { ProductId = p.ProductId.ToString(), ProductName = p.ProductName };

			foreach (var val in result12)
			{
				Console.WriteLine($"result12 {val}");
			}
		}
	}
}
