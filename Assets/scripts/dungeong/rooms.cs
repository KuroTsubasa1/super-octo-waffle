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

    //int[][] CreateRoom(int cordX, int cordY, int[][] tiles)
    //{   
    //    int roomSize = Random.Range(0, 8);
    //    bool inBound;

    //    inBound = TileOutOfBound(tiles, cordX, cordY, roomSize);

    //    if(!inBound){
    //        int i = cordX;
    //        for (int ii = cordY; ii < cordY + roomSize; ii++)
    //        {   
    //            Debug.Log("i: " + i);
    //            Debug.Log("ii: " + ii);
    //            tiles[i][ii] = 1; 
    //            if(ii == cordY + roomSize - 1 && i < cordX + roomSize -1){
    //                i++;
    //                ii = cordY - 1;
    //            }
    //        }

    //    }


    //    return tiles;
    //}

}


 