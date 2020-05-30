using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFolower : MonoBehaviour {
	[SerializeField] public Transform _target;
	[SerializeField] public Vector2 _offset = new Vector2 (3f,2f);
	[SerializeField] public float speed;

	private Transform _followertransform;
	private Vector2 _currentposition;
	private Vector3 _currentTrarget;

	public Player _player;


	// Use this for initialization
	void Start () {
		_followertransform = GetComponent<Transform> ();
		_currentTrarget = _target.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (_player) {
			if (_player.direction == Player.Direction.Right) {
				
				_currentTrarget = new Vector3 (_target.position.x - _offset.x, _target.position.y + _offset.y, _target.position.z);
			}
			else{
				
				_currentTrarget = new Vector3 (_target.position.x + _offset.x, _target.position.y + _offset.y, _target.position.z);
			} 
			_currentposition = Vector2.Lerp (_followertransform.position, _currentTrarget, speed*Time.deltaTime);
			_followertransform.position = new Vector3(_currentposition.x,_currentposition.y,_followertransform.position.z);
		}
	}
}
