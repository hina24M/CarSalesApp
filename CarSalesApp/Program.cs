using CarSalesApp.Data;

// Method to display list of cars
static void DisplayCars(List<Car> carList)
{
    foreach (var car in carList)
    {
        Console.WriteLine(car);
    }
}

// Connect and open database
using var db = new CarSalesDbContext();

// 1. Load all car records from database and display them
var cars = db.Cars.ToList();
Console.WriteLine("--- Initial Car List from Database ---");
DisplayCars(cars);

// 2. Add a new car record (Step 9) - Commented out to prevent duplicates
// var newCar = new Car(0, "Corolla", "Toyota", 2023, Fuel.HYBRID, 13995, DateOnly.FromDateTime(DateTime.Now), false);
// db.Cars.Add(newCar);
// db.SaveChanges();
// Console.WriteLine("\nAdded new Toyota Corolla record!");

// 3. Update an existing record - Car with ID 7 (Step 10)
var carToUpdate = db.Cars.Where(c => c.Id == 7).SingleOrDefault();
if (carToUpdate != null)
{
    Console.WriteLine($"\nBefore change (ID 7): {carToUpdate}");
    carToUpdate.Price = 19500;
    Console.WriteLine($"After change (ID 7): {carToUpdate}");

    // Save change to the database
    db.SaveChanges();
}