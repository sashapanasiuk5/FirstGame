using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardController : MonoBehaviour {
	private Player Player;
	private CombatSystem _combatsystem;
	// Use this for initialization
	void Start () {
		Player = GetComponent<Player> ();
		_combatsystem = GetComponent<CombatSystem>();
		if (Player == null) {
			Debug.LogError ("Player not set to Controller");
		}else if (_combatsystem == null) {
			Debug.LogError ("CombatSystem not set to Controller");
		}
	}

	// Update is called once per frame
	void Update () {
		if (Player != null) {
			if (Input.GetKeyDown (KeyCode.W)) {

				Player.Jump ();

			} else if (Input.GetKey (KeyCode.A)) {
				
				Player.MoveLeft ();

			} else if (Input.GetKey (KeyCode.D)) {

				Player.MoveRight ();
			} else if (Input.GetKey (KeyCode.LeftShift)) {

				Player.Sprint ();
			} else if (Input.GetKey (KeyCode.Mouse0)) {
				_combatsystem.Attack ();
			}	

			

			

			



		}
		
	}
}
