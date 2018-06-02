using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ParameterTests : NetworkBehaviour {

    public const int maxTechValue = 100;
    [SyncVar]
    public int currentTechValue = 0;

    public Button button;

    public RectTransform techBar;

    public void Start()
    {
        Button btn;
        btn = button.GetComponent<Button>();
        btn.onClick.AddListener(increaseTechValue);

    }

    public void increaseTechValue()
    {
        currentTechValue += 10;

        if(!isServer)
        techBar.sizeDelta = new Vector2(currentTechValue, techBar.sizeDelta.y);
    }

    
}
