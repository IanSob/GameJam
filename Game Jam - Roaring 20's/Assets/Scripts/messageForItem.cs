using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messageForItem : MonoBehaviour
{
    public message[] Messages;
    public Actor[] Actors;
    
    public void set()
	{
        FindObjectOfType<popUp>().setInfo(Messages, Actors);
	}
}

[System.Serializable]
public class message
{
    public int id;
    public string mess;
}

[System.Serializable]
public class Actor
{
    public Sprite sprite;
    public string name;
}