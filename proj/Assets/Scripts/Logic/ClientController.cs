using UnityEngine;
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
    public float patience = 15f; // strating minimum patience
    public int reward = 5; //starting min

    // settings
    float patiencePerResource = 3f;
    int rewardPerResource = 2;
    int rewardPerHeatLevel = 2;

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


        if (isEnough() && forgingBar.value < 1)
        {
            statusLabel.text = "Forging...";
            updateForging();
        }
        else {
            // only if ! forging
            updatePatience();
        }

        if (isEnough() && forgingBar.value >= 1)
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

    void updatePatience()
    {
        if (patienceInProgress)
        {
            // update patience
            patienceLeft -= Time.deltaTime;
            patienceBar.value = (patienceLeft / client.patience);
            
            
            if (patienceLeft <= 0)
            {
                finishFail.Play();
                Game.Instance.playerStuffManager.health -= 1;
                if (Game.Instance.playerStuffManager.health < 0) {
                    Game.Instance.playerStuffManager.health = 0;
                }
                // once
                removeSelf();
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

        foreach (Requirenment req in client.requirenments)
        {
            int amount = Game.Instance.playerResourcesManager.getAmountByType(req.type);
            if(amount < req.amount){
                statusLabel.text = "Needs Mat.";
                return false;
            }
        }

        return enough;
    }

    public void onGiveButtonClick()
    {
        Game.Instance.playerStuffManager.money += client.reward;

        foreach (Requirenment req in client.requirenments)
        {
            Game.Instance.playerResourcesManager.reduceAmountByType(req.type, req.amount);
        }

        finishSuccess.Play();

        removeSelf();
    }
    void removeSelf()
    {
        isActivated = false;
        patienceInProgress = false;


        giveButton.isEnabled = false;

        // TODO animation + destory after time
        float animationTime = 1f;
        
        /*Vector3 finish = gameObject.transform.position;
        finish.y -= 100;

        Vector3[] path = new Vector3[2] {gameObject.transform.position, finish};

        
        gameObject.MoveTo(path, animationTime, 0, EaseType.easeInSine);*/



        gameObject.MoveBy(new Vector3(0f, 1f, 0f), animationTime, 0, EaseType.easeInOutSine);
        
        Destroy(gameObject, animationTime);


        
        //NGUITools.Destroy(this.gameObject, );
    }

    void OnDestroy() {
        // set space to free !!!
        currentSpace.empty = true;
    }
}
