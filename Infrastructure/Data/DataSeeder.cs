using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Infrastructure.Data
{
    public static class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VehicleDbContext(serviceProvider.GetRequiredService<DbContextOptions<VehicleDbContext>>()))
            {
                if (context.Petrols.CountAsync().Result != 0)
                {
                    return;
                }
                var petrol1 = new Petrol { Name = "Бензин" };
                var petrol2 = new Petrol { Name = "Дизель" };
                var petrol3 = new Petrol { Name = "Газ природный" };
                var petrol4 = new Petrol { Name = "Пропан" };
                
                

                if (context.Engines.CountAsync().Result != 0)
                {
                    return;
                }
                var engine1 = new Engine() { Name = "CZCA", Number = "CFN637635", PetrolType = petrol1, Power = 125, Volume = 1.6 };
                var engine2 = new Engine() { Name = "AMF", Number = "CND223432", PetrolType = petrol2, Power = 75, Volume = 1.4};
                                  
                

                if (context.Employees.CountAsync().Result != 0)
                {
                    return;
                }
               // var role1 = context.SystemRoles.Find(1);
                var employee1 = new Employee()
                {
                   
                    FirstName = "Павел",
                    LastName = "Павлов",
                    DriveLicenseNumber = "АА00002232",
                    
                         
                };
                //var role2 = context.SystemRoles.Find(2);
                var employee2 = new Employee()
                {
                   
                    FirstName = "Сергей",
                    LastName = "Костинский",
                    DriveLicenseNumber = "GD3300234099",
                  
                };
               

                if (context.Vehicles.CountAsync().Result != 0)
                {
                    return;
                }


                var vehicle1 = new Vehicle()
                {
                    
                    Brand = "Volkswagen",
                    Model = "Polo Sedan",
                    Color = "Красный",
                    VINCode = "XW8ZZZ61ZDG000713",
                    ChassisNumber = "232SR",
                    HullNumber = "22332",
                    MaxMass = 1300,
                    StockMass = 1000,
                    RegistPlate = "AB3423",
                    Mileage = "13000",
                    Name = "VW Polo sedan 2019",
                    Engine = engine1,
                    ReleaseYear = 2019,
                    Type = "Легковой",
                    PhotoPath = "default",
                    Employee = employee1
                };
                var vehicle2 = new Vehicle()
                    {
                        
                        Brand = "Volkswagen",
                        Model = "Polo Sedan",
                        Color = "Синий",
                        VINCode = "XW8ZZZ61ZDG000713",
                        ChassisNumber = "232SE",
                        HullNumber = "22332",
                        MaxMass = 1300,
                        StockMass = 1000,
                        RegistPlate = "AB3411",
                        Mileage = "12010",
                        Name = "VW Polo sedan 2018",
                        Engine = engine1,
                        ReleaseYear = 2019,
                        Type = "Легковой",
                        PhotoPath = "default",
                        Employee = employee2
                    };
                

                context.Petrols.AddRange(petrol1, petrol2, petrol3, petrol4);
                context.Engines.AddRange(engine1, engine2);

                context.Employees.AddRange(employee1, employee2);
                context.Vehicles.AddRange(vehicle1, vehicle2);
                context.SaveChanges();
            }
        }

    }
}
