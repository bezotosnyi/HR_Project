﻿using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Entities.Setup;
using Domain.Repositories;
using WebApi.DTO;
using WebApi.DTO.DTOModels;


namespace WebApi.Controllers
{
    public class VacanciesController : BoTController
    {
        IVacancyRepository _vacancyRepository;
        public VacanciesController(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        } 

        [HttpGet]
        public HttpResponseMessage All()
        {
            var vacanciesDto = _vacancyRepository.GetAll().Select(x => DTOService.VacancyToDTO(x)).ToList();
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = SerializeContent(vacanciesDto),
            };
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response;
            var foundedVacancy = _vacancyRepository.Get(id);
            if (foundedVacancy != null)
            {
                var foundedVacancyDto = DTOService.VacancyToDTO(foundedVacancy);
                response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = SerializeContent(foundedVacancyDto)
                };
            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            return response;
        }

        [Route("api/vacancies/{vacancyId}/candidates")]
        [HttpGet]
        public HttpResponseMessage VacanciesProgress(int vacancyId)
        {
            HttpResponseMessage response;
            var foundedVacancy = _vacancyRepository.Get(vacancyId);
            if (foundedVacancy!=null)
            {
                response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = SerializeContent(foundedVacancy.CandidatesProgress)
                };
            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response;
            var foundedVacancy = _vacancyRepository.Get(id);
            if (foundedVacancy != null)
            {
                _vacancyRepository.Remove(foundedVacancy);
                response = new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            return response;
        }

        [HttpPost]
        public HttpResponseMessage Add([FromBody]JObject entity)
        {
            var newVacancyDto = entity.ToObject<VacancyDTO>();
            var newVacancy = DTOService.DTOToVacancy(newVacancyDto);
            _vacancyRepository.Add(newVacancy);
            return new HttpResponseMessage() {
                StatusCode = HttpStatusCode.Created
            };
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]JObject entity)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var changedVacancyDto = entity.ToObject<VacancyDTO>();
            if (changedVacancyDto != null)
            {
                var changedVacancy = DTOService.DTOToVacancy(changedVacancyDto);
                _vacancyRepository.Update(changedVacancy);
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
            }
            return response;
        }

    }
}
