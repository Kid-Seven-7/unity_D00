using UnityEngine;

public class pipe : MonoBehaviour{

	public Vector3 movePipe;

	public bool passed, play;

	// Use this for initialization
	void Start(){
		passed = false;
		movePipe = new Vector3(-20.0f, 0f, 0f);
	}

	// Update is called once per frame
	void Update(){
		transform.Translate(movePipe * Time.deltaTime);
		if (transform.position.x < -2.5f)
			passed = true;
		if (transform.position.x < -21f)
			DestroyObject(gameObject);
	}
}

