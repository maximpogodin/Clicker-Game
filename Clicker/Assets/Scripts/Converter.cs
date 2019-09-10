using UnityEngine;
using System.Collections;

public class Converter : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public string Convert(string x)
	{
		if (float.Parse (x) >= 1000 && float.Parse (x) < 1000000) 
		{
			x = (float.Parse(x)/1000).ToString("f2") + "K";
		}

		else if (float.Parse (x) >= 1000000 && float.Parse (x) < 1000000000) 
		{
			x = (float.Parse(x)/1000000).ToString("f2") + "M";
		}

		else
			x = float.Parse(x).ToString("f0");
		return x;
	}
}
