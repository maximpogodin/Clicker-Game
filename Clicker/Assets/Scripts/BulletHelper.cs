using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BulletHelper : MonoBehaviour 
{
	public int Damage { get; set; }
	HealthHelper _healthHelper;
	public GameObject target;

	// Use this for initialization
	void Start () 
	{
		target = GameObject.FindGameObjectWithTag ("GoldImage");
	}
	
	// Update is called once per frame
	void Update () 
	{
			
			transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * 300);
		//transform.Rotate (0, 0, Time.deltaTime * 200);

			if (Vector2.Distance(transform.position, target.transform.position)< 0.1f)
			{//попадание

				Destroy(gameObject);
			}
		}
	}
