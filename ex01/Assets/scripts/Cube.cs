using UnityEngine;

public class Cube : MonoBehaviour{

	private Transform tran;

	private Vector3 move;

	// Use this for initialization
	void Start (){
		move.x = move.z = 0.0f;
		move.y = -(Random.Range(5.0f, 15.0f));
	}
	
	// Update is called once per frame
	void Update (){
		transform.Translate(move * Time.deltaTime);
		if (transform.localPosition.y < 0f)
			DestroyObject(gameObject);
	}

	void OnDestroy(){
		if (transform.localPosition.y > 0f)
			Debug.Log("Precision : "+transform.localPosition.y);
	}
}
