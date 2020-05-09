using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardController : MonoBehaviour {
	private Player Player;
	// Use this for initialization
	void Start () {
		Player = GetComponent<Player> ();
		if (Player == null) {
			Debug.LogError ("Player not set to Controller");
		}
	}

	// Update is called once per frame
	void Update () {
		if (Player != null) {
			if (Input.GetKeyDown (KeyCode.W)) {

				Player.Jump();

			}else if (Input.GetKey (KeyCode.A)) {
				
				Player.MoveLeft ();

			} else if (Input.GetKey (KeyCode.D)) {

				Player.MoveRight ();
			}

			

			

			



		}
		
	}
}
