using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BomGetControl : MonoBehaviour
{
    //���ʉ�
    public GameObject gunSound;

    GameObject player;
    PlayerControl script;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //�v���C���[�Ɏ擾���������
        if (other.gameObject.tag == "Player")
        {
            script.Ui2 = "C�L�[�Ŕ��e��u��";
            script.UiDecision2 = true;

            Instantiate(gunSound, this.transform.position, this.transform.rotation);//���ʉ�
            Destroy(gameObject);
        }

    }


}
