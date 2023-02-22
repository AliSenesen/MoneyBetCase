using System;
using System.Collections.Generic;
using Core.QuestionArea;
using Extentions;
using UnityEngine;

namespace Managers
{
    public class QuestionManager : MonoSingleton<QuestionManager>
    {
        [SerializeField] private List<Question> questions;
        [SerializeField] private List<BetArea> betAreas;

        private void Start()
        {
            SetBetAreaQuestions();
        }

        private void SetBetAreaQuestions()
        {
            for (int i = 0; i < betAreas.Count; i++)
            {
                betAreas[i].SetAreaTexts(questions[i]);
            }
        }
    }

    [Serializable]
    public class Question
    {
        public string QuestionText;
        public string LeftAnswerText;
        public string RightAnswerText;
        public bool IsLeftCorrect;
        public int BetOdd;
    }
}