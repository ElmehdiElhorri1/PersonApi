using ChampionReview.Module.Helper;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using PersonApi.Business.InterfFace;
using PersonApi.Data.Contexts;
using PersonApi.Data.Models;
using PersonApi.Module.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonApi.Business.Repository
{
    public class PAddressRepository : BaseRepository, IPAddress
    {
        public PAddressRepository(PersonApiContext context) : base(context)
        {
        }

        public async Task<RESTServiceResponse<bool>> AddAddressn(PersonAddressModel model)
        {
            try
            {
                PersonAddress address = new PersonAddress();

                address.PersonAddressKey = model.PersonAddressKey;
                address.Street = model.Street;
                address.State = model.State;
                address.Apartment = model.Apartment;
                address.City = model.City;
                address.Zip = model.Zip;
                address.PersonKey = model.PersonKey;
                _context.PersonAddress.Add(address);




                if (await _context.SaveChangesAsync() > 0)
                    return new RESTServiceResponse<bool>(true, "success", true);

                return new RESTServiceResponse<bool>(false, "failed");
            }
            catch (Exception ex)
            {
                return new RESTServiceResponse<bool>(false, ex.Message);
            }
        }

        public async Task<RESTServiceResponse<bool>> DeletAddress(PersonAddressModel model)
        {
            try
            {
                var result = await _context.PersonAddress
                    .Where(w => w.PersonAddressKey == model.PersonAddressKey)
                    .FirstOrDefaultAsync();

                if (result != null)
                {
                    _context.PersonAddress.Remove(result);
                }


                if (await _context.SaveChangesAsync() > 0)
                    return new RESTServiceResponse<bool>(true, "success", true);

                return new RESTServiceResponse<bool>(false, "failed");
            }
            catch (Exception ex)
            {
                return new RESTServiceResponse<bool>(false, ex.Message);
            }
        }

        public async Task<RESTServiceResponse<List<PersonAddressModel>>> GetAddress()
        {


            var result = await _context.PersonAddress.Select(s => new PersonAddressModel
            {
                PersonAddressKey = s.PersonAddressKey,
                Street = s.Street,
                State = s.State,
                Apartment = s.Apartment,
                City = s.City,
                Zip = s.Zip,
                PersonKey = s.PersonKey
            }).ToListAsync();



            return new RESTServiceResponse<List<PersonAddressModel>>(true, "success", result);
        }

        public async Task<RESTServiceResponse<PersonAddressModel>> GetAddressById(int Key)
        {
            var result = await _context.PersonAddress
                .Where(i => i.PersonAddressKey == Key)
                .Select(s => new PersonAddressModel
                {
                    PersonAddressKey = s.PersonAddressKey,
                    Street = s.Street,
                    State = s.State,
                    Apartment = s.Apartment,
                    City = s.City,
                    Zip = s.Zip,
                    PersonKey = s.PersonKey
                }).FirstOrDefaultAsync();

            return new RESTServiceResponse<PersonAddressModel>(true, "success", result);
        }

        public async Task<RESTServiceResponse<bool>> UpdateAddress(PersonAddressModel model)
        {

            try
            {
                var result = await _context.PersonAddress
                    .Where(w => w.PersonAddressKey == model.PersonAddressKey)
                    .FirstOrDefaultAsync();

                if (result != null)
                {
                    result.Apartment = model.Apartment;
                    result.City = model.City;
                    result.Zip = model.Zip;
                    result.State = model.State;
                    result.Street = model.Street;
                    //result.PersonKey = model.PersonKey;
                }


                // select * from Person where w.key=Model.Key

                if (await _context.SaveChangesAsync() > 0)
                    return new RESTServiceResponse<bool>(true, "success", true);

                return new RESTServiceResponse<bool>(false, "failed");
            }
            catch (Exception ex)
            {
                return new RESTServiceResponse<bool>(false, ex.Message);
            }
        }
    }

}

