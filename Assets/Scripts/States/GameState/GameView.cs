using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    #region Fields

    [SerializeField] private Text _textStatus;

    #endregion //Fields

    #region Public Methods

    public void Init(string localEndPoint)
    {
        _textStatus.text = "Ready for Connection at " + localEndPoint;
    }

    #endregion //Public Methods
}
