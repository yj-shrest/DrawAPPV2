using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    // Start is called before the first frame update
   void OnMouseDown()
   { 
    if(gameObject.name =="EraserIcon")
    {
    Draw.tool="eraser";
    Draw.zvalue -=0.1f; 
    Debug.Log("Eraser Clicked");
    }
    if(gameObject.name =="PencilIcon")
    {
    Draw.zvalue -=0.1f;
    Draw.tool="pencil";
    Debug.Log("PencilClicked");
    }
    if(gameObject.name =="clearIcon")
    {
    Draw.zvalue = 9f;
    Draw.tool="clear";
    Debug.Log("Clear clckd");
    }
   }
}
