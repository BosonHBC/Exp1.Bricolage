using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Transform generatePoint;
    [SerializeField] GameObject _currObject;
    [SerializeField] bool b_ApplyPhysics = false;

    [SerializeField] Transform spawnObjectParent;
    private void Awake()
    {
        if (instance == null || instance != this)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeItems(GameObject _prefab)
    {
        if(_currObject == null)
        {
            Debug.Log("Null and Change");
            _currObject = Instantiate(_prefab, generatePoint, false);
            _currObject.name = _prefab.GetComponent<Items>().name;
            _currObject.transform.localPosition = Vector3.zero;
            _currObject.transform.localRotation = Quaternion.identity;
            _currObject.GetComponent<Rigidbody>().useGravity = false;

        }
        // if the button one is nor the same as the hanging one
        else  if (_currObject != null && _currObject.name != _prefab.name)
        {
            Debug.Log("Destroy and change");
            Destroy(_currObject);
            _currObject = Instantiate(_prefab, generatePoint, false);
            _currObject.name = _prefab.GetComponent<Items>().name;
            _currObject.transform.localPosition = Vector3.zero;
            _currObject.transform.localRotation = Quaternion.identity;
            _currObject.GetComponent<Rigidbody>().useGravity = false;
        }

    }

    public void PlaceItems()
    {
        if (_currObject != null)
        {
            _currObject.GetComponent<Rigidbody>().useGravity = true;
            _currObject.transform.parent = spawnObjectParent;
            Items go = _currObject.GetComponent<Items>();
            go.bApplyPhysics = b_ApplyPhysics;
            go.bPlaced = true;
            // clean it, making sure that no object is connecting in the bar
            _currObject = null;
        }
    }

    public void IsApplyPhysics(bool _toggle)
    {
        Debug.Log("Has physics: " + _toggle);
        b_ApplyPhysics = _toggle;
    }
}
