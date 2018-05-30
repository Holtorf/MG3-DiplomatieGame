using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScript : MonoBehaviour {

	//Script References
	public GameObject player;
	public GameObject decks;
	private Decks deckScript;

	//GUI
	public TextMeshProUGUI globalisierungText;
	public TextMeshProUGUI technischerFortschrittText;
	public TextMeshProUGUI umweltverschmutzungText;
	public TextMeshProUGUI rundenAnzeigeText;

	//static
	public static List<Card> playedCards = new List<Card>();

	void Start () {
		initReferences ();
	}
	
	void initReferences() {
		deckScript = decks.GetComponent<Decks> ();
	}

	public void endTurn() {
		playKICards ();
		updateGlobalStats ();
		updateGlobalStatsGui ();
		updateRundenAnzeige ();
		resetPlayedCards ();
	}

	void updateGlobalStats() {
		for (int i = 0; i < GameScript.playedCards.Count; i++) {
			GameStats.globalisierung += playedCards [i].globalisierung;
			GameStats.technischerFortschritt += playedCards [i].technischerFortschritt;
			GameStats.umweltverschmutzung += playedCards [i].umweltverschmutzung;
		}
	}

	void playKICards() {
		List<Card> someDeck = deckScript.getRegierung();
		if (someDeck.Count > 0) {
			Card kiCard = someDeck [Random.Range (0, someDeck.Count)];
			GameScript.playedCards.Add (kiCard);
		}
	}

	void updateGlobalStatsGui() {
		globalisierungText.text = GameStats.globalisierung.ToString();
		technischerFortschrittText.text = GameStats.technischerFortschritt.ToString();
		umweltverschmutzungText.text = GameStats.umweltverschmutzung.ToString();
	}

	void updateRundenAnzeige() {
		GameStats.gameRound++;
		rundenAnzeigeText.text = "Runde: " + GameStats.gameRound.ToString();
	}

	void resetPlayedCards() {
		GameScript.playedCards = new List<Card> ();
	}
}
