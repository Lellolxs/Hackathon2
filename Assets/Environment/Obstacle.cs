using UnityEngine;
using System;

namespace Assets.Environment
{
    internal class Obstacle
    {
        public Obstacle(float distance_x, float distance_y, float speed_x, float speed_y)
        {
            // devide values by 128 and 256 respectively because thats what the presentation stated
            Distance = new Vector2(distance_x / 128, distance_y / 128);
            Speed = new Vector2(speed_x / 256, speed_y / 256);
        }
        public Vector2 Distance { get; private set; }
        public Vector2 Speed { get; private set; }
        public override string ToString()
        {
            // only for debugging purposes
            return $"Distance: {Distance} | Speed: {Speed}";
        }
    }
}
