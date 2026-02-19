using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prodzsekt
{
	internal class Kezelo
	{
		private string nev;
		private string azonosito;
		private Szereepkor szerepkor;

		public Kezelo(string nev, string azonosito, Szereepkor szerepkor)
		{
			this.nev = nev;
			this.azonosito = azonosito;
			this.szerepkor = szerepkor;
		}

		public string Nev { get => nev; set => nev = value; }
		public string Azonosito { get => azonosito; set => azonosito = value; }
		internal Szereepkor Szerepkor { get => szerepkor; set => szerepkor = value; }
	}
}
