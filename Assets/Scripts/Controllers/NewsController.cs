using UnityEngine;

public class NewsController : MonoBehaviour
{
    private static NewsController _instance;
    public static NewsController Instance { get { return _instance; } }
    public MarkerContents[] news;
    
    private MarkerContents DummyData = new MarkerContents 
    { 
        Content = "a",
        Headline = "a", 
        TargetId = "a" 
    };

private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public MarkerContents TargetNews(string id)
    {
        MarkerContents content = DummyData;
        foreach(MarkerContents item in news)
        {
            if (item.TargetId.Equals(id))
            {
                content = item;
                break;
            }
        }
        return content;
    }
}