using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DesignPatternSamples.Application.DTO;

namespace DesignPatternSamples.Application.Services
{
	public interface IDetranVerificadorPontosService
	{

		Task<IEnumerable<PontosCarteira>> ConsultarPontos(Carteira carteira);
	}
}
