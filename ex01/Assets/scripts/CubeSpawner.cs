using UnityEngine;

public class CubeSpawner : MonoBehaviour{

	public GameObject aCube, sCube, dCube;

	public GameObject aClone, sClone, dClone;

	private float val, seed;

	void Start(){
		aClone = sClone = dClone = null;
		val = seed = 0;	
	}

	// Update is called once per frame
	void Update(){
		val += Time.deltaTime;
		seed = Random.Range(0.0f, 0.3f);

		if (Input.GetKeyDown("a") && aClone != null)
			DestroyImmediate(aClone, true);
		if (Input.GetKeyDown("s") && sClone != null)
			DestroyImmediate(sClone, true);
		if (Input.GetKeyDown("d") && dClone != null)
			DestroyImmediate(dClone, true);

		if (Mathf.RoundToInt(val) % 25 == 0){
			if (seed > 0.0f && seed < 0.1f){
				if (!aClone){
					aClone = Instantiate(aCube, new Vector3(-3f, 11f, 0f), Quaternion.identity);
					aClone.AddComponent<Cube>();
				}
			}
			
			if (seed > 0.1f && seed < 0.2f){
				if (!sClone){
					sClone = Instantiate(sCube, new Vector3(0f, 11f, 0f), Quaternion.identity);
					sClone.AddComponent<Cube>();
				}
			}

			if (seed > 0.2f && seed < 0.3f){
				if (!dClone){
					dClone = Instantiate(dCube, new Vector3(3f, 11f, 0f), Quaternion.identity);
					dClone.AddComponent<Cube>();
				}
			}
		}
		
		val++;
	}
}
