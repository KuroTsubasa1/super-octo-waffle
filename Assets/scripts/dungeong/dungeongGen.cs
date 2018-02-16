using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dungeongGen : MonoBehaviour {

    public GameObject solidWall;
    public GameObject wall;
    public GameObject floor;
    public GameObject player;

    public float tileSpread = 2;

	// Use this for initialization
	void Start () {



        // board size
        int sizeX = 32;
        int sizeY = 32;

        int[][] tiles;
        tiles = SetupMap(sizeX, sizeY);
        tiles = Fillarray(tiles);
        for (int i = 0; i < util.RandomInt(0,sizeX); i++)
        {
            tiles = CreateRoom(util.RandomInt(0,sizeX), util.RandomInt(0,sizeY), tiles);
        }

        RenderTiles(tiles);


    }

    int[][] SetupMap(int sizeX, int sizeY){

        int[][] tiles;
        // Set the tiles jagged array to the correct X.
        tiles = new int[sizeX][];

        for (int i = 0; i < tiles.Length; i++)
        {
            //set each tile array is the correct X.
            tiles[i] = new int[sizeY];
        }

        return tiles;
    }

    int[][] Fillarray(int[][]tiles){
        int i = 0; 
        for (int ii = 0; ii < tiles.Length; ii++)
        {
            tiles[i][ii] = 0;
            if (i == tiles.Length -1 )
            {
                i++;
                ii = -1;
            }
        }
        return tiles;
    }


    public rooms CreateRoom(){
        rooms room = new rooms(util.RandomInt(0,));


        return room
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

    bool TileOutOfBound(int[][] tiles, int cordX, int cordY, int roomSize){

        if(cordX + roomSize < tiles.Length && cordY + roomSize < tiles.Length){
            return false;
        }else{
            return true;
        }
    }

    void RenderTiles(int[][] tiles){
        int i = 0;
        Vector3 pos = new Vector3(0,0,0);
        Quaternion rot = new Quaternion(0,0,0,0);
        rot = Quaternion.Euler(-90f, 0, 0);
        GameObject tile;
        for (int ii = 0; ii < tiles.Length; ii++)
        {   
            switch (tiles[i][ii])
            {
                case 0:
                    tile = Instantiate(solidWall, pos, Quaternion.identity);
                    tile.name = i.ToString() + ii.ToString();
                    tile.transform.rotation = rot;
                    Debug.Log("Rotation: " + tile.transform.rotation);
                    pos.x += tileSpread;
                    break;
                case 1:
                    pos.y = 0;
                    tile = Instantiate(wall, pos, Quaternion.identity);
                    tile.name = i.ToString() + ii.ToString();
                    tile.transform.rotation = rot;
                    pos.x += tileSpread;
                    break;
                case 2:
                    tile = Instantiate(floor, pos, Quaternion.identity);
                    tile.name = i.ToString() + ii.ToString();
                    pos.x += tileSpread;
                    break;
                default:
                    tile = Instantiate(solidWall, pos, Quaternion.identity);
                    tile.name = i.ToString() + ii.ToString();
                    pos.x += tileSpread;
                    break;
            }

            if (ii == tiles.Length - 1 && i < tiles.Length - 1)
            {
                i++;
                ii = -1;
                pos.x = 0;
                pos.z += tileSpread;
            }
        }
    }
}
