using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMessage : MonoBehaviour
{
    [SerializeField]
    private Text txtMessage;//Text for pop up message

    //Setup and show pop up
    public void Show(string thisMessage)
    {
        this.gameObject.SetActive(true);
        if (txtMessage) txtMessage.text = thisMessage;
    }

    //Destroy pop up on close
    public void ClosePopUp()
    {
        Destroy(this.gameObject);
    }
}
