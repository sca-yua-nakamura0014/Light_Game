using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinstone : MonoBehaviour
{
    [SerializeField] private Text coinstoneText;
    public static int allcoin =0;//���ׂẴR�C���̖���
    int all = 0;//����l�������R�C���̍��v
    // Start is called before the first frame update
    void Start()
    { 
	    all = PlayerControl.coin+ (PlayerControl.asset * 3);//all�Ɋl�������R�C���Ǝ�����3�{�������̂𑫂�
        allcoin += PlayerControl.coin;//allcoin�Ɋl�������R�C���𑫂�
        allcoin += (PlayerControl.asset * 3);//allcoin�Ɋl������������3�{�������̂𑫂�
        coinstoneText.text = allcoin.ToString();//allcoin��\��
        //Debug.Log(allcoin);
    }

    // Update is called once per frame
    void Update()
    {
        //����l�������R�C���A�����A����̃R�C���̍��v������
        PlayerControl.coin = 0;
        PlayerControl.asset = 0;
        all = 0;
    }
}
