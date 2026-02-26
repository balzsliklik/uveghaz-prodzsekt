using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace prodzsekt
{
	internal class UveghazRacs
	{
		int meret;
		Cella[,] kert;
		public UveghazRacs(int meret)
		{
			this.meret = meret;
			this.kert = new Cella[this.meret, this.meret];
		}
		private void Parcellazas()
		{
			for(int i = 0; i<this.kert.GetLength(0); i++)
			{
				for (int j = 0; j < this.kert.GetLength(1); j++)
				{
					this.kert[i, j] = new Cella(new Pozicio(i, j));
				}
			}
		}
		public Cella CellaLekerdezes(int x, int y)
		{
			return kert[x-1, y-1];

		}
		public void Telepit(int x, int y, NovenyFaj noveny, int egyedszam)
		{
			bool sikeres = kert[x-1, y-1].Beultet(noveny, egyedszam);
			if (sikeres)
			{
				Console.WriteLine($"{noveny.Nev} beültetve a {x} - {y} agyasba");
			}
			else
			{
				Console.WriteLine($"{noveny.Nev} nem lett beultetve a {x} - {y} agyasba");
			}
		}

		public void Kiiratas()
		{
			Console.WriteLine("\n-------------------------------------------------------");
			for (int i = 0; i< this.kert.GetLength(0); i++)
			{
				Console.Write("|");
				for (int j = 0; j< this.kert.GetLength(1); j++)
				{
					if (kert[i, j].UresCella)
					{
						Console.Write($"| {"ÜRES", 8} |");
					}else
					{
						Console.Write($"| {kert[i, j].Noveny.Azonosito,3} {kert[i,j].EgyedSzam}db |");
					}
					

				}
				Console.Write("\n-------------------------------------------------------");
			}
			Console.WriteLine();
		}

		public void Novlelse(int x, int y, int mennyiseg)
		{
			kert[x-1, y-1].Noveles(mennyiseg);
			Console.WriteLine($"{x}-{y} ágyás novénye a {kert[x-1,y-1].Noveny.Nev}  uj egyedszám: {kert[x - 1, y - 1].Noveny.Egyedszam}");
			if(kert[x - 1, y - 1].Noveny.OptimalisSuruseg > kert[x-1, y - 1].Noveny.Egyedszam)
			{
				Console.WriteLine("novenyek oksak");
			}
			else
			{
				Console.WriteLine("novenyek tul sokan vanak");
				Csokkentes(x - 1, y - 1, (kert[x - 1, y - 1].Noveny.Egyedszam - kert[x - 1, y - 1].Noveny.OptimalisSuruseg));
			}
		}

		public void Csokkentes(int x, int y, int mennyiseg)
		{
			kert[x - 1, y - 1].Csokkentes(mennyiseg);
			Console.WriteLine($"{x}-{y} ágyás csokkentese a {kert[x - 1, y - 1].Noveny.Nev}  uj egyedszám: {kert[x - 1, y - 1].Noveny.Egyedszam}");
			Console.WriteLine($"{x}-{y} ágyás  {kert[x - 1, y - 1].Noveny.Nev}  uj egyedszám: {kert[x - 1, y - 1].Noveny.Egyedszam}");


		}
	}
}
