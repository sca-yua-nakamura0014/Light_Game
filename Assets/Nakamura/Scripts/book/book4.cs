using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class book4 : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    public static int d = 0;
    public static bool shopResu;

    void Start()
    {
        //���łɔ����Ă���Ȃ�A�N���b�N���ł��Ȃ��悤�ɂ��A�`�F�b�N�}�[�N��t����
        if (d == 1)
        {
            toggle.isOn = true;
            toggle.interactable = false;
        }
    }

    public void OnToggleChanged()
    {
        //�w�����Ă��Ȃ����
        if (d == 0)
        {
            //�R�C���̖�����5000�ȉ��Ȃ�`�F�b�N�}�[�N��t���Ȃ�
            if (coinstone.allcoin < 5000)
            {
                toggle.isOn = false;
            }

            //������5000�ȏォ�N���b�N���ꂽ��w��
            if (coinstone.allcoin >= 5000)
            {
                coinstone.allcoin -= 5000;
                toggle.interactable = false;
                shopResu = true;
                d = 1;
            }

        }



    }
}
