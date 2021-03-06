﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum HeatType{
    Any,
    Low = 0, 
    Medium,
    High,
    VeryHigh,
    TooMuch
}

/*

есть минимальное время patience
для начала игры
 */
public class Client{

    public string avatar;
    public string item;
    public HeatType heatType;
    public List<Requirenment> requirenments;
    public float patience = 11f; // strating minimum patience
    public int reward = 5; //starting min

    // settings
    float patiencePerResource = 1.7f;
    int rewardPerResource = 2;
    int rewardPerHeatLevel = 3;

// todo heat type
    public Client(string _avatar, string _item, HeatType type = HeatType.Any)
    {
        requirenments = new List<Requirenment>();

        avatar = _avatar;
        item = _item;
        heatType = type;

        reward += (int)heatType * rewardPerHeatLevel;
    }

    public void addRequirenment(Requirenment _req){
        requirenments.Add(_req);

        patience += _req.amount * patiencePerResource;
        reward += _req.amount * rewardPerResource;
    }
}

public class ClientController : MonoBehaviour {

    public UI2DSprite avatar;
    public UI2DSprite itemIcon;
    public UI2DSprite heatIcon;

    public UIGrid requirenmentsGrid;
    public GameObject requirenmentPrefab;

    public UIProgressBar patienceBar;

    public UIButton giveButton;

    public UILabel moneyRewardLabel;
    public UILabel statusLabel;

    public UIProgressBar forgingBar;

    Client client;
    ClientSpace currentSpace;

    float patienceLeft;

    bool isActivated = true;
    bool patienceInProgress = false;

    // Settings
    float patienceTimerDelay = 2f;

    [SerializeField]
    GameObject selectHeat;

    [SerializeField]
    AudioSource finishSuccess;

    [SerializeField]
    AudioSource finishFail;

    [SerializeField]
    ClientOverPanelController clientOverPanelController;

    [SerializeField]
    GameObject floatingCoinPrefab;


	// Use this for initialization
	void Start () {
        /*Client client1 = new Client("knight", "sword");
        client1.addRequirenment(new Requirenment(ResourceType.Wood, 2));
        client1.addRequirenment(new Requirenment(ResourceType.Metal, 3));

        create(client1);*/

        giveButton.isEnabled = false;
	}
	
    public void create(Client _client, ClientSpace space){
        client = _client;
        currentSpace = space;

        patienceLeft = client.patience;

        foreach (Requirenment req in client.requirenments)
        {
            addRequirenment(req);
        }
       

        Sprite t1 = Resources.Load <Sprite> ("clients/" + client.avatar);
        avatar.sprite2D = t1;



        if (client.item.Length == 0)
        {
            Sprite[] textures = Resources.LoadAll<Sprite>("items");
            Sprite texture = textures[Random.Range(0, textures.Length)];
            itemIcon.sprite2D = texture;
            //go.GetComponent<Renderer>().material.mainTexture = texture;
        }
        else {
            Sprite t2 = Resources.Load<Sprite>("items/" + client.item);
            itemIcon.sprite2D = t2;
        }
        /*
         Object[] textures = Resources.LoadAll("Textures");
        Texture2D texture = textures[Random.Range(0, textures.Length)];
        go.GetComponent<Renderer>().material.mainTexture = texture;
         */


        Sprite t3 = Resources.Load <Sprite> ("heat/" + getHeatName(client.heatType));
        heatIcon.sprite2D = t3;


        Invoke("startPatienceReduction", patienceTimerDelay);

        // TODO heat

        moneyRewardLabel.text = client.reward.ToString();


        gameObject.MoveBy(-new Vector3(0f, 0.75f, 0f), 1f, 0, EaseType.easeInOutSine);
    }

    string getHeatName(HeatType type){
        switch (type)
        {
            case HeatType.High:
                return "high";
            case HeatType.VeryHigh:
                return "veryhigh";
            case HeatType.Medium:
                return "medium";
            case HeatType.Low:
                return "low";
        }
        return "non";
    
    }

    void startPatienceReduction()
    {
        patienceInProgress = true;
    }

	// Update is called once per frame
	void Update () {
	    // todo - dont check every time

        if (!isActivated)
        {
            return;
        }


        if (isEnough()) {
            if (forgingBar.value < 1) {
                statusLabel.text = "Forging...";
                updateForging();
            }
            else  {
                updatePatience(0.5f); // if we just need to give - lower the rate at witch patience is going down
            }
        }
        else {
            // only if ! forging
            updatePatience();
        }


        if (enoughResources() && forgingBar.value >= 1)
        {
            statusLabel.text = "Give";
            giveButton.isEnabled = true;
        }
        else {
            giveButton.isEnabled = false;
        }

	}

    void updateForging()
    {
        forgingBar.value += 0.2f * Time.deltaTime;
    }

    void updatePatience(float factor = 1f)
    {
        if (patienceInProgress)
        {
            // update patience
            patienceLeft -= (Time.deltaTime * factor);
            patienceBar.value = (patienceLeft / client.patience);
            
            
            if (patienceLeft <= 0)
            {
                Game.Instance.getGameManager().Shake(0.05f, 0.005f);
                finishFail.Play();
                Game.Instance.playerStuffManager.health -= 1;
                if (Game.Instance.playerStuffManager.health < 0) {
                    Game.Instance.playerStuffManager.health = 0;
                }
                // once
                removeSelf(false);
            }
        }
    }

    void addRequirenment(Requirenment r){
        GameObject req = NGUITools.AddChild(requirenmentsGrid.gameObject, requirenmentPrefab);
        //requirenmentsGrid. //mb add child
        
        var requirenment = req.GetComponent<RequirenmentController>();
        requirenment.create(r);
        requirenmentsGrid.Reposition();
    }

    bool enoughResources()
    {
        foreach (Requirenment req in client.requirenments)
        {
            int amount = Game.Instance.playerResourcesManager.getAmountByType(req.type);
            if (amount < req.amount)
            {
                
                return false;
            }
        }

        return true;
    }

    // TODO probably will need to redo
    bool isEnough(){

        bool enough = true;

//        Debug.Log(Game.Instance.forgeController.getCurrentHeat());
        //if ((client.heatType != HeatType.Any) &&
           if ((Game.Instance.forgeController.getCurrentHeat() != client.heatType))
        {
            statusLabel.text = "Needs Heat";
            selectHeat.SetActive(false);
            enough =  false;

            if ((Game.Instance.forgeController.getCurrentHeat() < client.heatType)) {
                Game.Instance.forgeController.setClickHintVisible(true);
            }
        } else
        {
            selectHeat.SetActive(true);
            Game.Instance.forgeController.setClickHintVisible(false);
        }

        if (!enoughResources()) {
            statusLabel.text = "Needs Mat.";
            return false;
        }

        return enough;
    }

    void giveReward()
    {
        Game.Instance.playerStuffManager.money += client.reward;


        int coinsToSpawn = (client.reward / 5);
        GameObject uiTarget = Game.Instance.playerStuffManager.moneyIcon;
        for (int i = 0; i < coinsToSpawn; ++i)
        {
            // vizualize
            float time = Random.Range(0.6f, 0.8f);
            float delay = (0.02f * i);

            GameObject guiObject = BezierHelper.moveTo(avatar.gameObject, uiTarget, floatingCoinPrefab, time, delay);
            Destroy(guiObject, time + delay);

            // play sound only once
            if (i == 0) {
                uiTarget.GetComponent<PlayerCoinsController>().Invoke("OnFinishAnimation", time + delay);
            }
        }

        
    }

    public void onGiveButtonClick()
    {
        giveReward();
        
        foreach (Requirenment req in client.requirenments)
        {
            Game.Instance.playerResourcesManager.reduceAmountByType(req.type, req.amount);
        }

        finishSuccess.Play();

        removeSelf(true);
    }
    void removeSelf(bool success)
    {
        isActivated = false;
        patienceInProgress = false;
        giveButton.isEnabled = false;
        statusLabel.alpha = 0f;

        clientOverPanelController.show(success);


        // TODO animation + destory after time
        float animationTime = 1f;
        gameObject.MoveBy(new Vector3(0f, 1f, 0f), animationTime, 0, EaseType.easeInOutSine);
        
        Destroy(gameObject, animationTime);
    }

    void OnDestroy() {
        // set space to free !!!
        currentSpace.empty = true;
    }
}
