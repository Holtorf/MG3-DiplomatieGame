using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ParameterTests : NetworkBehaviour {

    [SyncVar(hook = "onChangedEnt")]   
    public int currentEnt;

    [SyncVar(hook = "onChangedGlo")]
    public int currentGlo;

    [SyncVar(hook = "onChangedUmw")]
    public int currentUmw;

    public Button entButton;
    public Button gloButton;
    public Button umwButton;

    public Text entValue;
    public Text gloValue;
    public Text umwValue;

    public void Start()
    {
        entValue.text = currentEnt.ToString();
        gloValue.text = currentGlo.ToString();
        umwValue.text = currentUmw.ToString();
    }

    public void increaseValue(int index)  //increase Value (Ent,Glo,Umw) with index (1,2,3)
    {
        if (!isServer)
        {
            return;
        }

        if (index == 1) currentEnt += 10;
        else if (index == 2) currentGlo += 10;
        else if (index == 3) currentUmw += 10;
        
    }

    void onChangedEnt(int ent)
    {
        entValue.text = ent.ToString();
    }

    void onChangedGlo(int glo)
    {
        gloValue.text = glo.ToString();
    }

    void onChangedUmw(int umw)
    {
        umwValue.text = umw.ToString();
    }

}
