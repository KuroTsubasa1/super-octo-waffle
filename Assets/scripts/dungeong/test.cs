using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public GameObject solidWall;
    public GameObject wall;
    public GameObject floor;

	// Use this for initialization
	void Start () {

        int mapSize = 10;

        Dictionary<int,int> map = new Dictionary<int,int>();
        //example.Add("hello","world");
        //Debug.Log (example["hello"]);

        map  = CreateMap(mapSize, map);

        map = CreateRoom(mapSize, map);

        RenderMap(map, mapSize);
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    // picks a random start tile 
    string pickRandomTile(int mapSize){
        string tile = "" + Random.Range(0, mapSize);
        tile += Random.Range(0, mapSize);
        return tile;
    }

    Dictionary<int, int> CreateRoom(int mapSize, Dictionary<int, int> map){
        string tile = pickRandomTile(mapSize);
        map[int.Parse(tile)] = 1;
        return map;
    }

    // generates mapSize * mapSize entrys and fills them with 0
    Dictionary<int, int> CreateMap(int mapSize, Dictionary<int,int> map){
        int row = 0;
        int column = 0;
        for (; row < mapSize; row++)
        {   
          
            string name = "" + column;
            name += row;
            Debug.Log(name);
            map.Add(int.Parse(name),0);

            if(row == mapSize -1 && column < mapSize - 1){
                column++;
                row = -1;
            }
        }
        return map;
    }


    // displays data map in CLI
    void RenderMap(Dictionary<int, int> map, int mapSize){
        int i = 0;
        string row = "";
        Vector3 pos = new Vector3(0, 0, 0);
        GameObject tile;
        foreach (KeyValuePair<int, int> entry in map)
        {   
            row += entry.Value + " ";

            switch(entry.Value){
                case 0:
                    tile =  Instantiate(solidWall,pos,Quaternion.identity);
                    tile.name = entry.Key.ToString();
                    pos.x += 1.1f;
                    break;
                case 1:
                    tile = Instantiate(wall, pos, Quaternion.identity);
                    tile.name = entry.Key.ToString();
                    pos.x += 1.1f;
                    break;
                case 2:
                    tile = Instantiate(floor, pos, Quaternion.identity);
                    tile.name = entry.Key.ToString();
                    pos.x += 1.1f;
                    break;
                default :
                    tile = Instantiate(solidWall, pos, Quaternion.identity);
                    tile.name = entry.Key.ToString();
                    pos.x += 1.1f;
                    break;
            }

           
            if(i == mapSize -1){
                Debug.Log(row);
                i = -1;
                pos.x = 0;
                pos.z += 1.1f;
                row = "";
            }
            i++;
        }
    }
}
