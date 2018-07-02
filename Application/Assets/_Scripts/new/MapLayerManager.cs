using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLayerManager : MonoBehaviour {

	//Technischer Fortschritt
	public GameObject cityLayer;
	private Image cityLayerRenderer;
	public Sprite city1;
	public Sprite city2;
	public Sprite city3;
	public Sprite city4;
	public Sprite city5;

	//Globalisierung
	public GameObject globalLayer;
	private Image globalLayerRenderer;
	public Sprite global1;
	public Sprite global2;
	public Sprite global3;
	public Sprite global4;
	public Sprite global5;

	//Umweltverschmutzung
	public GameObject schmutzLayer;
	private Image schmutzLayerRenderer;
	public Sprite schmutz1;
	public Sprite schmutz2;
	public Sprite schmutz3;
	public Sprite schmutz4;
	public Sprite schmutz5;


	// Use this for initialization
	void Start () {
		cityLayerRenderer = cityLayer.GetComponent<Image> ();
		globalLayerRenderer = globalLayer.GetComponent<Image> ();
		schmutzLayerRenderer = schmutzLayer.GetComponent<Image> ();
	}
		
	public void updateLayer(){
		updateCities ();
		updateGlobal ();
		updateSchmutz ();
	}

	void updateCities(){
		if (GlobalManager.technischerFortschritt < 3) {
			cityLayerRenderer.sprite = city1;
		} else if (GlobalManager.technischerFortschritt < 5) {
			cityLayerRenderer.sprite = city2;
		} else if (GlobalManager.technischerFortschritt < 7) {
			cityLayerRenderer.sprite = city3;
		} else if (GlobalManager.technischerFortschritt < 9) {
			cityLayerRenderer.sprite = city4;
		} else if (GlobalManager.technischerFortschritt > 8) {
			cityLayerRenderer.sprite = city5;
		}
	}
		
	void updateGlobal(){
		if (GlobalManager.globalisierung < 3) {
			globalLayerRenderer.sprite = global1;
		} else if (GlobalManager.globalisierung < 5) {
			globalLayerRenderer.sprite = global2;
		} else if (GlobalManager.globalisierung < 7) {
			globalLayerRenderer.sprite = global3;
		} else if (GlobalManager.globalisierung < 9) {
			globalLayerRenderer.sprite = global4;
		} else if (GlobalManager.globalisierung > 8) {
			globalLayerRenderer.sprite = global5;
		}
	}

	void updateSchmutz(){
		if (GlobalManager.umweltverschmutzung < 3) {
			schmutzLayerRenderer.sprite = schmutz1;
		} else if (GlobalManager.umweltverschmutzung < 5) {
			schmutzLayerRenderer.sprite = schmutz2;
		} else if (GlobalManager.umweltverschmutzung < 7) {
			schmutzLayerRenderer.sprite = schmutz3;
		} else if (GlobalManager.umweltverschmutzung < 9) {
			schmutzLayerRenderer.sprite = schmutz4;
		} else if (GlobalManager.umweltverschmutzung > 8) {
			schmutzLayerRenderer.sprite = schmutz5;
		}
	}

}
