using UnityEngine;
using System.Collections;

public class PlayerStuffManager : MonoBehaviour {

    public int money{ get; set;}
    public int health{ get; set;}

    [SerializeField]
    UILabel moneyLabel;

    [SerializeField]
    UILabel healthLabel;

    void Awake()
    {
        Game.Instance.playerStuffManager = this;
        health = 10;
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
