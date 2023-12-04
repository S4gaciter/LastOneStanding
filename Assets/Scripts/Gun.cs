using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Transform barrelOrigin;
    public LayerMask enemyLayer;
    private UIManager uiManager;

    public GunStats stats;

    Camera cam;
    float fov;

    bool ads;
    bool firing;
    bool reloading;

    // Initialization
    private void Awake()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        cam = GameObject.Find("PlayerCamera").GetComponent<Camera>();

        ads = false;
        firing = false;
        reloading = false;
    }
    private void Start()
    {
        stats.currentMag = stats.magazineSize;
        stats.currentAmmo = stats.maxAmmo;
        fov = cam.fieldOfView;
        UpdateGunUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.automatic)
        {
            if (Input.GetMouseButton(0) && !firing && !reloading && stats.currentMag > 0)
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && !firing && !reloading && stats.currentMag > 0)
            {
                Shoot();
            }
        }
        if ((Input.GetKeyDown(KeyCode.R) && stats.currentMag < stats.magazineSize && !reloading) || Input.GetMouseButton(0) && !reloading && stats.currentMag == 0)
        {
            Reload();
        }
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonUp(1))
        {
            ToggleADS();
        }
    }

    public void Shoot()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, stats.range, enemyLayer))
        {
            if (hit.transform.gameObject.GetComponent<Enemy>() != null)
            {
                Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
                enemy.RecieveDamage(stats.damage);
            }
        }
        stats.currentMag--;
        stats.currentAmmo--;
        UpdateGunUI();
        firing = true;
        Invoke(nameof(RefreshFiring), stats.fireRate);
    }

    void Reload()
    {
        reloading = true;
        Invoke(nameof(RefreshReload), stats.reloadTime);
    }

    void ToggleADS()
    {
        switch(ads)
        {
            case true:
                cam.fieldOfView = fov;
                ads = false;
                break;
            case false:
                cam.fieldOfView = fov / stats.scopeMultiplier;
                ads = true;
                break;
        }
    }

    public void UpdateGunUI()
    {
        uiManager.SetAmmoText(stats.currentMag, stats.maxAmmo - stats.currentMag);
    }

    void RefreshFiring()
    {
        firing = false;
    }
    void RefreshReload()
    {
        reloading = false;
        stats.currentMag = stats.magazineSize;
        UpdateGunUI();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * stats.range);
    }
}
