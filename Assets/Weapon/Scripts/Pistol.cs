using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Pistol : MonoBehaviour, IWeapon
{
    private float timeShot;
    public int currentAmmo;
    public int allAmmo;
    public Transform shotDir;
    public GameObject ammo;
    public float offset;

    public float startTime;
    public int startingAmmo;
    public int maxAmmo;

    [SerializeField]
    private Text ammoCount;

    void Start()
    {
        InitializeParameters();
    }

    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        if (timeShot <= 0 && Input.GetMouseButton(0) && currentAmmo > 0)
        {
            Instantiate(ammo, shotDir.position, transform.rotation);
            timeShot = startTime;
            currentAmmo--;
        }
        timeShot = Mathf.Max(0, timeShot - Time.deltaTime);

        ammoCount.text = $"{currentAmmo}/{allAmmo}";


        if (Input.GetKeyDown(KeyCode.R) && allAmmo > 0)
        {
            Reload();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PistolClip>())
        {
            allAmmo += startingAmmo;
            Destroy(collision.gameObject);
        }
    }

    public void Reload()
    {
        int reason = startingAmmo - currentAmmo;
        if (allAmmo >= reason)
        {
            allAmmo = allAmmo - reason;
            currentAmmo = startingAmmo;
        }
        else
        {
            currentAmmo = currentAmmo + allAmmo;
            allAmmo = 0;
        }
    }

    private void InitializeParameters()
    {
        currentAmmo = startingAmmo;
        allAmmo = 0;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
