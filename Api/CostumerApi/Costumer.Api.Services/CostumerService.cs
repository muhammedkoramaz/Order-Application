using Costumer.Api.Infastructure;
using Costumer.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Costumer.Api.Services
{
    public class CostumerService : ICostumerService
    {
        public CostumerDTO GetCostumerById(int id)
        {
            //BURADA VERİTABANINDAN ALINACAK VERİ VE SERVİS O VERİYİ DÖNDERECEK.
            Address address = new Address() { AddressLine = "asd", City = "Kayseri", CityCode = 38, Country = "Turkey" };   //geçici çözüm
            
            return new CostumerDTO()
            {
                Id = id,
                Email = "muhammed@gmail.com",
                Name = "Muhammed",
                Address = address,
                
                //Address = {AddressLine = "asd", City = "Kayseri", CityCode = 38, Country = "Turkey"}

            };
        }
    }
}
