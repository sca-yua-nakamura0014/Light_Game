using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class book3 : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    public static int c = 0;
    public static bool shopRec;

    void Start()
    {
        //���łɔ����Ă���Ȃ�A�N���b�N���ł��Ȃ��悤�ɂ��A�`�F�b�N�}�[�N��t����
        if (c == 1)
        {
            toggle.isOn = true;
            toggle.interactable = false;
        }
    }

    public void OnToggleChanged()
    {
        //�w�����Ă��Ȃ����
        if (c == 0)
        {
            //�R�C���̖�����1000�ȉ��Ȃ�`�F�b�N�}�[�N��t���Ȃ�
            if (coinstone.allcoin < 1000)
            {
                toggle.isOn = false;
            }

            //������1000�ȏォ�N���b�N���ꂽ��w��
            if (coinstone.allcoin >= 1000 && toggle.isOn == true)
            {
                coinstone.allcoin -= 1000;
                toggle.interactable = false;
                shopRec = true;
                c = 1;
            }


        }



    }
}
