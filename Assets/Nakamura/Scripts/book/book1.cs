using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class book1 : MonoBehaviour
{
    
    [SerializeField] private Toggle toggle;
    public static int a =0;
    public static bool shopDefense;

    void Start()
    {
        //���łɔ����Ă���Ȃ�A�N���b�N���ł��Ȃ��悤�ɂ��A�`�F�b�N�}�[�N��t����
        if (a == 1)
        {

	        toggle.interactable = false;
            toggle.isOn = true;
        }
    }

    void Update()
    {
       
    }
    public void OnToggleChanged()
    {
        //�w�����Ă��Ȃ����
        if (a == 0)
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
                    toggle.interactable = false;
	    		    a = 1;
                    shopDefense = true;
            }

        } 
         
        
       
    }

}
