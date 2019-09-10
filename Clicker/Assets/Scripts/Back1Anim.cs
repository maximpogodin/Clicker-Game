using UnityEngine;
using System.Collections;

public class Back1Anim : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void PlayAnim()
	{
		GetComponent<Animator>().SetTrigger("Back1");
	}
}
