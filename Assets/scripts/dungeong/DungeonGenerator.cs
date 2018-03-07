﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class DungeonGenerator : MonoBehaviour {

    [SerializeField]
    private int dungeongSizeXMax = 100;
    [SerializeField]
    private int dungeongSizeXMin = 10;
    [SerializeField]
    private int dungeongSizeYMax = 100;
    [SerializeField]
    private int dungeongSizeYMin = 10;

    [SerializeField]
    private int roomSizeXMax = 90;
    [SerializeField]
    private int roomSizeXMin = 5;
    [SerializeField]
    private int roomSizeYMax = 90;
    [SerializeField]
    private int roomSizeYMin = 5;


    [SerializeField]
    private int stepSize = 1;

    [SerializeField]
    private GameObject solidWall;
    [SerializeField]
    private GameObject wall;
    [SerializeField]
    private GameObject edge;
    [SerializeField]
    private GameObject corner;

    // floor variations
    [SerializeField]
    private GameObject[] floor = new GameObject[4];


    // Use this for initialization
    void Start () 
    {
        Dungeon dungeon = new Dungeon ( util.RandomInt (dungeongSizeXMin, dungeongSizeXMax), util.RandomInt (dungeongSizeYMax, dungeongSizeYMin));

        // this is bullshit but needed for init the array for now ...
        int[,] map = map = dungeon.GetMap();

       
            Room room = new Room(util.RandomInt(dungeongSizeXMin, dungeongSizeXMax), util.RandomInt(dungeongSizeYMax, dungeongSizeYMin), roomSizeXMin, roomSizeXMax, roomSizeYMin, roomSizeYMax, dungeon);

            var roomList = room.GetRoomList();
            map = dungeon.GetMap();

            map = UpdateMap(map, roomList);

       


        RenderMap(map,dungeon.GetSizeX(),dungeon.GetSizeY());

	}

    /// <summary>
    /// Renders the map.
    /// </summary>
    /// <param name="map">Map.</param>
    /// <param name="sizeX">Size x.</param>
    /// <param name="sizeY">Size y.</param>
    void RenderMap(int[,] map, int sizeX, int sizeY)
	{

        // really stupid way to this
        string dungeonRow = "";

		int ix = 0;
		for (int iy = 0; iy <sizeY; iy++) 
		{
            // dataview
            dungeonRow += map[ix, iy].ToString();

            switch(map[ix, iy])
            {
                case 0:
                    var wallss = Instantiate(wall, new Vector3(ix, -0.5f, iy), Quaternion.identity);
                    wallss.transform.eulerAngles = new Vector3(-90, 0, 0);
                    wallss.transform.localScale = new Vector3(50, 50, 50);
                    break;

                case 1:
                    var floor_ = Instantiate(floor[util.RandomInt(0, floor.Length - 1)], new Vector3(ix, -0.5f, iy), Quaternion.identity);
                    floor_.transform.eulerAngles = new Vector3(-90, 0, 0);
                    floor_.transform.localScale = new Vector3(50, 50, 50);
                    break;

                case 2:
                    var edge_ = Instantiate(edge, new Vector3(ix, -0.5f, iy), Quaternion.identity);
                    edge_.transform.eulerAngles = new Vector3(-90, 0, 0);
                    edge_.transform.localScale = new Vector3(50, 50, 50);
                    break;
                case 3:
                    var corner_ = Instantiate(corner, new Vector3(ix, -0.5f, iy), Quaternion.identity);
                    corner_.transform.eulerAngles = new Vector3(-90, 0, 0);
                    corner_.transform.localScale = new Vector3(50, 50, 50);

                    break;
            }
           
			if (iy == sizeY-1 && ix < sizeX -1) 
            {
                Debug.Log(dungeonRow);
                dungeonRow = "";
				iy = -1;
				ix++;
			}
		}
	}

    /// <summary>
    /// Updates the map.
    /// </summary>
    /// <returns>The map.</returns>
    /// <param name="map">Map.</param>
    /// <param name="roomList">Room list.</param>
    int[,] UpdateMap(int[,] map, List<int> roomList)
    {
        int ix = 0;
        int iy = 1;
        int iv = 2;

        int dataSetLenght = 3; 

        for (int i = 0; i < roomList.Count; i+= dataSetLenght)
        {   
            map[roomList[ix], roomList[iy]] = roomList[iv];
            ix += dataSetLenght;
            iy += dataSetLenght;
            iv += dataSetLenght;
        }

        return map;
    }

	// Update is called once per frame
	void Update () {
	}


}
