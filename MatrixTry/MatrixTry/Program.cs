using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PixelEngine;

namespace MatrixTry
{
    class Matrix : Game
    {
        private struct Streamer
        {
            public int nColumn { get; set; }
            public float fPosition { get; set; }
            public float fSpeed { get; set; }
            public string sText { get; set; }
        }
        
        private char RandChar()=> (char)Random(32, 128);

        private void PrepareStreamer(ref Streamer thisStreamer, int pos)
        {
            thisStreamer.fPosition = pos;
            thisStreamer.fSpeed = Random(10, 25);
            thisStreamer.nColumn = Random(ScreenWidth/8);
            thisStreamer.sText = string.Concat(MakeArray(Random(10, 50), i => RandChar()));
        }

        private List<Streamer> streamers = new List<Streamer>();
        private int nMaxStreamers = 300;

        public override void OnCreate()
        {
            for(int i = 0; i < nMaxStreamers; i++)
            {
                Streamer s = new Streamer();
                PrepareStreamer(ref s, Random(-ScreenHeight / 6, ScreenHeight * 5 / 6));
                streamers.Add(s);
            }
        }

        public override void OnUpdate(float elapsed)
        {
            Clear(Pixel.Presets.Black);
            for(int j = 0; j < streamers.Count; j++)
            {
                Streamer s = streamers[j];
                s.fPosition += elapsed * s.fSpeed * 10;

                for(int i = 0; i < s.sText.Length;i++)
                {
                    Pixel colour = s.fSpeed > 15 ? Pixel.Presets.Green : Pixel.Presets.DarkGreen;
                /*if (i == 0)
                    {
                        colour = Pixel.Presets.White;
                    }
                    else if (i <=2)
                    {
                        colour = Pixel.Presets.Grey;
                    }*/
                   
            //int index = Math.Abs((i - (int)s.fPosition) % s.sText.Length);
                    DrawText(new Point(s.nColumn * 8, (int)s.fPosition - i * 8), s.sText[i].ToString(), colour);
                    if (Random(1000) < 5)
                    {
                        s.sText = s.sText.Remove(i, 1).Insert(i, RandChar().ToString());
                    }
                }
                if (s.fPosition - s.sText.Length*8>ScreenHeight)
                {
                    PrepareStreamer(ref s, 0);
                }
                streamers[j] = s;
            }
            /*DrawRect(new Point(ScreenWidth / 3, ScreenHeight / 3),330,180,Pixel.Presets.Green);
            for(int k = 210; k <810;k++)
            {
                for(int g = 310; g <605;g++)
                {
                    Draw(k, g, Pixel.Presets.Black);
                }
            }
            /*string[] birthdayMessage = new string[]{ "Happy Birthday!", " I wish you to create a film with",
                " such an iconic status as \"Matrix\"",
                " has. Just don't give up, okay?" ,
                "P.S.: I had to use English because" ,"this engine doesn't support Russian." ,"Heh." };
            DrawText(new Point(380, ScreenHeight / 3+15), birthdayMessage[0], Pixel.Presets.Green,2);
            int y = 0;
            for(int i=1; i < birthdayMessage.Length; i++)
            {
                if(i==6) DrawText(new Point(465, ScreenHeight / 3 + 220), birthdayMessage[6], Pixel.Presets.Green,2);
                //else if(i==6) DrawText(new Point(440, ScreenHeight / 3 + 325), birthdayMessage[9], Pixel.Presets.Green,2);
                else DrawText(new Point(230, ScreenHeight / 3 + 45 + y), birthdayMessage[i], Pixel.Presets.Green,2);
                y += 35;
            }*/
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix();
            matrix.Construct(1000, 1000, 1, 1);
            matrix.Start();
        }
    }
}
