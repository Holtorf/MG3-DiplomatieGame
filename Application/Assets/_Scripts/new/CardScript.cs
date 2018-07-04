using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardScript : MonoBehaviour {


	//GUI
	public Card card;
	public TextMeshProUGUI description;
	public TextMeshProUGUI title;
	public bool red;
	public bool green;
	public SpriteRenderer redGlow;
	public SpriteRenderer greenGlow;
	public SpriteRenderer artwork;
	public TextMeshProUGUI level;
	public TextMeshProUGUI stats;
	//card
	private bool cardToggle = false;
	public CardManager cardManager;
	private int positionIndex;

	// Use this for initialization
	void Start () {
		initCard ();
	}

	void initCard() {
		description.text = card.description;
		title.text = card.cardName;
		artwork.sprite = card.artwork;
		level.text = card.level.ToString();
		this.createStatText ();
	}

	private void createStatText(){
		string text = "";
		if (card.ansehen > 0) {
			text = text + "+ Ansehen " + card.ansehen + "\n";
		}
		if (card.einfluss > 0) {
			text = text + "+ Einfluss " + card.einfluss + "\n";
		}
		if (card.geld > 0) {
			text = text + "+ Geld " + card.geld	+ "\n";
		}
		if (card.globalisierung > 0) {
			text = text + "+ Globalisierung " + card.globalisierung + "\n";
		}
		if (card.umweltverschmutzung > 0) {
			text = text + "+ Umweltverschmutzung " + card.umweltverschmutzung + "\n";
		}
		if (card.technischerFortschritt > 0) {
			text = text + "+ Technischer Fortschritt " + card.technischerFortschritt + "\n";
		}
		if (card.ansehen < 0) {
			text = text + "- Ansehen " + card.ansehen + "\n";
		}
		if (card.einfluss < 0) {
			text = text + "- Einfluss " + card.einfluss + "\n";
		}
		if (card.geld < 0) {
			text = text + "- Geld " + card.geld + "\n";
		}
		if (card.globalisierung < 0) {
			text = text + "- Globalisierung " + card.globalisierung + "\n";
		}
		if (card.umweltverschmutzung < 0) {
			text = text + "- Umweltverschmutzung " + card.umweltverschmutzung + "\n";
		}
		if (card.technischerFortschritt < 0) {
			text = text + "- Technischer Fortschritt " + card.technischerFortschritt + "\n";
		}
		if (card.vorraussetzungAnsehen > 0) {
			text = text + "o Ansehen " + card.vorraussetzungAnsehen + "\n";
		}
		if (card.vorraussetzungEinfluss > 0) {
			text = text + "o Einfluss " + card.vorraussetzungEinfluss + "\n";
		}
		if (card.vorraussetzungGeld > 0) {
			text = text + "o Geld " + card.vorraussetzungGeld + "\n";
		}
		if (card.vorraussetzungGlobalisierung > 0) {
			text = text + "o Globalisierung " + card.vorraussetzungGlobalisierung + "\n";
		}
		if (card.vorraussetzungUmweltverschmutzung > 0) {
			text = text + "o Umweltverschmutzung " + card.vorraussetzungUmweltverschmutzung + "\n";
		}
		if (card.vorraussetzungTechnischerFortschritt > 0) {
			text = text + "o Technischer Fortschritt " + card.vorraussetzungTechnischerFortschritt + "\n";
		}
		stats.text = text;
	}

	//Eventlistener
	void OnMouseEnter() {
		if (!cardToggle) {
			transform.Translate (new Vector3 (0, 100, 0));
		}
	}

	void OnMouseExit() {
		if (!cardToggle) {
			transform.Translate (new Vector3 (0, -100, 0));
		}
	}

	void OnMouseDown() {
		cardManager.onClick (this);
	}

	//setter/getter
	public void setPositionIndex(int index){
		this.positionIndex = index;
	}

	public int getPositionIndex(){
		return positionIndex;
	}

	public void setCard(Card card) {
		this.card = card;
	}

	public Card getCard(){
		return this.card;
	}

	public bool getGreen(){
		return this.green;
	}

	public bool getRed(){
		return this.red;
	}

	public void toggleGreen(){
		this.green = !green;
		greenGlow.enabled = green;
		cardToggle = !cardToggle;
	}

	public void toggleRed(){
		this.red = !red;
		redGlow.enabled = red;
		cardToggle = !cardToggle;
	}

	public void setCardManager(CardManager cardManager) {
		this.cardManager = cardManager;
	}
}
