using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BERG.Data;
using BERG.DP.PatientManagment.Interfaces;
using BERG.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BERG.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private readonly IPatientManagment patientManagment;
        private readonly DataContext db;

        public PatientController(IPatientManagment patientManagment, DataContext db)
        {
            this.patientManagment = patientManagment;
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new PatientViewModel()
            {
                Patients = patientManagment.ListAll()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult AddPatient()
        {
            var genders = db.Genders.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name.ToString()
            }).ToList();

            var model = new PatientViewModel()
            {
               Genders = genders
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddPatient(PatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                patientManagment.AddPatient(model);
                return RedirectToAction("Index", "Patient");
            }

            var genders = db.Genders.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name.ToString()
            }).ToList();

            model.Genders = genders;

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int patientID)
        {
            patientManagment.DeletePatient(patientID);
            return RedirectToAction("Index", "Patient");
        }

        [HttpGet]
        public IActionResult Edit(int patientID)
        {
            var patient = patientManagment.GetPatient(patientID);
            var model = new PatientEditViewModel()
            {
                Firstname = patient.Firstname,
                Lastname = patient.Lastname,
                Birthdate = patient.Birthdate,
                GenderID = patient.GenderID,
                PhoneNumber = patient.PhoneNumber,
                Address = patient.Address,
                PatientID = patientID
            };

            var genders = db.Genders.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name.ToString()
            }).ToList();

            model.Genders = genders;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(PatientEditViewModel model, string submitButton)
        {
            if (ModelState.IsValid)
            {
                if (submitButton.Equals("potvrdi"))
                {
                    patientManagment.UpdatePatient(model);
                }   
                else if (submitButton.Equals("ukloni"))
                {
                    patientManagment.DeletePatient(model.PatientID);
                }
            
                return RedirectToAction("Index", "Patient");
            }
            return View(model);
        }
    }
}