using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aviao : MonoBehaviour {
    private Rigidbody2D fisica;
    [SerializeField]
    private float forca;
    private Diretor diretor;
    private Vector3 posicaoInicial;
    private bool deveImpulsionar;
    // private Animator animacao;
    private int qtdCollider;
    // private ParticleSystem particula;

    private void Awake()
    {  
    
        
        this.posicaoInicial = this.transform.position;
        this.fisica = this.GetComponent<Rigidbody2D>();
        // this.animacao = this.GetComponent<Animator>();
        //  ParticleSystem ps = GetComponent<ParticleSystem>();
        // var coll = ps.collision;
        // coll.enabled = true;
        // coll.bounce = 0.5f;
    }

    private void Start()
    {
        this.qtdCollider = 0;
        // particula = GetComponent<ParticleSystem>();
        // particula.Stop(true);
        this.diretor = GameObject.FindObjectOfType<Diretor>();
    }

    private void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            this.deveImpulsionar = true;
        }
        // if (this.fisica.velocity.y != null){
        // // this.animacao.SetFloat("VelocidadeY", this.fisica.velocity.y);
        // }
	}

    private void FixedUpdate()
    {
        if(this.deveImpulsionar)
        {
            this.Impulsionar();
        }
        
    }

    public void Reiniciar()
    {
        this.transform.position = this.posicaoInicial;
        this.fisica.simulated = true;
    }

    private void Impulsionar()
    {
        this.fisica.velocity = Vector2.zero;
        this.fisica.AddForce(Vector2.up * this.forca, ForceMode2D.Impulse);
        this.deveImpulsionar = false;
    }

    private void OnCollisionEnter2D(Collision2D colisao)
    {
        
        if(this.qtdCollider<=1){
            this.qtdCollider++;
        }else{
            this.fisica.simulated = false;
            this.diretor.FinalizarJogo();
            this.qtdCollider = 0;
        }
        
    }
}
