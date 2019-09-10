using UnityEngine;
using System.Collections;

public class Back2Anim : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayAnim()
	{
		GetComponent<Animator>().SetTrigger("Back2");
	}
}
