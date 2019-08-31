using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*
Class: BoidController
Author: Brendan Kelly
Date: 11/11/2017
Description: Class that manages interaction between the Form and Boid class
*/


namespace kellybs1Boids2
{
    public class BoidController
    {
        //drawing /canvas
        private Brush boidBrush;
        private Brush fillBrush;
        private Pen boidPen;
        private Pen boidStroke;
        private Boid[] boids;
        private Graphics buffer;
        private int bufferWidth;
        private int bufferHeight;

        //size maths
        private int halfBoid;
        private int thirdBoid;

        //flock 
        private int nBoids;
        private int flockSize;

        private Random rand;


        public BoidController( Graphics inBuffer, int inNBoids, int inBufferWidth, int inBufferHeight )
        {
            rand = new Random();
            boidBrush = new SolidBrush( Color.SlateGray );
            fillBrush = new SolidBrush( Constants.BACKGROUND );
            boidPen = new Pen( Color.White );
            boidStroke = new Pen( Color.DarkGreen );
            nBoids = inNBoids;
            buffer = inBuffer;
            bufferWidth = inBufferWidth;
            bufferHeight = inBufferHeight;
            boids = new Boid[nBoids];
            halfBoid = Constants.BOID_SIZE / 2;
            thirdBoid = Constants.BOID_SIZE / 3;
            buffer.SmoothingMode = SmoothingMode.None;

            generateBoids();
            flockSize = boids.Length;
        }

        //runs the main Boid/update cycle
        public void BoidCycle()
        {
            buffer.FillRectangle( fillBrush, 0, 0, bufferWidth, bufferHeight ); //clear
            drawBoids();
            updateBoids();
        }


        //draws all Boids at their current positions
        private void drawBoids()
        {
            //draw all boids
            for ( int i = 0; i < nBoids; i++ )
            {
                //grab the current boid
                Boid currentBoid = boids[i];
                float angle = currentBoid.angleRads - Constants._90_DEG_IN_RADS; //align to face the right way

                //find its centre... very zen
                PointF centre = new PointF( currentBoid.XPos + halfBoid, currentBoid.YPos + halfBoid );

                //dart
                //PointF p1 = new PointF(currentBoid.XPos, currentBoid.YPos);
                //PointF p2 = new PointF(currentBoid.XPos + halfBoid, currentBoid.YPos + Constants.BOID_SIZE + Constants.BOID_STRETCH);
                //PointF p3 = new PointF(currentBoid.XPos + Constants.BOID_SIZE, currentBoid.YPos);
                //PointF p4 = new PointF(currentBoid.XPos + halfBoid, currentBoid.YPos + halfBoid);

                //fishie
                PointF p1 = new PointF( currentBoid.XPos, currentBoid.YPos );
                PointF p2 = new PointF( currentBoid.XPos + thirdBoid, currentBoid.YPos + thirdBoid );
                PointF p3 = new PointF( currentBoid.XPos, currentBoid.YPos + halfBoid );
                PointF p4 = new PointF( currentBoid.XPos + halfBoid, currentBoid.YPos + Constants.BOID_SIZE );
                PointF p5 = new PointF( currentBoid.XPos + Constants.BOID_SIZE, currentBoid.YPos + halfBoid );
                PointF p6 = new PointF( currentBoid.XPos + thirdBoid + thirdBoid, currentBoid.YPos + thirdBoid );
                PointF p7 = new PointF( currentBoid.XPos + Constants.BOID_SIZE, currentBoid.YPos );

                //rotate points around centre
                PointF p1r = rotatePoint( p1, centre, angle );
                PointF p2r = rotatePoint( p2, centre, angle );
                PointF p3r = rotatePoint( p3, centre, angle );
                PointF p4r = rotatePoint( p4, centre, angle );
                PointF p5r = rotatePoint( p5, centre, angle );
                PointF p6r = rotatePoint( p6, centre, angle );
                PointF p7r = rotatePoint( p7, centre, angle );

                //get color and make a brush
                Color dynamicColour = radToColourMap( angle );
                Brush dynamicBrush = new SolidBrush( dynamicColour );

                //draw shape
                PointF[] points = { p1r, p2r, p3r, p4r, p5r, p6r, p7r };
                //buffer.FillPolygon(dynamicBrush, points);
                buffer.DrawPolygon( new Pen( dynamicColour ), points );
            }
        }

        //rotates a point around a center for drawing
        private PointF rotatePoint( PointF point, PointF center, float angle )
        {
            PointF p = new PointF();

            //cosine and sine of angle
            double sinAngle = Math.Sin( angle );
            double cosAngle = Math.Cos( angle );

            //distance to center
            float centerX = point.X - center.X;
            float centerY = point.Y - center.Y;

            //assign confusing trigonometry to the points
            p.X = (float)( cosAngle * centerX - sinAngle * centerY + center.X );
            p.Y = (float)( sinAngle * centerX + cosAngle * centerY + center.Y );

            return p;
        }

        //mapping function maps given radian value to a modified colour
        //Credit: Liam Harris for the idea of changing colours based on angle
        //https://www.particleincell.com/2014/colormap/
        private Color radToColourMap( float value )
        {
            double absVal = Math.Abs( value );
            //normalize value s to the range 0:1
            double f = ( value - Constants.COLOUR_MAP_MIN ) / ( Constants.COLOUR_MAP_MAX - Constants.COLOUR_MAP_MIN );
            //invert and group
            double invertedGrouping = ( 1 - f ) / Constants.COLOUR_GROUP_DIV;
            //integer to divide grouping by
            int colourSplitter = (int)Math.Floor( invertedGrouping );
            //fractional part from 0-255
            int colourFraction = (int)Math.Floor( Constants.MAX_RGB_VALUE * ( invertedGrouping - colourSplitter ) );
            //return correct colour
            Color outColour = Color.FromArgb( 0, 0, 0 );
            switch ( colourSplitter )
            {
                case 0:
                    outColour = Color.FromArgb( Constants.MAX_RGB_VALUE, colourFraction, 0 );
                    break;

                case 1:
                    outColour = Color.FromArgb( Constants.MAX_RGB_VALUE - colourFraction, Constants.MAX_RGB_VALUE, 0 );
                    break;

                case 2:
                    outColour = Color.FromArgb( 0, Constants.MAX_RGB_VALUE, colourFraction );
                    break;

                case 3:
                    outColour = Color.FromArgb( 0, Constants.MAX_RGB_VALUE - colourFraction, Constants.MAX_RGB_VALUE );
                    break;

                case 4:
                    outColour = Color.FromArgb( colourFraction, 0, Constants.MAX_RGB_VALUE );
                    break;

                case 5:
                    outColour = Color.FromArgb( Constants.MAX_RGB_VALUE, 0, Constants.MAX_RGB_VALUE );
                    break;
            }

            return outColour;
        }

        //generates a flock of Boids randomly placed
        private void generateBoids()
        {
            for ( int i = 0; i < nBoids; i++ )
            {
                //randomise a position
                float xPos = rand.Next( bufferWidth );
                float yPos = rand.Next( bufferHeight );
                //create boid at rndom position
                Boid newBoid = new Boid( xPos, yPos, bufferWidth, bufferHeight, boids, i );
                //randomise direction
                //newBoid.RandomiseDirection(rand);
                //assign to flock of boids
                boids[i] = newBoid;
            }
        }

        //updates all boid positions
        private void updateBoids()
        {
            for ( int i = 0; i < nBoids; i++ )
                boids[i].MoveCycle();
        }

        //update alignment value
        public void RefreshAlignment( float value )
        {
            CommonBoidProperties.Alignment = value;
        }

        //update separation value
        public void RefreshSeparation( float value )
        {
            CommonBoidProperties.Separation = value;
        }

        //update separation value
        public void RefreshNeighbourDistance( int value )
        {
            CommonBoidProperties.NeighbourDistance = value;
        }

    }
}
