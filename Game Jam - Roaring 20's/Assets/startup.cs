using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        

        gameObject.GetComponent<messageForItem>().set();
        GameObject.Find("Text Pop-Up").GetComponent<popUp>().inConversation = true;
        GameObject.Find("Player").GetComponent<playerMovement>().speed = 0;
        gameObject.SetActive(false);
    }
}
