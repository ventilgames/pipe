using UnityEngine;

public class GameDataTest : MonoBehaviour
{
    private TestData _data = new TestData();

    private void OnEnable()
    {
        _data.Load();
    }

    private void OnDisable()
    {
        _data.Save();
    }
}
