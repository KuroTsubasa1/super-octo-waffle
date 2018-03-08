using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coridor{

    private int coridorSizeX;
    private int coridorSizeY;
    //private int cordX;
    //private int cordY;
    private int coridorSizeXMax;
    private int coridorSizeXMin;
    private int coridorSizeYMax;
    private int coridorSizeYMin;
    private Room room;


    private List<int> data = new List<int>();

    public Coridor(Room room, int coridorSizeXMax, int coridorSizeXMin, int coridorSizeYMax, int coridorSizeYMin)
    {
        this.coridorSizeX = util.RandomInt(coridorSizeXMin, coridorSizeXMax);
        this.coridorSizeY = util.RandomInt(coridorSizeYMin, coridorSizeYMax);
        this.room = room;
        CreateCoridor();
    }

    public void CreateCoridor()
    {
        List<int> edgeList = room.GetEdgeList();

        int randomCordX = util.RandomInt(0, edgeList.Count - 1);
        int startcord = edgeList[randomCordX]; 
        if(IsEvenNumber(startcord))
		{
            CheckCordPosition(edgeList[randomCordX], edgeList[randomCordX +1], edgeList, randomCordX); // plus 1 for the Y cord

            // check horizontal up
            if(edgeList[startcord + 2 ] == startcord + 1 )
            {
                Build(1);
            }

            // check horizontal down
            if (edgeList[startcord + 2] == startcord + 1)
            {
                Build(2);
            }

            // check vertical up
            if(edgeList[startcord + 2] == room.GetRoomSIzeX() -1 && startcord == edgeList[edgeList.Count-1]) 
            {
                Build(3);
            }

            // check vertical down
            if (edgeList[startcord + 2] == room.GetRoomSIzeX() - 1 && startcord == edgeList[edgeList.Count - 1])
            {
                Build(4);
            }
        }
        else
        {
            CreateCoridor();
        }
        
    }

	private void Build(int direction)
    {
        /*

                int ix = 0;
                for (int iy = 0; iy < coridorSizeY; iy++)
                {   
                    this.data.Add(cordX + ix);
                    this.data.Add(cordY + iy);
                    this.data.Add(4); // coridor tile

                    if (iy == coridorSizeY - 1 && ix < coridorSizeX - 1)
                    {
                        iy = -1;
                        ix++;
                    }
                }

        */
    }

    private int CheckCordPosition(int cordX, int cordY, List<int> edgeList, int randomCordX)
    {
        int number = 0;
        Debug.Log("Startpos X " + cordX);
        Debug.Log("Startpos Y " + cordY);

        this.data.Add(cordX );
        this.data.Add(cordY);
        this.data.Add(99);

        // determine if edge is horizontal or vertical
        
        if(edgeList[randomCordX] + 1 == edgeList[randomCordX + 2])
        {
            Debug.Log(edgeList[randomCordX + 2]);
            Debug.Log(edgeList[randomCordX + 3]);
            Debug.Log("Horizontal");

        }

        return number;
    }

    private bool IsEvenNumber(int number)
    {
        if(number % 2 == 0)
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
