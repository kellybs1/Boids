using System.Drawing;

/*
Class: Constants
Author: Brendan Kelly
Date: 11/11/2017
Description: Class to hold constant values for Fush
*/

namespace kellybs1Boids2
{
    public static class Constants
    {
        // form
        public static readonly int BTN_CLOSE_SIZE = 46;
        public static readonly int TRACKBAR_SEPARATOR = 100;
        public static readonly int TICKERTICKTICK = 17; // ms

        // physics
        public static readonly float BOID_SPEED = 9f;
        public static readonly float COHESION_WEIGHT = 1f;
        public static readonly float ALIGNMENT_WEIGHT = 6700f;
        public static readonly float SEPARATION_WEIGHT = 23f;

        // drawing boids
        public static readonly int BOID_SIZE = 24;
        public static readonly int HALF_BOID = ( BOID_SIZE / 2) ;
        public static readonly int BOID_DIST = 14;
        public static readonly int N_BOIDS = 250;
        public static readonly int NEIGHBOUR_DIST = 36;
        public static readonly float _90_DEG_IN_RADS = 1.5708f;
        public static readonly int BOID_STRETCH = 7;

        // colouring
        public static readonly Color BACKGROUND = Color.FromArgb(0, 10, 22);
        public static readonly int COLOUR_MAP_R = 100;
        public static readonly int COLOUR_MAP_G = 20;
        public static readonly float COLOUR_MAP_MAX = 6.28319f;
        public static readonly float COLOUR_MAP_MIN = -6.28319f;
        public static readonly int COLOUR_MAP_B_MIN = 20;
        public static readonly int COLOUR_MAP_B_MAX = 200;
        public static readonly int MAX_RGB_VALUE = 255;
        public static readonly double COLOUR_GROUP_DIV = 0.2;
    }
}
