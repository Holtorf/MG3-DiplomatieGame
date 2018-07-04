using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalManager : MonoBehaviour {

	public static int gameRound = 0;
	public static int globalisierung;
	public static int technischerFortschritt;
	public static int umweltverschmutzung;

	public PlayerManager playerManager;
	public CardManager cardManager;
	public MapLayerManager mapLayerManager;
	public Decks decks;

	//GUI
	public TextMeshProUGUI globalisierungText;
	public TextMeshProUGUI technischerFortschrittText;
	public TextMeshProUGUI umweltverschmutzungText;
	public TextMeshProUGUI rundenAnzeigeText;
	public TextMeshProUGUI unternehmenText;
	public TextMeshProUGUI regierungText;
	public TextMeshProUGUI forschungsinstText;
	public TextMeshProUGUI umweltschutzText;
	public GameObject panel;
	public GameObject gewonnenPanel;
	public TextMeshProUGUI gewonnenFraktion;

	private List<CardScript> playedCards = new List<CardScript> ();

	//KI
	public GameObject cardPrefab;
	private GameObject kiCard;

	public void endTurn() {
		playKICards ();
		updateGlobalStats ();
		updateGlobalStatsGui ();
		updateRundenAnzeige ();
		mapLayerManager.updateLayer ();
		createDialog ();
		checkPlayerWin ();
		resetPlayedCards ();
	}

	void updateGlobalStats() {
		for (int i = 0; i < playedCards.Count; i++) {
			GlobalManager.globalisierung += playedCards [i].getCard().globalisierung;
			GlobalManager.technischerFortschritt += playedCards [i].getCard().technischerFortschritt;
			GlobalManager.umweltverschmutzung += playedCards [i].getCard().umweltverschmutzung;
		}
	}

	void playKICards() {
		List<Card> unternehmenDeck = decks.getPlayerDeck0 (PlayerManager.Fraktion.Unternehmen);
		unternehmenDeck.AddRange(decks.getPlayerDeck1 (PlayerManager.Fraktion.Unternehmen));
		List<Card> forschungsinstDeck = decks.getPlayerDeck0 (PlayerManager.Fraktion.Forschungsinstitut);
		forschungsinstDeck.AddRange(decks.getPlayerDeck1 (PlayerManager.Fraktion.Forschungsinstitut));
		List<Card> umweltschutzDeck = decks.getPlayerDeck0 (PlayerManager.Fraktion.Umweltschutz);
		umweltschutzDeck.AddRange(decks.getPlayerDeck1 (PlayerManager.Fraktion.Umweltschutz));
		if (unternehmenDeck.Count > 0) {
			Card randomCard = unternehmenDeck [Random.Range (0, unternehmenDeck.Count)];
			kiCard = Instantiate (cardPrefab) as GameObject;
			kiCard.SetActive (false);
			kiCard.GetComponent<CardScript> ().setCard (randomCard);
			playedCards.Add (kiCard.GetComponent<CardScript>());
		}
		if (forschungsinstDeck.Count > 0) {
			Card randomCard = forschungsinstDeck [Random.Range (0, forschungsinstDeck.Count)];
			kiCard = Instantiate (cardPrefab) as GameObject;
			kiCard.SetActive (false);
			kiCard.GetComponent<CardScript> ().setCard (randomCard);
			playedCards.Add (kiCard.GetComponent<CardScript>());
		}
		if (umweltschutzDeck.Count > 0) {
			Card randomCard = umweltschutzDeck [Random.Range (0, umweltschutzDeck.Count)];
			kiCard = Instantiate (cardPrefab) as GameObject;
			kiCard.SetActive (false);
			kiCard.GetComponent<CardScript> ().setCard (randomCard);
			playedCards.Add (kiCard.GetComponent<CardScript>());
		}
	}

	void updateGlobalStatsGui() {
		globalisierungText.text = GlobalManager.globalisierung.ToString();
		technischerFortschrittText.text = GlobalManager.technischerFortschritt.ToString();
		umweltverschmutzungText.text = GlobalManager.umweltverschmutzung.ToString();
	}

	void updateRundenAnzeige() {
		GlobalManager.gameRound++;
		rundenAnzeigeText.text = "Runde: " + GlobalManager.gameRound.ToString();
	}

	void resetPlayedCards() {
		playedCards = new List<CardScript> ();
		Destroy (kiCard);
	}

	public void onCloseClick(){
		panel.SetActive (false);
	}

	public void onOpenClick(){
		panel.SetActive (true);
	}

	public void createDialog(){
		bool regierungHasText = false;
		bool unternehmenHasText = false;
		bool forschungHasText = false;
		bool umweltHasText = false;

		panel.SetActive (true);
		foreach (CardScript playedCard in playedCards){
			switch (playedCard.getCard().fraktion) {
			case PlayerManager.Fraktion.Regierung: 
				regierungText.text = playedCard.getCard ().description;
				regierungHasText = true;
				break;
			case PlayerManager.Fraktion.Unternehmen:
				unternehmenText.text = playedCard.getCard ().description;
				unternehmenHasText = true;
				break;
			case PlayerManager.Fraktion.Forschungsinstitut:
				forschungsinstText.text = playedCard.getCard ().description;
				forschungHasText = true;
				break;
			case PlayerManager.Fraktion.Umweltschutz:
				umweltschutzText.text = playedCard.getCard ().description;
				umweltHasText = true;
				break;
			}
		}
		if (!regierungHasText) {regierungText.text = "Karten verkauft";}
		if (!unternehmenHasText) {unternehmenText.text = "Karten verkauft";}
		if (!forschungHasText) {forschungsinstText.text = "Karten verkauft";}
		if (!umweltHasText) {umweltschutzText.text = "Karten verkauft";}


	}

	public void closeDialog(){
		panel.SetActive (false);
	}

	public void openDialog() {
		panel.SetActive (true);
	}

	private void checkPlayerWin(){
		if (GlobalManager.globalisierung >= 8 && PlayerManager.ansehen >= 8){
			gewonnenFraktion.text = "Regierung";
			gewonnenPanel.SetActive (true);
		}
//		if (PlayerManager.geld >= 8 && PlayerManager.einfluss >= 8){
//			gewonnenFraktion.text = "Unternehmen";
//			gewonnenPanel.SetActive (true);
//		}
//		if (GlobalManager.umweltverschmutzung <= 2 && PlayerManager.geld >= 8){
//			print ("Umweltschutzorganisation gewinnt");
//		}
//		if (GlobalManager.technischerFortschritt >= 8 && PlayerManager.ansehen >= 8){
//			print ("Forschungsinstitut gewinnt");
//		}
	}


	//Setter/Getter

	public List<CardScript> getPlayedCards() {
		return playedCards;
	}
}
