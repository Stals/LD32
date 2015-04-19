using UnityEngine;
using System.Collections;

public class ForgeController : MonoBehaviour {

    public float currentHeat = 0f;

    public float heatPerSecond = 0.1f;
    public float heatPerClick = 0.05f;

    [SerializeField]
    GameObject arrow;

    [SerializeField]
    UISprite forgeSprite;

    float forgeHeight;

	// Use this for initialization
	void Start () {
        forgeHeight = forgeSprite.height;
	}
	
	// Update is called once per frame
	void Update () {
        currentHeat -= (heatPerSecond * Time.deltaTime);
        if (currentHeat <= 0f)
        {
            currentHeat = 0f;
        }

        Vector3 newArrowPosition = arrow.transform.localPosition;
        newArrowPosition.y = getArrowPosition();
        arrow.transform.localPosition = newArrowPosition;
	}

    public void onHeatClick(){
        currentHeat += heatPerClick;
    }

    public void onWaterClick(){
        currentHeat = 0;
    }

    float getArrowPosition(){
        return currentHeat * forgeHeight;
    }
}
