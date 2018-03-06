using System.Collections;
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

    // Use this for initialization
    void Start () {

        Dungeon dungeon = new Dungeon ( util.RandomInt (dungeongSizeXMin, dungeongSizeXMax), util.RandomInt (dungeongSizeYMax, dungeongSizeYMin));

        Room room = new Room(util.RandomInt(dungeongSizeXMin, dungeongSizeXMax), util.RandomInt(dungeongSizeYMax, dungeongSizeYMin), roomSizeXMin, roomSizeXMax, roomSizeYMin, roomSizeYMax, dungeon);

        var roomList = room.GetRoomList();

        //Debug.Log("-----------------------");
        //foreach (object o in roomList)
        //{
        //    Debug.Log(o);
        //}
        //Debug.Log("-----------------------");

        Debug.Log(dungeon.GetSizeX());
        Debug.Log(dungeon.GetSizeY());

        int[,] map = dungeon.GetMap();

        map = UpdateMap(map,roomList);
        RenderMap(map,dungeon.GetSizeX(),dungeon.GetSizeY());

	}

    void RenderMap(int[,] map, int sizeX, int sizeY)
	{	
		int ix = 0;
		for (int iy = 0; iy <sizeY; iy++) 
		{	
            // dataview
            print("ix : " + ix + " " + "iy :" + iy + " " + "value : " + map[ix, iy]);
            WriteMapToFile(map[ix, iy].ToString());

            switch(map[ix, iy])
            {
                case 0:
                    Instantiate(solidWall, new Vector3(ix, 0, iy), Quaternion.identity);
                    break;

                case 1:
                    Instantiate(wall, new Vector3(ix, 0, iy), Quaternion.identity);
                    StartCoroutine(Example());
                    break;
            }
           
			if (iy == sizeY-1 && ix < sizeX -1) 
            {
                WriteMapToFile("\n");   
				iy = -1;
				ix++;
			}
		}
	}

    int[,] UpdateMap(int[,] map, List<int> roomList)
    {
        int ix = 0;
        int iy = 1;
        int iv = 2;

        int dataSetLenght = 3; 

        Debug.Log("count " + roomList.Count);
        Debug.Log("map " + map.Length);

        for (int i = 0; i < roomList.Count; i+= dataSetLenght)
        {   
            Debug.Log("ix " + ix + " value " + roomList[ix]);
            Debug.Log("iy " + iy + " value " + roomList[iy]);
            Debug.Log("iv " + iv + " value " + roomList[iv]);
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

    IEnumerator Example()
    {
        yield return new WaitForSeconds(10);
        print("test");
    }

    void WriteMapToFile(String input)
    {
        string path = "/Users/harmlasse/Documents/super-octo-waffle/Assets/scripts/";
        File.Create(path);
        File.WriteAllText(path, input);
    }
}
