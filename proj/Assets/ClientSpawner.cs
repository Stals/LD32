﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientSpawner : MonoBehaviour {

    [SerializeField]
    GameObject clientPanelPrefab;

    List<Client> clients;

	// Use this for initialization
	void Start () {
        clients = new List<Client>();

        {
            Client client = new Client("knight", "sword");
            client.addRequirenment(new Requirenment(ResourceType.Wood, 2));
            client.addRequirenment(new Requirenment(ResourceType.Metal, 3));
            clients.Add(client);
        }
        {
            Client client = new Client("mage", "sword");
            client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(1, 4)));
            client.addRequirenment(new Requirenment(ResourceType.Magic, 3));
            clients.Add(client);
        }
           
        spawn();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void spawn()
    {
        var spaces = GetComponentsInChildren<ClientSpace>();

        foreach (ClientSpace space in spaces)
        {
            if(space.empty){
                GameObject go = NGUITools.AddChild(space.gameObject, clientPanelPrefab);

                ClientController clientController = go.GetComponent<ClientController>();
                clientController.create(getRandomClient());
                // TODO set position
                go.transform.position = space.transform.position;

                // TODO set free false
                space.empty = false;
                return;
            }
        }
    }

    Client getRandomClient()
    {
        int rnd = Random.Range(0, clients.Count);
        return clients[rnd];
    }
}