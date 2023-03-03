using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPControl : MonoBehaviour
{
    //HP

    private Image image;

    GameObject player;
    PlayerControl script;

    //������
    private float recTime=0f;
    private float recSpan=1.0f;//�񕜃y�[�X


    private void Start()
    {
        image = this.GetComponent<Image>();

        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();

    }

    private void Update()
    {

       image.fillAmount = script.HP / 160;

        if(script.Rec==true)//�����񕜃A�C�e���擾�����s
        {

            recTime += Time.deltaTime;

            if (recTime > recSpan)
            {
                if (script.HP<script.HPLimit)
                {
                    script.HP += 0.1f;//0.1��
                }
                recTime = 0f;
            }
        }
    }
}
