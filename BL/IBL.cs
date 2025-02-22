﻿using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BL
{
    public interface IBL
    {
        //ADD
        void AddDoctor(Doctor doctor); //This function adds a doctor to the system
        void AddMedicine(Medicine medicine, HttpPostedFileBase httpPostedFile); //This function adds a medicine to the system
        void AddPatient(Patient patient); //This function adds a patient to the system
        void AddPrescription(Prescription prescription); //This function adds a prescription to the system

        //UPDATE
        void UpdateDoctor(Doctor doctor); //This function updates a chosen doctor from the system
        void UpdateMedicine(Medicine medicine, HttpPostedFileBase httpPostedFile); //This function updates a chosen doctor from the system
        void UpdatePatient(Patient patient); //This function updates a chosen patient from the system

        //DELETE
        bool DeleteDoctor(int? id); //This function deletes a chosen doctor from the system
        bool DeleteMedicine(int? id); //This function deletes a chosen medicine from the system
        bool DeletePatient(int? id); //This function deletes a chosen patient from the system

        //GET
        Doctor GetDoctor(int? id); //This function returns a single doctor by his ID
        Medicine GetMedicine(int? id); //This function returns a single medicine by an ID
        Patient GetPatient(int? id); //This function returns a single patient by his ID
        Prescription GetPrescription(int? id); //This function returns a prescription by an ID
        string GetNDCForMedicine(string genericName); //This function returns NDC code for a medicine by it's generic name
        IEnumerable<Person> GetAllPerson(Func<Person, bool> predicat = null); //This function returns a collection of all the persons in the system
        IEnumerable<Doctor> GetDoctors(Func<Doctor, bool> predicat = null); //This function returns a collection of all the doctors in the system
        IEnumerable<Medicine> GetMedicines(Func<Medicine, bool> predicat = null); //This function returns a collection of all the medicines in the system
        IEnumerable<Patient> GetPatients(Func<Patient, bool> predicat = null); //This function returns a collection of all the patients in the system
        IEnumerable<Prescription> GetPrescriptions(Func<Prescription, bool> predicat = null); //This function returns a collection of all the prescriptions in the system
        IEnumerable<MedicineWrraper> GetAllNDC();
        List<string> GetNDCForAllActiveMedicine(int patientID); //This function returns a collection of all the NDC codes of the medicines in the system

        //FILTER
        IEnumerable<Prescription> FilterPrescriptionsForPatient(int patientID); //This function returns all the prescriptions of a specific patient by his ID
        IEnumerable<Prescription> FilterActivePrescriptionsForPatient(int patientID); //This function returns all the current prescriptions of a specific patient by his ID
        IEnumerable<Medicine> FilterActiveMedicinesForPatient(int patientID); //This function returns all the current medicines of a specific patient by his ID

        //DISPOSE
        void Dispose(bool disp);

        //SEND
        void SendMail(string mailAdress,string subject, string receiverName, string message); //This function responsible for sending a mail

        //ACCOUNT
        void SignIn(DoctorSign doctorSign); //This function returns rather a person signed in is allowed
        void SignUp(DoctorSign doctorSign); //This function represent signing up
        void ForgotPassword(string mail); //This function responsible for reseting the password if the person forgot it


        //VALIDATION
        Dictionary<string, string> PersonValidation(Person person);

        Dictionary<string, string> SignValidation(DoctorSign doctorSign); //This function returns rather a person is OK by his input details or not

        //Image Service
        bool ValidateImage(string path); //This function returns rather an image is allowed or not
        string ConvertStringToUrl(string path); //This function returns a url link to an image path

        //CONFLICT DRUGS SERVICE 
        List<string> IsConflict(List<string> NDC); //This function returns rather there is a conflict between medicines in the prescription or not
    }
}
