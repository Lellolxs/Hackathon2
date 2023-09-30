using Assets.Environment;
using System.Collections.Generic;

namespace DataStructureTEST
{
    internal class Snapshot
    {
        public Snapshot(IList<Obstacle> obstackles, double vehicle_speed, double yaw_rate, double timestamp)
        {
            Obstackles = new List<Obstacle>(obstackles);

            // divide by 256 because thats what the presentation said
            VehicleSpeed = vehicle_speed/256;
            YawRate = yaw_rate;
            Timestamp = timestamp;
        }
        public IList<Obstacle> Obstackles { get; private set; }

        // supposed properties of the target vehicle
        public double VehicleSpeed { get; private set; }
        public double YawRate { get; private set; }

        public double Timestamp { get; private set; } // time of snapshot

        public override string ToString()
        {
            string objectDataString = "";
            for (int i = 0; i < Obstackles.Count; i++)
            {
                objectDataString += $"\n\t Object{i} data:";
                objectDataString += $"\n\t\t{Obstackles[i].ToString()}";
            }
            return $"{Timestamp} | Vehicle speed: {VehicleSpeed}, Yaw rate: {YawRate}" + objectDataString;

        }
    }
}
