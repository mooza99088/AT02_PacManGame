using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour
{
    [Tooltip("A reference to the overview map game object in the UI for the scene")]
    [SerializeField] private GameObject overviewMap; 

    public bool CursorEnabled
    {
        set
        {
            Cursor.visible = value;
            if(value == true)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Cursor.lockState &= ~CursorLockMode.Locked;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(overviewMap.activeSelf == true)
        {
            ToggleOverviewMap();
        }

    }
    

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if(Input.GetButtonDown("Toggle Map") == true)
        {
            ToggleOverviewMap();
        }
    }



    public bool ToggleOverviewMap()
    {
        overviewMap.SetActive(!overviewMap.activeSelf);
        return overviewMap.activeSelf;
    }

    
}
