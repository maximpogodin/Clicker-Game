using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopSkyAnim : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void ShopSkyOpen()
	{
		GetComponent<Animator>().SetBool("ShopSky",true);
		gameObject.SetActive (true);

	}

	public void ShopSkyClose()
	{
		GetComponent<Animator>().SetBool("ShopSky",false);
	}
}
