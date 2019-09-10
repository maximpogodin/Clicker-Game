using UnityEngine;
using System.Collections;

public class Ranks : MonoBehaviour 
{
	public GameObject[] RanksPrefab;
	public Transform RankPosition;
	public Transform parentRank;
	public int level;
	public GameObject ranksImage;

	// Use this for initialization
	void Start () 
	{
		ranksImage = Instantiate (RanksPrefab[level]) as GameObject;
		ranksImage.transform.SetParent (parentRank, true);
		ranksImage.transform.position = RankPosition.position;
		ranksImage.transform.SetSiblingIndex (17);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void LevelUp()
	{
		level++;
		ranksImage = GameObject.FindGameObjectWithTag("Rank");
		Destroy (ranksImage);
		//GameObject rankobj = Instantiate (RanksPrefab [level]) as GameObject;
		ranksImage = Instantiate (RanksPrefab [level]) as GameObject;
		ranksImage.transform.SetParent (parentRank, true);
		ranksImage.transform.position = RankPosition.position;
		ranksImage.transform.SetSiblingIndex (18);
	}
}
