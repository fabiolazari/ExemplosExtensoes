using System;
using System.ComponentModel;

namespace ExemplosExtensoes
{
	public class Program
	{
		private enum eMesesAno
		{
			[Description("Janeiro")]
			JAN,
			[Description("Fevereiro")]
			FEV,
			[Description("Março")]
			MAR,
			[Description("Abril")]
			ABR,
			[Description("Maio")]
			MAI,
			[Description("Junho")]
			JUN,
			[Description("Julho")]
			JUL,
			[Description("Agosto")]
			AGO,
			[Description("Setembro")]
			SET,
			[Description("Outubro")]
			OUT,
			[Description("Novembro")]
			NOV,
			[Description("Dezembro")]
			DEZ
		}

		static void Main(string[] args)
		{
			//strings
			string nome = "Teste de String!";
			string nomao = nome.ToMeuUpper();
			string nominho = nome.ToMeuLower();
			int quantidade = nome.ContaCaracter();
			string nomeRepetido = nome.RepeteTexto(4);
			int quantidadeTotal = nomeRepetido.ContaCaracter();

			//Inteiros
			int num = 14;

			int doblo = num.Doblo();
			int soma = num.SomaCom(23);
			int sub = num.SubtraiDe(16);

			//Enums
			string mes = eMesesAno.NOV.ToDescription();
			var descricao = mes.GetValueFromDescription<eMesesAno>();

			Console.ReadLine();
		}
	}
}
