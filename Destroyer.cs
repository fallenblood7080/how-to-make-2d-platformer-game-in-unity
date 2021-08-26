using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] float timeLeft;
    void Update()
    {
        Destroy(this.gameObject, timeLeft);
    }
}
