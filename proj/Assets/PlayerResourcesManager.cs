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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void upgradeMax()
    {
        //amountPerUpgrade

        var resources = GetComponentsInChildren<ResourceManager>();

        foreach (ResourceManager r in resources)
        {
            r.upgradeMax(amountPerUpgrade);
        }

        currentMax += amountPerUpgrade;;
        currentMaxLabel.text = "MAX: " + currentMax.ToString();
    }
}
