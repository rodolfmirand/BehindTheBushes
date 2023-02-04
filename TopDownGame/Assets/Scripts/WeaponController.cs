using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    SpriteRenderer sr;

    [Header("Ponto das Particulas")]
    public Transform pontoParticula;

    [Header("Shoot point")]
    public Transform spawnBullet;

    [Header("Ataque básico")]
    public GameObject bullet;
    public float tempMaxTiro;
    public float tempAtualTiro;

    [Header("Lança Chamas")]
    public GameObject lancaChamas;
    public GameObject fireObject;
    public float tempMaxChamas;
    public float tempAtualChamas;
    public float cdMaxChamas;
    public float cdAtualChamas;
    public bool coolDown;

    [Header("Shotgun shootpoint")]
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    public Transform point5;

    [Header("Shotgun")]
    public GameObject shotgunBullet;
    //public GameObject efeitoShotgun;
    public float cdMaxShotgun;
    public float cdAtualShotgun;
    public int quantidadeTiros;
    public ParticleSystem efeitoShotgun;
    public bool coolDownShotgun = false;
    bool shotgunAtivada = false;
    public GameObject Shotgun;

    [Header("Escudo")]
    public GameObject escudo;
    public Escudo esc;
    public bool escudoAtivado = false;
    private float vidaEscudo;
    public float tempMaxEscudo;
    public float tempAtualEscudo;
    private float vidaMaxEsc;
    public GameObject barraEscudo;

    [Header("Lança Granadas")]
    public GameObject lancaGranada;
    public float cdMaxLancaGranada;
    public float cdAtualLancaGranada;
    public int quantidadeTirosLancaGranada;
    public Text txtGranada;
    //public ParticleSystem efeioLancaGranada;
    public GameObject LancaGranadaBullet;
    public bool coolDownLancaGranada = false;
    public Transform granadaSpawn;
    public bool granadaOn = false;

    [Header("Minigun")]
    public GameObject minigun;
    public float cdMaxMinigun;
    public float cdAtualMinigun;
    public float tempMaxTiroMinigun;
    public float tempAtualTiroMinigun;
    public bool minigunOn = false;
    public GameObject minigunBullet;
    public int quantidadeTirosMinigun;
    public int quantidadeMaxTirosMinigun;
    public Text txtMinigun;
    public ParticleSystem efeitoMinigun;
    public MiniGunCoolDown miniguncd;

    public bool tiroNormal = true;

    [Header("Sons")]
    public AudioSource LancadorGranada;
    public AudioSource LancaChamas;
    public AudioSource tiroPadrao;
    public AudioSource somEscudo;
    public AudioSource tiroShotgun;
    public AudioClip[] tiroMinigun;
    public AudioSource audioSource;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        lancaChamas.SetActive(false);
        fireObject.SetActive(false);  
        escudo.SetActive(false);
        minigun.SetActive(false);
        
        vidaMaxEsc = escudo.GetComponent<Escudo>().vidaMaxEscudo;
        barraEscudo.SetActive(false);
        
        
    }

    void Update()
    {
        Aim();
        Shoot();
        ShotgunShoot();
        AtivarEscudo();

        if(minigunOn == true)
        {
            if(miniguncd.minigunAtira == true)
            {
                if(Input.GetButtonDown("Z"))
                {
                    if(tiroNormal == true)
                    {
                        tiroNormal = false;
                    }else{
                        tiroNormal = true;
                    }   
                }
            }
        }
        
        shotgunAtivada = Shotgun.GetComponent<PlayerLife>().shotgunOn;

        vidaEscudo = escudo.GetComponent<Escudo>().vidaAtualEscudo;

        if(vidaEscudo <= 0)
        {
            escudo.SetActive(false);
            tempAtualEscudo = tempMaxEscudo;
            escudoAtivado = false;
            barraEscudo.SetActive(false);
        }

        txtGranada.text = ""+ quantidadeTirosLancaGranada;
    }

    void AtivarEscudo()
    {
        tempAtualEscudo -= Time.deltaTime;

        if(escudoAtivado == false)
        {
            esc.SetVidaEscudo();
        }

        if(Input.GetButtonDown("E"))
        {

            if(tempAtualEscudo <= 0 && escudoAtivado == false)
            {   
                somEscudo.Play();
                barraEscudo.SetActive(true);
                escudo.SetActive(true);
                escudoAtivado = true;
            }          
        }
    }

    void Shoot(){
        tempAtualTiro -= Time.deltaTime;
        tempAtualTiroMinigun -= Time.deltaTime;

        if(Input.GetButtonDown("Fire1"))
        {
            if(tiroNormal == true)
            {
                if(tempAtualTiro <= 0){
                    Instantiate(bullet, spawnBullet.position, transform.rotation);
                    tempAtualTiro = tempMaxTiro;
                    tiroPadrao.Play();
                }
            }
        }
        if(Input.GetButton("Fire1")){
            
            if(tiroNormal == false)
            {
                if(tempAtualTiroMinigun <= 0)
                {
                    if(miniguncd.minigunAtira == true)
                    {
                        audioSource.PlayOneShot(tiroMinigun[Random.Range(0,2)]);
                        Instantiate(minigunBullet, spawnBullet.position, transform.rotation);
                        Instantiate(efeitoMinigun, pontoParticula.position, pontoParticula.rotation);
                        tempAtualTiroMinigun = tempMaxTiroMinigun;
                        quantidadeTirosMinigun--;
                        txtMinigun.text = ""+quantidadeTirosMinigun;

                        if(quantidadeTirosMinigun <= 0)
                        {
                            //minigunOn = false;
                            cdAtualMinigun = cdMaxMinigun;
                        }
                    }
                }
            }
        }
  
        tempAtualChamas -= Time.deltaTime;

        if(tempAtualChamas <= 0){
            lancaChamas.SetActive(false);
            fireObject.SetActive(false);
            
            coolDown = true;  
        }

        if(coolDown == true){
        
            cdAtualChamas -= Time.deltaTime;
        
        }

        if(Input.GetButtonDown("F")){


            if(cdAtualChamas <= 0){

                LancaChamas.Play();
                StartCoroutine(OnOff());
                
                coolDown = false;

                //lancaChamas.SetActive(true);
                fireObject.SetActive(true);

                tempAtualChamas = tempMaxChamas;
                cdAtualChamas = cdMaxChamas;

            }     
        }

        cdAtualLancaGranada -= Time.deltaTime;
        
        if(Input.GetButtonDown("X") && granadaOn == true){
            if(cdAtualLancaGranada <= 0){
                if(quantidadeTirosLancaGranada > 0)
                {
                    LancadorGranada.Play();
                    Instantiate(LancaGranadaBullet, granadaSpawn.position, transform.rotation);
                    cdAtualLancaGranada = cdMaxLancaGranada;
                    quantidadeTirosLancaGranada--;
                    txtGranada.text = ""+ quantidadeTirosLancaGranada;
                    coolDownLancaGranada = true;
                }
            }
        }
    }

    void ShotgunShoot() 
    {
        cdAtualShotgun -= Time.deltaTime;

        if(quantidadeTiros == 0)
        {
            quantidadeTiros = 2;
            coolDownShotgun = false;
            
        }

        if(Input.GetButtonDown("Fire2"))
        {   
            if(shotgunAtivada == true)
            {
                if(cdAtualShotgun <= 0 && quantidadeTiros > 0)
                {
                    //efeitoShotgun.SetActive(true);
                    tiroShotgun.Play();
                    Instantiate(efeitoShotgun, pontoParticula.position, pontoParticula.rotation);

                    Instantiate(shotgunBullet, point1.position, point1.rotation);
                    Instantiate(shotgunBullet, point2.position, point2.rotation);
                    Instantiate(shotgunBullet, point3.position, point3.rotation);
                    Instantiate(shotgunBullet, point4.position, point4.rotation);
                    Instantiate(shotgunBullet, point5.position, point5.rotation);

                    quantidadeTiros--;

                    if(quantidadeTiros == 0)
                    {
                        cdAtualShotgun = cdMaxShotgun;
                        coolDownShotgun = true;
                    }
                }
            }

            //efeitoShotgun.SetActive(false);
        }
    }

    void Aim(){

        Vector3 mousePos = Input.mousePosition;
        Vector3 screePoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - screePoint.x, mousePos.y - screePoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        sr.flipY = (mousePos.x < screePoint.x);
    }

    public IEnumerator OnOff()
    {
        
        for(int i = 0; i < 15; i++){
            lancaChamas.SetActive(true);
            yield return new WaitForSeconds(0.15f);
            lancaChamas.SetActive(false); 
            yield return new WaitForSeconds(0.15f);

        }
    }
}
