using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

class SmoothForm : Form
{
    public SmoothForm(Size window)
    {
        this.Text = "MandelBrot in C#";
        this.ClientSize = window;

        DoubleBuffered = true;
    }
}
class Program
{
    static void Main()
    {
        int screenWidth = 800;
        int screenHeight = 800;




        Size window = new Size(screenWidth, screenHeight);
        SmoothForm screen = new SmoothForm(window);
       

        Bitmap bitmap = new Bitmap(screenWidth,screenHeight);
        Label background = new Label();
        screen.Controls.Add(background);
        Size clientWindow = window;
        background.Size = window;


        double rangeWidth = 4;
        double rangeMin = -2;


        int maxIteration = 1000;
        for (int pixelX = 0; pixelX < screenWidth; pixelX++)
        {
            for (int pixelY = 0; pixelY < screenHeight; pixelY++) 
            {
                // mapping functie
                double x = (pixelX / (double)screenWidth * rangeWidth + rangeMin);
                double y = (pixelY / (double)screenHeight * rangeWidth + rangeMin);

                double a = 0;
                double b = 0;
                int iteration = 0;

                // iteratie functie
                while (a*a+b*b<=4 && iteration < maxIteration)
                {
                    

                    double newA = a * a - b * b + x;
                    double newB = 2 * a * b + y;

                    a = newA;
                    b = newB;

                    iteration++;

                    //Debug.Print($"a={a}|b={b}");
                }


                //int R = 255%iteration;
                //int G = 200%iteration;
                //int B = 150%iteration;

                int R = (iteration == maxIteration) ? 75 : iteration%255;
                int G = (iteration == maxIteration) ? 100 : iteration%255;
                int B = (iteration == maxIteration) ? 50 : iteration%255;

                
                

                bitmap.SetPixel(pixelX, pixelY, Color.FromArgb(R,G,B));
            }
        }

        


        background.Image = bitmap;

        


        


        Application.Run(screen);
    }
 
}

