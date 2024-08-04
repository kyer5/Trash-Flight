using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [FormerlySerializedAs("weapon")] [SerializeField]
    private GameObject[] weapons;

    private int weaponIndex = 0;

    [SerializeField] 
    private Transform shootTransform;

    [SerializeField] 
    private float shootInterval = 0.05f;
    private float lastShotTime = 0f;
    // Update is called once per frame
    void Update()
    { 
        /*float horizontalInput = Input.GetAxisRaw("Horizontal");
        //float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveTo1 = new Vector3(horizontalInput, 0f, 0f);
        transform.position += moveTo1 * moveSpeed * Time.deltaTime;

        Vector3 moveTo2 = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= moveTo2;
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += moveTo2;
        }*/

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);

        Shoot();
    }

    void Shoot()
    {
        if (Time.time - lastShotTime > shootInterval) 
        {
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Coin")
        {
            GameManager.instance.IncreaseCoin();
            Destroy(other.gameObject);
        }
    }

    public void Upgrade()
    {
        weaponIndex++;
        if (weaponIndex >= weapons.Length)
        {
            weaponIndex = weapons.Length - 1;
        }
    }
    
}
