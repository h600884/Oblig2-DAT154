using System;
using System.Drawing;
using System.Numerics;
using System.Xml.Linq;

namespace SpaceSim
{
    public class SpaceObject
    {
        protected String name;
        protected double radius;
        protected double orbitalRadius;
        protected double orbitalPeriod;
        protected double rotationPeriod;
        protected String color;
        protected double positionX;
        protected double positionY;



        public SpaceObject(String name, double radius, double orbitalRadius, double orbitalPeriod, double rotationPeriod, String color)
        {
            this.name = name;
            this.radius = radius;
            this.orbitalRadius = orbitalRadius;
            this.orbitalPeriod = orbitalPeriod;
            this.rotationPeriod = rotationPeriod;
            this.color = color;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public double OrbitalRadius
        {
            get { return orbitalRadius; }
            set { orbitalRadius = value; }
        }

        public double OrbitalPeriod
        {
            get { return orbitalPeriod; }
            set { orbitalPeriod = value; }
        }

        public double RotationPeriod
        {
            get { return rotationPeriod; }
            set { rotationPeriod = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public double PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }

        public double PositionY
        {
            get { return positionY; }
            set { positionY = value; }
        }

        public virtual void Draw()
        {
            Console.WriteLine(name);
        }

        public System.Numerics.Vector2 CalculatePosition(double time)
        {
            double angle = 2 * Math.PI * time / orbitalPeriod;
            positionX = orbitalRadius * Math.Cos(angle);
            positionY = orbitalRadius * Math.Sin(angle);
            return new System.Numerics.Vector2((float)positionX, (float)positionY);
        }

        public static Planet FindPlanetByName(List<SpaceObject> solarSystem, string name)
        {
            foreach (SpaceObject obj in solarSystem)
            {
                if (obj is Planet planet && planet.Name.ToLower() == name.ToLower())
                {
                    return planet;
                }
            }

            return null;
        }

    }
    public class Star : Planet
    {
        public Star(String name, double radius, double orbitalRadius, double orbitalPeriod, double rotationPeriod, String color)
                    : base(name, radius, 0, 0, rotationPeriod, color) { }

        public override void Draw()
        {
            Console.Write("Star : ");
            base.Draw();
        }
    }
    public class Planet : SpaceObject
    {
        List<Moon> moons;
        protected SpaceObject parent;
        public Planet(String name, double radius, double orbitalRadius, double orbitalPeriod, double rotationPeriod, String color)
                     : base(name, radius, orbitalRadius, orbitalPeriod, rotationPeriod, color) { moons = new List<Moon>(); }

        public override void Draw()
        {
            Console.Write("Planet : ");
            base.Draw();
        }


        public void AddMoon(Moon moon)
        {
            moons.Add(moon);
        }
        public List<Moon> Moons
        {
            get
            {
                return moons;
            }
        }

    }
    public class Moon : SpaceObject
    {
        protected SpaceObject parent;
        public Moon(String name, double radius, double orbitalRadius, double orbitalPeriod, double rotationPeriod, String color)
                     : base(name, radius, orbitalRadius, orbitalPeriod, rotationPeriod, color)
        {

        }

        public override void Draw()
        {
            Console.Write("Moon : ");
            base.Draw();
        }

    }
    public class Comet : SpaceObject
    {
        public Comet(String name, double radius, String color)
                     : base(name, radius, 0, 0, 0, color) { }

        public override void Draw()
        {
            Console.Write("Comet : ");
            base.Draw();
        }
    }
    public class Asteroid : SpaceObject
    {
        public Asteroid(String name, double radius, String color)
                     : base(name, radius, 0, 0, 0, color) { }

        public override void Draw()
        {
            Console.Write("Asteroid : ");
            base.Draw();
        }
    }

    public class AsteroidBelt : SpaceObject
    {
        public AsteroidBelt(String name, double radius, String color)
                     : base(name, radius, 0, 0, 0, color) { }

        public override void Draw()
        {
            Console.Write("Asteroid : ");
            base.Draw();
        }
    }

    public class DwarfPlanet : SpaceObject
    {
        public DwarfPlanet(String name, double radius, double orbitalRadius, double orbitalPeriod, double rotationPeriod, String color)
                     : base(name, radius, orbitalRadius, orbitalPeriod, rotationPeriod, color) { }
        public override void Draw()
        {
            Console.Write("Dwarfplanet : ");
            base.Draw();
        }
    }

}