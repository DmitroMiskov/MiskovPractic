using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour
{
    public float offset;

    public GameObject ammo;
    public Transform shotDir;

    private float timeShot;
    public float startTime;

    public int currentAmmo = 8;
    public int allAmmo = 0;
    public int fullAmmo = 24;

    public GameObject ammoPistol;
    public Pistol pistol;

    [SerializeField]
    private Text ammoCount;

    void Start()
    {
        ammoCount.text = $"{currentAmmo}/{allAmmo}";
    }

    void Update()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        if (timeShot <= 0 )
        {
            if(Input.GetMouseButton(0) && currentAmmo > 0)
            {
                Instantiate(ammo, shotDir.position, transform.rotation);
                timeShot = startTime;
                currentAmmo--;
            }
            
        }
        else
        {
            timeShot -= Time.deltaTime;
        }
        

        ammoCount.text = $"{currentAmmo}/{allAmmo}";


        if (Input.GetKeyDown(KeyCode.R) && allAmmo > 0)
        {
            StartCoroutine(Reload());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BulletsShotgun>())
        {
            allAmmo += 8;
            Destroy(collision.gameObject);
        }

        else if(collision.GetComponent<PistolClip>())
        {
            if(pistol == null)
            {
                Debug.LogError("Pisto is NULL");
                return;
            }
            pistol.allAmmo += 15;
            Destroy(collision.gameObject);
        }

    }

    public IEnumerator Reload()
    {
        int reason = 8 - currentAmmo;

        if (allAmmo >= reason)
        {
            for (int i = 0; i < reason; i++)
            {
                yield return new WaitForSeconds(1);
                currentAmmo += 1;
                allAmmo -= 1;
            }
        }
        else
        {
            for (int i = 0; i < allAmmo; i++)
            {
                yield return new WaitForSeconds(1);
                currentAmmo += 1;
                allAmmo -= 1;
            }
        }
        
    }
}
