using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWeapons : MonoBehaviour
{
    public List<GameObject> bag = new List<GameObject>();
    public GameObject inv;
    public GameObject selectorWeapon;
    public int id;
    public static string weaponName;
    public float fireRate;
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public int bulletsCant;
    public int bulletsCant2;
    public int bulletsCant3;
    [SerializeField]private float timeUntilFire;
    private CharacterMovement chM;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapons"))
        {
            GetComponent<CharacterMovement>().hasGun = true;
            for (int i = 0; i < bag.Count; i++)
            {
                if (bag[i].GetComponent<Image>().enabled == false)
                {
                    bag[i].GetComponent<Image>().enabled = true;
                    bag[i].GetComponent<Image>().sprite = other.GetComponent<SpriteRenderer>().sprite;
                    break;
                }
            }
            Destroy(other.gameObject);
        }
    }

    public void Navegar()
    {
        if (Input.GetKeyDown(KeyCode.X) && id < bag.Count - 1)
        {
            id++;
        }

        if (Input.GetKeyDown(KeyCode.Z) && id > 0)
        {
            id--;
        }

        selectorWeapon.transform.position = bag[id].transform.position;
    }

    public void WeaponName()
    {
        if (bag[id].GetComponent<Image>().enabled == false)
        {
            weaponName = "null";
        }
        else
        {
            weaponName = bag[id].GetComponent<Image>().sprite.name;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        chM = gameObject.GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        WeaponName();
        Navegar();
        if (Input.GetKeyDown(KeyCode.R) && timeUntilFire < Time.time)
        {
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }   
    }

    void Shoot()
    {
        if (weaponName == "gun1" && bulletsCant > 0 && CharacterMovement.aim)
        {
            fireRate = 1;
            bulletsCant--;
            Bullet.bulletSpeed = 20;
            Bullet.bulletDamage = 5;
        } else if (weaponName == "gun2" && bulletsCant2 > 0)
        {
            fireRate = .5f;
            bulletsCant2--;
            Bullet.bulletSpeed = 30;
            Bullet.bulletDamage = 10;
        }
        else if (weaponName == "gun3" && bulletsCant3 > 0)
        {
            fireRate = 1.5f;
            bulletsCant3--;
            Bullet.bulletSpeed = 50;
            Bullet.bulletDamage = 20;
        }
        float angle = chM.facing ? 0f : 180f;
        Instantiate(bulletPrefab, shootingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
        
    }
}
