using ChampionReview.Module.Helper;
using Microsoft.EntityFrameworkCore;
using PersonApi.Business.InterfFace;
using PersonApi.Data.Contexts;
using PersonApi.Data.Models;
using PersonApi.Module.Module;
using PersonApi.Module.result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonApi.Business.Repository
{
    public class PersonRepository : BaseRepository, IPerson
    {
        public PersonRepository(PersonApiContext context) : base(context)
        {
        }

        public async Task<RESTServiceResponse<bool>> AddPerson(PersonModel model)
        {
            try
            {
                Person person = new Person();
                person.PersonKey = model.PersonKey;
                person.FirstName = model.FirstName;
                person.LastName = model.LastName;
                _context.Person.Add(person);

                //-------------------------------------

               

                //_context.Person.Add(new Person
                //{ 
                //    PersonKey = model.PersonKey,
                //    FirstName = model.FirstName,
                //    LastName = model.LastName,
                //});

                if (await _context.SaveChangesAsync() > 0)
                    return new RESTServiceResponse<bool>(true, "success", true);

                return new RESTServiceResponse<bool>(false, "failed");
            }
            catch (Exception ex)
            {
                return new RESTServiceResponse<bool>(false, ex.Message);
            }
        }

        public async Task<RESTServiceResponse<bool>> DeletPerson(PersonModel model)
        {
            try
            {
                var result = await _context.Person
                    .Where(w => w.PersonKey == model.PersonKey)
                    .FirstOrDefaultAsync();
                if(result != null)
                {
                    _context.Person.Remove(result);
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


        public async Task<RESTServiceResponse<List<PersonModel>>> GetPerson()
        {
            var result = await _context.Person.Select(s => new PersonModel
            {
                PersonKey = s.PersonKey,
                FirstName = s.FirstName,
                LastName = s.LastName
            }).ToListAsync();

          
            //var PersonAddres =  _context.PersonAddress
            //    .Include(i => i.PersonKey) 
                
            //    .Select(w => new PersonAddressModel
            //    {
            //      PersonAddressKey = w.PersonAddressKey,
            //      Apartment=w.Apartment,
            //      Street=w.Street,
            //      City=w.City,
            //      State=w.State,
            //      Zip=w.Zip,
            //      PersonKey=w.PersonKey,
            //    })
            //    .FirstOrDefaultAsync();



                return new RESTServiceResponse<List<PersonModel>>(true, "success", result );
        }

        public async Task<RESTServiceResponse<List<PAddress>>> GetPersonAdress()
        {
            var result = await (from p in _context.Person
                               join i in _context.PersonAddress
                               on p.PersonKey equals i.PersonKey
                               select new PAddress()
                               {
                                   Apartment = i.Apartment,
                                   LastName = p.LastName

                               }).ToListAsync();

            return new RESTServiceResponse<List<PAddress>>(true, "success", result);

            //PersonAddress personAddress = new PersonAddress();
            //var result = await _context.Person
            //     .Select(i => new PersonModel
            //     {
            //         PersonKey = i.PersonKey,
            //         FirstName = i.FirstName,
            //         LastName = i.LastName,


            //     }).ToListAsync();
            //Context.person.selecte(s => new {
            //    Adress = s.personadress.city

            //var result = await _context.Person.Select(s => new
            //{
            //    per
            //    Adress = s.PersonAddress.city,
            //}).Tolist();
            //var AddressPerson = await _context.PersonAddress
            //    .Include(i => i.PersonAddressKey)
            //    //.Where(s => s.PersonKey == s.PersonKey)
            //    .Select(w => new PersonAddressModel
            //    {
            //         Apartment= w.Apartment,
            //         PersonKey = w.PersonKey.select( w new PersonModel

            //             w.

            //             )
            //    } )
            //    .ToListAsync();



        }


        public async Task<RESTServiceResponse<PersonModel>> GetPersonById(int Key)
        {
            var result = await _context.Person.
                Where(u => u.PersonKey == Key).
                Select(u => new PersonModel
                {
                    PersonKey = u.PersonKey,
                    LastName = u.LastName,
                    FirstName = u.FirstName,
                }).FirstOrDefaultAsync();

            return new RESTServiceResponse<PersonModel>(true, "success", result);
        }

        public async Task<RESTServiceResponse<bool>> UpdatePerson(PersonModel model)
        {
            try
            {
                var result = await _context.Person
                    .Where(w => w.PersonKey == model.PersonKey)
                    .FirstOrDefaultAsync();

                if (result != null)
                {
                    result.LastName = model.LastName;
                    result.FirstName = model.FirstName;
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
