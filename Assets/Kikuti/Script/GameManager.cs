using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�h���b�v����Ǘ�

    GameObject player;
    PlayerControl script;


    public static int attackUp;//�U���́@
    public static int attackSpeedUp;//�U�����x
    public static int speedUp;//�ړ����x
    public static int jumpUp;//�W�����v
    public static int hpUp;//HP
    public static int o2Up;//�_�f������
    public static int defenseUp;//�h���
    public static int attackRange;//�U���͈�
    public static int hpRecUp;//������


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();

       attackUp = 12;//�U���́@
       attackSpeedUp = 5;//�U�����x
       speedUp = 10;//�ړ����x
       jumpUp = 1;//�W�����v
       hpUp = 10;//HP
       o2Up = 5;//�_�f������
       defenseUp = 10;//�h���
       attackRange = 10;//�U���͈�
       hpRecUp = 1;//������
}

    // Update is called once per frame
    void Update()
    {
       
    }

}

