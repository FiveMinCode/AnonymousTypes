// Creating Anonymous types

var user = new { FullName = "Mark T", Country = "US" };

Console.WriteLine($"User name is {user.FullName} and he lives in {user.Country}.");

// Anonymous Types LINQ usage

var users = new[]
{
    new User("Hanna", UserGroup.GovtEmployee, 27),
    new User("Jones", UserGroup.GovtEmployee, 30),
    new User("Craig", UserGroup.SelfEmployeed, 34),
    new User("Redmond", UserGroup.PrivateEmployee, 27),
    new User("Sab", UserGroup.UnEmployed, 28),
    new User("Dan", UserGroup.UnEmployed, 32),
    new User("Ricky", UserGroup.SelfEmployeed, 38),
    new User("Jim", UserGroup.PrivateEmployee, 29)
};

// Without Anonymous function
var ageData = users
    .GroupBy(x => x.Group)
    .Select(k => k.Average(user => user.Age));

foreach (var item in ageData)
{
    Console.WriteLine(item);
}

// With Anonymous function
var averageageData = users
    .GroupBy(x => x.Group)
    .Select(group => new
    {
        Type = group.Key,
        AgeAverage = group.Average(x => x.Age)
    })
    .OrderBy(data => data.AgeAverage);


foreach (var item in averageageData)
{
    Console.WriteLine($"Average age for type {item.Type} is {item.AgeAverage}");
}


// Anonymous types non-destructive mutation
var userData = new { Id = 5, Name = "Greg" };
var changedData = userData with { Name = "Tim" };

Console.WriteLine($"Values: Id = {userData.Id}, Name = {userData.Name}) \n");
Console.WriteLine($"Values: Id = {changedData.Id}, Name = {changedData.Name})");

public class User
{
    public string FullName { get; set; }
    public UserGroup Group { get; set; }
    public int Age { get; set; }

    public User(string fullName, UserGroup group, int age)
    {
        FullName = fullName;
        Group = group;
        Age = age;
    }
}

public enum UserGroup
{
    GovtEmployee,
    PrivateEmployee,
    SelfEmployeed,
    UnEmployed
}





