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
    private int[] usedTiles;
    private int[,,] cordSet;

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

    /// <summary>
    /// Creates the room.
    /// </summary>
    public void CreateRoom()
    {
        bool inBound;
        inBound = TileOutOfBound();
        if(inBound)
        {
            int ix = 0;
            for (int iy = 0; iy < roomSizeY; iy++)
            {
                this.data.Add(cordX + ix);
                this.data.Add(cordY + iy);
                this.data.Add(1);
                if (iy == roomSizeY - 1 && ix < roomSizeX -1 )
                {
                    iy = -1;
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

    /// <summary>
    /// Tiles the out of bound.
    /// </summary>
    /// <returns><c>true</c>, if out of bound was tiled, <c>false</c> otherwise.</returns>
    bool TileOutOfBound()
    {
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
