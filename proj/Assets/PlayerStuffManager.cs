using UnityEngine;
using System.Collections;

public class PlayerStuffManager : MonoBehaviour {

    int money = 0;
    int health = 5;

    [SerializeField]
    UILabel moneyLabel;

    [SerializeField]
    UILabel healthLabel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        moneyLabel.text = " " + money.ToString();
        healthLabel.text = " " + health.ToString();
	}
}
