using UnityEngine;
using System.Collections;

public class GestureButton : MonoBehaviour {
	public GameObject battle;
	public GameObject gestureMenu;
	public GameObject[] buttons;
	//public GameObject[] tempButtons;



	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			RaycastHit hit;
			if( Physics.Raycast( ray, out hit, 100 ) ){
			}
			int i = 0;

			if (hit.collider.tag == "GestureMenu") {
				while (i < 4) {
					buttons[i].SetActive (true);
					i++;
			}
				i = 0;
				gameObject.SetActive (false);
		}
			else if (hit.collider.tag == "Gesture" ) { //send values to battle or something
				Debug.Log("hit");
				while(i<4){
					
					buttons [i].SetActive (false);
					i++;
				}
				i=0;
				gestureMenu.SetActive (true);
			}
		}
	}
}
