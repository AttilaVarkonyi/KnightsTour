using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour
{
    public class Movement
    {
        int[,] chessTableFreeSpace;
        public int[,] chessTableOrder;
        int[,] xyCoordinates;

        public Movement()
        {
            chessTableFreeSpace = new int[8, 8];
            chessTableOrder = new int[8, 8];
            xyCoordinates = new int[8, 2];
            defaultMap();
            defaultMovement();
        }


        // 0 = free space
        // -1 = forbidden space
        // -2 = explored space
        // 9 = knight position
        private void defaultMap()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    chessTableFreeSpace[i, j] = 0;
                }
            }
            chessTableFreeSpace[0, 0] = -1;
            chessTableFreeSpace[7, 0] = -1;
            chessTableFreeSpace[0, 7] = -1;
            chessTableFreeSpace[7, 7] = -1;
            chessTableFreeSpace[0, 1] = 9;
        }

        private void defaultMovement()
        {
            xyCoordinates[0, 0] = 2;
            xyCoordinates[0, 1] = 1;

            xyCoordinates[1, 0] = 2;
            xyCoordinates[1, 1] = -1;

            xyCoordinates[2, 0] = 1;
            xyCoordinates[2, 1] = 2;

            xyCoordinates[3, 0] = 1;
            xyCoordinates[3, 1] = -2;

            xyCoordinates[4, 0] = -1;
            xyCoordinates[4, 1] = 2;

            xyCoordinates[5, 0] = -1;
            xyCoordinates[5, 1] = -2;

            xyCoordinates[6, 0] = -2;
            xyCoordinates[6, 1] = 1;

            xyCoordinates[7, 0] = -2;
            xyCoordinates[7, 1] = -1;
        }

        private bool additionalRules(int x, int y) //Knight's next position
        {
            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                return false;
            }
            else if (chessTableFreeSpace[x,y] == -1 || chessTableFreeSpace[x, y] == -2)
            {
                return false;
            }
            
            return true;
        }

        public bool move(int x, int y, int counter)
        {
            int xNext;
            int yNext;

            if (counter == 59) //&& ((x == 2 && y == 0)||(x == 2 && y == 2) || ( x == 3 && y == 1))
            {
                return true;
            }

            for (int i = 0; i < 8; i++)
            {
                xNext = x + xyCoordinates[i, 0];
                yNext = y + xyCoordinates[i, 1];
                if (additionalRules(xNext, yNext))
                {
                    chessTableFreeSpace[xNext, yNext] = 9;
                    chessTableFreeSpace[x, y] = -2;

                    chessTableOrder[xNext, yNext] = counter + 1;
                    if (move(xNext, yNext, counter + 1))
                    {
                        return true;
                    }
                    else
                    {
                        chessTableFreeSpace[xNext, yNext] = 0;
                    }
                    
                }   
            }
            return false;
        }

    }
}
