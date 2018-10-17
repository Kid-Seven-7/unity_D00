using UnityEngine;

public class init : MonoBehaviour {

	private Vector3 inflate;

	public GameObject ballon;

	private float time, hold;

	// Use this for initialization
	void Start (){
		inflate.x = inflate.y = inflate.z = 0.4f;
		time = hold = 0;
	}

	// Update is called once per frame
	void Update (){
		time += Time.deltaTime;

		if (inflate.x > 0.4f)
			inflate.x = inflate.y = inflate.z -= 0.1f;

		if ((Mathf.RoundToInt(time) % 10 == 0) && (Mathf.RoundToInt(time) != 0)){
			inflate.x = inflate.y = inflate.z = 0.4f;
			hold = time;
		}

		if (Input.GetKeyDown("space")){
			if (time > (hold + 2.5f))
				ballon.transform.localScale += inflate;
		}

		if (ballon.transform.localScale.x > 1.0f)
			ballon.transform.localScale -= (inflate / 16);

		if (ballon.transform.localScale.x > 20f){
			Destroy(ballon);
			Debug.Log("Ballon life time: "+ Mathf.RoundToInt(time) + "s");
		}

		if (Mathf.RoundToInt(time) == 120){
			Destroy(ballon);
			Debug.Log("Time limit exceeded");
		}
	}
}
