using UnityEngine;

public class GameDataTest : MonoBehaviour
{
    private TestData _data = new TestData();

    private void OnEnable()
    {
        _data.Load();

        Debug.Log(_data.Coins);
    }

    private void OnDisable()
    {
        _data.Save();
    }
}
