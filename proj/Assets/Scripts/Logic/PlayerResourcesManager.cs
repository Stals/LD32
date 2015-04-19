using UnityEngine;
using System.Collections;

public class PlayerResourcesManager : MonoBehaviour {

    [SerializeField]
    int amountPerUpgrade = 10;

    [SerializeField]
    UILabel currentMaxLabel;

    [SerializeField]
    int currentMax = 10;

    void Awake()
    {
        Game.Instance.playerResourcesManager = this;
    }

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

    public int getAmountByType(ResourceType type){
        var resources = GetComponentsInChildren<ResourceManager>();
        
        foreach (ResourceManager r in resources)
        {
            if(r.resourceType == type){
                return r.getAmount();

            }
        }
        return -1;

    }

    public void reduceAmountByType(ResourceType type, int amount){
        var resources = GetComponentsInChildren<ResourceManager>();
        
        foreach (ResourceManager r in resources)
        {
            if(r.resourceType == type){
                r.remove(amount);
                return;
            }
        }
    }
}
