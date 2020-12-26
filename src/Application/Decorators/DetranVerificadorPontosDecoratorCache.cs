using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Services;
using Microsoft.Extensions.Caching.Distributed;
using Workbench.IDistributedCache.Extensions;

namespace DesignPatternSamples.Application.Decorators
{
	public class DetranVerificadorPontosDecoratorCache : IDetranVerificadorPontosService
	{

		private readonly IDetranVerificadorPontosService _Inner;
		private readonly IDistributedCache _Cache;

		public DetranVerificadorPontosDecoratorCache(IDetranVerificadorPontosService inner, IDistributedCache cache) 
		{
			_Inner = inner;
			_Cache = cache;
		}

		public Task<IEnumerable<PontosCarteira>> ConsultarPontos(Carteira carteira)
		{
			return Task.FromResult(_Cache.GetOrCreate($"{carteira.UF}_{carteira.Numero}", () => _Inner.ConsultarPontos(carteira).Result));
		}
	}
}
