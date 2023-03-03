using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHole3 : MonoBehaviour
{
    //�W�����v��Ɍ������邩����X�N���v�g�i���j
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

    //�W�����v��Ɍ������邩
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hole")
        {
            script.JumpHole3 = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hole")
        {
            script.JumpHole3 = false;
        }
    }
}
