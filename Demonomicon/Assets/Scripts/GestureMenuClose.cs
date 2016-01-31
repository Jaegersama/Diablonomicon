using UnityEngine;
using System.Collections;

public class GestureMenuClose : MonoBehaviour {
	public GameObject battle;
	public GameObject gestureMenu;
	public GameObject[] buttons;
	public int gestureValue = 1;
	//public GameObject[] tempButtons;



	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			RaycastHit hit;
			if( Physics.Raycast( ray, out hit, 100 ) ){


			if (hit.collider.tag == "Gesture") {
					battle.GetComponent<Battle>().ChangeGestures (gestureValue);
				gestureMenu.SetActive (true);
				for (int i =0; i < 4; i++ ) {
					buttons[i].SetActive (false);

					//	getGesture += gestureValue;

				}
		
				gameObject.SetActive (false);
			}
		
		}
		}
	}
}
