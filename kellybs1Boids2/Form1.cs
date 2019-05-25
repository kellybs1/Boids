using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kellybs1Boids2
{
    public partial class Form1 : Form
    {
        private Graphics mainCanvas;
        private Graphics bufferGraphics;
        private Bitmap bufferImage;
        private Random rand;
        private int panelHeight;
        private int panelWidth;
        private BoidController boidCon;

        public Form1()
        {
            InitializeComponent();
        }


        //main timer
        private void timer1_Tick(object sender, EventArgs e)
        {      
            boidCon.BoidCycle();
            mainCanvas.DrawImage(bufferImage, 0, 0);
        }



        private void Form1_Load(object sender, EventArgs e)
        {           
            rand = new Random();

            //init graphics
            mainCanvas = panelDraw.CreateGraphics();
            panelWidth = panelDraw.Width;
            panelHeight = panelDraw.Height;

            //close button starting parameters
            buttonClose.Visible = false;
            buttonClose.Enabled = false;
            Point buttonCloseLocation = new Point(panelWidth - Constants.BTN_CLOSE_SIZE, 0);
            buttonClose.Location = buttonCloseLocation;
            buttonClose.Width = Constants.BTN_CLOSE_SIZE;
            buttonClose.Height = Constants.BTN_CLOSE_SIZE;

            //minimize button starting parameters
            buttonMin.Visible = false;
            buttonMin.Enabled = false;
            Point buttonMinLocation = new Point(buttonCloseLocation.X - Constants.BTN_CLOSE_SIZE, 0);
            buttonMin.Location = buttonMinLocation;
            buttonMin.Width = Constants.BTN_CLOSE_SIZE;
            buttonMin.Height = Constants.BTN_CLOSE_SIZE;

            //modifiers
            trackBarAlignment.Visible = false;
            trackBarAlignment.Enabled = false;
            labelAlignment.Visible = false;
            labelAlignmentVal.Visible = false;       
            trackBarAlignment.Location = new Point(panelWidth - trackBarAlignment.Width, panelHeight - trackBarAlignment.Height);
            labelAlignment.Location = new Point(panelWidth - trackBarAlignment.Width, panelHeight - trackBarAlignment.Height - labelAlignment.Height);
            labelAlignmentVal.Location = new Point(panelWidth - trackBarAlignment.Width + labelAlignment.Width, panelHeight - trackBarAlignment.Height - labelAlignment.Height);
            labelAlignmentVal.Text = trackBarAlignment.Value.ToString();

            //modifiers
            trackBarSeparation.Visible = false;
            trackBarSeparation.Enabled = false;
            labelSeparation.Visible = false;
            label1.Visible = false;
            trackBarSeparation.Location = new Point(panelWidth - trackBarAlignment.Width, panelHeight - trackBarAlignment.Height - Constants.TRACKBAR_SEPARATOR);
            labelSeparation.Location = new Point(panelWidth - trackBarAlignment.Width, panelHeight - trackBarAlignment.Height - labelSeparation.Height - Constants.TRACKBAR_SEPARATOR);
            label1.Location = new Point(panelWidth - trackBarAlignment.Width + labelSeparation.Width, panelHeight - trackBarAlignment.Height - labelAlignment.Height - Constants.TRACKBAR_SEPARATOR);
            label1.Text = trackBarSeparation.Value.ToString();


            //modifiers
            trackBarNeighbours.Visible = false;
            trackBarNeighbours.Enabled = false;
            labelNeighbours.Visible = false;
            label2.Visible = false;
            trackBarNeighbours.Location = new Point(panelWidth - trackBarAlignment.Width, panelHeight - trackBarAlignment.Height - Constants.TRACKBAR_SEPARATOR * 2);
            labelNeighbours.Location = new Point(panelWidth - trackBarAlignment.Width, panelHeight - trackBarAlignment.Height - labelNeighbours.Height - Constants.TRACKBAR_SEPARATOR * 2);
            label2.Location = new Point(panelWidth - trackBarAlignment.Width + labelNeighbours.Width, panelHeight - trackBarAlignment.Height - labelNeighbours.Height - Constants.TRACKBAR_SEPARATOR * 2);
            label2.Text = trackBarNeighbours.Value.ToString();

            //set all control background colours
            labelAlignment.BackColor = Constants.BACKGROUND;
            label1.BackColor = Constants.BACKGROUND;
            trackBarSeparation.BackColor = Constants.BACKGROUND;
            trackBarAlignment.BackColor = Constants.BACKGROUND;
            labelSeparation.BackColor = Constants.BACKGROUND;
            labelAlignmentVal.BackColor = Constants.BACKGROUND;
            buttonClose.BackColor = Constants.BACKGROUND;
            buttonMin.BackColor = Constants.BACKGROUND;
            labelNeighbours.BackColor = Constants.BACKGROUND;
            trackBarNeighbours.BackColor = Constants.BACKGROUND;
            label2.BackColor = Constants.BACKGROUND;

            //graphics init
            bufferImage = new Bitmap(panelWidth, panelHeight);
            bufferGraphics = Graphics.FromImage(bufferImage);

            //init controller
            boidCon = new BoidController(bufferGraphics, Constants.N_BOIDS, panelWidth, panelHeight);

            //go
            timer1.Interval = Constants.TICKERTICKTICK;
            timer1.Enabled = true;

            
            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //toggle pause
            if (e.KeyChar == 'p' || e.KeyChar == 'P')
                timer1.Enabled ^= true;
          

            //toggle on-screen controls if esc is pressed
            if (e.KeyChar == (char)27) //if it is escape
            {
                toggleControls();
            }
        }


        //close the program 
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //minimize window
        private void buttonMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //toggle the close/minimize buttons when panel is clicked
        private void panelDraw_Click(object sender, EventArgs e)
        {
            toggleControls();
        }


        //toggle visibility/functionality of on screen controls
        private void toggleControls()
        {
            buttonClose.Enabled ^= true;
            buttonClose.Visible ^= true;

            buttonMin.Enabled ^= true;
            buttonMin.Visible ^= true;

            trackBarAlignment.Enabled ^= true;
            trackBarAlignment.Visible ^= true;
            labelAlignment.Visible ^= true;
            labelAlignmentVal.Visible ^= true;

            trackBarSeparation.Enabled ^= true;
            trackBarSeparation.Visible ^= true;
            labelSeparation.Visible ^= true;
            label1.Visible ^= true;

            trackBarNeighbours.Enabled ^= true;
            trackBarNeighbours.Visible ^= true;
            labelNeighbours.Visible ^= true;
            label2.Visible ^= true;
        }


        //update aligngment value
        private void trackBarAlignment_Scroll(object sender, EventArgs e)
        {
            float alignVal = trackBarAlignment.Value;
            labelAlignmentVal.Text = alignVal.ToString();
            boidCon.RefreshAlignment(alignVal);
        }


        //update separation values
        private void trackBarSeparation_Scroll(object sender, EventArgs e)
        {
            float sepVal = trackBarSeparation.Value;
            label1.Text = sepVal.ToString();
            boidCon.RefreshSeparation(sepVal);
        }


        //update distance to neighbours
        private void trackBarNeighbours_Scroll(object sender, EventArgs e)
        {
            int distVal = (int)trackBarNeighbours.Value;
            label2.Text = distVal.ToString();
            boidCon.RefreshNeighbourDistance(distVal);
        }
    }
}
