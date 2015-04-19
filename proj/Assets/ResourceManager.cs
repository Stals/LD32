using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour {

	[SerializeField]
	UILabel amountLabel;

    [SerializeField]
    Color labelColorNormal;

    [SerializeField]
    Color labelColorMax;

    [SerializeField]
    public ResourceType resourceType;

	
    int amount = 0;
	public int max = 10;

	// Use this for initialization
	void Start () {
	
	}

    public void upgradeMax(int nAmount){
        max = nAmount;
    }

    public int getAmount()
    {
        return amount;
    }
	
    public void remove(int am){
        amount -= am;
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
