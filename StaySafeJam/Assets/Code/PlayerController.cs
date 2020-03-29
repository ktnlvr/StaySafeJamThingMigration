using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    bool walkingSFX;
    public GameObject SummonParticles;
    public GameObject CollectorHive;
    [Space(10)]
    public float mouseSensetivty = 3f;
    public float speed = 3f;
    public float jumpForce = 12f;
    public CharacterController controller;
    public float gravity = 9.81f * 3;
    public Transform cameraControl;
    public bool isSprinting;
    public float dragOffset;
    public Camera cam;
    public TextMeshProUGUI debugText;
    Vector3 lastPos;

    float xRotation = 0f;
    Vector3 Velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameManager.honey = 8;
        GameManager.honeyUpd.AddListener(IncrementHoneyCounter);
    }

    void IncrementHoneyCounter()
    {
        HoneyCounter.text = GameManager.honey.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameManager.honey);
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            if (hit.collider.gameObject.GetComponent<Beehive>())
            {
                Beehive rayData = hit.collider.gameObject.GetComponent<Beehive>();
                debugText.text = $"Effect Radius: {rayData.ScanRadius}\n" +
                                    $"Work Time: {rayData.WorkTime}\n" +
                                    $"Pollen Capacity: {rayData.PollenCapacity}\n" +
                                    $"Flowers Around: {rayData.plants.Count}\n" +
                                    $"Honey Capacity: {rayData.HoneyCapacity}\n" +
                                    $"Honey Amount: {rayData.PollenAmount / GameManager.CostMultiplier}\n" +
                                    $"Working: {(rayData.working ? "Yes" : "No")}\n" +
                                    $"Automatic: {(rayData.flowMode ? "Yes" : "No")}";


                //rayData.ScanRadius + " Scan Radius, " + rayData.WorkTime + " Work Time, " + rayData.PollenCapacity + " Pollen Capacity, " + rayData.HoneyCapacity + " Honey Capacity";
            }
            else
            {
                debugText.text = "";
            }
        }
        else
        {
            debugText.text = "";
        }
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivty;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivty;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -75f, 75);
        cameraControl.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * Time.deltaTime;

        Vector3 move = (transform.right * x + transform.forward * z) * speed * (isSprinting ? 1.5f : 1f);
        controller.Move(move);

        Velocity.y += -gravity * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            Velocity.y += jumpForce;
        } else if(controller.isGrounded && Velocity.y < 0)
        {
            Velocity.y = 0f;
        }

        if (transform.position.y < -20)
        {
            transform.position = new Vector3(0, 11, 0);
            Velocity = new Vector3(0,0,0);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
            isSprinting = true;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            isSprinting = false;
        

        if(Input.GetKeyDown(KeyCode.R))
        {
            if (GameManager.honey >= 4)
            {
                Vector3 landPosition = transform.position + transform.forward * 2 + transform.up * 30;
                GameManager.honey -= 4;
                Instantiate(CollectorHive, landPosition, transform.rotation);
            }
            
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            purchaseMenu.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            purchaseMenu.SetActive(false);
        }
    }
}
