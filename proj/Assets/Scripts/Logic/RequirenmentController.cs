using UnityEngine;
using System.Collections;

public enum ResourceType{
    Metal,
    Gold,
    Magic,
    Wood,
    Gem
}

public class Requirenment{
    public ResourceType type;
    public int amount;

    public Requirenment(ResourceType _type, int _amount){
        type = _type;
        amount = _amount;
    }

};

public class RequirenmentController : MonoBehaviour {

    [SerializeField]
    UILabel amountLabel;

    [SerializeField]
    Color notEnoughColor;

    [SerializeField]
    Color enoughColor;

    Requirenment requirenment;

	// Use this for initialization
	void Start () {
	
	}

    public void create(Requirenment req){
        requirenment = req;

        amountLabel.text = requirenment.amount.ToString();
        GetComponent<UISprite>().spriteName = typeToSprite(req.type);
        GetComponent<UISprite>().MarkAsChanged();
    }
	
	// Update is called once per frame
	void Update () {
        int current = Game.Instance.playerResourcesManager.getAmountByType(requirenment.type);
        current = Mathf.Min(current, requirenment.amount);

        amountLabel.text = current.ToString() + " / " + requirenment.amount.ToString();

        if (current >= requirenment.amount)
        {
            amountLabel.color = enoughColor;
        } else
        {
            amountLabel.color = notEnoughColor;
        }
	}

    static string typeToSprite(ResourceType type){
        switch (type)
        {
            case ResourceType.Metal: return "metal";
            case ResourceType.Gold: return "gold";
            case ResourceType.Magic: return "magic";
            case ResourceType.Wood: return "wood";
            case ResourceType.Gem: return "gem";
            default: return "";
        }

    }
}
