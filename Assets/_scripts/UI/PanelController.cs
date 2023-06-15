using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelController : MonoBehaviour
{
    public TextMeshProUGUI panelTutoText;
    // Start is called before the first frame update

    public void SetPanelTutoText(string ptt){
        panelTutoText.text = ptt;
    }

    public void setPanelTutoImage(){

    }
}
