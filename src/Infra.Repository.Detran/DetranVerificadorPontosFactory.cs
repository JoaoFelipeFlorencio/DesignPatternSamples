using System;
using System.Collections.Generic;
using System.Text;
using DesignPatternSamples.Application.Repository;

namespace DesignPatternSamples.Infra.Repository.Detran
{
	public class DetranVerificadorPontosFactory : IDetranVerificadorPontosFactory
	{
		private readonly IServiceProvider _serviceProvider;
		private readonly IDictionary<string, Type> _Repositories = new Dictionary<string, Type>();

		public DetranVerificadorPontosFactory(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}
		public IDetranVerificadorPontosRepository Create(string UF)
		{
			IDetranVerificadorPontosRepository result = null;

			if (_Repositories.TryGetValue(UF, out Type type)) 
			{
				result = _serviceProvider.GetService(type) as IDetranVerificadorPontosRepository;
			}

			return result;
		}

		public IDetranVerificadorPontosFactory Register(string UF, Type repository)
		{
			if (!_Repositories.TryAdd(UF, repository)) 
			{
				_Repositories[UF] = repository;
			}

			return this;
		}
	}
}
