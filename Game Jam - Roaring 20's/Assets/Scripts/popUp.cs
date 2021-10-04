using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class popUp : MonoBehaviour
{
    public GameObject ui;
    public Image characterSprite;
    public TextMeshProUGUI act;
    public TextMeshProUGUI mess;
    private GameObject character;
    private Camera cam;
    private GameObject objcam;
    public bool inConversation = false;
    private message[] Messages;
    private Actor[] Actor;
    int num;
    public GameObject tofar;



    private void Start()
    {
        character = GameObject.Find("Player");
        objcam = GameObject.Find("Camera");
        cam = objcam.GetComponent<Camera>();
        Physics2D.queriesStartInColliders = false;
    }

    private void Update()
    {
        if (inConversation == true && (Input.GetKeyDown(KeyCode.Mouse0) == true || Input.GetKeyDown(KeyCode.Space) == true))
        {
            num += 1;
            loadConversation();
            Debug.Log("Load");
        }
        else if(inConversation == true && Input.GetKeyDown(KeyCode.Escape))
		{
            num = 100;
            loadConversation();
		}

        RaycastHit2D cast = Physics2D.Linecast(character.transform.position, cam.ScreenToWorldPoint(Input.mousePosition));


        if (cast.collider != null)
        {
            Debug.DrawLine(character.transform.position, cast.point, Color.red);
            
            if(cast.collider.GetComponent<messageForItem>() != null && Input.GetKeyDown(KeyCode.Mouse0) == true && inConversation == false)
			{
                if (cast.distance <= 5)
                {
                    cast.collider.GetComponent<messageForItem>().set();
                    inConversation = true;
                    character.GetComponent<playerMovement>().speed = 0;
                }
                else
				{
                    StartCoroutine(errorBuffer());
                }
			}
        }       
    }

    public void setInfo(message[] mess, Actor[] act)
	{
        Actor = act;
        Messages = mess;
        num = 0;
        loadConversation();
	}

    private void loadConversation()
	{
        

		if (num <= Messages.Length - 1 && Messages[num] != null)
		{        
            ui.SetActive(true);

            int loadId = Messages[num].id;
            string loadMessage = Messages[num].mess;
            string loadName = Actor[loadId].name;
            Sprite loadSprite = Actor[loadId].sprite;

            characterSprite.sprite = loadSprite;
            act.text = loadName;
            mess.text = loadMessage;
		}
		else
		{
            inConversation = false;
            ui.SetActive(false);
            character.GetComponent<playerMovement>().speed = 5;
		}
	}
    
    IEnumerator errorBuffer()
	{
        tofar.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        tofar.SetActive(false);
	}
}