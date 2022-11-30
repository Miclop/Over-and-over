using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    // 0 for Buttom
    // 1 for Left
    // 2 for Top
    // 3 for Right
    public int OpeningDirection;
	private int rand;
	public bool spawned = false;
	private RoomTemplates RT;
	private GameObject TheMaze;
    void Start()
    {
      RT = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
	  TheMaze = GameObject.FindGameObjectWithTag("123");
		//Destroy(gameObject, 4f);
		Invoke("Spawn", 0.1f);
	}
	void Spawn()
	{
		if (spawned == false)
		{
			if (OpeningDirection == 0)
			{
                if (MazeInfo.NumofRoom <= 10)
                {
					rand = Random.Range(0, 2);
				}
				else if (MazeInfo.NumofRoom <= 20)
                {
					rand = Random.Range(0, RT.BottomRooms.Length);
				}
                else if (MazeInfo.NumofRoom <= 30)
                {
					rand = Random.Range(0, RT.BottomRooms.Length);
				}
                else
                {
					spawned = true;
					return;
				}

                if (MazeInfo.NumofRoom == 5)
                {
					GameObject temp = Instantiate(RT.Crystals[0], transform.position, RT.Crystals[0].transform.rotation);
					temp.transform.parent = TheMaze.transform;
				}
				if (MazeInfo.NumofRoom == 10)
				{
					GameObject temp = Instantiate(RT.Crystals[1], transform.position, RT.Crystals[1].transform.rotation);
					temp.transform.parent = TheMaze.transform;
				}
				if (MazeInfo.NumofRoom == 15)
				{
					GameObject temp = Instantiate(RT.Crystals[2], transform.position, RT.Crystals[2].transform.rotation);
					temp.transform.parent = TheMaze.transform;
				}


				GameObject tempGO =Instantiate(RT.BottomRooms[rand], transform.position, RT.BottomRooms[rand].transform.rotation);
				tempGO.transform.parent = TheMaze.transform;
				MazeInfo.NumofRoom++;
				Debug.Log(MazeInfo.NumofRoom);

			}
			else if (OpeningDirection == 2)
			{
				if (MazeInfo.NumofRoom <= 10)
				{
					rand = Random.Range(0, 2);
				}
				else if (MazeInfo.NumofRoom <= 20)
				{
					rand = Random.Range(0, RT.TopRooms.Length);
				}
				else if (MazeInfo.NumofRoom <= 30)
				{
					rand = Random.Range(0, RT.TopRooms.Length);
				}
				else
				{
					spawned = true;
					return;
				}

				if (MazeInfo.NumofRoom == 5)
				{
					GameObject temp = Instantiate(RT.Crystals[0], transform.position, RT.Crystals[0].transform.rotation);
					temp.transform.parent = TheMaze.transform;
				}
				if (MazeInfo.NumofRoom == 10)
				{
					GameObject temp = Instantiate(RT.Crystals[1], transform.position, RT.Crystals[1].transform.rotation);
					temp.transform.parent = TheMaze.transform;
				}
				if (MazeInfo.NumofRoom == 15)
				{
					GameObject temp = Instantiate(RT.Crystals[2], transform.position, RT.Crystals[2].transform.rotation);
					temp.transform.parent = TheMaze.transform;
				}
				GameObject tempGO = Instantiate(RT.TopRooms[rand], transform.position, RT.TopRooms[rand].transform.rotation);
				tempGO.transform.parent = TheMaze.transform;
				MazeInfo.NumofRoom++;
				Debug.Log(MazeInfo.NumofRoom);
			}
			else if (OpeningDirection == 1)
			{
				if (MazeInfo.NumofRoom <= 10)
				{
					rand = Random.Range(0, 2);
				}
				else if (MazeInfo.NumofRoom <= 20)
				{
					rand = Random.Range(0, RT.LeftRooms.Length);
				}
				else if (MazeInfo.NumofRoom <= 30)
				{
					rand = Random.Range(0, RT.LeftRooms.Length);
				}
				 else
				{
					spawned = true;
					return;
				}
				//rand = Random.Range(0, RT.LeftRooms.Length);
				if (MazeInfo.NumofRoom == 5)
				{
					GameObject temp = Instantiate(RT.Crystals[0], transform.position, RT.Crystals[0].transform.rotation);
					temp.transform.parent = TheMaze.transform;
				}
				if (MazeInfo.NumofRoom == 10)
				{
					GameObject temp = Instantiate(RT.Crystals[1], transform.position, RT.Crystals[1].transform.rotation);
					temp.transform.parent = TheMaze.transform;
				}
				if (MazeInfo.NumofRoom == 15)
				{
					GameObject temp = Instantiate(RT.Crystals[2], transform.position, RT.Crystals[2].transform.rotation);
					temp.transform.parent = TheMaze.transform;
				}
				GameObject tempGO = Instantiate(RT.LeftRooms[rand], transform.position, RT.LeftRooms[rand].transform.rotation);
				tempGO.transform.parent = TheMaze.transform;
				MazeInfo.NumofRoom++;
				Debug.Log(MazeInfo.NumofRoom);
			}
			else if (OpeningDirection == 3)
			{
				if (MazeInfo.NumofRoom <= 10)
				{
					rand = Random.Range(0,2);
				}
				else if (MazeInfo.NumofRoom <= 20)
				{
					rand = Random.Range(0, RT.RightRooms.Length);
				}
				else if (MazeInfo.NumofRoom <= 30)
				{
					rand = Random.Range(0, RT.RightRooms.Length);
				}
				else
				{
					spawned = true;
					return;
				}

				if (MazeInfo.NumofRoom == 5)
				{
					GameObject temp = Instantiate(RT.Crystals[0], transform.position, RT.Crystals[0].transform.rotation);
					temp.transform.parent = TheMaze.transform;
				}
				if (MazeInfo.NumofRoom == 10)
				{
					GameObject temp = Instantiate(RT.Crystals[1], transform.position, RT.Crystals[1].transform.rotation);
					temp.transform.parent = TheMaze.transform;
				}
				if (MazeInfo.NumofRoom == 15)
				{
					GameObject temp = Instantiate(RT.Crystals[2], transform.position, RT.Crystals[2].transform.rotation);
					temp.transform.parent = TheMaze.transform;
				}
				rand = Random.Range(0, RT.RightRooms.Length);
				GameObject tempGO = Instantiate(RT.RightRooms[rand], transform.position, RT.RightRooms[rand].transform.rotation);
				tempGO.transform.parent = TheMaze.transform;
				MazeInfo.NumofRoom++;
				//Debug.Log(MazeInfo.NumofRoom);
			}
			spawned = true;
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("SpawnPoint"))
		{
		
				//Debug.Log("hit");
				//Instantiate(RT.closedRoom, transform.position, Quaternion.identity);
				Destroy(gameObject);
			

		}
		spawned = true;
	}

}
