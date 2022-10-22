using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgScroll : MonoBehaviour
{

    [SerializeField] float speed = 0.3f;
    [SerializeField] float scroll_duration = 1;

    MeshRenderer mesh_rendere;
    bool isScroll = false;
    float time;

    void Awake()
    {
        mesh_rendere = GetComponent<MeshRenderer>();
        time = scroll_duration;
    }

    
    void Update()
    {

        //Scrolling functionality
        if (isScroll)
        {
            time -= Time.deltaTime;
            Vector2 offset = mesh_rendere.sharedMaterial.GetTextureOffset("_MainTex");
            offset.y += Time.deltaTime * speed;

            mesh_rendere.sharedMaterial.SetTextureOffset("_MainTex", offset);

            if(time < 0)
            {
                isScroll = false;
                time = scroll_duration;
            }
        }

    }


    public void startScrolling()
    {
        isScroll = true;
    }
    

}
