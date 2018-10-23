using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TochilinaAnna
{
    public class GameModeSnake
    {
        private int level;
        public int score, points;
        public int rows, cols;
        public int scale;
        public int countFruits;
        public int sizeSnake;
        public short snakeDirection;
        public bool menuLevel;

        public List<int> SnakeX = new List<int>();
        public List<int> SnakeY = new List<int>();
        public List<int> FruitsX = new List<int>();
        public List<int> FruitsY = new List<int>();
        public List<int> TextureFruits = new List<int>();

        public int Level() { return level; }
        public void Level(int Level)
        {
            level = Level;
            points = level * 3;
        }

        public GameModeSnake(int rows = 15, int cols = 15, int scale = 50, int sizeSnake = 2, int countFruits = 5)
        {
            level = 1;
            score = 0;
            points = level * 3;
            this.rows = rows;
            this.cols = cols;
            this.scale = scale;
            this.countFruits = countFruits;
            this.sizeSnake = sizeSnake;
            menuLevel = false;

            for (int i = 0; i < sizeSnake; i++)
            {
                SnakeX.Add(cols / 2);
                SnakeY.Add(rows / 2);
            }

            Random r = new Random();
            for (int i = 0; i < countFruits; i++)
            {
                FruitsX.Add(r.Next(cols));
                FruitsY.Add(r.Next(rows));
                TextureFruits.Add(r.Next(0,7));
            }
        }

        ~GameModeSnake() { }
    }
}
