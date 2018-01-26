using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardRoomManager : MonoBehaviour {
	public Text winIndicator;
	public Image ideaImage;
	private List<Vector3> spawnLocations;
	private bool ideaSpawned = false;
	private float timeLeft;
	private bool gameIsStarting = true;
	private bool gameOver = false;
	// Use this for initialization
	void Start () {
		Screen.SetResolution(760,384, true);
		timeLeft = Random.Range(3,6);
		winIndicator.text = "";
		Color color = ideaImage.color;
		color.a = 0;
		ideaImage.color = color;
		spawnLocations = new List<Vector3>();
		spawnLocations.Add(new Vector3(230,40));
		spawnLocations.Add(new Vector3(185,70));
		spawnLocations.Add(new Vector3(155,120));
		spawnLocations.Add(new Vector3(105,165));
		spawnLocations.Add(new Vector3(0,200));
		spawnLocations.Add(new Vector3(-230,40));
		spawnLocations.Add(new Vector3(-185,70));
		spawnLocations.Add(new Vector3(-155,120));
		spawnLocations.Add(new Vector3(-105,165));
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameIsStarting) {
			// fancy cool animation
			//winIndicator.text = "FANCY ANIMATION";
			// fancy cool animation over
			gameIsStarting = false;
		}
		else if (!gameOver) {
			winIndicator.text = "";

			timeLeft -= Time.deltaTime;
			print(timeLeft);
			if (Input.anyKeyDown) {
				// they pressed the action
				if (ideaSpawned) {
					// they got it
					winIndicator.text = "YOU WIN";
					gameOver = true;
				}
				else {
					// they were too early
					winIndicator.text = "YOU LOSE";
					gameOver = true;
				}
			}
			if (timeLeft < 0) {
				if (!ideaSpawned) {
					// create random location
					
					Color color = ideaImage.color;
					color.a = 1;
					ideaImage.color = color;
					ideaImage.transform.position = spawnLocations[Random.Range(0, spawnLocations.Count)];
					ideaSpawned = true;
					timeLeft = 5;
				}

				else {
					// the idea is in play, and they missed it
					winIndicator.text = "YOU LOSE";
					gameOver = true;
				}
			}
		}
		else {
			// game is over, fancy cool animation to end game
			//winIndicator.text = "FANCY ANIMATION";
		}

	}
}
