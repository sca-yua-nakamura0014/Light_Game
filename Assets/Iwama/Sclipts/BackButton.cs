
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : CheckButton
{
    GameObject number;
    CheckButton script;
 
    public void PushButtonDialBack()//�~�{�^���������ꂽ���̏���
    {
        number = GameObject.Find("Check");
        script = number.GetComponent<CheckButton>();
        
        script.inputString = "";
        suuji.text = "";
        Panel.SetActive(false);

        Debug.Log("�߂�");
    }

}

