using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class util
{

    public static int RandomInt(int min, int max)
    {
        return Random.Range(min, max);
    }

    // generel update function to update the map
    /// <summary>
    /// Updates the map with the given List.
    /// </summary>
    /// <returns>The map.</returns>
    /// <param name="map">Map.</param>
    /// <param name="roomList">Room list.</param>
    /// <param name="dataSetLenght">Data set lenght.</param>
    public static int[,] UpdateMap(int[,] map, List<int> roomList)
    {   
        // cursors
        int ix = 0;
        int iy = 1;
        int iv = 2;

        // default dataset lenght is 3 (x,y,value)
        int dataSetLenght = 3;


        for (int i = 0; i < roomList.Count; i += dataSetLenght)
        {
            map[roomList[ix], roomList[iy]] = roomList[iv];
            ix += dataSetLenght;
            iy += dataSetLenght;
            iv += dataSetLenght;
        }

        return map;
    }
}
