using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalParamsManager : MonoBehaviour {

	//Geld
	public GameObject geldLayer;
	private Image geldLayerRenderer;
	public Sprite geld1;
	public Sprite geld2;
	public Sprite geld3;
	public Sprite geld4;
	public Sprite geld5;

	//Ansehen
	public GameObject ansehenLayer;
	private Image ansehenLayerRenderer;
	public Sprite ansehen1;
	public Sprite ansehen2;
	public Sprite ansehen3;
	public Sprite ansehen4;
	public Sprite ansehen5;

	//Einfluss
	public GameObject einflussLayer;
	private Image einflussLayerRenderer;
	public Sprite einfluss1 = null;
	public Sprite einfluss2;
	public Sprite einfluss3;
	public Sprite einfluss4;
	public Sprite einfluss5;


	// Use this for initialization
	void Start () {
		geldLayerRenderer = geldLayer.GetComponent<Image> ();
		ansehenLayerRenderer = ansehenLayer.GetComponent<Image> ();
		einflussLayerRenderer = einflussLayer.GetComponent<Image> ();
	}
		
	public void updateLayer(){
		updateGeld ();
		updateAnsehen ();
		updateEinfluss ();
	}

	void updateGeld(){
		if (PlayerManager.geld < 3) {
			geldLayerRenderer.sprite = geld1;
		} else if (PlayerManager.geld < 5) {
			geldLayerRenderer.sprite = geld2;
		} else if (PlayerManager.geld < 7) {
			geldLayerRenderer.sprite = geld3;
		} else if (PlayerManager.geld < 9) {
			geldLayerRenderer.sprite = geld4;
		} else if (PlayerManager.geld < 11) {
			geldLayerRenderer.sprite = geld5;
		}
	}
		
	void updateAnsehen(){
		if (PlayerManager.ansehen < 3) {
			ansehenLayerRenderer.sprite = ansehen1;
		} else if (PlayerManager.ansehen < 5) {
			ansehenLayerRenderer.sprite = ansehen2;
		} else if (PlayerManager.ansehen < 7) {
			ansehenLayerRenderer.sprite = ansehen3;
		} else if (PlayerManager.ansehen < 9) {
			ansehenLayerRenderer.sprite = ansehen4;
		} else if (PlayerManager.ansehen < 11) {
			ansehenLayerRenderer.sprite = ansehen5;
		}
	}

	void updateEinfluss(){
		if (PlayerManager.einfluss < 3) {
			einflussLayerRenderer.sprite = einfluss1;
		} else if (PlayerManager.einfluss < 5) {
			einflussLayerRenderer.sprite = einfluss2;
		} else if (PlayerManager.einfluss < 7) {
			einflussLayerRenderer.sprite = einfluss3;
		} else if (PlayerManager.einfluss < 9) {
			einflussLayerRenderer.sprite = einfluss4;
		} else if (PlayerManager.einfluss < 11) {
			einflussLayerRenderer.sprite = einfluss5;
		}
	}

}
