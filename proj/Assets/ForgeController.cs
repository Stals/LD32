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


    [SerializeField]
    GameObject LowSelect;
    [SerializeField]
    GameObject MediumSelect;
    [SerializeField]
    GameObject HighSelect;
    [SerializeField]
    GameObject VeryHighSelect;

    [SerializeField]
    AudioSource waterSound;

    [SerializeField]
    AudioSource clickSound;
    
    void Awake(){
        Game.Instance.forgeController = this;

    }

	// Use this for initialization
	void Start () {
        forgeHeight = forgeSprite.height - 45;
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

        updateSelect();
	}

    public void updateSelect()
    {
        LowSelect.SetActive(false);
        MediumSelect.SetActive(false);
        HighSelect.SetActive(false);
        VeryHighSelect.SetActive(false);
        
        HeatType type =  getCurrentHeat();

        switch (type)
        {
            case HeatType.Low: LowSelect.SetActive(true); break;
            case HeatType.High: HighSelect.SetActive(true); break;
            case HeatType.Medium: MediumSelect.SetActive(true); break;
            case HeatType.VeryHigh: VeryHighSelect.SetActive(true); break;
             
        }
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
        waterSound.Play();
    }

    float getArrowPosition(){
        return currentHeat * forgeHeight + 30;
    }

    public HeatType getCurrentHeat()
    {
        float arrowPosition = getArrowPosition();

        if (arrowPosition > VeryHighHeatEnd.transform.localPosition.y)
        {
            return HeatType.TooMuch;
        }
        if (arrowPosition > HighHeatEnd.transform.localPosition.y)
        {
            return HeatType.VeryHigh;
        }
        if (arrowPosition > MediumHeatEnd.transform.localPosition.y)
        {
            return HeatType.High;
        }
        if (arrowPosition > LowHeatEnd.transform.localPosition.y)
        {
            return HeatType.Medium;
        }
        return HeatType.Low;
    }
}
