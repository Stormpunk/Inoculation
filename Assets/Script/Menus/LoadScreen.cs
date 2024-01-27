using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{
    public static LoadScreen instance;
    public GameObject loadScreen;
    public Slider loadBar;
    public Text progressText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        loadBar = GetComponentInChildren<Slider>();
        progressText = GetComponentInChildren<Text>();
    }
}
