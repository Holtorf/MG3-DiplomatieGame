using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decks : MonoBehaviour {


	public List<Card> regierung;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public List<Card> getRegierung(){
		return regierung;
	}
}
