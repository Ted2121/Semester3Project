﻿using DataAccessDefinitionLibrary.Data_Access_Models;

namespace QuizBytesAPIServer.DTOs;

public class WebUserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string? NewPassword { get; set; }
    public string Email { get; set; }
    public int TotalPoints { get; set; }
    public int AvailablePoints { get; set; }
    public int NumberOfCorrectAnswers { get; set; }
    
    public IEnumerable<ChapterDto>? WebUserChapterUnlocks { get; set; }
    public bool IsInChallenge { get; set; }
    public int PointsAccumulatedInChallenge { get; set; }
    public int ElapsedSecondsInChallenge { get; set; }
}
