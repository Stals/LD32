using UnityEngine;
using System.Collections;

public class PlayerResourcesManager : MonoBehaviour {

    [SerializeField]
    int amountPerUpgrade = 10;

    [SerializeField]
    UILabel currentMaxLabel;

    [SerializeField]
    int currentMax = 10;

	// Use this for initialization
	void Start () {
        setNewAmount(currentMax);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void upgradeMax()
    {
        //amountPerUpgrade
        currentMax += amountPerUpgrade;
        setNewAmount(currentMax);
    }

    void setNewAmount(int nAmount)
    {
        var resources = GetComponentsInChildren<ResourceManager>();
        
        foreach (ResourceManager r in resources)
        {
            r.upgradeMax(nAmount);
        }

        currentMaxLabel.text = "MAX: " + currentMax.ToString();
    }
}
