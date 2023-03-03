using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRangeControl2 : MonoBehaviour
{
    //�W�����v��ɏ������邩����X�N���v�g�i���j

    GameObject player;
    PlayerControl script;

    BoxCollider2D boxCol;
    private float posX, posY;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();

        boxCol = GetComponent<BoxCollider2D>();
        posX = boxCol.size.x;
        posY = boxCol.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        //�W�����vUP�̃A�C�e���E�������Collider�̈ʒu
        if (script.JumpPower==2)
        {
            boxCol.offset = new Vector3(0,  -3.5f, script.JumpPower);
            boxCol.size = new Vector3(posX, script.JumpPower, script.JumpPower);
        }
    }

    //�W�����v��ɏ������邩
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Road")
        {
            script.JumpDecision2 = true;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Road")
        {
            script.JumpDecision2 = false;
        }
    }
}
