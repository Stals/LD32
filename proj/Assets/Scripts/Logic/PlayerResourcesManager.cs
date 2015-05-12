using UnityEngine;
using System.Collections;

public class PlayerResourcesManager : MonoBehaviour {

    [SerializeField]
    int amountPerUpgrade = 10;

    [SerializeField]
    UILabel currentMaxLabel;

    [SerializeField]
    int currentMax = 10;

    [SerializeField]
    UILabel upgradePriceLabel;

    [SerializeField]
    UIButton upgradeButton;

    [SerializeField]
    UIButton winButton;

    [SerializeField]
    GameObject glowButton;

    int amountToWin = 50;

    int upgradePrice = 50;

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
        upgradePriceLabel.text = upgradePrice.ToString();


        bool enoughMoney =  (Game.Instance.playerStuffManager.money >= upgradePrice);
       
        upgradeButton.isEnabled = (Game.Instance.playerStuffManager.money >= upgradePrice);
        glowButton.SetActive(enoughMoney);

        winButton.gameObject.SetActive(isWin());         
	}

    bool isWin()
    {
        var resources = GetComponentsInChildren<ResourceManager>();
        foreach (ResourceManager r in resources)
        {
            if (r.getAmount() < amountToWin) {
                
                return false;
            }
        }
        return true;
    }

    public void upgradeMax()
    {
        Game.Instance.playerStuffManager.money -= upgradePrice;

        //amountPerUpgrade
        currentMax += amountPerUpgrade;
        setNewAmount(currentMax);

        upgradePrice += upgradePrice;

        audio.Play();
        
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
