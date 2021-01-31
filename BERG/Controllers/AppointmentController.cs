using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BERG.Data;
using BERG.DP.AppointmentManagment.Interfaces;
using BERG.Models;
using BERG.ViewModels;
using BERG.ViewModels.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BERG.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentManagment appointmentManagment;
        private readonly DataContext db;
        private readonly UserManager<User> usermanager;

        public AppointmentController(IAppointmentManagment appointmentManagment, DataContext db, UserManager<User> usermanager)
        {
            this.appointmentManagment = appointmentManagment;
            this.db = db;
            this.usermanager = usermanager;
        }
        public IActionResult Index()
        {
            List<BERG.Models.Appointment> appointments = appointmentManagment.ListAllAppointemnts();
            var model = new AppointementViewModel()
            {
                Appointments = appointments
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(AppointementViewModel model)
        {
            var appos = appointmentManagment.GetAppointmentsByDate(model);
            model.Appointments = appos;
            return View(model);
        }

        [HttpGet]
        public IActionResult AddAppointment()
        {
            var patients = db.Patients.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Firstname.ToString() + " " + c.Lastname.ToString()
            }).ToList();

            var users = usermanager.Users.Where(c => c.Title.Name == "Specijalista").Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Firstname.ToString() + " " + c.Lastname.ToString()
            }).ToList();

            var model = new AppointementViewModel()
            {
                Users = users,
                Patients = patients,
                Time = DateTime.Now
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddAppointment(AppointementViewModel model)
        {
            if (ModelState.IsValid)
            {
                appointmentManagment.AddAppointent(model);
                return RedirectToAction("Index", "Appointment");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int appointmentID)
        {
            var appointment = appointmentManagment.GetAppointmentByID(appointmentID);
            var gotRecord = appointmentManagment.IsAppointmentGotRecord(appointmentID);
            var model = new AppointementViewModel()
            {
                Time = appointment.Time,
                UserID = appointment.UserID,
                PatientID = appointment.PatientID,
                Urgent = appointment.Urgently,
                AppointmentID = appointment.Id,
                GotRecord = gotRecord
            };

            var patients = db.Patients.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Firstname.ToString() + " " + c.Lastname.ToString()
            }).ToList();

            var users = usermanager.Users.Where(c => c.Title.Name == "Specijalista").Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Firstname.ToString() + " " + c.Lastname.ToString()
            }).ToList();

            model.Users = users;
            model.Patients = patients;


            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(AppointementViewModel model)
        {
            if (ModelState.IsValid)
            {
                appointmentManagment.Edit(model);
                return RedirectToAction("Index", "Appointment");
            }

            var patients = db.Patients.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Firstname.ToString() + " " + c.Lastname.ToString()
            }).ToList();

            var users = usermanager.Users.Where(c => c.Title.Name == "Specijalista").Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Firstname.ToString() + " " + c.Lastname.ToString()
            }).ToList();

            model.Users = users;
            model.Patients = patients;

            return View(model);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var appo = db.Appointments.SingleOrDefault(c => c.Id == id);
            db.Appointments.Remove(appo);
            db.SaveChanges();
            return RedirectToAction("Index", "Appointment");
        }


    }
}