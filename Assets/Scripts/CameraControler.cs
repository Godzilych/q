using UnityEngine;
using System.Collections;

public class CameraControler : MonoBehaviour
{
    public float cameraSpeed;
    public GameObject target;
    //public Camera camera;

    void Start ()
    {
        target = GameObject.Find("Target");
        //camera = GetComponent<Camera>();
        TestStepaATD();
    }

    private void TestStepaATD()
    {
        //IStepaATDVector vector = new StepaATDVectorViaList();

        //vector.AddToEnd("Первый элемент");
        //vector.AddToEnd("Второй элемент");
        //vector.AddToEnd("Третий элемент");
        //vector.AddAt(2, "Второй с половиной элемент");

        //Debug.Log("Complete");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        transform.Translate( direction * cameraSpeed * Time.deltaTime, Space.World);

        if (Input.GetButton("Fire1"))
        {
            Ray pointClicked = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(pointClicked,out hit))
            {
                Debug.Log(hit.point);
                target.transform.Translate(-target.transform.position.x + hit.point.x, 0, -target.transform.position.z + hit.point.z);
                target.SetActive(true);
            }
        }
    }
}
