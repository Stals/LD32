using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour {

	[SerializeField]
	UILabel amountLabel;

    [SerializeField]
    Color labelColorNormal;

    [SerializeField]
    Color labelColorMax;

	int amount = 0;
	int max = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		amountLabel.text = amount.ToString ();

        if (amount == max)
        {
            amountLabel.color = labelColorMax;
        } else
        {
            amountLabel.color = labelColorNormal;
        }
	}

	void addBlock()
	{
		if (amount < max) {
			amount += 1;
		}
	}
}
