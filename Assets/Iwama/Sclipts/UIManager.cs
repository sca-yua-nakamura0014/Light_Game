using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject Panel;//�{�^������ɂ܂Ƃ߂��p�l��

    void Start()
    {
     Panel.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D Collision)
    {
      Panel.SetActive(true);
    }
}