using System.Collections.Generic;
using Managers;
using Scripts.Core.QuestionArea;
using TMPro;
using UnityEngine;

namespace Core.QuestionArea
{
    public class BetArea : MonoBehaviour
    {
        [SerializeField] private BetBelt leftBelt;
        [SerializeField] private BetBelt rightBelt;
        [SerializeField] private TextMeshPro questionTmp;
        [SerializeField] private TextMeshPro leftAnswerTmp;
        [SerializeField] private TextMeshPro rightAnswerTmp;
        [SerializeField] private TextMeshPro betOddTmp;


        private int _betOdd ;
        private BetBelt _correctBelt;


        public void SetAreaTexts(Question question)
        {
            questionTmp.text = question.QuestionText;
            leftAnswerTmp.text = question.LeftAnswerText;
            rightAnswerTmp.text = question.RightAnswerText;
            betOddTmp.text = question.BetOdd.ToString();
            _betOdd = question.BetOdd;
            if (question.IsLeftCorrect)
            {
                _correctBelt = leftBelt;
            }
            else
            {
                _correctBelt = rightBelt;
            }
        }


        public int GetBetReward()
        {
           return _correctBelt.TakeRewardAmount()* _betOdd;
        }
    }
}