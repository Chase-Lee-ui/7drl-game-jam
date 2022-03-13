using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	public GameObject closedRoom;

	public List<GameObject> rooms;

	public float waitTime;
	public int LimitRooms;
	private float Modifier;

	void Start()
	{
		this.Modifier = GameObject.Find("PlayerPrefab").GetComponent<Player_Manager>().Modifier;
        LimitRooms = Mathf.CeilToInt(LimitRooms * Modifier);
	}

	void Update(){
		if(rooms.Count >= LimitRooms)
		{
			var saveRoomB = bottomRooms[0];
			bottomRooms = new GameObject[1];
			bottomRooms[0] = saveRoomB;

			var saveRoomT = topRooms[0];
			topRooms = new GameObject[1];
			topRooms[0] = saveRoomT;

			var saveRoomR = rightRooms[0];
			rightRooms = new GameObject[1];
			rightRooms[0] = saveRoomR;

			var saveRoomL = leftRooms[0];
			leftRooms = new GameObject[1];
			leftRooms[0] = saveRoomL;
		}
	}
}
