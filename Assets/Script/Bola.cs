using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bola : MonoBehaviour
{
  	public int kekuatan;
    Rigidbody2D rigid2d;
    int skoreP1;
    int skoreP2;
    Text skoreUIP1;
    Text skoreUIP2;
    GameObject panelSelesai;
    Text teksPemenang;
    AudioSource audio;
    public AudioClip hitSound;
 
    // Use this for initialization
    void Start () {
        rigid2d = GetComponent<Rigidbody2D> ();
        Vector2 arah = new Vector2 (2, 0).normalized;
        rigid2d.AddForce (arah * kekuatan);
        skoreP1 = 0;
        skoreP2 = 0;
        skoreUIP1 = GameObject.Find("Skor1").GetComponent<Text>();
    	skoreUIP2 = GameObject.Find("Skor2").GetComponent<Text>();
    	panelSelesai = GameObject.Find ("PanelSelesai");
    	panelSelesai.SetActive (false);
    	audio = GetComponent<AudioSource> ();
    }
 
    // Update is called once per frame
    void Update () {
 
    }
 
    private void OnCollisionEnter2D (Collision2D colltabrakan) {
    	audio.PlayOneShot (hitSound);
        if (colltabrakan.gameObject.name == "wallkanan") 
        {
        	skoreP1 += 1;
            TampilkanSkor ();
            if (skoreP1 == 5) {
                panelSelesai.SetActive(true);
                teksPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                teksPemenang.text = "Player Blue ------ Pemenang";
                Destroy(gameObject);
                return;
            }
            ResetBola ();
            Vector2 arah = new Vector2 (2, 0).normalized;
            rigid2d.AddForce (arah * kekuatan);
        }
        if (colltabrakan.gameObject.name == "wallkiri") 
        {
        	skoreP2 += 1;
            TampilkanSkor ();
            if (skoreP2 == 5) {
                panelSelesai.SetActive(true);
                teksPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                teksPemenang.text = "Player Pink ------ Pemenang!";
                Destroy(gameObject);
                return;
            }
            ResetBola ();
            Vector2 arah = new Vector2 (-2, 0).normalized;
            rigid2d.AddForce (arah * kekuatan);
        }

        if (colltabrakan.gameObject.name == "Pemain1" || colltabrakan.gameObject.name == "Pemain2") {
            float sudut = (transform.position.y - colltabrakan.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid2d.velocity.x, sudut).normalized;
            rigid2d.velocity = new Vector2(0, 0);    
            rigid2d.AddForce(arah * kekuatan * 2);
        }
    }
    
    void ResetBola () {
        transform.localPosition = new Vector2 (0, 0);
        rigid2d.velocity = new Vector2 (0, 0);
    }


        void TampilkanSkor() {
        Debug.Log("Score P1: " + skoreP1 + " Score P2: " + skoreP2);
        skoreUIP1.text = skoreP1 + "";
        skoreUIP2.text = skoreP2 + "";
    }
}