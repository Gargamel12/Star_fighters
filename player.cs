using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Star_fighters
{
    public class Player
    {
        public int HP { get; set; }
        public int DMG { get; set; } = 10;
        public int Angle { get; set; } = 0;
        public int Speed { get; set; } = 0;
        public Rectangle HitBox { get; set; }

        public Player(int hp, int dmg)
        {
            HP = hp;
            DMG = dmg;
        }
        public void punch(Player enemy)
        {
            enemy.HP -= DMG;
        }
    }
}
