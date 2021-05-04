using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetActive(bool state)
    {
        transform.gameObject.SetActive(state);
    }
    public void SetText(string text)
    {
        GetComponent<TextMesh>().text = text;
    }

}



