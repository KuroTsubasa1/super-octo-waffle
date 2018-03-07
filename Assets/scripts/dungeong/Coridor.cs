using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coridor{

    private int coridorSizeX;
    private int coridorSizeY;
    private int cordX;
    private int cordY;
    private int coridorSizeXMax;
    private int coridorSizeXMin;
    private int coridorSizeYMax;
    private int coridorSizeYMin;
    private Room room;


    private List<int> data = new List<int>();

    public Coridor(Room room,int coridorSizeX, int coridorSizeY, int coridorSizeXMax, int coridorSizeXMin, int coridorSizeYMax, int coridorSizeYMin)
    {
        this.coridorSizeX = util.RandomInt(coridorSizeXMin, coridorSizeXMax);
        this.coridorSizeY = util.RandomInt(coridorSizeYMin, coridorSizeYMax);
        this.room = room;
    }

    public void CreateCoridor()
    {
        List<int> edgeList = room.GetEdgeList();

        int startcord = edgeList[util.RandomInt(0, edgeList.Count - 1)]; 
        if(IsEvenNumber(startcord))
		{
            // check horizontal up
            if(edgeList[startcord + 2 ] == startcord + 1 )
            {

            }

            // check horizontal down
            if (edgeList[startcord + 2] == startcord + 1)
            {

            }

            // check vertical
            if(edgeList[startcord + 2] == room.GetRoomSIzeX() -1 && startcord == edgeList[edgeList.Count-1]) 
            {
                
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


}
