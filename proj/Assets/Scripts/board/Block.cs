﻿using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	[SerializeField]
	GameObject uiTarget;

	[SerializeField]
	GameObject fakeBlock;

	bool isTriggered = false;

	public int x;
	public int y;

    bool selected = false;

	// Use this for initialization
	void Start () {
        //InvokeRepeating("updateRotation", 0.5f, 0.5f);
	}

    public void updateRotation()
    {
        if (selected)
        {
            gameObject.RotateBy(new Vector3(0, 0, 1f), 0.48f, 0, EaseType.easeInOutSine, true);
        } else
        {
            //gameObject.RotateBy(new Vector3(0, 0, 0.025f), 0.5f, 0, EaseType.easeInOutSine, LoopType.pingPong, true);
        }
    }

	public void setIDs(int _x, int _y)
	{
		x = _x;
		y = _y;
	}

	// Update is called once per frame
	void Update () {
        /*Vector2 newPos;

        newPos.x = Mathf.Lerp(transform.localPosition.x, targetPosition.x, Time.deltaTime * 8f);
        newPos.y = Mathf.Lerp(transform.localPosition.y, targetPosition.y, Time.deltaTime * 8f);

        transform.localPosition = newPos;*/


		if (isMouseOver ()) {
			if(!isTriggered){
				Game.Instance.getBoardManager ().onBlockTrigger (this);
				isTriggered = true;
			}
		} else {
			isTriggered = false;		
		}
	}

	bool isMouseOver()
	{
		if (Input.GetMouseButton(0))// GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray,Mathf.Infinity);
			
			foreach (RaycastHit2D hit in hits)
			{
				if((hit.collider != null) && (hit.collider.transform == this.gameObject.transform))
				{
					return true;
				}
			}
		}
		return false;
	}

	public void updatePosition()
	{
        //gameObject.MoveTo(Game.Instance.getBoardManager ().getPosition (x, y), 0.5f, 0f, EaseType.easeInOutSine);

        /*iTween.MoveTo(gameObject, iTween.Hash("position", Game.Instance.getBoardManager ().getPosition (x, y),
                                              "time", 0.3f, "delay", 0f, "islocal", true, 
                                              "easetype", "easeInOutSine"));*/

		Vector3 currentPosition = transform.position;
		Vector3 targetPosition = Game.Instance.getBoardManager ().getPosition (x, y);

		float distance = Vector3.Distance(currentPosition, targetPosition);

        iTween.MoveTo(gameObject, iTween.Hash("position", Game.Instance.getBoardManager ().getPosition (x, y),
		                                      "time", distance * 0.5f, "delay", 0f, "islocal", true, 
			                                      "easetype", "easeInQuad"));
        
    }

    public string getImageName()
    {
        return GetComponentInChildren<SpriteRenderer>().sprite.name;
    }

    public void setSelected(bool _selected){
        updatePosition(); // so that shakes dont add up
        if (!_selected && selected)
        {
            particleSystem.Stop();

            iTween.Stop(gameObject);
            gameObject.RotateTo(new Vector3(0, 0, 0), 0.2f, 0);
            //transform.localEulerAngles = new Vector3(0, 0, 4.5f);
			gameObject.ScaleTo(new Vector3(1f, 1f), 0.2f, 0);

        }

        if (_selected)
        {
            particleSystem.Play();

            audio.pitch = Random.Range(0.92f, 0.97f) + (Game.Instance.getBoardManager().getSelectedCount() * 0.045f); 
            audio.Play();
			gameObject.ScaleTo(new Vector3(0.75f, 0.75f), 0.2f, 0);
        }
        
        selected = _selected;
    }

    public bool isSelected()
    {
        return selected;
    }

	public void destroyBlock()
	{

        float time = Random.Range(0.6f, 0.8f);
        float delay = Random.Range(0.05f, 0.15f);

        GameObject guiObject = BezierHelper.moveTo(gameObject, uiTarget, fakeBlock, time, delay);



        guiObject.GetComponent<FakeBlockController>().Invoke("OnFinishAnimation", time + delay);

        guiObject.GetComponent<UISprite>().spriteName = GetComponentInChildren<SpriteRenderer>().sprite.name; ;
        guiObject.GetComponent<UISprite>().MarkAsChanged();

        uiTarget.GetComponent<ResourceManager>().Invoke("addBlock", time + delay);

		Destroy (this.gameObject);
        //TODO finish sound
        // TODO allow for the particles To fade

	}

    public void shake()
    {
        gameObject.ShakePosition(new Vector3(0.025f, 0f), 0.4f, 0.1f);
    }
}
