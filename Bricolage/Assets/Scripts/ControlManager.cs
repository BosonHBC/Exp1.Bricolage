using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    public static ControlManager instance;

    private void Awake()
    {
        if (instance == null || instance != this)
            instance = this;
    }

    public Transform theBar;
    public Transform theItem;
    [Range(1,3.7f)]
    [SerializeField] float range;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Place item");
            GameManager.instance.PlaceItems();
        }

        // horizontal movement
        float hori = Input.GetAxis("Horizontal");
        theBar.position += 2*hori* Vector3.right * Time.deltaTime;
        if (theBar.localPosition.x < -range)
            theBar.localPosition = new Vector3(-range, theBar.localPosition.y, theBar.localPosition.z);
        if (theBar.localPosition.x > range)
            theBar.localPosition = new Vector3(range, theBar.localPosition.y, theBar.localPosition.z);

        // vertical rotation
        float vert = Input.GetAxis("Vertical");
        if(theItem!=null)
        theItem.localEulerAngles += vert * new Vector3(0, 0, 45 * Time.deltaTime);
    }

}
