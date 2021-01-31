using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BERG.DP.AppointmentManagment.Interfaces;
using BERG.DP.RecordManagment.Interfaces;
using BERG.ViewModels.MedicalRecord;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BERG.Controllers
{
    [Authorize]
    public class MedicalRecordController : Controller
    {
        private readonly IAppointmentManagment appointmentManagment;
        private readonly IRecordManagment recordManagment;

        public MedicalRecordController(IAppointmentManagment appointmentManagment, IRecordManagment recordManagment)
        {
            this.appointmentManagment = appointmentManagment;
            this.recordManagment = recordManagment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddRecord(int appointmentID)
        {
            var appointment = appointmentManagment.GetAppointmentByID(appointmentID);
            var model = new MedicalRecordViewModel()
            {
                Appointment = appointment
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddRecord(MedicalRecordViewModel model)
        {
            if (ModelState.IsValid)
            {
                recordManagment.AddRecord(model);
                return RedirectToAction("Index", "Appointment");
            }

            return View(model);
        }
    }
}