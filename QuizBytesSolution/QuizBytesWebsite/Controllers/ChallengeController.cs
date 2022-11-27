﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizBytesWebsite.Helpers;
using WebApiClient;
using WebApiClient.DTOs;

namespace QuizBytesWebsite.Controllers
{
    [Authorize]
    public class ChallengeController : Controller
    {
        private IWebUserFacadeApiClient WebUserFacadeApiClient { get; set; }
        private IChallengeFacadeApiClient ChallengeFacadeApiClient { get; set; }
        private ICourseSelectionHelper CourseSelectionHelper { get; set; }


        public ChallengeController(IChallengeFacadeApiClient client, ICourseSelectionHelper courseSelectionHelper, IWebUserFacadeApiClient webUserFacadeApiClient)
        {
            ChallengeFacadeApiClient = client;
            CourseSelectionHelper = courseSelectionHelper;
            WebUserFacadeApiClient = webUserFacadeApiClient;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Start(int id)
        {
            var userToRegister = await GetUserFromClaim();
            // TODO replace the line with monday with parameterless once u r done testing the challenge
            //var courseForChallenge = await CourseSelectionHelper.GetCourseForChallenge();
            var courseForChallenge = await CourseSelectionHelper.GetCourseForChallenge("monday");
            await ChallengeFacadeApiClient.RegisterParticipantAsync(userToRegister, courseForChallenge);
            return RedirectToAction("Start");
        }

        private async Task<WebUserDto> GetUserFromClaim()
        {
            var stringIdOfUserToRegister = HttpContext.User.Claims.FirstOrDefault((claim) => claim.Type == "id")?.Value;
            int userId;
            bool success = int.TryParse(stringIdOfUserToRegister, out userId);

            if (success)
            {
                return await WebUserFacadeApiClient.GetWebUserByIdAsync(userId);
            }
            else
            {
                return null;
            }
        }

        public IActionResult Start()
        {
            return View();
        }


        [HttpGet]
        public async Task<JsonResult> Quiz()
        {
            // TODO replace the line with monday with parameterless once u r done testing the challenge
            //var courseForChallenge = await CourseSelectionHelper.GetCourseForChallenge();
            var courseForChallenge = await CourseSelectionHelper.GetCourseForChallenge("monday");
            var quiz = await GetQuiz(courseForChallenge);
            return Json(quiz);
        }
        private async Task<QuizDto> GetQuiz(CourseDto courseForChallenge)
        {
            return await ChallengeFacadeApiClient.GetChallengeQuizAsync(courseForChallenge);
        }
    }
}
