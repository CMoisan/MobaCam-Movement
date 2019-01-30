using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f;
    public float panBorderThickness = 20f; 
    public Vector2 camOffset;//0 -10
    public Transform playerTransform;
    public Vector3 panLimit; // 40 54 30
    public Vector2 camLimit;
    public float scrollSpeed = 20f;
    public bool camLock = true;
    void Update()
    {
        Vector3 pos = transform.position;
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float posyori = pos.y;
        float poszori = pos.z;
        Debug.Log(scroll);
        if (Input.GetKey("t"))
        {
            Debug.Log("Touche : T");
            camLock = !camLock;
        }
        /////////////////////////Recul camera////////////////////////////////////
        /*      if (pos.y != camLimit.x && pos.y != camLimit.y)
              {
                  Debug.Log("WOLOLO");
                  pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;
                  pos.z += scroll * scrollSpeed * 100f * Time.deltaTime;
                 camOffset.y += scroll * scrollSpeed * 100f * Time.deltaTime;
              }
              else
              {
                  if((pos.y == camLimit.y) && (scroll > 0f))
                  {
                  Debug.Log("Javance");
                   pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;
                   pos.z += scroll * scrollSpeed * 100f * Time.deltaTime;
                  }
                  if ((pos.y == camLimit.x) && (scroll <0f))
                  {
                  Debug.Log("Jrecule");
                      pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;
                      pos.z += scroll * scrollSpeed * 100f * Time.deltaTime;
                  }

              }*/
        if (scroll != 0)
        {
            if ((pos.y != camLimit.x) && (pos.y != camLimit.y) || (pos.y == camLimit.y) && (scroll > 0f) || (pos.y == camLimit.x) && (scroll < 0f))
            {
                Debug.Log("*Chuckle*, I'm in");
                scroll *= 10;
                pos.y -= scroll;                
                camOffset.y += scroll;
                if (pos.y < 15) pos.y = 15;
                if (pos.y > 40) pos.y = 40;
                if (camLock)
                    {
                        pos.z -= scroll;
                        if (pos.z > -15) pos.z = -15;
                        if (pos.z < -40) pos.z = -40;
                        if (camOffset.y < -35) camOffset.y = -35;
                        if (camOffset.y > -10) camOffset.y = -10;
                    }
                else
                {
                    pos.z += scroll;
                }
            }
        }
        //////////////////////////////////Camera lock///////////////////////////////////////
        if (camLock == true)
        {
            pos.x = playerTransform.position.x + camOffset.x; // 0 + 0
            pos.z = playerTransform.position.z + camOffset.y; // -5 + -28 = -33
        }
        ///////////////////////////////////Camera delock//////////////////////////////////
        ////////////////////////Controles/////////////////////////////////////////////
        if (camLock == false)
        {
            if ((Input.GetKey("up") || Input.mousePosition.y >= Screen.height - panBorderThickness))
            {
                Debug.Log("Touche : up ou Souris : Haut");
                pos.z += panSpeed * Time.deltaTime;
            }
            if ((Input.GetKey("down") || Input.mousePosition.y <= panBorderThickness))
            {
                Debug.Log("Touche : down ou Souris : Bas");
                pos.z -= panSpeed * Time.deltaTime;
            }
            if ((Input.GetKey("right") || Input.mousePosition.x >= Screen.width - panBorderThickness))
            {
                Debug.Log("Touche : right ou Souris : Droite");
                pos.x += panSpeed * Time.deltaTime;
            }
            if ((Input.GetKey("left") || Input.mousePosition.x <= panBorderThickness))
            {
                Debug.Log("Touche : left ou Souris : Gauche");
                pos.x -= panSpeed * Time.deltaTime;
            }
        }
        ///////////////////Controle des valeurs/////////////////////////////
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        // pos.y = Mathf.Clamp(pos.y, camLimit.x, camLimit.y);
        pos.y = Mathf.Clamp(pos.y, camLimit.x, camLimit.y);

        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.z);
        ///////////////////////Assignation valeur//////////////////////////////////
        transform.position = pos;        
    }
}
