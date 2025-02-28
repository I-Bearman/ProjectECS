using UnityEngine;
using Zenject;
using static MyInsteller;

public class injectionTest : MonoBehaviour
{
    private ITest _test;
    [Inject]
    public void Init(ITest t)
    {
        _test = t;
    }
    // Start is called before the first frame update
    void Start()
    {
        _test.Echo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
