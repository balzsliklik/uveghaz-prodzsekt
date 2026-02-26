using prodzsekt;
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace uveghazrendszer

{

	internal class Cella

	{

		Pozicio poz;

		Novenyfaj noveny;

		int egyedSzam;

		List<Riasztas> riasztasok;

		List<Szenzor> szenzorok;

		public Cella(Pozicio poz)

		{

			Novenyfaj noveny = null;

			this.poz = poz;

			egyedSzam = 0;

			riasztasok = new List<Riasztas>();

			szenzorok = new List<Szenzor>();

		}

		public int EgyedSzam { get => egyedSzam; set => egyedSzam = value; }

		internal Pozicio Poz { get => poz; set => poz = value; }

		internal Novenyfaj Noveny { get => noveny; set => noveny = value; }

		internal List<Riasztas> Riasztasok { get => riasztasok; set => riasztasok = value; }

		internal List<Szenzor> Szenzorok { get => szenzorok; set => szenzorok = value; }

		public bool UresCella

		{

			get

			{

				return this.noveny == null;

			}

		}

		public bool Beultet(Novenyfaj noveny, int egyedSzam)

		{

			if (this.UresCella)

			{

				this.noveny = noveny;

				this.egyedSzam = egyedSzam;

				if (this.egyedSzam > noveny.OptimalSuruseg)

				{

					this.noveny.EgeszsegiAllapot -= 2;

				}

				return true;

			}

			else if (noveny == this.noveny)

			{

				this.egyedSzam += egyedSzam;

				if (this.egyedSzam > noveny.OptimalSuruseg)

				{

					this.noveny.EgeszsegiAllapot -= 2;

				}

				return true;

			}

			else

			{

				return false;

			}

		}

		public void Noveles(int egyedszam)

		{

			this.Beultet(this.noveny, egyedszam);

		}

		public void Csokkentes(int egyedszam)

		{

			this.egyedSzam -= egyedszam;

			if (this.egyedSzam <= 0)

			{

				this.Urit();

			}

		}

		public void Urit()

		{

			this.egyedSzam = 0;

			this.noveny = null;

		}

		public override string ToString()

		{

			return $"{this.noveny.Nev} {this.egyedSzam} db {this.noveny.EgeszsegiAllapot}";

		}

	}

}

