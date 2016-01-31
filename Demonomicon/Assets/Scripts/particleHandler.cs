using UnityEngine;
using System.Collections;

public class particleHandler : MonoBehaviour {

	public Object particle;
	public Transform ember;
	public bool embersEnabled;

	public bool customColor = false;

	// Use this for initialization
	void Start () {
		int particleLimit = 35;
		for (int i = 0; i < particleLimit; i++) {
			GameObject p = Instantiate(particle, transform.position, transform.rotation) as GameObject;
			p.GetComponent<Particle>().customColor = customColor;
			if (customColor) {
				p.GetComponent<Particle>().particleColor = new Color(26/255.0f,19/255.0f,31/255.0f,1);
			}
        }

        if (embersEnabled) {
	        int emberLimit = 14;
	        for (int i = 0; i < emberLimit; i++) {
	            Instantiate(ember,new Vector3(0, 0, 0), Quaternion.identity);
	        }
	    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
