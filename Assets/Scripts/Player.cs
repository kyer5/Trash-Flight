using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    
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
        
    }
}
