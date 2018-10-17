using UnityEngine;

public class bird : MonoBehaviour{
	private Vector3 down, up;

	private GameObject birdie;

	public GameObject upper_pipe, mid_pipe, lower_pipe;
	private GameObject c_upper_pipe, c_mid_pipe, c_lower_pipe;

	private Vector3 uPipeVec, mPipeVec, lPipeVec;

	private float seed, time;
	private int rnd, score;

	private bool Upassed, Mpassed, Lpassed;
	private bool Uadded, Madded, Ladded;
	private bool playing;

	// Use this for initialization
	void Start(){
		playing = true;
		time = score = rnd = 0;
		up = new Vector3(0f, 100f, 0f);
		down = new Vector3(0f, -7f, 0f);
		uPipeVec = new Vector3(21f, 4.2f, 0f);
		mPipeVec = new Vector3(21f, 1.66f, 0f);
		lPipeVec = new Vector3(21f, -0.46f, 0f);
		c_upper_pipe = c_mid_pipe = c_lower_pipe = null;
	}

	// Update is called once per frame
	void Update(){
		time += Time.deltaTime;
		rnd++;

		if (playing){
			seed = Random.Range(0.0f, 9.0f);
			
			if (Input.GetKeyDown("space"))
				transform.Translate(up * Time.deltaTime);
			else
				transform.Translate(down * Time.deltaTime);

			if (rnd % 250 == 0){
				if (!c_upper_pipe && (seed < 3.0f && seed > 0.0f)){
					c_upper_pipe = createClone(upper_pipe, c_upper_pipe, uPipeVec);
					Upassed = Uadded = false;
				}else if (!c_mid_pipe && (seed < 6.0f && seed > 3.0f)){
					c_mid_pipe = createClone(mid_pipe, c_mid_pipe, mPipeVec);
					Mpassed = Madded = false;
				}else if (!c_lower_pipe && (seed < 9.0f && seed > 6.0f)){
					c_lower_pipe = createClone(lower_pipe, c_lower_pipe, lPipeVec);
					Lpassed = Ladded = false;
				}
			}
			
			if (Upassed && !Uadded){
				Uadded = true;
				score += 5;
			}else if (Mpassed && !Madded){
				Madded = true;
				score += 5;
			}else if (Lpassed && !Ladded){
				Ladded = true;
				score += 5;
			}

			if (transform.position.y < -5.36f || transform.position.y > 7.37f)
				playing = showScore(score, time);

			if (c_upper_pipe)
				Upassed = collideCheck(c_upper_pipe);
			if (c_mid_pipe)
				Mpassed = collideCheck(c_mid_pipe);
			if (c_lower_pipe)
				Lpassed = collideCheck(c_lower_pipe);
		}
	}

	private GameObject createClone(GameObject og, GameObject clone, Vector3 pos){
		clone = Instantiate(og, pos, Quaternion.identity);
		clone.AddComponent<pipe>();
		return (clone);
	}

	private bool collideCheck(GameObject obj){
		if (obj.transform.position.x < 2.5f
				&& obj.transform.position.x > -2.5f)
			if (transform.position.y > 3.32f || transform.position.y < -0.37f)
				playing = showScore(score, time);
		return (obj.GetComponent<pipe>().passed);
	}

	private bool showScore(int score, float time){
		Debug.Log("Score: " + score);
		Debug.Log("Time: " + Mathf.RoundToInt(time) + "s");
		return (false);
	}
}