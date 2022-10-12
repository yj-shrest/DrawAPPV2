using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Draw : MonoBehaviour
{   
    [SerializeField]
    GameObject pointPrefab1,pointPrefab2,UI;
    List<GameObject> ls = new List<GameObject>();


    public static string tool="pencil";
    public static float zvalue = 9f;
    void Update()
    {
     draw();  
    }
    
    void draw()
    {  

        if(Input.GetKey(KeyCode.Mouse0))
        {

        if(tool=="pencil")
            {
            Vector3 mpos = new Vector3 (Input.mousePosition.x,Input.mousePosition.y,zvalue);
            Vector3 pos = Camera.main.ScreenToWorldPoint(mpos);
            GameObject point = Instantiate(pointPrefab1);
            ls.Add(point);
            point.transform.localPosition = pos;
            }
            if(tool=="eraser")
            {
            Vector3 mpos = new Vector3 (Input.mousePosition.x,Input.mousePosition.y,zvalue);
            Vector3 pos = Camera.main.ScreenToWorldPoint(mpos);
            GameObject point = Instantiate(pointPrefab2);
            point.transform.localPosition = pos;
            ls.Add(point);
            }
            if(tool=="clear")
            {
                foreach (GameObject point in ls)
                {
                    Destroy(point);
                }
                StartCoroutine(Delay());
                

            }
        
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        tool="pencil";
    }
     IEnumerator ss()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width,Screen.height*7/9,TextureFormat.RGB24,false);
        texture.ReadPixels(new Rect(0,Screen.height*2/9,Screen.width,Screen.height*7/9),0,0);
        texture.Apply();
        string name ="Image"+System.DateTime.Now.ToString("HH-mm-ss")+".png";
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/SavedPictures/"+name ,bytes);
        
        Destroy(texture);
        UI.SetActive(true);
        }

        public void takess()
    {   
        UI.SetActive(false);
        StartCoroutine(ss());
    }

}
