using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class book2 : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    public static bool shopRange;
    public static int b = 0;

    void Start()
    {
        //���łɔ����Ă���Ȃ�A�N���b�N���ł��Ȃ��悤�ɂ��A�`�F�b�N�}�[�N��t����
        if (b == 1)
        {
            toggle.isOn = true;
	        toggle.interactable = false;
        }

    }

    public void OnToggleChanged()
    {
        //�w�����Ă��Ȃ����
        if (b == 0)
       	{
            //�R�C���̖�����500�ȉ��Ȃ�`�F�b�N�}�[�N��t���Ȃ�
            if (coinstone.allcoin < 500)
        	{
            		toggle.isOn = false;
        	}

            //�������T�O�O�ȏォ�N���b�N���ꂽ��w��
            if (coinstone.allcoin >= 500 && toggle.isOn == true)
        	{
            		coinstone.allcoin -= 500;
                    shopRange = true;
                    toggle.interactable = false;
	    		    b = 1;
        	}
	    }
        


       
    }
}

