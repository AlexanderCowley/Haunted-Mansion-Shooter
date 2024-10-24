using UnityEngine;
using UnityEngine.SceneManagement;
public class Rails : MonoBehaviour
{
    public Player player;
    //Target Node
    //Current Node
    [SerializeField] Node[] Nodes;
    Node StartingNode;
    [SerializeField] public Canvas GameOverCanvas;

    void Awake() 
    {
        //Node init
        player = FindAnyObjectByType<Player>();
        StartingNode = Nodes[0];
        player.transform.position = StartingNode.transform.position;
        player.SetNode(StartingNode);
    }

    void Start()
    {
        GameOverCanvas.gameObject.SetActive(false);
    }

    public void OnClickRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickQuit()
    {
        SceneManager.LoadScene(1);
    }
    
    //For unity editor stuff
    #if UNITY_EDITOR
    void OnDrawGizmos() 
    {
        //
    }
    #endif
}
