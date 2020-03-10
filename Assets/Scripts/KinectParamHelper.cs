using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(KinectParam))]
public class KinectParamHelper : MonoBehaviour
{
    KinectParam param;
    public RectTransform optionPanel;
    public Slider controller;
    public Text valueText;

    void Awake(){
        param = GetComponent<KinectParam>();
    }

    void Start()
    {
        controller.onValueChanged.AddListener(OnController);
        param.unitMoveShift = PlayerPrefs.GetFloat("KinectUnitShift", 1);
        controller.value = param.unitMoveShift;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            optionPanel.gameObject.SetActive(!optionPanel.gameObject.activeSelf);
        }
    }

    void OnController(float val){
        param.unitMoveShift = val;
        valueText.text = val.ToString("0.00");
        PlayerPrefs.SetFloat("KinectUnitShift", val);
    }

    public void QuitApp(){
        Application.Quit();
    }
}
