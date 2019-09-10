using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StrangerAnim : MonoBehaviour 
{
	public ShopSkyAnim _shop;

	// Use this for initialization
	void Start () 
	{
		_shop = GameObject.FindObjectOfType<ShopSkyAnim> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void StrangerOpen()
	{
		_shop.ShopSkyOpen ();
		GetComponent<Animator> ().SetBool ("Shop", true);
	}

	public void StrangerClose()
	{
		_shop.ShopSkyClose ();
		GetComponent<Animator> ().SetBool ("Shop", false);
	}
}
