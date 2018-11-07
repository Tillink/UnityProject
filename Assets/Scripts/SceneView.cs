using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneView : MonoBehaviour
{
    public GameObject Screen1;
    public GameObject Screen2;
    public GameObject Screen3;

    //public List<GameObject> Scenes;


    private bool _isVisible = false;

	void Start () 
	{


        //Screen1.SetActive(_isVisible);
        //Screen2.SetActive(_isVisible);
        //Screen3.SetActive(_isVisible);
	}

    void Update()
    {
        ClickedButton1();
        ClickedButton2();
        ClickedButton3();
    }

    public void ClickedButton1()
    {
        if (Input.GetMouseButton(0))
        {
            Screen1.SetActive(!_isVisible);
            Screen2.SetActive(_isVisible);
            Screen3.SetActive(_isVisible);
        }
    }

    public void ClickedButton2()
    {
        if (Input.GetMouseButton(0))
        {
            Screen2.SetActive(!_isVisible);
            Screen1.SetActive(_isVisible);
            Screen3.SetActive(_isVisible);
        }
    }

    public void ClickedButton3()
    {
        if (Input.GetMouseButton(0))
        {
            Screen3.SetActive(!_isVisible);
            Screen1.SetActive(_isVisible);
            Screen2.SetActive(_isVisible);
        }
    }

}
