// Include the namespaces (code libraries) you need below.
using Microsoft.VisualBasic.FileIO;
using System;
using System.Net.Security;
using System.Numerics;
using System.Runtime.Serialization;
using System.Threading;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        float x;
        float radius = 50; // unused variables because i couldnt get things working
        float speed = 200;

        float ketchupX = 0;
        float ketchupY = 0;

        float pRadius = 50.0f;
        float aLineweight = 20.0f;


        Vector2 ketchup = new Vector2(0, 0);

        bool condition = true;
        bool emit = true;
        bool aura = true;

        float cooldown = 0;
        int cycle = 0; //probably would need this for arrays

        Vector2 lasagna = new Vector2(0,0);

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Loop Test");
            Window.SetSize(600,600);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.White);

            ++cycle; 

            // particle spawner 

            if (cycle == 5) //supposed to be a timer 
                {
                emit = true;
                }
            else if (cycle == 10)
                {
                emit = false;
                cycle = 0;
                }


            if (emit == true)
                {
                Particle0(); //creates a particle (a circle) except it. instead just creates it for the frame emit is true
                emit = false; //resets the cycle
                }

            // cursor aura

            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space) == true) 
                {
                if (aura == false)
                    {
                    aura = true;
                    }
                else if (aura == true)
                    { 
                    aura = false;
                    }
                }
            if (aura == true)
                {
                Aura();
                }   



        }
        void Particle0()
        {
            DrawParticle();
        }

        void DrawParticle()
        {
            float pRadius = 50.0f - (Time.DeltaTime / 10.0f);

            Draw.LineSize = 0;
            Draw.LineColor = Color.Red;
            Draw.FillColor = Color.Black;
            if (emit == true)
                {
                lasagna = Input.GetMousePosition(); // supposed to track a 'snapshot' of the position of the mouse but it keeps tracking the current position instead
                }
            Draw.Circle((lasagna + ketchup), pRadius);
        }
        void Aura()
        {
            pRadius = 50.0f + (Time.DeltaTime * 10.0f); // was supposed to create a shockwave of sorts but i suspect the deltatime keeps resetting every frame its initiated, not sure how to fix that
            aLineweight = 20.0f - (Time.DeltaTime / 5.0f);

            if (aLineweight <= 0)
            {
                aura = false; // would remove the aura once its done, but the aura is never done
            }

            Input.GetMousePosition();
            Draw.LineSize = aLineweight;
            Draw.LineColor = Color.Red;
            Draw.FillColor = Color.White;

            Vector2 olives = Input.GetMousePosition();
            Draw.Circle(olives, pRadius);
        }
    }

}
