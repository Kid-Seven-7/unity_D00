using UnityEngine;

public class ball : MonoBehaviour{

	public GameObject golfClub, ballObj;

	private float force, baseForce;

	public bool up, swingup, stopped, won;

	public int score;

	private Vector3 move;

	// Use this for initialization
	void Start () {
		stopped = up = swingup =true;
		baseForce = 0f;
		score = -15;
	}
	
	// Update is called once per frame
	void Update (){
		force = golfClub.GetComponent<club>().force;

		if (force != 0f){
			baseForce = force/4;
			if (!won)
				score += 5;
			Debug.Log("Score : " + score);
		}

		if (baseForce > 0f)
			stopped = false;

		if (baseForce > 0f){
			baseForce -= 0.01f;
			if (up)
				transform.Translate(0f, baseForce, 0f);
			if (!up)
				transform.Translate(0f, -baseForce, 0f);
			if (baseForce < 0f)
				baseForce = 0f;	
		}

		if (transform.position.y > 4.65f)
			up = false;
		if (transform.position.y < -4.65f)
			up = true;
		if (transform.position.y < 3.69f){
			if (baseForce == 0f)
				up = true;
			swingup = true;
		}else
			swingup = false;

		if (baseForce == 0f){
			stopped = true;
		}

		if ((transform.position.y > 3.32f 
			&& transform.position.y < 3.94f 
			&& baseForce < 0.3f) || score > 0){
			won = true;
			transform.Translate(10f,10f,1f);
		}
	}
}
