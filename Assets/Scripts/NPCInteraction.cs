using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public float GridSize;
    public Color HoverColor;
    public LayerMask Ignore;
    public float Timer;

    private Color OriginalColor;
    private bool YaHangingThere = false;
    private Vector3 Offset;

    private void Start()
    {
        OriginalColor = GetComponent<SpriteRenderer>().color;
    }

    private void Update()
    {
        if (!YaHangingThere)
        {
            if (MouseHover())
            {
                GetComponent<SpriteRenderer>().color = HoverColor;

                if (Input.GetKey(KeyCode.Mouse0))
                {
                    Timer -= Time.deltaTime;
                    if (Timer < 0)
                    {
                        YaHangingThere = true;
                        Offset = transform.position - RatInACage();
                    }

                }
                else
                {
                    YaHangingThere = false;
                    Timer = 0.25f;
                }
            }
            else GetComponent<SpriteRenderer>().color = OriginalColor;
        }
        else
        {
            Vector3 CursorPos = RatInACage() + Offset;
            Vector3 SnappedPos = new Vector3(
                Mathf.Round(CursorPos.x / GridSize) * GridSize,
                CursorPos.y = 2f,
                Mathf.Round(CursorPos.z / GridSize) * GridSize);
            transform.position = Vector3.Lerp(CursorPos,SnappedPos,2f);
            if (Input.GetKeyUp(KeyCode.Mouse0))
                YaHangingThere = false;
        };
    }

    bool MouseHover()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        return !Input.GetKey(KeyCode.Mouse1) && !Input.GetKey(KeyCode.Mouse2) && Physics.Raycast(ray, out hit) && hit.collider.name == name;
    }
    
    Vector3 RatInACage()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~Ignore))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}