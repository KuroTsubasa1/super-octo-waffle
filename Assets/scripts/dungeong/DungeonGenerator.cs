using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    private int coridorSizeXMax = 2;
    [SerializeField]
    private int coridorSizeXMin = 2;
    [SerializeField]
    private int coridorSizeYMax = 2;
    [SerializeField]
    private int coridorSizeYMin = 2;



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

    [SerializeField]
    private GameObject startPosition;

    [SerializeField]
    private int seed = 0;


    // Use this for initialization
    void Start () 
    {      
        // check for random seed
        if(seed == 0){
            seed = Random.seed;
            Debug.Log("The session seed is " + seed);
        }
        else
        {
            Random.InitState(seed);
        }


        Dungeon dungeon = new Dungeon ( util.RandomInt (dungeongSizeXMin, dungeongSizeXMax), util.RandomInt (dungeongSizeYMax, dungeongSizeYMin));

        // this is bullshit but needed for init the array for now ...
        int[,] map = map = dungeon.GetMap();

        for (int i = 0; i < 3; i++)
        {
            Debug.Log("Room Generation -> This is Room : " + i);

            Room room = new Room(util.RandomInt(dungeongSizeXMin, dungeongSizeXMax), util.RandomInt(dungeongSizeYMax, dungeongSizeYMin), roomSizeXMin, roomSizeXMax, roomSizeYMin, roomSizeYMax, dungeon);
            Coridor coridor = new Coridor(room, coridorSizeXMax, coridorSizeXMin, coridorSizeYMax, coridorSizeYMax);
            var roomList = room.GetRoomList();
            map = dungeon.GetMap();
            map = UpdateMap(map, roomList);

            // update coridors 
            roomList = coridor.GetRoomList();
            map = UpdateMap(map, roomList);
        }


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
                case 99:    // wip start position for coridor
                    var start = Instantiate(startPosition, new Vector3(ix, -0.5f, iy), Quaternion.identity);
                    start.transform.eulerAngles = new Vector3(-90, 0, 0);
                    start.transform.localScale = new Vector3(50, 50, 50);
                    break;
            }
           
			if (iy == sizeY-1 && ix < sizeX -1) 
            {
               // Debug.Log(dungeonRow);
                dungeonRow = "";
				iy = -1;
				ix++;
			}
		}
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

        // debug section
        /*
        Debug.Log("ix " + roomList[ix]);
        Debug.Log("iy " + roomList[iy]);
        Debug.Log("iv " + roomList[iv]);
        Debug.Log("List Lenght " + roomList.Count);
        */
        Debug.Log("-------------------");

        for (int i = 0; i < roomList.Count; i += dataSetLenght)
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
