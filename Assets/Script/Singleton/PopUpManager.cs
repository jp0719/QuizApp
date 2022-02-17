using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : Singleton<PopUpManager>
{
    [SerializeField]
    private PopUpMessage messageBubble;//Prefab pop up

    //Show popup message
    public void showMessage(string message)
    {
        PopUpMessage bubble = Instantiate(messageBubble, this.transform);
        bubble.Show(message);
    }
}
