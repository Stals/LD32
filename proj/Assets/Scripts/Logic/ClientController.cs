﻿using UnityEngine;
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

    Client client;

	// Use this for initialization
	void Start () {
        Client client1 = new Client("Knight", "Sword");
        client1.addRequirenment(new Requirenment(ResourceType.Wood, 2));
        client1.addRequirenment(new Requirenment(ResourceType.Metal, 3));

        create(client1);
	}
	
    void create(Client _client){
        client = _client;

        foreach (Requirenment req in client.requirenments)
        {
            addRequirenment(req);
        }

        // avatar
        // item
    }

	// Update is called once per frame
	void Update () {
	
	}

    void addRequirenment(Requirenment r){
        GameObject req = NGUITools.AddChild(requirenmentsGrid.gameObject, requirenmentPrefab);
        //requirenmentsGrid. //mb add child
        
        var requirenment = req.GetComponent<RequirenmentController>();
        requirenment.create(r);
        requirenmentsGrid.Reposition();
    }
}
