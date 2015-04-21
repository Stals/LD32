using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Day {
    public Day()
    {
        clients = new List<Client>();
    }

    public void Add(Client client) {
        clients.Add(client);
    }

    public List<Client> clients;
    public int clientsPerDay;

    public bool isClientsRemaining()
    {
        return clientsPerDay != 0;
    }
}


// когда дни кончились - переигрываем последний


//TODO list of lists, from which we generate random stuff set number of times
public class ClientSpawner : MonoBehaviour {

    [SerializeField]
    GameObject clientPanelPrefab;

    List<Day> days;

    [SerializeField]
    UILabel dayLabel;

    int currentDay = 0;

	// Use this for initialization
    void Start()
    {
        days = new List<Day>();

        // ========== DAY START =============
        {
            Day day = new Day();
            days.Add(day);

            day.clientsPerDay = 5;
            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(1, 3)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(1, 3)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(1, 4)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Metal, Random.Range(1, 6)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(1, 5)));
                day.Add(client);
            }


        }
        // =======================

        // ========== DAY START =============
        {
            Day day = new Day();
            days.Add(day);

            day.clientsPerDay = 10;
            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(2, 3)));
                client.addRequirenment(new Requirenment(ResourceType.Metal, Random.Range(2, 3)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(2, 3)));
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(2, 3)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(2, 3)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(2, 3)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(2, 3)));
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(2, 3)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(2, 6)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(3, 5)));
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(3, 5)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Medium);
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(4, 8)));
                client.addRequirenment(new Requirenment(ResourceType.Metal, Random.Range(4, 8)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(5, 8)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Medium);
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(4, 9)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(2, 6)));
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(6, 9)));
                day.Add(client);
            }
        }
        // =======================


        // ========== DAY START =============
        {
            Day day = new Day();
            days.Add(day);

            day.clientsPerDay = 10;
            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(5, 13)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(6, 12)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.High);
                client.addRequirenment(new Requirenment(ResourceType.Metal, Random.Range(5, 14)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.VeryHigh);
                client.addRequirenment(new Requirenment(ResourceType.Metal, Random.Range(5, 10)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(3, 6)));
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(3, 6)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Medium);
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(4, 8)));
                client.addRequirenment(new Requirenment(ResourceType.Metal, Random.Range(4, 8)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Metal, Random.Range(10, 14)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Medium);
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(10, 13)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(2, 6)));
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(6, 9)));
                day.Add(client);
            }
        }

        // =======================

        // ========== DAY START =============
        // обязательный medium типок
        //{
        //   Day day = new Day();
        //    days.Add(day);
        //
        //  day.clientsPerDay = 1; 
        //  {
        //        Client client = new Client(getHeroName(), "", HeatType.Medium);
        //        client.addRequirenment(new Requirenment(ResourceType.Metal, Random.Range(2, 3)));
        //        day.Add(client);
        //    }
        //    
        //}
        // =======================

        // ========== DAY START =============
        {
            Day day = new Day();
            days.Add(day);

            day.clientsPerDay = 10;
            {
                Client client = new Client(getHeroName(), "", HeatType.Medium);
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(5, 9)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(3, 6)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.VeryHigh);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(5, 8)));
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(2, 5)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.High);
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(2, 3)));
                client.addRequirenment(new Requirenment(ResourceType.Metal, Random.Range(2, 3)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Medium);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(2, 3)));
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(2, 3)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Medium);
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(1, 4)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(1, 4)));
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(1, 4)));
                day.Add(client);
            }
        }
        // =======================
        // ========== DAY START =============
        {
            Day day = new Day();
            days.Add(day);

            day.clientsPerDay = 15;
            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(5, 9)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(3, 6)));
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(3, 8)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.High);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(5, 8)));
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(3, 7)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.High);
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(2, 3)));
                client.addRequirenment(new Requirenment(ResourceType.Metal, Random.Range(2, 3)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Medium);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(2, 3)));
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(2, 3)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Medium);
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(1, 4)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(1, 4)));
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(1, 4)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(5, 7)));
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(8, 11)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.VeryHigh);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(3, 6)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(3, 6)));
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(3, 6)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(5, 8)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(3, 7)));
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(4, 6)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.High);
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(11, 14)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(11, 14)));
                day.Add(client);
            }
        }
        // =======================

        // ========== DAY START =============
        {
            Day day = new Day();
            days.Add(day);

            day.clientsPerDay = 15;
            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(5, 9)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(3, 6)));
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(3, 8)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.High);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(5, 8)));
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(3, 7)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.High);
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(2, 3)));
                client.addRequirenment(new Requirenment(ResourceType.Metal, Random.Range(2, 3)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.High);
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(6, 12)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Medium);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(2, 3)));
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(2, 3)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Medium);
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(2, 4)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(2, 4)));
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(2, 4)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(5, 7)));
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(8, 11)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.VeryHigh);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(5, 7)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(4, 6)));
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(4, 6)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(5, 8)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(3, 7)));
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(4, 6)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.High);
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(11, 14)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(11, 14)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(10, 11)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(10, 11)));
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(10, 11)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(20, 25)));
                day.Add(client);
            }
        }
        // =======================



        // TODO день для расслабления


        // ВАЖНО для последнего дня задать day.clientsPerDay = -1;
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // ========== LAST DAY START =============
        // ========== LAST DAY START =============
        // ========== LAST DAY START =============
        // ========== LAST DAY START =============
        // ========== LAST DAY START =============
        // ========== LAST DAY START =============
        // ========== LAST DAY START =============
        // обязательный medium типок

        // ========== DAY START =============
        {
            Day day = new Day();
            days.Add(day);

            day.clientsPerDay = -1;
            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(5, 9)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(3, 6)));
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(3, 8)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.High);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(5, 8)));
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(3, 7)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.High);
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(2, 3)));
                client.addRequirenment(new Requirenment(ResourceType.Metal, Random.Range(2, 3)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Medium);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(2, 3)));
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(2, 3)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Medium);
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(1, 4)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(1, 4)));
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(1, 4)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(5, 7)));
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(8, 11)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.VeryHigh);
                client.addRequirenment(new Requirenment(ResourceType.Magic, Random.Range(3, 6)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(3, 6)));
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(3, 6)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.Low);
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(5, 8)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(3, 7)));
                client.addRequirenment(new Requirenment(ResourceType.Wood, Random.Range(4, 6)));
                day.Add(client);
            }

            {
                Client client = new Client(getHeroName(), "", HeatType.High);
                client.addRequirenment(new Requirenment(ResourceType.Gem, Random.Range(11, 14)));
                client.addRequirenment(new Requirenment(ResourceType.Gold, Random.Range(11, 14)));
                day.Add(client);
            }

        }
        // =======================


        // =======================

        InvokeRepeating("spawn", 2f, 5f);
    }

    string getHeroName()
    {
        return "hero_" + Random.Range(1, 6).ToString(); 
    }
	
	// Update is called once per frame
	void Update () {
        dayLabel.text = "Day " + (currentDay + 1).ToString();
	}

    void spawn()
    {
        var spaces = GetComponentsInChildren<ClientSpace>();

        foreach (ClientSpace space in spaces)
        {
            if(space.empty){

                if (!getCurrentDay().isClientsRemaining()) {
                    currentDay += 1;
                }
                getCurrentDay().clientsPerDay -= 1;


                GameObject go = NGUITools.AddChild(space.gameObject, clientPanelPrefab);

                ClientController clientController = go.GetComponent<ClientController>();
                clientController.create(getRandomClient(), space);
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
        Day day = getCurrentDay();

        int rnd = Random.Range(0, day.clients.Count);
        return day.clients[rnd];
    }

    Day getCurrentDay()
    {
        return days[currentDay];

        
    }

}
