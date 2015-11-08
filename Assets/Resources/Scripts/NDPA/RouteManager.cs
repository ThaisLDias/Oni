using UnityEngine;
using System.Collections;

public class RouteManager : MonoBehaviour 
{
	
	//Route[ID,Tile];
	public Transform[,] Route;
	//ID's
	public int routeTile = 0;
	public int routeID = 0;
	//PlaceHolders
	public bool creatingRoute;
	Vector3 TilePosition;
	public GameObject Bus;
	public bool[] onion;
	int timer;
	Animator anim;
	GameObject BusAnimationBoolGetter;
	GameObject BusButton;
	GameObject Money;
	public bool LoseMoney;
	
	GameObject[] person;
	
	public AudioClip AuDio;
	
	
	
	
	
	public void SetPoint(Transform point)
	{
		Route[routeID,routeTile] = point;
		Debug.Log (Route [routeID, routeTile]);
		routeTile++;
	}
	void Start ()
	{
		Route = new Transform[1000, 20];
		onion = new bool[1000];
		BusAnimationBoolGetter = GameObject.Find("RotaManager");
		BusButton = GameObject.Find("SetBusButton");
		anim = BusButton.GetComponent <Animator> ();
		Money = GameObject.Find ("fad");
		LoseMoney = false;
		//SetTextFinal = false;
		
		//	Person = GameObject.Find ("Timer").GetComponent<Time> ().person;
		
	}
	
	
	public void BusSpawn() 
	{
		
		if(Route[routeID,0] != null && timer <= 0)
		{
			Instantiate(Bus, new Vector3(Route[routeID,1].position.x, Route[routeID,1].position.y+0.3f, Route[routeID,1].position.z), Bus.transform.rotation);
			timer = 30;
			onion[routeID] = true;
			LoseMoney = true;
			
		}
		
		if (BusAnimationBoolGetter.GetComponent<Route>().BusAnimController)
		{
			anim.SetBool("ClickTheBus", true);
			
		}
		
		if (LoseMoney == true && Money.GetComponent<Money>().couste >= -1) {
			Money.GetComponent<Money>().couste += 10;
		} 
		else
			Money.GetComponent<Money>().couste -= 10;
		
		

		Social.TutorialString = "|Parabens! Voce fez varios alunos irem a escola!@ #EscolaParaTodos #VersaoBeta";
		GameObject.Find ("SocialText").GetComponent<Social> ().Type1 ();
		creatingRoute = false;
		
	} 
	
	
	
	
	public void Update () 
		
		
	{
		
		timer--;
		if (BusAnimationBoolGetter.GetComponent<Route>().BusAnimController == false)
		{
			anim.SetBool("ClickTheBus", false);
			BusAnimationBoolGetter.GetComponent<Route>().BusAnimController = true;
		}
		
	}
}