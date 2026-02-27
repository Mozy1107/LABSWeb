using Microsoft.EntityFrameworkCore;
using Rabota2.Data;

namespace Rabota2.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Rabochiy.Any() || context.Inzhener.Any() || context.Administraciya.Any())
                {
                    return;
                }

                context.Rabochiy.AddRange(
                    new Rabochiy
                    {
                        Name = "Иванов Иван Иванович",
                        EmployeeType = "Механик",
                        Specialnost = "Механик по ремонту двигателей",
                        Ceh = "Отдел обслуживания"
                    },
                    new Rabochiy
                    {
                        Name = "Петров Петр Петрович",
                        EmployeeType = "Механик",
                        Specialnost = "Мастер кузовного ремонта",
                        Ceh = "Кузовной цех"
                    },
                    new Rabochiy
                    {
                        Name = "Сидоров Сидор Сидорович",
                        EmployeeType = "Механик",
                        Specialnost = "Механик по электрооборудованию",
                        Ceh = "Отдел обслуживания"
                    },
                    new Rabochiy
                    {
                        Name = "Васильев Василий Васильевич",
                        EmployeeType = "Механик",
                        Specialnost = "Мастер по диагностике",
                        Ceh = "Диагностический центр"
                    },
                    new Rabochiy
                    {
                        Name = "Николаев Николай Николаевич",
                        EmployeeType = "Механик",
                        Specialnost = "Специалист по автомасле",
                        Ceh = "Отдел обслуживания"
                    }
                );

                context.Inzhener.AddRange(
                    new Inzhener
                    {
                        Name = "Смирнова Анна Викторовна",
                        EmployeeType = "Специалист по продажам",
                        Kvalifikaciya = "Менеджер по продажам - высшая категория",
                        Podrazdelenie = "Отдел продаж легковых автомобилей"
                    },
                    new Inzhener
                    {
                        Name = "Кузнецов Алексей Дмитриевич",
                        EmployeeType = "Специалист по продажам",
                        Kvalifikaciya = "Менеджер по продажам - первая категория",
                        Podrazdelenie = "Отдел продаж коммерческого транспорта"
                    },
                    new Inzhener
                    {
                        Name = "Морозова Елена Сергеевна",
                        EmployeeType = "Специалист по продажам",
                        Kvalifikaciya = "Ведущий менеджер продаж",
                        Podrazdelenie = "Отдел продаж легковых автомобилей"
                    },
                    new Inzhener
                    {
                        Name = "Павлов Павел Павлович",
                        EmployeeType = "Специалист по продажам",
                        Kvalifikaciya = "Консультант по продажам - высшая категория",
                        Podrazdelenie = "Отдел обслуживания клиентов"
                    },
                    new Inzhener
                    {
                        Name = "Федорова Мария Ивановна",
                        EmployeeType = "Специалист по продажам",
                        Kvalifikaciya = "Менеджер по работе с клиентами",
                        Podrazdelenie = "Отдел послепродажного обслуживания"
                    },
                    new Inzhener
                    {
                        Name = "Соловьев Дмитрий Александрович",
                        EmployeeType = "Специалист по продажам",
                        Kvalifikaciya = "Старший менеджер по продажам",
                        Podrazdelenie = "Отдел продаж легковых автомобилей"
                    }
                );

                context.Administraciya.AddRange(
                    new Administraciya
                    {
                        Name = "Волков Владимир Александрович",
                        EmployeeType = "Управление",
                        Dolzhnost = "Генеральный директор автосалона"
                    },
                    new Administraciya
                    {
                        Name = "Соколова Ольга Николаевна",
                        EmployeeType = "Управление",
                        Dolzhnost = "Менеджер по финансам"
                    },
                    new Administraciya
                    {
                        Name = "Лебедев Андрей Сергеевич",
                        EmployeeType = "Управление",
                        Dolzhnost = "Заместитель директора по операциям"
                    },
                    new Administraciya
                    {
                        Name = "Козлова Татьяна Петровна",
                        EmployeeType = "Управление",
                        Dolzhnost = "Начальник отдела кадров"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
