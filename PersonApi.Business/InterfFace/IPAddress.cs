using ChampionReview.Module.Helper;
using PersonApi.Module.Module;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonApi.Business.InterfFace
{
    public interface IPAddress
    {
        Task<RESTServiceResponse<List<PersonAddressModel>>> GetAddress();
        Task<RESTServiceResponse<PersonAddressModel>> GetAddressById(int Key);
        Task<RESTServiceResponse<bool>> AddAddressn(PersonAddressModel model);
        Task<RESTServiceResponse<bool>> UpdateAddress(PersonAddressModel model);
        Task<RESTServiceResponse<bool>> DeletAddress(PersonAddressModel model);
    }
}
