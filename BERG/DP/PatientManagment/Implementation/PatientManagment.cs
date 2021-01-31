using BERG.Data;
using BERG.DP.PatientManagment.Interfaces;
using BERG.Models;
using BERG.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BERG.DP.PatientManagment.Implementation
{
    public class PatientManagment : IPatientManagment
    {
        private readonly DataContext db;

        public PatientManagment(DataContext db)
        {
            this.db = db;
        }

        public List<Patient> ListAll()
        {
            var patients = db.Patients.Include(c => c.Gender).ToList();
            return patients;
        }

        public void AddPatient(PatientViewModel model)
        {
            var patient = new Patient
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Birthdate = model.Birthdate,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                GenderID = model.GenderID
            };

            db.Patients.Add(patient);
            db.SaveChanges();
        }

        public void DeletePatient(int patientID)
        {
            var patient = db.Patients.SingleOrDefault(c => c.Id == patientID);
            if(patient != null)
            {
                db.Patients.Remove(patient);
                db.SaveChanges();
            }
        }

        public Patient GetPatient(int patientID)
        {
            var patient = db.Patients.Include(c => c.Gender).SingleOrDefault(c => c.Id == patientID);
            if(patient != null)
            {
                return patient;
            }
            return null;
        }

        public void UpdatePatient(PatientEditViewModel model)
        {
            var patient = db.Patients.Include(c => c.Gender).SingleOrDefault(c => c.Id == model.PatientID);

            patient.Firstname = model.Firstname;
            patient.Lastname = model.Lastname;
            patient.Birthdate = model.Birthdate;
            patient.GenderID = model.GenderID;
            patient.PhoneNumber = model.PhoneNumber;
            patient.Address = model.Address;

            db.SaveChanges();
        }
    }
}
