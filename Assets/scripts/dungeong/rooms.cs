using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room 
{

    private int cordX;
    private int cordY;
    private int roomSizeX;
    private int roomSizeY;
    private Dungeon dungeon;
    private int[] usedTiles;
    private int[,,] cordSet;

    public Room(int x, int y, Dungeon dungeon)
    {
        cordX = x;
        cordY = y;
        roomSizeX = util.RandomInt(3, 10);
        roomSizeY = util.RandomInt(3, 10);
        this.dungeon = dungeon;
    }

    public void CreateRoom(){
        bool inBound;
        inBound = TileOutOfBound();

        if (!inBound)
        {
            int counterArray = 0;
            int counterX = cordX;
            for (int i = cordY; i < cordY + roomSizeY; i++)
            {
                cordSet[counterX,i,i] = 
                usedTiles[counterArray] = cordSet[cordX + i, cordY + i, 1];
                if (cordY + i == cordY + roomSizeY - 1 && cordX + counterX < cordX + roomSizeX -1)
                {
                    counterX++;
                    i = cordY - 1;
                }
                counterArray++;
            }
        }

        }

    bool TileOutOfBound()
    {
        if (cordX + roomSizeX < dungeon.GetDungeonX() && cordY + roomSizeY < dungeon.GetDungeonY())
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}


 