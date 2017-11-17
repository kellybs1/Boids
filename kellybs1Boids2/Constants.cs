using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //form
        public const int BTN_CLOSE_SIZE = 46;
        public const int TRACKBAR_SEPARATOR = 100;


        //physics
        public const float BOID_SPEED = 6f;
        public const float COHESION_WEIGHT = 1f;
        public const float ALIGNMENT_WEIGHT = 6700f;
        public const float SEPARATION_WEIGHT = 25f;

        //drawing boids
        public const int BOID_SIZE = 20;
        public const int BOID_DIST = 25;
        public const int N_BOIDS = 220;
        public const int NEIGHBOUR_DIST = 34;

        public const float _90_DEG_IN_RADS = 1.5708f;
        public const int BOID_STRETCH = 7;

        //colouring
        public static Color BACKGROUND = Color.FromArgb(0, 10, 22);
        public const int COLOUR_MAP_R = 100;
        public const int COLOUR_MAP_G = 20;
        public const float COLOUR_MAP_MAX = 6.28319f;
        public const float COLOUR_MAP_MIN = -6.28319f;
        public const int COLOUR_MAP_B_MIN = 20;
        public const int COLOUR_MAP_B_MAX = 200;
        public const int MAX_RGB_VALUE = 255;
        public const double COLOUR_GROUP_DIV = 0.2;


    }
}
