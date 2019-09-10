using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Timers;

public class Statistics : MonoBehaviour 
{
	public GameHelper _gameHelper;
	public Converter convert;
	public GameObject StatPanel;
    public Text timeText;
    private System.DateTime timeBegin;
    private System.TimeSpan timeTimer;
    public string timeString;

    bool setopen = true;

	public Text TotalGold;


	// Use this for initialization
	void Start () 
	{
        timeBegin = System.DateTime.Now;
        StartCoroutine(Timer());
        _gameHelper = GameObject.FindObjectOfType<GameHelper> ();
		convert = GameObject.FindObjectOfType<Converter> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		TotalGold.text = convert.Convert(_gameHelper.totalGold.ToString());
    }

	public void OpenStat()
	{
		if (setopen) 
		{
			StatPanel.SetActive (true);
			setopen = false;
		}
		else
		{
			StatPanel.SetActive (false);
			setopen = true;
		}
	}

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        //second += 1;

        timeTimer = System.DateTime.Now - timeBegin;
        timeText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeTimer.Hours, timeTimer.Minutes, timeTimer.Seconds);

        StartCoroutine(Timer());
    }
}
