using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2UpBook : MonoBehaviour
{
    //O2�ϋvUP

    GameObject oxygen;
    OxygenControl script;

    GameObject player;
    PlayerControl script2;


    //���ʉ�
    public GameObject bookSound;

    // Start is called before the first frame update
    void Start()
    {
        oxygen = GameObject.Find("Oxygen");
        script = oxygen.GetComponent<OxygenControl>();

        player = GameObject.Find("Player");
        script2 = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Instantiate(bookSound, this.transform.position, this.transform.rotation);//���ʉ�
            script.O2Up += 0.1f;
            script2.Ui = "�_�f������DOWN";
            script2.UiDecision = true;
            Destroy(gameObject);
        }

    }
}
