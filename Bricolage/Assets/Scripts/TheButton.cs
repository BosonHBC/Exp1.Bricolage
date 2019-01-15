using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TheButton : MonoBehaviour
{
    public Items theItem;
    private Text title;
    private Image _texture;
    // Start is called before the first frame update
    void Start()
    {
        title = transform.GetChild(0).GetComponent<Text>();
        if (theItem == null)
            Debug.Log("Error! No item in this button");
        else
        {
            title.text = theItem.Name;
            _texture = GetComponent<Image>();
            _texture.sprite = theItem.texture;
        }

     }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton()
    {
        Debug.Log("Onclick item");
        GameManager.instance.ChangeItems(theItem.gameObject);
    }
}
