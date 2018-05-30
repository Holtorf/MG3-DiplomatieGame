using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScript : MonoBehaviour {


	public static List<Card> playedCards = new List<Card>();
	public TextMeshProUGUI globalisierungText;
	public TextMeshProUGUI technischerFortschrittText;
	public TextMeshProUGUI umweltverschmutzungText;
	public TextMeshProUGUI rundenAnzeigeText;

	public GameObject player;
	public GameObject decks;
	private Decks deckScript;

	// Use this for initialization
	void Start () {
		deckScript = decks.GetComponent<Decks> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void endTurn(){
		this.playKICards ();
		this.updateGlobalStats ();
		this.updateGlobalStatsGui ();
		this.updateRundenAnzeige ();
		this.resetPlayedCards ();
	}

	void updateGlobalStats(){
		for (int i = 0; i < GameScript.playedCards.Count; i++) {
			GameStats.globalisierung += playedCards [i].globalisierung;
			GameStats.technischerFortschritt += playedCards [i].technischerFortschritt;
			GameStats.umweltverschmutzung += playedCards [i].umweltverschmutzung;
		}
	}

	void playKICards(){
		List<Card> someDeck = deckScript.getRegierung();
		if (someDeck.Count > 0) {
			Card kiCard = someDeck [Random.Range (0, someDeck.Count)];
			GameScript.playedCards.Add (kiCard);
		}
	}

	void updateGlobalStatsGui(){
		globalisierungText.text = GameStats.globalisierung.ToString();
		technischerFortschrittText.text = GameStats.technischerFortschritt.ToString();
		umweltverschmutzungText.text = GameStats.umweltverschmutzung.ToString();
	}

	void updateRundenAnzeige(){
		GameStats.gameRound++;
		rundenAnzeigeText.text = "Runde: " + GameStats.gameRound.ToString();
	}

	void resetPlayedCards(){
		GameScript.playedCards = new List<Card> ();
	}
}
