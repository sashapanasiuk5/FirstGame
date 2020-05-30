using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Crystal : MonoBehaviour {
	public GameObject Pickupper;
	public UnityEvent CrystalPickuped;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject == Pickupper) {
			Destroy (this.gameObject);
			CrystalPickuped.Invoke ();

		}
	}
}
