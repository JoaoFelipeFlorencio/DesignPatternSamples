using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Services;
using DesignPatternSamples.WebAPI.Models;
using DesignPatternSamples.WebAPI.Models.Detran;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternSamples.WebAPI.Controllers.Detran
{
	[Route("api/Detran/[controller]")]
	[ApiController]
	public class PontosController : ControllerBase
	{
		private readonly IMapper _Mapper;
		private readonly IDetranVerificadorPontosService _ClinicaVerificadorConsultaServices;


		public PontosController(IMapper mapper, IDetranVerificadorPontosService clinicaVerificadorConsultaServices)
		{
			_Mapper = mapper;
			_ClinicaVerificadorConsultaServices = clinicaVerificadorConsultaServices;
		}

		[HttpGet]
		[ProducesResponseType(typeof(SuccessResultModel<IEnumerable<PontosCarteiraModel>>), StatusCodes.Status200OK)]
		public async Task<IActionResult> Get([FromQuery]CarteiraModel model) 
		{
			var pontos = await _ClinicaVerificadorConsultaServices.ConsultarPontos(_Mapper.Map<Carteira>(model));

			var result = new SuccessResultModel<IEnumerable<PontosCarteiraModel>>(_Mapper.Map<IEnumerable<PontosCarteiraModel>>(pontos));

			return Ok(result);
		}
	}
}
