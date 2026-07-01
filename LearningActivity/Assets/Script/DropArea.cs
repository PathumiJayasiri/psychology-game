
using UnityEngine;
using UnityEngine.EventSystems;


public class DropArea : MonoBehaviour, IDropHandler
{

    public string category;



    public void OnDrop(PointerEventData eventData)
    {

        DraggableItem item =
        eventData.pointerDrag.GetComponent<DraggableItem>();


        if(item == null)
            return;



        // Already placed item
        if(item.dropped)
            return;



        // Move item into box
        item.transform.SetParent(transform);



        RectTransform rt =
        item.GetComponent<RectTransform>();


        rt.anchoredPosition = Vector2.zero;



        bool answer =
        item.correctCategory == category;



        item.SetAnswer(answer);

    }

}