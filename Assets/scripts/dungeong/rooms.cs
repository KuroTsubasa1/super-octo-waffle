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

    //
    private List<int> edge = new List<int>();

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
        if (inBound)
        {
            int ix = 0;
            for (int iy = 0; iy < roomSizeY; iy++)
            {

                // edge detection
                if (iy == 0 || iy == roomSizeY - 1 || ix == 0 || ix == roomSizeX - 1)
                {
                    this.data.Add(cordX + ix);
                    this.data.Add(cordY + iy);
                    this.data.Add(2); // edge tile

                    edge.Add(cordX + ix);
                    edge.Add(cordY + iy);
                }
                else
                {
                    this.data.Add(cordX + ix);
                    this.data.Add(cordY + iy);
                    this.data.Add(1); // floor tile

                }

                // corner detection
                if (iy == 0 && ix == 0 || iy == roomSizeY - 1 && ix == 0 || iy == 0 && ix == roomSizeX - 1 ||iy == roomSizeY - 1 && ix == roomSizeX - 1)
                {
                    this.data.Add(cordX + ix);
                    this.data.Add(cordY + iy);
                    this.data.Add(3); // corner tile
 
                }

                if (iy == roomSizeY - 1 && ix < roomSizeX - 1)
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

    public List<int> GetEdgeList()
    {
        return this.edge;
    }

    public int GetRoomSIzeX()
    {
        return this.roomSizeX;
    }

    public int GetRoomSIzeY()
    {
        return this.roomSizeY;
    }
}
