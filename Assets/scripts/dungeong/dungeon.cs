using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon {

	int sizeX, sizeY;
	int[,] array2D;

	public Dungeon(int sizeX, int sizeY)
	{
		this.sizeX = sizeX;
		this.sizeY = sizeY;
		this.array2D = new int[this.sizeX,this.sizeY];
		CreateMap();
	}

	private void CreateMap()
	{
		int ix = 0;
		for (int iy = 0; iy < sizeY; iy++) 
		{
			array2D[ix, iy] = 0;

			if (iy == sizeY && ix < sizeX) 
			{
				iy = -1;
				ix++;
			}
		}

	}

	public int [,] GetMap()
	{
		return array2D;
	}

	public int GetSizeX()
	{
		return this.sizeX;
	}

	public int GetSizeY()
	{
		return this.sizeY;
	}

}