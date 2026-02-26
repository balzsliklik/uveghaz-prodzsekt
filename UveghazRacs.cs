using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uveghazrendszer
{
	internal class UveghazRacs
	{
		int meret;
		Cella[,] kert;

		public UveghazRacs(int meret)
		{
			this.meret = meret;
			this.kert = new Cella[this.meret, this.meret];
			Parcellaz();
		}

		private void Parcellaz()
		{
			for (int i = 0; i < this.kert.GetLength(0); i++)
			{
				for (int j = 0; j < this.kert.GetLength(1); j++)
				{
					this.kert[i, j] = new Cella(new Pozicio(i, j));
				}
			}
		}

		public Cella CellaLekerdez(int x, int y)
		{
			return kert[x - 1, y - 1];
		}

		public void Telepit(int x, int y, Novenyfaj noveny, int egyedszam)
		{
			bool sikeres = kert[x - 1, y - 1].Beultet(noveny, egyedszam);
			if (sikeres)
			{
				Console.WriteLine($"{noveny.Nev} beültetve a {x}-{y} ágyásba.");
			}
			else
			{
				Console.WriteLine($"{noveny.Nev} nem lett beültetve.. :c");
			}
		}


		public void Noveles(int x, int y, int mennyiseg)
		{
			kert[x - 1, y - 1].Noveles(mennyiseg);
			Console.WriteLine($"{x}, {y} ágyás növénye, a(z) {kert[x - 1, y - 1].Noveny.Nev}, egyedszám: {kert[x - 1, y - 1].EgyedSzam}");
			if (kert[x - 1, y - 1].Noveny.OptimalSuruseg > kert[x - 1, y - 1].EgyedSzam)
			{
				Console.WriteLine("A növények jól érzik magukat.");
			}
			else
			{
				Console.WriteLine("A növéynek sokan vannak, nem érzik jól magukat.");
				Csokkentes(x, y, Math.Abs(kert[x - 1, y - 1].Noveny.OptimalSuruseg - kert[x - 1, y - 1].EgyedSzam));
			}
		}

		public void Csokkentes(int x, int y, int mennyiseg)
		{
			kert[x - 1, y - 1].Csokkentes(mennyiseg);
			Console.WriteLine($"{x}, {y} ágyás növénye, a(z) {kert[x - 1, y - 1].Noveny.Nev}, egyedszám: {kert[x - 1, y - 1].EgyedSzam}");
		}

		public void CellaUrit(int x, int y)
		{
			kert[x - 1, y - 1].Urit();
		}

		public void Kiiratas()
		{
			for (int i = 0; i < this.kert.GetLength(0); i++)
			{
				Console.WriteLine();
				for (int v = 0; v < this.kert.GetLength(0); v++)
				{
					Console.Write("----------");
				}
				Console.WriteLine();
				Console.Write("|");
				for (int j = 0; j < this.kert.GetLength(1); j++)
				{
					if (kert[i, j].UresCella)
					{
						Console.Write($"  Üres  |");
					}
					else
					{
						Console.Write($"{kert[i, j].Noveny.Azonosito,3} {kert[i, j].EgyedSzam}db |");
					}
				}
				Console.WriteLine();
				for (int v = 0; v < this.kert.GetLength(0); v++)
				{
					Console.Write("----------");
				}
				Console.WriteLine();
				//Console.WriteLine("\n------------------------------------------------------------------------------------------");
			}
		}

		public void CellaUrites(int x, int y)
		{
			kert[x - 1, y - 1].Urit();
			Console.WriteLine($"{x-1} - {y-1} cella ki lett ürítve");
		}
		public void Szomszedok(int x, int y)
		{
			Console.WriteLine($"{x - 1} - {y - 1} cell szomszédjai: \n----------------");
			for (int i = 0; i< this.kert.GetLength(0); i++)
			{
				for (int j = 0; j< this.kert.GetLength(1); j++)
				{
					if ((j - (x-1) == 1 || j - (x - 1) == -1)&& (i - (x - 1) == 1 || i - (x - 1) == -1))
					{

					}
				}
			}
		}

	}
}
