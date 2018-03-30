using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Collar : MonoBehaviour {

	public MeshRenderer Color_Slider;
	public Color MyColor;

	float y;
	//float speed = 3f; //Snelheid voor de if statement
	float StartHight;
	float time;
	float Amp;
	float Offset;
	float speed;


	Vector3 StartPos;

	void Start () 
	{
		speed = Random.Range (0.1f, 0.5f);
		Offset = Random.Range (0, 2 * Mathf.PI);
		Amp = Random.Range (1, Mathf.Abs(transform.localScale.z/2));
		StartPos = transform.localPosition;
		StartCoroutine (Loop ());

		transform.localScale = new Vector3(transform.localScale.x+Random.Range (0f,0.5f),transform.localScale.y+Random.Range (0f,0.5f),transform.localScale.z+Random.Range (0, 40f));

		/*
		y = Random.Range(-1f, 1f)+transform.position.y;
		Vector3 pos = new Vector3(transform.position.x, y, transform.position.z);
		transform.position = pos;
		StartHight = transform.position.y;//De waarde voor StartHight is y positie in de transform move tool
		*/

	}
		
	void Update () {
		if (Input.GetKeyDown(KeyCode.E) == true) 
		{
			//Color_Slider.material.color = MyColor;
			GetComponent<Renderer> ().material.color = Random.ColorHSV (0f, 0f, 0f, 1f, 0f, 1f, 0f, 0f);
		}
		time += speed * Time.deltaTime;
		transform.localPosition = StartPos + transform.forward * (Amp *Mathf.Sin (time+Offset));

		/*Deze code is vervangen met PingPong
		if (transform.position.y > 0.5f){
			Debug.Log ("you fucked up");
			transform.Translate (0, 0 ,-speed * Time.deltaTime);
		}/*
		if (transform.position.y < -0.5f) {
			Debug.Log ("you fucked down");
			transform.Translate (0, 0 ,speed * Time.deltaTime);
		}*/

			
	}

	void OnMouseDown()
	{
		GetComponent<Renderer> ().material.color = Random.ColorHSV (0f, 1f, 1f, 1f, 0.5f, 1f);
	}

	IEnumerator Loop()
	{
		while(true)
		{
			yield return new WaitForSeconds (9f);
			GetComponent<Renderer> ().material.color = Random.ColorHSV (0f, 0f, 0f, 1f, 0f, 1f, 0f, 0f);
		}
	}
}
