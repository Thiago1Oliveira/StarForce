using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float velocidadeY;
    // Start is called before the first frame update
    void Start()
    {
        Direcao = this.transform.up;
    }

    // Update is called once per frame
   private void Update()
    {
         Camera camera = Camera.main;
         Vector3 posicaoNaCamera = camera.WorldToViewportPoint(this.transform.position);

        if(posicaoNaCamera.y > 1){
            Destroy(this.gameObject);

        }
         
        
    }

    public Vector2 Direcao{
        set{
            this.transform.up = value;
            this.rigidbody.velocity = this.transform.up * this.velocidadeY;

        }

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.CompareTag  ("Inimigo"))
        {
            Inimigo inimigo = collider.GetComponent<Inimigo>();
            inimigo.ReceberDano();
            Destroy(this.gameObject);
        }
    }   
}
