using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public string　ItemTag = "Item";
    public string TextTag = "Text";

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("左クリック");
            Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //マウスクリックした場所からRayを飛ばし、オブジェクトがあればtrue 
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.CompareTag(ItemTag))
                {
                    hit.collider.gameObject.GetComponent<ItemControl>().OnUserAction();
                }
                if (hit.collider.gameObject.CompareTag(TextTag))
                {
                    hit.collider.gameObject.GetComponent<TextControl>().OnUserAction();
                }
            }
        }
    }

}
