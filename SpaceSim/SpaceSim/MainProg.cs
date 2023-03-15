using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Numerics;
using SpaceSim;
using static System.Formats.Asn1.AsnWriter;


class Astronomy
{
    public static void Main()
    {


        Star sun = new Star("Sun", 696340, 0, 0, 27, "White");

        Planet Mercury = new Planet("Mercury", 2439.7, 57910, 87.97, 59, "grey");


        Planet Venus = new Planet("Venus", 6051.8, 108200, 224.70, 243, "yellow");

        Planet Earth = new Planet("Earth", 6371, 149600, 365.26, 1, "blue");
        Moon Moon = new Moon("The Moon", 1737.4, 38427.32, 27.3, 27.3, "lightgrey");

        Planet Mars = new Planet("Mars", 3389, 227940, 686.98, 1, "red");
        Moon Phobos = new Moon("Phobos", 11.267, 9, 0.32, 0.3, "grey");
        Moon Deimos = new Moon("Deimos", 6.2, 23, 1.26, 1.26, "lightred");

        Planet Jupiter = new Planet("Jupiter", 69911, 788330, 433.11, 0.42, "orange");
        Moon Metris = new Moon("Metis", 21.5, 128, 0.29, 0.21, "red");
        Moon Adrastea = new Moon("Adrastea", 8.2, 129, 0.30, 0.3, "grey");
        Moon Amalthea = new Moon("Amalthea", 83.5, 181, 0.50, 0.5, "red");
        Moon Thebe = new Moon("Thebe", 49.3, 222, 0.67, 0.6, "red");
        Moon Io = new Moon("Io", 1821.6, 422, 1.77, 1.8, "orange");
        Moon Europa = new Moon("Europa", 1560.8, 671, 3.55, 3.5, "orange");

        Planet Saturn = new Planet("Saturn", 58232, 1429400, 10759.50, 0.45, "brown");
        Moon Pan = new Moon("Pan", 14.1, 134, 0.58, 0.58, "grey");
        Moon Atlas = new Moon("Atlas", 15.1, 138, 60, 0.6, "grey");

        Planet Uranus = new Planet("Uranus", 25362, 2870990, 30685, 0.7, "lightblue");
        Moon Cordelia = new Moon("Cordelia", 20.1, 50, 0.34, 0.34, "grey");
        Moon Ariel = new Moon("Ariel", 578.9, 191, 2.52, 2.52, "brown");


        Planet Neptun = new Planet("Neptun", 24622, 4504300, 60190, 0.8, "blue");
        Moon Naiad = new Moon("Naiad", 33, 48, 0.29, 0.25, "blue");
        Moon Thalassa = new Moon("Thalassa", 41, 50, 0.31, 0.31, "blue");

        Comet Halley = new Comet("Halley", 5.5, "white");
        Asteroid Ceres = new Asteroid("Ceres", 476, "grey");
        AsteroidBelt KuiperBelt = new AsteroidBelt("KuiperBelt", 7500000000, "red/blue/white");
        DwarfPlanet Pluto = new DwarfPlanet("Pluto", 1188, 5913520, 90550.00, 6.39, "BrownRed");


        Earth.AddMoon(Moon);
        Mars.AddMoon(Phobos);
        Mars.AddMoon(Deimos);
        Jupiter.AddMoon(Metris);
        Jupiter.AddMoon(Adrastea);
        Jupiter.AddMoon(Amalthea);
        Jupiter.AddMoon(Thebe);
        Jupiter.AddMoon(Io);
        Jupiter.AddMoon(Europa);
        Saturn.AddMoon(Pan);
        Saturn.AddMoon(Atlas);
        Uranus.AddMoon(Cordelia);
        Uranus.AddMoon(Ariel);
        Neptun.AddMoon(Naiad);
        Neptun.AddMoon(Thalassa);


        List<SpaceObject> solarSystem = new List<SpaceObject> {

            Mercury,
            Venus,
            Earth,
            Mars,
            Jupiter,
            Saturn,
            Uranus,
            Neptun,
            Halley,
            Ceres,
            KuiperBelt,
            Pluto

        };
        Console.WriteLine("Skriv inn antall dager etter tid 0: ");
        double time = double.Parse(Console.ReadLine());

        Console.WriteLine("Skriv inn en planet (eller ingenting for å få opp solen: ");
        string planetName = Console.ReadLine();

        Planet planet;

        if (string.IsNullOrWhiteSpace(planetName))
        {
            // ingen planet valgt, default til solen
            planet = sun;
            Console.WriteLine("Du valgte Solen:");


        }
        else
        {
            // Finner planeten
            planet = Planet.FindPlanetByName(solarSystem, planetName);
            if (planet == null)
            {
                Console.WriteLine("Planet ikke funnet!");
                return;
            }
            Console.WriteLine("Du valgte " + planet.Name + ":");
        }


        //Regner ut planetens posisjon ut i fra den valgte tiden over
        Vector2 position = planet.CalculatePosition(time);

        // Printer ut informasjon om planeten og tilhørende måner
        Console.WriteLine($"Detaljer om {planet.Name} {time} dager etter tid 0:");
        Console.WriteLine($"Posisjon: ({position.X}, {position.Y})");
        Console.WriteLine($"Radius i km: {planet.Radius}");
        Console.WriteLine($"Rotatsjonsperiode i dager: {planet.RotationPeriod}");
        Console.WriteLine($"Farge: {planet.Color}");


        //Skriver ut planetene i solsystemet under informasjonen om solen
        if (planet == sun)
        {
            Console.WriteLine("");
            Console.WriteLine("Planetene i Solsystemet: ");
            foreach (SpaceObject obj in solarSystem)
            {
                if (obj is Planet)
                {
                    obj.Draw();
                }

            }
            Console.ReadLine();
        }


        Console.WriteLine("");
        Console.WriteLine($"Månene til {planet.Name}: ");

        foreach (Moon moon in planet.Moons)
        {
            Vector2 moonPosition = moon.CalculatePosition(time);
            Console.WriteLine($"Moons: {moon.Name}, Position: ({moonPosition.X}, {moonPosition.Y})");


        }
    }

}


