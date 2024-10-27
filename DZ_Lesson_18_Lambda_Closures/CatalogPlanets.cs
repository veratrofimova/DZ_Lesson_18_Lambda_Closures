namespace DZ_Lesson_18_Lambda_Closures
{
    public class CatalogPlanets
    {
        static Planet planetVenus = new Planet()
        {
            Name = "Венера",
            SequenceNumber = 2,
            LengthEquator = 6051,
            PreviousPlanet = null,
        };

        static Planet planetEarth = new Planet()
        {
            Name = "Земля",
            SequenceNumber = 3,
            LengthEquator = 40075,
            PreviousPlanet = planetVenus,
        };

        static Planet planetMars = new Planet()
        {
            Name = "Марс",
            SequenceNumber = 4,
            LengthEquator = 21326,
            PreviousPlanet = planetEarth,
        };

        static List<Planet> planets = new List<Planet>() { planetVenus, planetEarth, planetMars };

        private delegate Func<string, (int?, int?, string)> PlanetValidator(string planet);

        private static (int?, int?, string) FindPlanet(string planet)
        {
            var findPlanet = planets.Where(x => x.Name == planet).FirstOrDefault();

            if (findPlanet == null)
                return (null, null, "Не удалось найти планету");
            else
                return (findPlanet.SequenceNumber, findPlanet.LengthEquator, "");
        }

        public static (int?, int?, string) GetPlanet(string planet, Func<string, (int?, int?, string)> planetValidator)
        {         
            if (string.IsNullOrEmpty(planetValidator(planet).Item3))
                return FindPlanet(planet);
            else
                return planetValidator(planet);
        }
    }
}