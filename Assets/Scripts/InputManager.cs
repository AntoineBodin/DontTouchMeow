using Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public enum Direction { Left, Up, Right, Down, None }

    public static InputManager Instance { get; private set; }

    public GameObject sphere;
    public RectTransform panelTransform;
    SwipeIndicator swipeIndicator;
    Direction direction;
    Vector2 startPos, endPos;
    public float swipeThreshold = 100f;
    bool draggingStarted;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            return;
        }

        draggingStarted = false;
        direction = Direction.None;
    }

    private void Start()
    {
        swipeIndicator = new SwipeIndicator(sphere);
        SwipeEnd();
    }

    public void SwipeStart()
    {
        swipeIndicator.Start();
    }

    public void SwipeStart(Vector2 position)
    {
        swipeIndicator.Start(position);
    }

    public void Swipe(Vector2 newPos)
    {
        swipeIndicator.Swipe(newPos);
    }

    public void SwipeEnd()
    {
        swipeIndicator.Stop();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (GameManager.Instance.IsSequencePlaying) return;
        draggingStarted = true;
        startPos = eventData.pressPosition;
        SwipeStart();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!draggingStarted || GameManager.Instance.IsSequencePlaying) return;

        endPos = eventData.position;

        Vector2 difference = endPos - startPos; // difference vector between start and end positions.

        if (difference.magnitude > swipeThreshold)
        {
            if (Mathf.Abs(difference.x) > Mathf.Abs(difference.y)) // Do horizontal swipe
            {
                direction = difference.x > 0 ? Direction.Right : Direction.Left; // If greater than zero, then swipe to right.
            }
            else //Do vertical swipe
            {
                direction = difference.y > 0 ? Direction.Up : Direction.Down; // If greater than zero, then swipe to up.
            }
        }
        else
        {
            direction = Direction.None;
        }

        Swipe(Camera.main.ScreenToWorldPoint(new Vector3(endPos.x, endPos.y, 10)));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (GameManager.Instance.IsSequencePlaying) return;

        if (draggingStarted && direction != Direction.None)
        {
            //Do something with this direction data.
            Debug.Log("Swipe direction: " + direction);
            // @TODO: Call GameManager
        }

        //reset the variables
        startPos = Vector2.zero;
        endPos = Vector2.zero;
        draggingStarted = false;
        SwipeEnd();
    }
}
