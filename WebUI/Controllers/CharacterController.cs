﻿using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebUI.Models;
using WebUI.Infrastructure;

namespace WebUI.Controllers
{
    public class CharacterController : Controller
    {
        private ICharacterRepository repository;
        private IVoteRepository voteRepository;
        private IUserProvider userProvider;
        private IWeekProvider weekProvider;


        public CharacterController (
            ICharacterRepository productRepository, 
            IVoteRepository voteRepository, 
            IUserProvider userProvider,
            IWeekProvider weekProvider)
        {
            this.repository = productRepository;
            this.voteRepository = voteRepository;
            this.weekProvider = weekProvider;
            this.userProvider = userProvider;
        }

        private bool UserVoted()
        {
            var userId = userProvider.GetId(this);
            if (userId == Guid.Empty)
                return false;
            return voteRepository.Contains(weekProvider.GetWeek(),userId);
        }

        public List<Character> FilterByField(string fieldName, string fieldValue)
        {
            return repository.Characters.ToList()
                .Where(x => x.GetType().GetProperty(fieldName).GetValue(x).ToString() == fieldValue)
                .ToList();

        }
        public List<Character> FilterByParameters(string name, bool isAlive, Sex sex)
        {
            return repository.Characters
                .Where(c => c.Name.Contains(name) && c.IsAlive == isAlive && c.Sex == sex).ToList();
        }


        [HttpGet]
        public ViewResult AdvancedList(string name, bool isAlive, Sex sex)
        {
            var view = View("List",new MainModel(FilterByParameters(name, isAlive, sex), Request.RawUrl, UserVoted()));
            view.ViewBag.Name = name;
            view.ViewBag.IsAlive = isAlive;
            view.ViewBag.Sex = sex;
            return view;
        }

        [HttpPost]
        public ViewResult List(string name, bool isAlive, Sex sex)
        {

            var backUrl = string.Format("/Character/AdvancedList?name={0}&isAlive={1}&sex={2}", name, isAlive, sex);
            var view = View(new MainModel(FilterByParameters(name, isAlive, sex), backUrl, UserVoted()));
            var userId = User.Identity.GetUserId();
            var userName = User.Identity.Name;
            view.ViewBag.Name = name;
            view.ViewBag.IsAlive = isAlive;
            view.ViewBag.Sex = sex;
            return view;
        }

        public ViewResult List(string fieldName, string fieldValue)
        {
            if (fieldValue == null && fieldName == null)
                return View(new MainModel(repository.Characters, Request.RawUrl, UserVoted()));
            return View(new MainModel(FilterByField(fieldName, fieldValue), Request.RawUrl, UserVoted()));
        }
    }
}
