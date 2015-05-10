using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    

    int currentLinesID = 0;
    int currentBetsID = 0;

    

    Player player;


    [SerializeField]
    CameraShake cameraShake;


	// Use this for initialization
	void Start () {
        Game.Instance.setGameManager(this);
        player = Game.Instance.getPlayer();
	}

	// Update is called once per frame
	void Update () {
	}


    public void onLineRemove(int blockCount)
    {
    }
    
    public bool canRemoveLine()
    {
		return true;
    }

    public void Shake(float intent, float decay) {
        cameraShake.Shake(intent, decay);
    }
}
