using UnityEngine;

public class club : MonoBehaviour {

	public GameObject golfClub, ballObj;

	private Vector3 ballPos, move, baseVal;

	public float force, temp;

	private bool stopped, swing, up;

	// Use this for initialization
	void Start () {
		temp = 0f;
		swing = false;
		move.x = move.z = 0.0f;
		move.y = -0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (force < 0f){
			baseVal.y = transform.localPosition.y;
			force = 0f;
		}

		stopped = ballObj.GetComponent<ball>().stopped;

		if (ballPos.y < 3.69f)
			move.y = -0.5f;
		else
			move.y = 0.5f;
			
		if (stopped){
			if (Input.GetKey("space")){
				swing = true;
				transform.Translate(move * Time.deltaTime);
				temp += 0.1f;
			}
			if (Input.GetKeyUp("space")){
				swing = false;
				force = temp;
				temp = 0;
				golfClub.transform.position = baseVal;
			}
			ballPos.x = ballObj.GetComponent<ball>().transform.position.x - 0.2f;
			if (ballPos.y < 3.69f)
				ballPos.y = ballObj.GetComponent<ball>().transform.position.y + 0.2f;
			else
				ballPos.y = ballObj.GetComponent<ball>().transform.position.y + 1.0f;
			ballPos.z = ballObj.GetComponent<ball>().transform.position.z;
			if (!swing)
				transform.position = ballPos;
		}else{
			force = 0f;
		}
	}
}
