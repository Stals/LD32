using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour {

	[SerializeField]
	UILabel amountLabel;

	int amount = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		amountLabel.text = amount.ToString ();
	}

	void addBlock()
	{
		amount += 1;
	}
}
