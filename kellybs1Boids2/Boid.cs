﻿using System;
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


        //neighbours
        private List<Boid> neighbours;
        private int neighbourCount;

        //positioning
        public float XPos { get; set; }
        public float YPos { get; set; }
        private float xVelocity;
        private float yVelocity;

        private PointF alignment;
        private PointF cohesion;
        private PointF separation;

        public float angleRads { get; set; }

        public Boid( float inXPos, float inYPos, int inCanvasWidth, int inCanvasHeight, Boid[] inBoids, int inMyIndex )
        {
            alignment = new PointF( 0, 0 );
            cohesion = new PointF( 0, 0 );
            separation = new PointF( 0, 0 );
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
            XPos += ( xVelocity * Constants.BOID_SPEED );
            YPos += ( yVelocity * Constants.BOID_SPEED );
        }

        //updates the Boid's direction
        private void updateDirection()
        {
            //if i have neighbours
            if ( neighbourCount > 0 )
            {
                //get alignment, separation and cohesion point
                updateAlignment();
                updateCohesion();
                updateSeparation();

                //combine points with weighted values
                float targetX = ( alignment.X * CommonBoidProperties.Alignment ) +
                                ( cohesion.X * Constants.COHESION_WEIGHT ) +
                                ( separation.X * CommonBoidProperties.Separation );


                float targetY = ( alignment.Y * CommonBoidProperties.Alignment ) +
                                ( cohesion.Y * Constants.COHESION_WEIGHT ) +
                                ( separation.Y * CommonBoidProperties.Separation );

                //calculate distance to target
                float distanceX = ( targetX - XPos );
                float distanceY = ( targetY - YPos );
                //calculate angle to target
                angleRads = (float)Math.Atan2( distanceY, distanceX );
                //calculate modifications to current velocity
                xVelocity = (float)Math.Cos( angleRads );
                yVelocity = (float)Math.Sin( angleRads );
            }
        }

        //cohesion - move towards the average position of your neighbors
        private void updateCohesion()
        {
            //average neighbour positions
            float avgX = 0;
            float avgY = 0;
            //total
            foreach ( Boid fush in neighbours )
            {
                avgX += fush.XPos;
                avgY += fush.YPos;
            }
            //now average
            cohesion.X = ( avgX / neighbourCount );
            cohesion.Y = ( avgY / neighbourCount );
        }


        //alignment - match your neighbors' average velocity
        private void updateAlignment()
        {
            //find my neighbours' average direction
            float avgX = 0;
            float avgY = 0;

            foreach ( Boid fush in neighbours )
            {
                //total
                avgX += fush.xVelocity;
                avgY += fush.yVelocity;
            }

            //average 
            alignment.X = ( avgX / neighbourCount );
            alignment.Y = ( avgY / neighbourCount );
        }

        //separation - space between myself and neighbours
        private void updateSeparation()
        {
            separation.X = 0;
            separation.Y = 0;

            for ( int i = 0; i < neighbourCount; i++ )
            {
                //get signed difference
                //use halfboid modifier to get center of boids
                float aDiffX = ( neighbours[i].XPos + Constants.HALF_BOID ) - ( XPos + Constants.HALF_BOID );
                float aDiffY = ( neighbours[i].YPos + Constants.HALF_BOID ) - ( YPos + Constants.HALF_BOID );
                //get absolute differences between self and neighbour
                float diffX = Math.Abs( aDiffX );
                float diffY = Math.Abs( aDiffY );

                //change position if too close
                if ( diffX < Constants.BOID_DIST && diffY < Constants.BOID_DIST )
                {
                    separation.X -= aDiffX;
                    separation.Y -= aDiffY;
                }
            }
        }


        //bounces of sides of screen
        private void bounce()
        {
            if ( XPos < 0 || XPos > canvasWidth )
                xVelocity *= -1;
            else
            if ( YPos < 0 || YPos > canvasHeight )
                yVelocity *= -1;

        }

        //warps to other side of screen
        private void wrap()
        {
            //if  boid goes of screen, is repositioned at other side of screen
            float warpBoundX = 0 - Constants.BOID_SIZE;
            float warpBoundY = 0 - Constants.BOID_SIZE;

            //gone off the left
            if ( XPos < warpBoundX )
            {
                XPos = ( canvasWidth - 1 );
                return;
            }

            //gone off the right
            if ( XPos > ( canvasWidth - 1 ) )
            {
                XPos = 0 - Constants.BOID_SIZE;
                return;
            }

            //gone off the top
            if ( YPos < warpBoundY )
            {
                YPos = ( canvasHeight - 1 );
                return;
            }

            //gone off the bottom
            if ( YPos > ( canvasHeight - 1 ) )
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
            for ( int i = 0; i < boidsLength; i++ )
            {
                if ( i != myIndex ) //don't check self
                {
                    //get differences between self and neighbour
                    //use half boid size modifier to calculate on center of boid
                    float diffX = Math.Abs( ( boids[i].XPos + Constants.HALF_BOID ) - ( XPos + Constants.HALF_BOID ) );
                    float diffY = Math.Abs( ( boids[i].YPos + Constants.HALF_BOID ) - ( YPos + Constants.HALF_BOID ) );
                    //if they're close, add them
                    if ( diffX < CommonBoidProperties.NeighbourDistance && diffY < CommonBoidProperties.NeighbourDistance )
                        neighbours.Add( boids[i] );
                }
            }
            //update the count
            neighbourCount = neighbours.Count;
        }

        //randomises a Boids current direction
        public void RandomiseDirection( Random rand )
        {
            //generate random target
            float targetXPos = rand.Next( canvasWidth );
            float targetYPos = rand.Next( canvasHeight );

            //calculate distance to target
            float distanceX = targetXPos - XPos;
            float distanceY = targetYPos - YPos;

            //calculate angle to target
            angleRads = (float)Math.Atan2( distanceY, distanceX );
            //calculate modifications to current angle
            float moveX = (float)Math.Cos( angleRads );
            float moveY = (float)Math.Sin( angleRads );
            xVelocity = moveX * Constants.BOID_SPEED;
            yVelocity = moveY * Constants.BOID_SPEED;
        }
    }
}
