using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kellybs1Boids2
{

    /*
    Class: Boid
    Author: Brendan Kelly
    Date: 11/11/2017
    Description: Class that manages the behaviour and data of a single Fush object
    */

    /*
     * Boids: Algorithm description:
     * The individual Boid calculates its velocity based on three basic factors:
     * 1) Cohesion - The Boid steers towards the average position of all neighbouring Boids.
     * 2) Alignment - The Boid steers to maintain the average velocity of neighbouring Boids.
     * 3) Separation - The Boid steers away from neighbouring Boids if it is too close.
     * 
     * Different weightings are applied to the three values to modify the behaviour of the flock.
     * 
     * Each cycle of the program, each Boids updates which Boids are its neighbours, then goes
     * through the process of updating its velocity based on the three basic factors.
     */ 

    public class Boid
    {
        //canvas stuff
        private int canvasWidth;
        private int canvasHeight;

        //flock info
        private int myIndex;
        private Boid[] boids;
        private int boidsLength;
        public float Alignment { get; set; }
        public float Separation { get; set; }

        public int NeighbourDistance { get; set; }

        //neighbours
        private List<Boid> neighbours;
        private int neighbourCount;

        //half boid size
        private int halfBoid;

        //positioning
        public float XPos { get; set; }
        public float YPos { get; set; }
        private float xVelocity;
        private float yVelocity;

        public float angleRads { get; set; }

        public Boid(float inXPos, float inYPos, int inCanvasWidth, int inCanvasHeight, Boid[] inBoids, int inMyIndex)
        {
            halfBoid = Constants.BOID_SIZE / 2;
            neighbourCount = 0;
            myIndex = inMyIndex;
            boids = inBoids;
            boidsLength = boids.Length;
            canvasWidth = inCanvasWidth;
            canvasHeight = inCanvasHeight;
            XPos = inXPos;
            YPos = inYPos;
            xVelocity = 0;
            yVelocity = 0;
            //default alignment and separation
            Alignment = Constants.ALIGNMENT_WEIGHT;
            Separation = Constants.SEPARATION_WEIGHT;
            NeighbourDistance = Constants.NEIGHBOUR_DIST;
        }

        //runs all methods to be run during each step of movement cycle
        public void MoveCycle()
        {
            refreshNeighbours();
            updateDirection();
            move();
            wrap();
        }

        //moves the Boid one step in its current direction
        private void move()
        {
            XPos += xVelocity * Constants.BOID_SPEED;
            YPos += yVelocity * Constants.BOID_SPEED;
        }

        //updates the Boid's direction
        private void updateDirection()
        {
            //if i have neighbours
            if (neighbourCount > 0)
            {
                //get alignment, separation and cohesion point
                PointF align = alignment();
                PointF cohes = cohesion();
                PointF separ = separation();

                //combine points with weighted values
                float targetX = align.X * Alignment +
                                cohes.X * Constants.COHESION_WEIGHT +
                                separ.X * Separation;


                float targetY = align.Y * Alignment +
                                cohes.Y * Constants.COHESION_WEIGHT +
                                separ.Y * Separation;

                //calculate distance to target
                float distanceX = targetX - XPos;
                float distanceY = targetY - YPos;
                //calculate angle to target
                angleRads = (float)Math.Atan2(distanceY, distanceX);
                //calculate modifications to current velocity
                xVelocity = (float)Math.Cos(angleRads);
                yVelocity = (float)Math.Sin(angleRads);
            }
        }

        //cohesion - move towards the average position of your neighbors
        private PointF cohesion()
        {
            //average neighbour positions
            float avgX = 0;
            float avgY = 0;
            //total
            foreach (Boid fush in neighbours)
            {
                avgX += fush.XPos;
                avgY += fush.YPos;
            }
            //now average
            float targetX = avgX / neighbourCount;
            float targetY = avgY / neighbourCount;

            return new PointF(targetX, targetY);        
        }


        //alignment - match your neighbors' average velocity
        private PointF alignment()
        {
            //find my neighbours' average direction
            float avgX = 0;
            float avgY = 0;

            foreach (Boid fush in neighbours)
            {
                //total
                avgX += fush.xVelocity;
                avgY += fush.yVelocity;
            }

            //average 
            avgX = avgX / neighbourCount;
            avgY = avgY / neighbourCount;

            return new PointF(avgX, avgY);
        }

        //separation - space between myself and neighbours
        private PointF separation()
        {
            PointF dist = new Point(0, 0);

            for (int i = 0; i < neighbourCount; i++)
            {
                //get signed difference
                //use halfboid modifier to get center of boids
                float aDiffX = (neighbours[i].XPos + halfBoid) - (XPos + halfBoid);
                float aDiffY = (neighbours[i].YPos + halfBoid) - (YPos + halfBoid);
                //get absolute differences between self and neighbour
                float diffX = Math.Abs(aDiffX);
                float diffY = Math.Abs(aDiffY);

                //change position if too close
                if (diffX < Constants.BOID_DIST && diffY < Constants.BOID_DIST)
                {
                    dist.X -= aDiffX;
                    dist.Y -= aDiffY;
                }
            }
            return dist;
        }
  

        //bounces of sides of screen
        private void bounce()
        {
            if (XPos < 0 || XPos > canvasWidth)
                xVelocity *= -1;
            else
            if (YPos < 0 || YPos > canvasHeight)
                yVelocity *= -1;

        }

        //warps to other side of screen
        private void wrap()
        {
            //if  boid goes of screen, is repositioned at other side of screen
            float warpBoundX = 0 - Constants.BOID_SIZE;
            float warpBoundY = 0 - Constants.BOID_SIZE;

            //gone off the left
            if (XPos < warpBoundX)
            {
                XPos = canvasWidth - 1;
                return;
            }

            //gone off the right
            if (XPos > canvasWidth - 1)
            {
                XPos = 0 - Constants.BOID_SIZE;
                return;
            }

            //gone off the top
            if (YPos < warpBoundY)
            {
                YPos = canvasHeight - 1;
                return;
            }

            //gone off the bottom
            if (YPos > canvasHeight - 1)
            {
                YPos = 0 - Constants.BOID_SIZE;
                return;
            }


        }

        //fetches neighbouring boids
        private void refreshNeighbours()
        {
            neighbours = new List<Boid>();
            //check distances between self and other boids
            for (int i = 0; i < boidsLength; i++)
            {
                if (i != myIndex) //don't check self
                {
                    //get differences between self and neighbour
                    //use half boid size modifier to calculate on center of boid
                    float diffX = Math.Abs((boids[i].XPos + halfBoid) - (XPos + halfBoid));
                    float diffY = Math.Abs((boids[i].YPos + halfBoid) - (YPos + halfBoid));
                    //if they're close, add them
                    if (diffX < NeighbourDistance && diffY < NeighbourDistance)
                        neighbours.Add(boids[i]);
                }
            }
            //update the count
            neighbourCount = neighbours.Count;
        }

        //randomises a Boids current direction
        public void RandomiseDirection(Random rand)
        {
            //generate random target
            float targetXPos = rand.Next(canvasWidth);
            float targetYPos = rand.Next(canvasHeight);

            //calculate distance to target
            float distanceX = targetXPos - XPos;
            float distanceY = targetYPos - YPos;

            //calculate angle to target
            angleRads = (float)Math.Atan2(distanceY, distanceX);
            //calculate modifications to current angle
            float moveX = (float)Math.Cos(angleRads);
            float moveY = (float)Math.Sin(angleRads);
            xVelocity = moveX * Constants.BOID_SPEED;
            yVelocity = moveY * Constants.BOID_SPEED;
        }
    }
}
