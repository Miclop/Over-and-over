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

    private void Start()
    {
      RT = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
	 // Destroy(gameObject, 4f);
	  Invoke("Spawn", 0.1f);
	}
	void Spawn()
	{
		if (spawned == false)
		{
			if (OpeningDirection == 0)
			{
				// Need to spawn a room with a BOTTOM door.
				rand = Random.Range(0, RT.BottomRooms.Length);
				Instantiate(RT.BottomRooms[rand], transform.position, RT.BottomRooms[rand].transform.rotation);
			}
			else if (OpeningDirection == 2)
			{
				// Need to spawn a room with a TOP door.
				rand = Random.Range(0, RT.TopRooms.Length);
				Instantiate(RT.TopRooms[rand], transform.position, RT.TopRooms[rand].transform.rotation);
			}
			else if (OpeningDirection == 1)
			{
				// Need to spawn a room with a LEFT door.
				rand = Random.Range(0, RT.LeftRooms.Length);
				Instantiate(RT.LeftRooms[rand], transform.position, RT.LeftRooms[rand].transform.rotation);
			}
			else if (OpeningDirection == 3)
			{
				// Need to spawn a room with a RIGHT door.
				rand = Random.Range(0, RT.RightRooms.Length);
				Instantiate(RT.RightRooms[rand], transform.position, RT.RightRooms[rand].transform.rotation);
			}
			spawned = true;
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("SpawnPoint"))
		{
			Debug.Log("hit");
				//Instantiate(RT.closedRoom, transform.position, Quaternion.identity);
				Destroy(gameObject);
			

		}
	}

}
