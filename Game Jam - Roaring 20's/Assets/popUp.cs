using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class popUp : MonoBehaviour
{
    public Actor[] actors;
    public Message[] message;

    public GameObject pop;
    public Image characterSprite;
    public TextMeshProUGUI act;
    public TextMeshProUGUI mess;
    private GameObject character;
    private Camera cam;
    private GameObject objcam;
    
    

    private void Start()
    {
        character = GameObject.Find("Player");
        objcam = GameObject.Find("Camera");
        cam = objcam.GetComponent<Camera>();
        Physics2D.queriesStartInColliders = false;
    }

    private void Update()
    {

        RaycastHit2D cast = Physics2D.Raycast(character.transform.position, cam.ScreenToWorldPoint(Input.mousePosition), 50);

        if(cast.collider != null)
        {
            Debug.DrawLine(character.transform.position, cam.ScreenToWorldPoint(Input.mousePosition), Color.red);
            
        }
        else
        {
            Debug.DrawLine(character.transform.position, cam.ScreenToWorldPoint(Input.mousePosition), Color.green);
        }        
    }

    private void setPopUp(string actorname, Actor[] act, Message[] mess)
    {
        
    }
}

[System.Serializable]
public class Actor
{
    public Sprite sprite;
    public string name;
}

[System.Serializable]
public class Message
{
    public int characterId;
    public string message;
}