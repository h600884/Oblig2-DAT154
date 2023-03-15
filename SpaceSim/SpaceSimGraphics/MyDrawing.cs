
using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Text;
using Microsoft.Maui.Animations;
using System.Collections.Generic;




namespace SpaceSimGraphics
{

    internal class MyDrawing : IDrawable
    {

        public Point sun { get; set; } = new Point(800, 570);
        public Point mercury { get; set; } = new Point(800, 490);
        public Point venus { get; set; } = new Point(800, 465);
        public Point earth { get; set; } = new Point(800, 430);
        public Point mars { get; set; } = new Point(800, 395);
        public Point jupiter { get; set; } = new Point(800, 330);
        public Point saturn { get; set; } = new Point(800, 230);
        public Point uranus { get; set; } = new Point(800, 126);
        public Point neptune { get; set; } = new Point(800, 30);

        public double mercuryAngle = 0.0;
        public double venusAngle = 0.0;
        public double earthAngle = 0.0;
        public double marsAngle = 0.0;
        public double jupiterAngle = 0.0;
        public double saturnAngle = 0.0;
        public double uranusAngle = 0.0;
        public double neptuneAngle = 0.0;

        public double mercuryDistance = 80;
        public double venusDistance = 120;
        public double earthDistance = 160;
        public double marsDistance = 220;
        public double jupiterDistance = 340;
        public double saturnDistance = 430;
        public double uranusDistance = 490;
        public double neptuneDistance = 560;


        public Point sunPos = new Point(800, 570);

        public MyDrawing()
        {


        }

        public readonly Dictionary<string, Point> planetPositions = new Dictionary<string, Point>()
        {
            { "Sun", new Point(800, 570) },
            { "Mercury", new Point(800, 490) },
            { "Venus", new Point(800, 465) },
            { "Earth", new Point(800, 430) },
            { "Mars", new Point(800, 395) },
            { "Jupiter", new Point(800, 330) },
            { "Saturn", new Point(800, 230) },
            { "Uranus", new Point(800, 126) },
            { "Neptune", new Point(800, 30) },
        };

        public void UpdatePlanetPositions(Dictionary<string, Point> newPositions)
        {
            foreach (var planet in newPositions)
            {
                planetPositions[planet.Key] = planet.Value;
            }
        }

        private void DrawSolarSystem(ICanvas canvas)
        {

            canvas.FillColor = Colors.Yellow;
            canvas.FillCircle(sun, 70.0);

            // Draw each planet
            DrawPlanet(canvas, "Mercury", Colors.Gray, 5.0, mercury, mercuryAngle);
            DrawPlanet(canvas, "Venus", Colors.LightYellow, 10.0, venus, venusAngle);
            DrawPlanet(canvas, "Earth", Colors.LightBlue, 12.0, earth, earthAngle);
            DrawPlanet(canvas, "Mars", Colors.Red, 8.0, mars, marsAngle);
            DrawPlanet(canvas, "Jupiter", Colors.Orange, 30.0, jupiter, jupiterAngle);
            DrawPlanet(canvas, "Saturn", Colors.Orange, 25.0, saturn, saturnAngle);
            DrawPlanet(canvas, "Uranus", Colors.LightBlue, 20.0, uranus, uranusAngle);
            DrawPlanet(canvas, "Neptune", Colors.Blue, 18.0, neptune, neptuneAngle);

        }


        private void DrawPlanet(ICanvas canvas, string planetName, Color color, double PlanetRadius, Point PlanetOrbitRadius, double PlanetAngel)
        {
            if (!planetPositions.ContainsKey(planetName)) return;

            var planetPos = planetPositions[planetName];
            var planetRadius = GetPlanetRadius(planetName);

            canvas.FillColor = GetPlanetColor(planetName);
            canvas.FillCircle(planetPos, planetRadius);
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            DrawSolarSystem(canvas);

        }
        private double GetPlanetRadius(string planetName)
        {
            switch (planetName)
            {
                case "Sun": return 70.0;
                case "Mercury": return 5.0;
                case "Venus": return 10.0;
                case "Earth": return 12.0;
                case "Mars": return 7.0;
                case "Jupiter": return 37.0;
                case "Saturn": return 27.0;
                case "Uranus": return 19.0;
                case "Neptune": return 17.0;
                default: return 0.0;
            }
        }

        private Color GetPlanetColor(string planetName)
        {
            switch (planetName)
            {
                case "Sun": return Colors.Yellow;
                case "Mercury": return Colors.Grey;
                case "Venus": return Colors.LightYellow;
                case "Earth": return Colors.LightBlue;
                case "Mars": return Colors.Red;
                case "Jupiter": return Colors.Brown;
                case "Saturn": return Colors.SandyBrown;
                case "Uranus": return Colors.LightSkyBlue;
                case "Neptune": return Colors.Blue;
                default: return Colors.Black;
            }
        }

        private double PlanetOrbitRadius(string planetName)
        {
            switch (planetName)
            {
                case "Sun": return 0.0;
                case "Mercury": return 80.0;
                case "Venus": return 130.0;
                case "Earth": return 180.0;
                case "Mars": return 230.0;
                case "Jupiter": return 350.0;
                case "Saturn": return 490.0;
                case "Uranus": return 590.0;
                case "Neptune": return 680.0;
                default: return 0;
            }
        }


    }
}