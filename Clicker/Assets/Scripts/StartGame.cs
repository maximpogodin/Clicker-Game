using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartGame : MonoBehaviour 
{
	public GameObject back1;
	public GameObject back2;
	public GameObject title;
	public Text text;

	public Back1Anim back1Animation;
	public Back2Anim back2Animation;
	public TitleAnim titleAnimation;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButton (0)) 
		{
			back1Animation.PlayAnim();
			back2Animation.PlayAnim();
			titleAnimation.PlayAnim();
			Destroy(back1, 3f);
			Destroy(back2, 3f);
			Destroy(title, 2f);
			Destroy(text);
		}
	}
}
