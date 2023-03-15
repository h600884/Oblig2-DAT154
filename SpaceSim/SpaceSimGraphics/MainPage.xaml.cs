using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using System.Numerics;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace SpaceSimGraphics
{

    public partial class MainPage : ContentPage
    {

        public delegate void TickEventHandler(object sender, EventArgs e);
        public event EventHandler DoTick;
        private MyDrawing drawing = new();

        public double simulationSpeed = 5;


        public MainPage()
        {
            InitializeComponent();
            draw.Drawable = drawing;

            IDispatcherTimer ct = Application.Current.Dispatcher.CreateTimer();
            ct.Interval = TimeSpan.FromMilliseconds(100);
            ct.Tick += Tick;
            ct.Start();
        }
        private void Tick(object state, EventArgs args)
        {


            double mercuryAngle = drawing.mercuryAngle;
            double venusAngle = drawing.venusAngle;
            double earthAngle = drawing.earthAngle;
            double marsAngle = drawing.marsAngle;
            double jupiterAngle = drawing.jupiterAngle;
            double saturnAngle = drawing.saturnAngle;
            double uranusAngle = drawing.uranusAngle;
            double neptuneAngle = drawing.neptuneAngle;

            drawing.mercuryAngle += 0.05 * simulationSpeed;
            drawing.venusAngle += 0.03 * simulationSpeed;
            drawing.earthAngle += 0.02 * simulationSpeed;
            drawing.marsAngle += 0.01 * simulationSpeed;
            drawing.jupiterAngle += 0.005 * simulationSpeed;
            drawing.saturnAngle += 0.003 * simulationSpeed;
            drawing.uranusAngle += 0.002 * simulationSpeed;
            drawing.neptuneAngle += 0.001 * simulationSpeed;

            var newPositions = new Dictionary<string, Point>();
            newPositions["Sun"] = drawing.planetPositions["Sun"];
            newPositions["Mercury"] = CalculatePosition(drawing.planetPositions["Sun"], drawing.mercuryDistance, drawing.mercuryAngle);
            newPositions["Venus"] = CalculatePosition(drawing.planetPositions["Sun"], drawing.venusDistance, drawing.venusAngle);
            newPositions["Earth"] = CalculatePosition(drawing.planetPositions["Sun"], drawing.earthDistance, drawing.earthAngle);
            newPositions["Mars"] = CalculatePosition(drawing.planetPositions["Sun"], drawing.marsDistance, drawing.marsAngle);
            newPositions["Jupiter"] = CalculatePosition(drawing.planetPositions["Sun"], drawing.jupiterDistance, drawing.jupiterAngle);
            newPositions["Saturn"] = CalculatePosition(drawing.planetPositions["Sun"], drawing.saturnDistance, drawing.saturnAngle);
            newPositions["Uranus"] = CalculatePosition(drawing.planetPositions["Sun"], drawing.uranusDistance, drawing.uranusAngle);
            newPositions["Neptune"] = CalculatePosition(drawing.planetPositions["Sun"], drawing.neptuneDistance, drawing.neptuneAngle);



            drawing.UpdatePlanetPositions(newPositions);

            // invoke DoTick event
            DoTick?.Invoke(this, EventArgs.Empty);

            // invalidate canvas
            draw.Invalidate();


        }
        public Point CalculatePosition(Point center, double distance, double angle)
        {
            return new Point(center.X + distance * Math.Cos(angle), center.Y + distance * Math.Sin(angle));
        }


        /* private void CalculatePosition2(object sender, EventArgs e)
         {
             double mercuryAngle = drawing.mercuryAngle;
             double venusAngle = drawing.venusAngle;
             double earthAngle = drawing.earthAngle;
             double marsAngle = drawing.marsAngle;
             double jupiterAngle = drawing.jupiterAngle;
             double saturnAngle = drawing.saturnAngle;
             double uranusAngle = drawing.uranusAngle;
             double neptuneAngle = drawing.neptuneAngle;

             Point sun = drawing.planetPositions["Sun"];
             Point mercury = drawing.planetPositions["Mercury"];
             Point venus = drawing.planetPositions["Venus"];
             Point earth = drawing.planetPositions["Earth"];
             Point mars = drawing.planetPositions["Mars"];
             Point jupiter = drawing.planetPositions["Jupiter"];
             Point saturn = drawing.planetPositions["Saturn"];
             Point uranus = drawing.planetPositions["Uranus"];
             Point neptune = drawing.planetPositions["Neptune"];


             // Update the planet positions based on the new angles and distances
             mercury.X = sun.X + Math.Cos(mercuryAngle) * drawing.mercuryDistance;
             mercury.Y = sun.Y + Math.Sin(mercuryAngle) * drawing.mercuryDistance;
             venus.X = sun.X + Math.Cos(venusAngle) * drawing.venusDistance;
             venus.Y = sun.Y + Math.Sin(venusAngle) * drawing.venusDistance;
             earth.X = sun.X + Math.Cos(earthAngle) * drawing.earthDistance;
             earth.Y = sun.Y + Math.Sin(earthAngle) * drawing.earthDistance;
             mars.X = sun.X + Math.Cos(marsAngle) * drawing.marsDistance;
             mars.Y = sun.Y + Math.Sin(marsAngle) * drawing.marsDistance;
             jupiter.X = sun.X + Math.Cos(jupiterAngle) * drawing.jupiterDistance;
             jupiter.Y = sun.Y + Math.Sin(jupiterAngle) * drawing.jupiterDistance;
             saturn.X = sun.X + Math.Cos(saturnAngle) * drawing.saturnDistance;
             saturn.Y = sun.Y + Math.Sin(saturnAngle) * drawing.saturnDistance;
             uranus.X = sun.X + Math.Cos(uranusAngle) * drawing.uranusDistance;
             uranus.Y = sun.Y + Math.Sin(uranusAngle) * drawing.uranusDistance;
             neptune.X = sun.X + Math.Cos(neptuneAngle) * drawing.neptuneDistance;
             neptune.Y = sun.Y + Math.Sin(neptuneAngle) * drawing.neptuneDistance;

             // Update the angles for the next tick
             drawing.mercuryAngle = mercuryAngle;
             drawing.venusAngle = venusAngle;
             drawing.earthAngle = earthAngle;
             drawing.marsAngle = marsAngle;
             drawing.jupiterAngle = jupiterAngle;
             drawing.saturnAngle = saturnAngle;
             drawing.uranusAngle = uranusAngle;
             drawing.neptuneAngle = neptuneAngle;


         }
        */
    }

}



