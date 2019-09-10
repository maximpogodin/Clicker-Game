using UnityEngine;
using System.Collections;

public class PlayerHelper : MonoBehaviour 
{
	public Transform AttackStartPosition;
	public GameObject[] AttackPrefabs;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void RunAttack()
	{
		GetComponent<Animator>().SetTrigger("Attack");
		int index = Random.Range (0, AttackPrefabs.Length);
		GameObject effect = Instantiate (AttackPrefabs [index]) as GameObject;
		effect.transform.position = AttackStartPosition.position;
		Destroy (effect, 0.15f);
	}
}
