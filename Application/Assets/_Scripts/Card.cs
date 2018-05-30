using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject {

	public string cardName;
	public string description;

	public Sprite artwork;
	public string[] vorraussetungen;
	public int[] vorraussetzungenWert;

	public int level;
	public string fraktion;

	public int technischerFortschritt;
	public int globalisierung;
	public int umweltverschmutzung;
	public int geld;
	public int ansehen;
	public int einfluss;


}
