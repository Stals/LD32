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

        if (Game.Instance.getGameManager() != null)
        {
            Game.Instance.getGameManager().playHit();
        }
    } }


    [SerializeField]
    UILabel moneyLabel;

    [SerializeField]
    UILabel healthLabel;

    [SerializeField]
    public GameObject moneyIcon;

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
