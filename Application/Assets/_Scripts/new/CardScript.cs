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
