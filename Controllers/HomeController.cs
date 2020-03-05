using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HomeController:Controller
    {
        public void SetSessionDojodachi(dojodachi pet = null)
        {
            if(pet ==null)
            {
                pet =new dojodachi();
            }
            else
            {
            HttpContext.Session.SetInt32("Fullness", pet.fullness);
            HttpContext.Session.SetInt32("Happiness", pet.happiness);
            HttpContext.Session.SetInt32("Meals", pet.meals);
            HttpContext.Session.SetInt32("Energy", pet.energy);
            }
        }
        private dojodachi GetSessionDojodachi()
        {
            return new dojodachi
                (
                    HttpContext.Session.GetInt32("Fullness"),
                    HttpContext.Session.GetInt32("Happiness"),
                    HttpContext.Session.GetInt32("Meals"),
                    HttpContext.Session.GetInt32("Energy")
                );
            
        }

        [HttpGet("")]
        public IActionResult index()
        {
            if (GetSessionDojodachi()==null)
            {
                SetSessionDojodachi();
            }
            if (GetSessionDojodachi().win())
            {
                TempData["result"] = "Congratulations! You won!";
                TempData["image"] = "https://i.pinimg.com/236x/4c/08/23/4c082366b3e137009286f9dbaba72150.jpg";
                ViewBag.Result = (string)TempData["result"];
                ViewBag.petImage = (string)TempData["image"];
                return View("win", GetSessionDojodachi());
            }
            if (GetSessionDojodachi().loose())
            {
                TempData["result"] = "Your Dojodachi is D.E.D. dead";
                TempData["image"] = "https://i.dailymail.co.uk/i/pix/2017/10/27/17/45BCF2B700000578-5024741-image-a-56_1509120377044.jpg";
                ViewBag.Result = (string)TempData["result"];
                ViewBag.petImage = (string)TempData["image"];
                return View("loose", GetSessionDojodachi());
            }
            if (TempData["result"] == null)
            {
                TempData["result"] = "Let's Get Started!";
            }
            if (TempData["image"] == null)
            {
                TempData["image"] = "https://i.kym-cdn.com/entries/icons/original/000/011/732/Screen_shot_2012-11-16_at_2.20.55_PM.png";
            }
            ViewBag.Result = (string)TempData["result"];
            ViewBag.petImage = (string)TempData["image"];
            return View(GetSessionDojodachi());
        }
        [HttpGet("feed")]
        public IActionResult Feed()
        {
            dojodachi pet = GetSessionDojodachi();
            TempData["result"] =pet.Feed();
            SetSessionDojodachi(pet);
            return RedirectToAction("index");
        }

        [HttpGet("play")]
        public IActionResult Play()
        {
            dojodachi pet = GetSessionDojodachi();
            TempData["result"] =pet.Play();
            SetSessionDojodachi(pet);
            return RedirectToAction("index");
        }

        [HttpGet("work")]
        public IActionResult Work()
        {
            dojodachi pet = GetSessionDojodachi();
            TempData["result"] =pet.Work();
            SetSessionDojodachi(pet);
            return RedirectToAction("index");
        }

        [HttpGet("sleep")]
        public IActionResult Sleep()
        {
            dojodachi pet = GetSessionDojodachi();
            TempData["result"] =pet.Sleep();
            SetSessionDojodachi(pet);
            return RedirectToAction("index");
        }

        [HttpGet("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }

    }
}