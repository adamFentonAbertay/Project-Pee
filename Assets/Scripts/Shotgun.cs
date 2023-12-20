using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{

    private const double V = 0.1;
    public float damage = 10f;
    public float range = 100f;
    public GameObject PlayerObject;
    public Camera fpsCam;
    public Animator RecoilAnim;
    public ParticleSystem muzzleFlash;
    public Vector3 recoilMultiplier = new Vector3(0.1f, 0.1f, 0.1f);
    public AudioSource audioSource;
    public AudioClip audioClip;
    public ParticleSystem collisionEffect;
  


    Vector3 originalPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        } 
    }

    void Shoot()
    {
      
        muzzleFlash.Play();
        RecoilAdd();
        audioSource.PlayOneShot(audioClip, .5f);
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
          //  UnityEngine.ParticleSystem.EmitParams;

            Debug.Log(hit.transform.name);
            var emitParams = new ParticleSystem.EmitParams();
            emitParams.position = hit.transform.position;
            //emitParams.velocity = new Vector3(0.0f, 0.0f, -2.0f);
            collisionEffect.Emit(emitParams, 1);

            //collisionEffect.Play();
            //collisionEffect.Emit(hit.transform.position, 0);

            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
   
    }

    void RecoilAdd()
    {
        RecoilAnim.Play("GunRecoil");

       // RecoilAnimation.;
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");
       // RecoilAnim.Play();
        //RecoilAnim.enabled = true;
        //RecoilAnim.Play("GunRecoil");
      



        //Vector3 recoilVec = PlayerObject.transform.right * x + PlayerObject.transform.forward * z;

        //recoilVec.y = 0.2389994f;

        //transform.position = recoilVec;
    }
}
