using ChampionReview.Module.Helper;
using PersonApi.Module.Module;
using PersonApi.Module.result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonApi.Business.InterfFace
{
    public interface IPerson
    {
        Task<RESTServiceResponse<List<PersonModel>>> GetPerson();
        Task<RESTServiceResponse<List<PAddress>>> GetPersonAdress();
        Task<RESTServiceResponse<PersonModel>> GetPersonById(int Key);
        Task<RESTServiceResponse<bool>> AddPerson(PersonModel model);
        Task<RESTServiceResponse<bool>> UpdatePerson(PersonModel model);
        Task<RESTServiceResponse<bool>> DeletPerson(PersonModel model);





    }
}
