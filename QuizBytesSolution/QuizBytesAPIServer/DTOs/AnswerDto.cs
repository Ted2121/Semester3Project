﻿namespace QuizBytesAPIServer.DTOs
{
    public class AnswerDto
    {
        public int PKAnswerId { get; set; }
        public string IsCorrect { get; set; }
        public string AnswerText { get; set; }
        public int FKQuestionId { get; set; }
    }
}
