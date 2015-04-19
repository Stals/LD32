using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum HeatType{
    Any,
    Low, 
    Medium,
    Hight,
    VeryHigh
}

public class Client{

    public string avatar;
    public string item;
    public HeatType heatType;
    public List<Requirenment> requirenments;

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

    Client client;

	// Use this for initialization
	void Start () {
        Client client1 = new Client("knight", "sword");
        //client1.addRequirenment(new Requirenment(ResourceType.Wood, 2));
        //client1.addRequirenment(new Requirenment(ResourceType.Metal, 3));

        create(client1);
	}
	
    void create(Client _client){
        client = _client;

        foreach (Requirenment req in client.requirenments)
        {
            addRequirenment(req);
        }
       
        Sprite t1 = Resources.Load <Sprite> ("clients/" + client.avatar);
        avatar.sprite2D = t1;

        Sprite t2 = Resources.Load <Sprite> ("items/" + client.item);
        itemIcon.sprite2D = t2;

        // TODO heat
    }

	// Update is called once per frame
	void Update () {
	    // todo - dont check every time


        giveButton.isEnabled = isEnough();
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
        foreach (Requirenment req in client.requirenments)
        {
            Game.Instance.playerResourcesManager.reduceAmountByType(req.type, req.amount);
        }
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
}
