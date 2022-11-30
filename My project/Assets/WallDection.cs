using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDection : MonoBehaviour
{
	public Teleportation Tele;


	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.CompareTag("wall"))
		{
			Tele.isWall = true;

		}
		if (collision.CompareTag("TP"))
		{
			Tele.isEnd = false;
		}

	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("TP"))
		{
			Tele.isEnd = false;

		}
	}
}


