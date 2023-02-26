using TachFly.Domain.Entities;
using TechFly.DataAccess.Repository;

Client client1 = new Client()
{
    FirstName = "Muxammad",
    LastName = "Raximboyev",
    PhoneNumber = "+998888585088",
    Email = "muxamamddv@gmail.com",
    Password = "password",
    Role = TachFly.Domain.Enums.Role.Clent


};

Repository<Client> repository = new Repository<Client>();
var a = await repository.SelectAsync(2);
Console.WriteLine(a.FirstName);