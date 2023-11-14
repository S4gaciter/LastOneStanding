using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Transform barrelOrigin;
    public LayerMask enemyLayer;
    private Text uiText;

    public GunStats stats;

    bool firing = false;
    bool reloading = false;
    private void Start()
    {
        uiText = GameObject.Find("AmmoText").GetComponent<Text>();
        UpdateGunUI();
        stats.currentAmmo = stats.maxAmmo;
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
        if (Input.GetKeyDown(KeyCode.R) && stats.currentMag < stats.magazineSize && !reloading)
        {
            Reload();
        }
    }

    public void Shoot()
    {
        if (Physics.Raycast(barrelOrigin.position, barrelOrigin.forward, out RaycastHit hit, stats.range, enemyLayer))
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

    void UpdateGunUI()
    {
        uiText.text = stats.currentMag.ToString() + "/" + (stats.currentAmmo - stats.currentMag).ToString();
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

    public void SetText(Text text)
    {
        {
            uiText = text;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(barrelOrigin.position, barrelOrigin.forward * stats.range);
    }
}
