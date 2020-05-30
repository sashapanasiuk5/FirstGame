using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour {
	private Animator _animator;
	private Player.MoveState _playerstate;
	private Player _player;
	private float _attackCouldown = 0.15f;




	public void Attack (){
		_attackCouldown = 0.15f;
		_playerstate = Player.MoveState.Attack;
		_animator.Play ("Hit2");
	}
	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();
		_player = GetComponent<Player> ();
		_playerstate = _player.movestate;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (_playerstate == Player.MoveState.Attack) {
			_attackCouldown -= Time.deltaTime;
			if (_attackCouldown <= 0) {
				_playerstate = Player.MoveState.Idle;
				_animator.Play ("Idle");
			}
		}
	}
}
