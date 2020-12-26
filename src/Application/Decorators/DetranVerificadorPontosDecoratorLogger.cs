using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Services;
using Microsoft.Extensions.Logging;

namespace DesignPatternSamples.Application.Decorators
{
	public class DetranVerificadorPontosDecoratorLogger : IDetranVerificadorPontosService
	{

		private readonly IDetranVerificadorPontosService _Inner;
		private readonly ILogger<DetranVerificadorPontosDecoratorLogger> _Logger;


		public DetranVerificadorPontosDecoratorLogger(IDetranVerificadorPontosService inner,ILogger<DetranVerificadorPontosDecoratorLogger> logger)
		{
			_Inner = inner;
			_Logger = logger;
		}

		public async Task<IEnumerable<PontosCarteira>> ConsultarPontos(Carteira carteira)
		{
			Stopwatch watch = Stopwatch.StartNew();
			_Logger.LogInformation($"Iniciando a execução do método ConsultarPontos({carteira})");
			var result = await _Inner.ConsultarPontos(carteira);
			watch.Stop();
			_Logger.LogInformation($"Encerrando a execução do método ConsultarPontos({carteira}) {watch.ElapsedMilliseconds}ms");
			return result;
		}
	}
}
