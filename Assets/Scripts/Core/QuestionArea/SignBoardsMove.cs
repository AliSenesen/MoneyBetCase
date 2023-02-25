using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Core.QuestionArea
{
    public class SignBoardsMove : MonoBehaviour
    {
        [SerializeField] private List<GameObject> signBoards;

        public void MoveSignBoards()
        {
            foreach (var board in signBoards)
            {
                board.transform.DOMoveZ(45, 4.5f).SetEase(Ease.Linear).SetRelative(true);
            }
        }
        
    }
}