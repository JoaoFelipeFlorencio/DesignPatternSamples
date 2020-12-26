using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using DesignPatternSamples.Application.DTO;

namespace DesignPatternSamples.Infra.Repository.Detran
{
	public class DetranPEVerificadorPontosRepository : DetranVerificadorPontosRepositoryCrawlerBase
	{

		private readonly ILogger _Logger;

		public DetranPEVerificadorPontosRepository(ILogger<DetranPEVerificadorPontosRepository>logger) 
		{
			_Logger = logger;
		}


		protected override Task<IEnumerable<PontosCarteira>> PadronizarResultado(string html)
		{
			_Logger.LogDebug($"Padronizando o Resultado {html}.");
			return Task.FromResult<IEnumerable<PontosCarteira>>(new List<PontosCarteira>() { new PontosCarteira() { DataDaOcorrencia = DateTime.UtcNow, Descricao ="Gravissima", Pontos = 7}, new PontosCarteira() { DataDaOcorrencia = DateTime.UtcNow, Descricao = "Leve", Pontos = 3 } });
		}

		protected override Task<string> RealizarAcesso(Carteira carteira)
		{
			Task.Delay(5000).Wait();
			_Logger.LogDebug($"Buscando pontos da carteira de numero {carteira.Numero} para o estado de PE.");
			return Task.FromResult("CONTEUDO DO SITE DO DETRAN PE");
		}
	}
}
