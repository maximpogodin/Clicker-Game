using UnityEngine;
using System.Collections;

public class TitleAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayAnim()
	{
		GetComponent<Animator>().SetTrigger("Title");
	}
}
