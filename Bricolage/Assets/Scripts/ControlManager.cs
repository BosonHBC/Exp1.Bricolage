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

        float hori = Input.GetAxis("Horizontal");

        theBar.position += hori* Vector3.right * Time.deltaTime;
        
    }

}
