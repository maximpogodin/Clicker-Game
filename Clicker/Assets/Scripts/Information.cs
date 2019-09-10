using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Information : MonoBehaviour
{
    public GameObject StatPanel;
    public GameObject AchievePanel;

    public Button[] infromButton;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void StatOpen()
    {
        StatPanel.transform.SetSiblingIndex(+1);
    }

    public void AchieveOpen()
    {
        AchievePanel.transform.SetSiblingIndex(+1);
    }
}
