using UnityEngine;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Manager Referances")]
    public SystemManager systemManager;
    public AudioManager audioManager;
    [Header("Object Referances")]
    public GameObject menuUI;
    public GameObject howToUI;
    [Header("Paramiters")]
    public float fadeTime = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FetchUIElements();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FetchUIElements()
    {
        if(menuUI == null)
        {
            menuUI = GameObject.FindWithTag("MenuPanel");
        }
        if(howToUI == null)
        {
            howToUI = GameObject.FindWithTag("HowToPanel");
        }
    }
}
