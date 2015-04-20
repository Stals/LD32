using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum HeatType{
    Any,
    Low, 
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
    public float patience = 7f; // strating minimum patience
    public int reward = 10; //starting min

    // settings
    float patiencePerResource = 0.8f;
    int rewardPerResource = 2;

// todo heat type
    public Client(string _avatar, string _item, HeatType type = HeatType.Any)
    {
        requirenments = new List<Requirenment>();

        avatar = _avatar;
        item = _item;
        heatType = type;
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

    Client client;
    ClientSpace currentSpace;

    float patienceLeft;

    bool isActivated = true;
    bool patienceInProgress = false;

    // Settings
    float patienceTimerDelay = 2f;

    [SerializeField]
    GameObject selectHeat;

	// Use this for initialization
	void Start () {
        /*Client client1 = new Client("knight", "sword");
        client1.addRequirenment(new Requirenment(ResourceType.Wood, 2));
        client1.addRequirenment(new Requirenment(ResourceType.Metal, 3));

        create(client1);*/
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

        Sprite t2 = Resources.Load <Sprite> ("items/" + client.item);
        itemIcon.sprite2D = t2;

        Sprite t3 = Resources.Load <Sprite> ("heat/" + getHeatName(client.heatType));
        heatIcon.sprite2D = t3;


        Invoke("startPatienceReduction", patienceTimerDelay);

        // TODO heat

        moneyRewardLabel.text = client.reward.ToString();
    }

    string getHeatName(HeatType type){
        switch (type)
        {
            case HeatType.High:
                return "high";
            case HeatType.VeryHigh:
                return "veryhight";
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

        giveButton.isEnabled = isEnough();


        updatePatience();

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

//        Debug.Log(Game.Instance.forgeController.getCurrentHeat());
        //if ((client.heatType != HeatType.Any) &&
           if ((Game.Instance.forgeController.getCurrentHeat() != client.heatType))
        {
            selectHeat.SetActive(false);
            return false;
        } else
        {
            selectHeat.SetActive(true);
        }

        foreach (Requirenment req in client.requirenments)
        {
            int amount = Game.Instance.playerResourcesManager.getAmountByType(req.type);
            if(amount < req.amount){
                return false;
            }
        }
        return true;
    }

    public void onGiveButtonClick()
    {
        Game.Instance.playerStuffManager.money += client.reward;

        foreach (Requirenment req in client.requirenments)
        {
            Game.Instance.playerResourcesManager.reduceAmountByType(req.type, req.amount);
        }

        removeSelf();
    }
    void removeSelf()
    {
        isActivated = false;
        patienceInProgress = false;
         

        // TODO animation + destory after time
        float animationTime = 1f;
        
        /*Vector3 finish = gameObject.transform.position;
        finish.y -= 100;

        Vector3[] path = new Vector3[2] {gameObject.transform.position, finish};

        
        gameObject.MoveTo(path, animationTime, 0, EaseType.easeInSine);*/
        
        gameObject.MoveBy(new Vector3(0f, 0.75f, 0f), animationTime, 0, EaseType.easeInOutSine );
        
        Destroy(gameObject, animationTime);
        
        //NGUITools.Destroy(this.gameObject, );
    }

    void OnDestroy() {
        // set space to free !!!
        currentSpace.empty = true;
    }
}
