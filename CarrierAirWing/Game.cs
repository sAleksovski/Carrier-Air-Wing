using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CarrierAirWing
{
    public class Game
    {
        public Level level;
        public Player p1;
        public LinkedList<Rocket> playerRockets;
        public int BoundsX { get; set; }
        public int BoundsY { get; set; }
        //public Player p2;

        public Game()
        {
            GraphicsEngine.Init();
            level = new Level();
            p1 = new Player(new A10Thunderbolt(100, 100));
            playerRockets = new LinkedList<Rocket>();
        }
        
        public void Move()
        {
            p1.Move();

            if (p1.plane.keys.ctrl == 1)
            {
                Rocket r = p1.Fire();
                if (r != null)
                    playerRockets.AddFirst(r); //ili AddLast?
            }

            LinkedList<Rocket> deleteRockets = new LinkedList<Rocket>();

            foreach (Rocket r in playerRockets)
            {
                if (r.X >= BoundsX - 100)
                {
                    deleteRockets.AddFirst(r);
                }
                else
                {
                    r.Move();
                }
            }

            foreach (Rocket r in deleteRockets)
            {
                playerRockets.Remove(r);
            }

            Collision();
        }

        private void Collision()
        {
           
        }

        public void Draw(Graphics g)
        {
            level.Draw(g);
            p1.Draw(g);
            foreach (Rocket r in playerRockets)
            {
                r.Draw(g);
            }
        }
    }
}
