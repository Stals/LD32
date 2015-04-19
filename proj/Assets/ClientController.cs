using UnityEngine;
using System.Collections;

public class Client{

}

public class ClientController : MonoBehaviour {

    public UI2DSprite avatar;
    public UI2DSprite itemIcon;
    public UI2DSprite heatIcon;

    public UIGrid requirenmentsGrid;
    public GameObject requirenmentPrefab;

    public UIProgressBar patienceBar;

	// Use this for initialization
	void Start () {
        addRequirenment(new Requirenment(ResourceType.Wood, 2));
        addRequirenment(new Requirenment(ResourceType.Metal, 3));
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
