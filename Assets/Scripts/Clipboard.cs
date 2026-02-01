using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

public class Clipboard : MonoBehaviour
{
    public enum BoardState{open,closed}
    public BoardState boardState;
    private RectTransform selfTransform;
    public float closedPos;
    public float openPos;
    public float moveTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selfTransform = this.GetComponent<RectTransform>();
        boardState = BoardState.closed;
    }

    public void ToggleBoardState()
    {
        //Debug.Log("Clipboard clicked");
        if(boardState == BoardState.closed)
        {
            selfTransform.DOMoveY(openPos,moveTime);
            boardState = BoardState.open;
        }
        else if(boardState == BoardState.open)
        {
            selfTransform.DOMoveY(closedPos,moveTime);
            boardState = BoardState.closed;
        }
    }
}
