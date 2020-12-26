using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DesignPatternSamples.Application.DTO;
using Microsoft.Extensions.Logging;

namespace DesignPatternSamples.Infra.Repository.Detran
{
	public class DetranBAVerificadorPontosRepository : DetranVerificadorPontosRepositoryCrawlerBase
	{


		private readonly ILogger _Logger;

		public DetranBAVerificadorPontosRepository(ILogger<DetranBAVerificadorPontosRepository> logger)
		{
			_Logger = logger;
		}

		protected override Task<IEnumerable<PontosCarteira>> PadronizarResultado(string html)
		{
			_Logger.LogDebug($"Padronizando o Resultado {html}.");
			return Task.FromResult<IEnumerable<PontosCarteira>>(new List<PontosCarteira>() { new PontosCarteira() { DataDaOcorrencia = DateTime.UtcNow, Descricao = "Media", Pontos = 5 }, new PontosCarteira() { DataDaOcorrencia = DateTime.UtcNow, Descricao = "Media", Pontos = 5 } });
		}

		protected override Task<string> RealizarAcesso(Carteira carteira)
		{
			_Logger.LogDebug($"Buscando pontos da carteira de numero {carteira.Numero} para o estado de BA.");
			return Task.FromResult("CONTEUDO DO SITE DO DETRAN BA");
		}
	}
}
