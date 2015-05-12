using UnityEngine;
using System.Collections;

public class PlayerStuffManager : MonoBehaviour {

    public int money{ get; set;}

    int hp;
    public int health
    {
        get {
            return hp;
        }
        set
        {
            hp = value;

            // max durty hack!
            if (hp != 15)
            {
                spawnDropingHeart();
            }


            /*if (Game.Instance.getGameManager() != null)
            {
                Game.Instance.getGameManager().playHit();
            }*/
    } }


    [SerializeField]
    UILabel moneyLabel;

    [SerializeField]
    UILabel healthLabel;

    [SerializeField]
    public GameObject moneyIcon;

    [SerializeField]
    GameObject heartIcon;

    [SerializeField]
    GameObject dropingHeartObject;


    void spawnDropingHeart()
    {
        Camera gameCamera = NGUITools.FindCameraForLayer(gameObject.layer);
        Camera uiCamera = UICamera.mainCamera;


        GameObject guiObject = NGUITools.AddChild(gameObject, dropingHeartObject);

        /* UILabel label = guiObject.GetComponentInChildren<UILabel>();
         label.text = amout.ToString();*/

        /* MOVE TO CORRECT POSITION*/
        // Get screen location of node
        Vector2 screenPos = Camera.main.WorldToScreenPoint(heartIcon.transform.position);

        // Move to node
        guiObject.transform.position = uiCamera.ScreenToWorldPoint(screenPos);
    }

    void Awake()
    {
        Game.Instance.playerStuffManager = this;
        health = 15;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        moneyLabel.text = " " + money.ToString();
        healthLabel.text = " " + health.ToString();
	}
}
