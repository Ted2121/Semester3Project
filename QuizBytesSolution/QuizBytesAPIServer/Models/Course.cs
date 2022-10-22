﻿namespace QuizBytesAPIServer.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CurrentChallengeId { get; set; }
        public CurrentChallenge CurrentChallenge { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
    }
}
