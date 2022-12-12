// See https://aka.ms/new-console-template for more information


using EncryptColumnDemo.Data;
using EncryptColumnDemo.Models;

Console.WriteLine("Do you want to (a)dd yourself, or (g)et all users?");
string? reply = Console.ReadLine();



if (reply == "a")
{
Console.WriteLine("Hello, whats your username?");
string? userName = Console.ReadLine();
Console.WriteLine("Whats your password?");
string? password = Console.ReadLine();
Console.WriteLine("Whats your email?");
string? email = Console.ReadLine();

    if (userName != null && password != null && email != null)
    {
        User user = new();
        user.Username = userName;
        user.Password = password;
        user.Email = email;

        using (AppDbContext context = new())
        {
            context.Users.Add(user);
            context.SaveChanges();
            Console.WriteLine("You've been added to the db...");
            Console.WriteLine("Press enter to leave...");
        }
    }
}
else if (reply == "g")
{
    using(AppDbContext context = new())
    {
        List<User> users = context.Users.ToList();

        users.ForEach(u => Console.WriteLine($"Username: {u.Username} / Password: {u.Password}"));
    }
}