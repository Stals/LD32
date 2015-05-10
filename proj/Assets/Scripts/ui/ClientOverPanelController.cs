using UnityEngine;
using System.Collections;

public class ClientOverPanelController : MonoBehaviour {
    [SerializeField]
    GameObject BackgroundObject;

    [SerializeField]
    GameObject SuccessObject;

    [SerializeField]
    GameObject FailObject;

    [SerializeField]
    UITweener tweener;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void show(bool success) {
        tweener.gameObject.SetActive(true);
        tweener.PlayForward();

        BackgroundObject.SetActive(true);

        if (success)
        {
            SuccessObject.SetActive(true);
        }
        else {
            FailObject.SetActive(true);
        }
    }
}
