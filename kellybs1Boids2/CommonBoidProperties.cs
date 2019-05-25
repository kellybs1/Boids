using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Class: Boid
Author: Brendan Kelly
Date: 25/08/2018
Description: Class that holds static values accessed by all boids
*/


namespace kellybs1Boids2
{
    public static class CommonBoidProperties
    {
        public static float Alignment { get; set; } = Constants.ALIGNMENT_WEIGHT;
        public static float Separation { get; set; } = Constants.SEPARATION_WEIGHT;
        public static int NeighbourDistance { get; set; } = Constants.NEIGHBOUR_DIST;
    }
}
