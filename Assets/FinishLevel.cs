using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    Node _node;
    void Awake() 
    {
        _node = GetComponent<Node>();
        _node.NodeEnteredHandler += ExitToCredits;
    }

    public void ExitToCredits()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        SceneManager.LoadScene(2);
    }
}
