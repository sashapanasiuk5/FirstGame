using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletUI : MonoBehaviour {
	public Text CrystalText;
	private Wallet _wallet;
	private int _ammount;
	 
	private void Start()
	{
		
		_wallet = GetComponent<Wallet> ();
	}
	// Use this for initialization
	public void UpdategText(){
		_ammount = _wallet.getAmmount();
		CrystalText.text = ""+_ammount;
	}
}
