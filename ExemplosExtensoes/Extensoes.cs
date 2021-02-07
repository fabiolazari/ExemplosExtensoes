using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExemplosExtensoes
{
	public static class Extensoes
	{
		public static string ToMeuUpper(this string lstring)
		{
			return lstring.ToUpper();
		}

		public static string ToMeuLower(this string lstring)
		{
			return lstring.ToLower();
		}

		public static int ContaCaracter(this string lstring)
		{
			return lstring.Length;
		}

		public static string RepeteTexto(this string lstring, int quantidade)
		{
			string retorno = string.Empty;
			for (int i = 1; i <= quantidade; i++)
			{
				retorno += lstring;
			}
			return retorno;
		}

		public static int Doblo(this Int32 numero)
		{
			return numero * 2;
		}

		public static int SomaCom(this Int32 numero, Int32 numero2)
		{
			return numero + numero2;
		}

		public static int SubtraiDe(this Int32 numero, Int32 numero2)
		{
			return numero2 - numero;
		}

		public static string ToDescription(this Enum Enum)
		{
			FieldInfo fi = Enum.GetType().GetField(Enum.ToString());

			DescriptionAttribute[] attributes =
				(DescriptionAttribute[])fi.GetCustomAttributes(
				typeof(DescriptionAttribute),
				false);

			if (attributes != null &&
				attributes.Length > 0)
				return attributes[0].Description;
			else
				return Enum.ToString();
		}

		public static T GetValueFromDescription<T>(this string description)
		{
			var type = typeof(T);
			if (!type.IsEnum)
				throw new ArgumentException();

			FieldInfo[] fields = type.GetFields();
			var field = fields.SelectMany(f => f
							  .GetCustomAttributes(typeof(DescriptionAttribute), false), (f, a) => new { Field = f, Att = a })
							  .Where(a => ((DescriptionAttribute)a.Att).Description == description)
							  .SingleOrDefault();

			//return field == null ? "" : field.Field.Name.ToString();
			return field == null ? default : (T)field.Field.GetRawConstantValue();
		}

	}
}
