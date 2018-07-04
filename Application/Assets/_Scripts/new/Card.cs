using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject {

	public string cardName;
	public string description;

	public Sprite artwork;
	public int vorraussetzungGeld;
	public int vorraussetzungEinfluss;
	public int vorraussetzungAnsehen;
	public int vorraussetzungGlobalisierung;
	public int vorraussetzungUmweltverschmutzung;
	public int vorraussetzungTechnischerFortschritt;

	public int level;
	public PlayerManager.Fraktion fraktion;

	public int technischerFortschritt;
	public int globalisierung;
	public int umweltverschmutzung;
	public int geld;
	public int ansehen;
	public int einfluss;
}
