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
	private bool spawnedBoss;
	public GameObject boss;
	public int LimitRooms;

	void Start()
	{
		
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

		if(waitTime <= 0 && spawnedBoss == false){
			for (int i = 0; i < rooms.Count; i++) {
				if(i == rooms.Count-1){
					Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
					spawnedBoss = true;
				}
			}
		} else {
			waitTime -= Time.deltaTime;
		}
	}
}
