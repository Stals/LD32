using UnityEngine;
using System.Collections;

public class IntroController : MonoBehaviour {

    [SerializeField]
    TweenAlpha tween;

	// Use this for initialization
	void Start () {
        onShow();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void onShow()
    {
        Time.timeScale = 0f;
    }

    public void close (){
        tween.PlayForward();
        Destroy(gameObject, tween.duration);
        Time.timeScale = 1f;
    }
}
