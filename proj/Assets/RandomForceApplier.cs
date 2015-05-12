using UnityEngine;
using System.Collections;

public class RandomForceApplier : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().AddForce(new Vector2 (Random.Range(-40f, 40f), 50f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
