using DZ_Lesson_18_Lambda_Closures;

List<string> planets = new List<string>() { "Земля", "Лимония", "Марс" };

int count = 0;

CatalogPlanets catalogPlanets = new CatalogPlanets();

foreach (var planet in planets)
{
    count++;
    var returnValue = CatalogPlanets.GetPlanet(planet,
            planet => 
            {
                if (count == 3)
                    return (null, null, "Вы спрашиваете слишком часто");
                else
                    return (null, null, "");
            });

    string result = string.IsNullOrEmpty(returnValue.Item3)
        ? $"порядковый номер от Солнца - {returnValue.Item1}, длина экватора - {returnValue.Item2} км"
        : returnValue.Item3;

    Console.WriteLine($"Вывод информации по планете {planet}: {result}");
}

Console.WriteLine("\r\nЗадание со звездочкой\r\n");

foreach (var planet in planets)
{
    var returnValue = CatalogPlanets.GetPlanet(planet,
            planet =>
            {
                if (planet == "Лимония")
                    return (null, null, "Это запретная планета");
                else
                    return (null, null, "");
            });

    string result = string.IsNullOrEmpty(returnValue.Item3)
        ? $"порядковый номер от Солнца - {returnValue.Item1}, длина экватора - {returnValue.Item2} км"
        : returnValue.Item3;

    Console.WriteLine($"Вывод информации по планете {planet}: {result}");
}