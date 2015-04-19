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

    [SerializeField]
    GameObject LowHeatEnd;
    [SerializeField]
    GameObject MediumHeatEnd;
    [SerializeField]
    GameObject HighHeatEnd;
    [SerializeField]
    GameObject VeryHighHeatEnd;

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
        if (currentHeat >= 1)
        {
            currentHeat = 1f;
        }
    }

    public void onWaterClick(){
        currentHeat = 0;
    }

    float getArrowPosition(){
        return currentHeat * forgeHeight + 45;
    }

    public HeatType getCurrentHeat()
    {
        float arrowPosition = getArrowPosition();

        if (arrowPosition > VeryHighHeatEnd.transform.position.x)
        {
            return HeatType.TooMuch;
        }
        if (arrowPosition > HighHeatEnd.transform.position.x)
        {
            return HeatType.VeryHigh;
        }
        if (arrowPosition > MediumHeatEnd.transform.position.x)
        {
            return HeatType.High;
        }
        if (arrowPosition > LowHeatEnd.transform.position.x)
        {
            return HeatType.Medium;
        }
        return HeatType.Low;
    }
}
