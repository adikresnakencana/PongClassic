using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kodingPemain : MonoBehaviour
{  
    public float btsAtas;
    public float btsBawah;
    public float kecepatan;
    public string axis;
 
    // Use this for initialization
    void Start () {
 
    }
    
    // Update is called once per frame
    void Update () {
        float gerakan = Input.GetAxis (axis) * kecepatan * Time.deltaTime;
        float nextPos = transform.position.y + gerakan;
        if (nextPos > btsAtas) {
            gerakan = 0;
        }
        if (nextPos < btsBawah) {
            gerakan = 0;
        }
        transform.Translate (0, gerakan, 0);
    }
}