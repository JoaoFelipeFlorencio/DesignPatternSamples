﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Repository;

namespace DesignPatternSamples.Infra.Repository.Detran
{
	public abstract class DetranVerificadorPontosRepositoryCrawlerBase : IDetranVerificadorPontosRepository
	{
		public async Task<IEnumerable<PontosCarteira>> ConsultarPontos(Carteira carteira)
		{
			var html = await RealizarAcesso(carteira);
			return await PadronizarResultado(html);
		}


		protected abstract Task<string> RealizarAcesso(Carteira carteira);

		protected abstract Task<IEnumerable<PontosCarteira>> PadronizarResultado(string html);
	}
}
