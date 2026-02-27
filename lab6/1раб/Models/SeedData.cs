using Microsoft.EntityFrameworkCore;
using Rabota1.Data;

namespace Rabota1.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context == null || context.Car == null)
                {
                    throw new ArgumentNullException("Null ApplicationDbContext");
                }

                if (context.Car.Any())
                {
                    return;
                }

                context.Car.AddRange(
                    new Car { Brand = "Toyota", Model = "Camry", Year = 2024, CarType = "Седан", Price = 2500000M },
                    new Car { Brand = "BMW", Model = "X5", Year = 2023, CarType = "Внедорожник", Price = 6800000M },
                    new Car { Brand = "Mercedes-Benz", Model = "GLE", Year = 2024, CarType = "Кроссовер", Price = 7200000M },
                    new Car { Brand = "Volkswagen", Model = "Polo", Year = 2023, CarType = "Компактный", Price = 1900000M },
                    new Car { Brand = "Audi", Model = "A6", Year = 2024, CarType = "Премиум-седан", Price = 5400000M },
                    new Car { Brand = "Honda", Model = "Civic", Year = 2022, CarType = "Седан", Price = 1700000M },
                    new Car { Brand = "Honda", Model = "CR-V", Year = 2023, CarType = "Кроссовер", Price = 3200000M },
                    new Car { Brand = "Ford", Model = "Focus", Year = 2021, CarType = "Хэтчбек", Price = 1300000M },
                    new Car { Brand = "Ford", Model = "Mustang", Year = 2022, CarType = "Купе", Price = 5500000M },
                    new Car { Brand = "Chevrolet", Model = "Camaro", Year = 2021, CarType = "Купе", Price = 4800000M },
                    new Car { Brand = "Tesla", Model = "Model 3", Year = 2024, CarType = "Электро", Price = 4500000M },
                    new Car { Brand = "Tesla", Model = "Model Y", Year = 2024, CarType = "Кроссовер", Price = 5200000M },
                    new Car { Brand = "Nissan", Model = "Qashqai", Year = 2022, CarType = "Кроссовер", Price = 2200000M },
                    new Car { Brand = "KIA", Model = "Rio", Year = 2021, CarType = "Компактный", Price = 950000M },
                    new Car { Brand = "KIA", Model = "Seltos", Year = 2023, CarType = "Кроссовер", Price = 2000000M },
                    new Car { Brand = "Hyundai", Model = "Elantra", Year = 2022, CarType = "Седан", Price = 1400000M },
                    new Car { Brand = "Hyundai", Model = "Sonata", Year = 2023, CarType = "Седан", Price = 2100000M },
                    new Car { Brand = "Genesis", Model = "G80", Year = 2024, CarType = "Премиум-седан", Price = 7800000M },
                    new Car { Brand = "Subaru", Model = "Outback", Year = 2022, CarType = "Универсал", Price = 2800000M },
                    new Car { Brand = "Mazda", Model = "6", Year = 2021, CarType = "Седан", Price = 1600000M },
                    new Car { Brand = "Lada", Model = "Vesta", Year = 2020, CarType = "Седан", Price = 650000M },
                    new Car { Brand = "Renault", Model = "Logan", Year = 2021, CarType = "Седан", Price = 720000M },
                    new Car { Brand = "Peugeot", Model = "308", Year = 2022, CarType = "Хэтчбек", Price = 1250000M },
                    new Car { Brand = "Skoda", Model = "Octavia", Year = 2023, CarType = "Универсал", Price = 2150000M },
                    new Car { Brand = "Mitsubishi", Model = "Outlander", Year = 2022, CarType = "Кроссовер", Price = 2400000M },
                    new Car { Brand = "Volvo", Model = "XC60", Year = 2023, CarType = "Кроссовер", Price = 6100000M },
                    new Car { Brand = "Lexus", Model = "RX", Year = 2023, CarType = "Премиум-кроссовер", Price = 7500000M },
                    new Car { Brand = "Porsche", Model = "Macan", Year = 2022, CarType = "Кроссовер", Price = 9800000M }
                );
                context.SaveChanges();
            }
        }
    }
}
