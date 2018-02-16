using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon {

    private int sizeX;
    private int sizeY;
    private Room[] currentRooms;
    private int[][] map;


    public Dungeon(int x, int y, Room [] rooms ){

        sizeX = x;
        sizeY = y;
        currentRooms = rooms;

        PrepareMap();
        FillArray();
    }

    private void PrepareMap(){

        map = new int[sizeX][];
        for (int i = 0; i < map.Length; i++)
        {
            //set each tile array is the correct X.
            map[i] = new int[sizeY];
        }
    }

    private void FillArray()
    {
        int i = 0;
        for (int ii = 0; ii < map.Length; ii++)
        {
            map[i][ii] = 0;
            if (i == map.Length - 1)
            {
                i++;
                ii = -1;
            }
        }
    }

    private void UpdateMap(){
        int i = 0;
        for (int ii = 0; ii < rooms; ii++)
        {
            map 
        }
    }

    public int GetDungeonX(){
        return sizeX;
    }

    public int GetDungeonY()
    {
        return sizeY;
    }

}
