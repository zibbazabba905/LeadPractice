using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    private HunterAim rHunterAim;
    private WeaponDisplay rWeaponDisplay;

    public Camera fpsCam;
    public GameObject Bullet;
    public Transform BulletSpawn;
    public GameObject ScreenAimPoint;
    public GameObject[] Guns;
    public float ShotDelay;
    private float ShotTime;

    private float _BulletVelocity;
    public float BulletVelocity
    {
        get { return _BulletVelocity; }
        set { _BulletVelocity = value; }
    }
    private void Awake()
    {
        rHunterAim = GetComponent<HunterAim>();
        rWeaponDisplay = GetComponent<WeaponDisplay>();
    }

    void Update()
    {
        if (!GameManager.Instance.InMenus)
        {
            HandleSway();
            HandleShooting();
        }
    }

    private void HandleShooting()
    {
        if ((Time.time > ShotTime + ShotDelay) && rHunterAim.CanShoot && Input.GetButtonDown("Fire1"))
        {
            //FEATURE ADD SHOT LIMITER
            //StartCoroutine(ShootingDelay());
            ShotTime = Time.time;
            
            //TimerTest = new Timer(ShotDelay);

            //find hitpoint
            Ray ray = fpsCam.ViewportPointToRay(AimPointCalc());
            RaycastHit hit;
            Vector3 targetPoint;

            //check for hit
            if (Physics.Raycast(ray, out hit))
                targetPoint = hit.point;
            else
                targetPoint = ray.GetPoint(300);//if no hit point far out

            //calculate direction
            Vector3 ShotDirection = targetPoint - BulletSpawn.position;

            //Instantiate bullet
            GameObject currentBullet = Instantiate(Bullet, BulletSpawn.position, Quaternion.identity);
            //rotate bullet to shoot direction (do with instantiate instead?)
            currentBullet.transform.forward = ShotDirection.normalized;
            //set future point for raycasting Nope, tell bullet its speed let it do that shit itself;
            currentBullet.GetComponent<BulletScript>().BulletVelocity = BulletVelocity;
        }
    }
    
    private Vector3 AimPointCalc()
    {
        Vector3 ap = ScreenAimPoint.transform.position;
        float w = Screen.width;
        float h = Screen.height;
        return new Vector3(ap.x / w, ap.y / h, 1f);
    }

    private void HandleSway()
    {
        ScreenAimPoint.transform.position = ScreenAimPoint.transform.position + rWeaponDisplay.SwayTest();
    }
}



