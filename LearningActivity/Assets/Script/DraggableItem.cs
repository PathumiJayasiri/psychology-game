
// using UnityEngine;
// using UnityEngine.EventSystems;
// using TMPro;

// public class DraggableItem : MonoBehaviour,
//     IBeginDragHandler,
//     IDragHandler,
//     IEndDragHandler
// {

//     private CanvasGroup canvasGroup;
//     private RectTransform rectTransform;

//     private Vector3 startPosition;

//     public string correctCategory;

//     public bool dropped = false;

//     private TextMeshProUGUI text;


//     void Awake()
//     {
//         canvasGroup = GetComponent<CanvasGroup>();

//         rectTransform = GetComponent<RectTransform>();

//         text = GetComponent<TextMeshProUGUI>();

//         startPosition = transform.position;
//     }


//     // When player starts dragging
//     public void OnBeginDrag(PointerEventData eventData)
//     {

//         // Block dragging until instruction closed
//         if(!GameState.gameStarted)
//             return;


//         // Already placed item cannot move
//         if(dropped)
//             return;


//         canvasGroup.alpha = 0.6f;

//         // Allows DropArea to receive the drop
//         canvasGroup.blocksRaycasts = false;

//     }



//     // While dragging
//     public void OnDrag(PointerEventData eventData)
//     {

//         if(!GameState.gameStarted)
//             return;


//         if(dropped)
//             return;


//         rectTransform.position = eventData.position;

//     }



//     // When mouse released
//     public void OnEndDrag(PointerEventData eventData)
//     {

//         canvasGroup.alpha = 1f;

//         canvasGroup.blocksRaycasts = true;


//         // If not dropped into a box
//         if(!dropped)
//         {
//             transform.position = startPosition;
//         }

//     }



//     // Called by DropArea after successful drop
//     public void LockItem()
//     {
//         dropped = true;

//         canvasGroup.blocksRaycasts = true;
//     }



//     // Change wrong answer text colour
//     public void ChangeToWrongColor()
//     {

//         if(text != null)
//         {
//             text.color = Color.red;
//         }

//     }



//     // Optional reset for restarting game
//     public void ResetItem()
//     {

//         dropped = false;

//         text.color = Color.white;

//         transform.position = startPosition;

//     }

// }

using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


public class DraggableItem : MonoBehaviour,
IBeginDragHandler,
IDragHandler,
IEndDragHandler
{

    private CanvasGroup canvasGroup;

    private RectTransform rectTransform;

private Transform originalParent;
    private Vector3 startPosition;


    public string correctCategory;


    public bool dropped = false;


    public bool correctAnswer = false;


    private TextMeshProUGUI text;


    private bool locked = false;



    void Awake()
    {

        canvasGroup = GetComponent<CanvasGroup>();

        rectTransform = GetComponent<RectTransform>();

        text = GetComponent<TextMeshProUGUI>();

   // Save original position and parent
    startPosition = rectTransform.position;
    originalParent = transform.parent;


    // Reset state
    dropped = false;
    correctAnswer = false;
    locked = false;


    canvasGroup.blocksRaycasts = true;
        }



    public void OnBeginDrag(PointerEventData eventData)
    {

        if(!GameState.gameStarted)
            return;


        if(locked)
            return;


        canvasGroup.alpha = 0.6f;

        canvasGroup.blocksRaycasts = false;

    }



    public void OnDrag(PointerEventData eventData)
    {
         if(!GameState.gameStarted)
        return;


        if(locked)
            return;


        rectTransform.position = eventData.position;

    }



    public void OnEndDrag(PointerEventData eventData)
    {

        canvasGroup.alpha = 1f;

        canvasGroup.blocksRaycasts = true;


        if(!dropped)
        {
            transform.position = startPosition;
        }

    }



    public void SetAnswer(bool value)
    {
 correctAnswer = value;
    dropped = true;


 LockItem();


    GameManager.instance.ItemDropped();
            }



    public void LockItem()
    {
        locked = true;

        canvasGroup.blocksRaycasts = false;
    }



    public void ChangeToWrongColor()
    {

        text.color = Color.red;

    }



    public void ChangeToCorrectColor()
    {

        text.color = Color.green;

    }



    public void ResetItem()
    {

   dropped = false;

    correctAnswer = false;

    locked = false;


    // Return to original parent
    transform.SetParent(originalParent);


    // Reset position
    rectTransform.position = startPosition;


    // Reset colour
    if(text != null)
    {
        text.color = Color.black;
    }


    // Enable dragging again
    canvasGroup.blocksRaycasts = true;
    }
public void EnableDragging()
{
    canvasGroup.blocksRaycasts = true;

    locked = false;
}
}