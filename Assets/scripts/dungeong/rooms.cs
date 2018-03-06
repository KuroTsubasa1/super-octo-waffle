using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{

    private int cordX;
    private int cordY;
    private int roomSizeX;
    private int roomSizeY;
    private int roomSizeXMin;
    private int roomSizeXMax;
    private int roomSizeYMin;
    private int roomSizeYMax;
    private Dungeon dungeon;

    //private int[] data;
    private List<int> data = new List<int>();
    private Dictionary<string, List<int>> data2;
    private int[] container;

    public Room(int cordX, int cordY, int roomSizeXMin, int roomSizeXMax, int roomSizeYMin, int roomSizeYMax, Dungeon dungeon)
    {
        this.cordX = cordX;
        this.cordY = cordY;
        this.roomSizeX = util.RandomInt(roomSizeXMin, roomSizeXMax);
        this.roomSizeY = util.RandomInt(roomSizeYMin, roomSizeYMax);
        this.roomSizeXMin = roomSizeXMin;
        this.roomSizeXMax = roomSizeXMax;
        this.roomSizeYMin = roomSizeYMin;
        this.roomSizeYMax = roomSizeYMax;
        this.dungeon = dungeon;
        CreateRoom();

    }

    public void CreateRoom()
    {
        bool inBound;
        inBound = TileOutOfBound();
        Debug.Log("roomSizeX " + roomSizeX);
        Debug.Log("roomSizeY" + roomSizeY);
        Debug.Log("result " + inBound);
        if(inBound)
        {
            int ix = cordX;
            for (int iy = cordY; iy < roomSizeY; iy++)
            {
                // this.data = [ix, iy, 1];
                //Debug.Log("added " + ix + " to List");
                this.data.Add(ix);
                //Debug.Log("added " + iy + " to List");
                this.data.Add(iy);
                //Debug.Log("added " + 1 + " to List");
                this.data.Add(1);

                if (iy == roomSizeY - 1 && ix < roomSizeX -1 )
                {
                    iy = cordY -1; 
                    ix++;
                }
            }
        }
        else
        {
            this.cordX = util.RandomInt(0, dungeon.GetSizeX());
            this.cordY = util.RandomInt(0, dungeon.GetSizeY());
            this.roomSizeX = util.RandomInt(roomSizeXMin, roomSizeXMax);
            this.roomSizeY = util.RandomInt(roomSizeYMin, roomSizeYMax);
            CreateRoom();
        }
    }

    bool TileOutOfBound()
    {   
        Debug.Log(cordX + roomSizeX + " < " + dungeon.GetSizeX() + " && " + cordY + roomSizeY + " < " + dungeon.GetSizeY());
        if (cordX + roomSizeX < dungeon.GetSizeX() && cordY + roomSizeY < dungeon.GetSizeY())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<int> GetRoomList()
    {
        return this.data;
    }

}



 