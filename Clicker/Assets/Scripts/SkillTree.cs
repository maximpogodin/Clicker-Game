using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillTree : MonoBehaviour 
{
	bool open;
	public Skill1 skillScript1;
	public Button _skill1;
	public Button _skill2;
	public Button _skill5;

	// Use this for initialization
	void Start () 
	{
		open = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (skillScript1.costUpgrades > 1) 
		{
			_skill2.interactable = true;
			_skill5.interactable = true;
		} 
		else 
		{
			_skill2.interactable = false;
			_skill5.interactable = false;
		}

		if (skillScript1.costUpgrades > 3) 
		{
			_skill1.interactable = false;
		}
	}

	public void OpenCloseSkill()
	{
		if (open) 
		{
			GetComponent<Animator>().SetBool("Skill", true);
			open = false;
		} 
		else 
		{
			GetComponent<Animator>().SetBool("Skill", false);
			open = true;
		}
	}
	

}
