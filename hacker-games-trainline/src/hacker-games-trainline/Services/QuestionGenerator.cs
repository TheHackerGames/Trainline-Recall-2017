using System;
using System.Linq;
using hacker_games_trainline.Data;
using hacker_games_trainline.Model;

namespace hacker_games_trainline.Services
{
    public class QuestionGenerator
    {
        private readonly Random _random;

        public QuestionGenerator()
        {
            _random = new Random();
        }

        public Question RandomQuestion()
        {
            var persons = Persons.GetAll(CurrentUser.User.Id).ToList();
            var randomNum = _random.Next(1, persons.Count + 1);
            var selectedPerson = persons.Single(p => p.Id == randomNum);
            // Get a random vertex, take its name and image, return them
            return new Question {Name = selectedPerson.Name, PicturePath = selectedPerson.PicturePath};
        }
    }
}