using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternSamples.Application.DTO
{
	[Serializable]
	public class PontosCarteira
	{

		public DateTime DataDaOcorrencia{ get; set; }

		public string Descricao { get; set; }

		public byte	Pontos { get; set; }
	}
}
