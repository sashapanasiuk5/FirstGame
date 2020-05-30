using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour {
	
	[SerializeField]private int _ammount;

	public int getAmmount(){
		return _ammount;
	}
	public void addCrystal()
	{
		_ammount++;
	}
}
