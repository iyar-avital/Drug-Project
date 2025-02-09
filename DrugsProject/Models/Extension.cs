﻿using BE;
using BL;
using DrugsProject.Models.Doctor;
using DrugsProject.Models.Patient;
using DrugsProject.Models.Prescription;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DrugsProject.Models
{
    public static class Extension
    {
        public static IEnumerable<BE.Prescription> GetPrescriptionsForPatient(this PatientVM patVM)
        {
            IBL bl = new BlClass();
            return bl.FilterPrescriptionsForPatient(patVM.Current.Id);
        }
        public static BE.Medicine GetMedicineForPrescription(this PrescriptionVM pre)
        {
            IBL bl = new BlClass();
            return bl.GetMedicine(pre.MedicineId);
        }
        public static DoctorVM GetDoctorForPrescription(this PrescriptionVM pre)
        {
            IBL bl = new BlClass();
            return new DoctorVM(bl.GetDoctor(pre.DoctorId));
        }
        public static MvcHtmlString DisplayImage(this HtmlHelper html, string imgPath, int size = 150, string cla = "")
        {
            return new MvcHtmlString($"<img src='{imgPath}' class='{cla}' height='{size}' width='{size}'/>");
        }

        public static MvcHtmlString DisplayHeader(this HtmlHelper html, string textForHeader, int size)
        {
            return new MvcHtmlString($"<h{size} class='panel-heading bold'>{textForHeader}</h{size}>");
        }
        public static MvcHtmlString DisplayHeaderColorful(this HtmlHelper html, string textForBlackHeader, string textForColorHeader, int size, string icon = "", string link = "", string icon2 = "", string link2 = "")
        {
            if (icon == "")
                return new MvcHtmlString($"<h{size} class='panel-heading'>{ textForBlackHeader } <span> { textForColorHeader }</span></h{size}>");
            string header = $"{ textForBlackHeader } <span> { textForColorHeader }</span>";
            if (RouteConfig.IsManager == true)
            {
                string Link1 = $"<a href='{link}'><i class='{icon}'></i></a><a href='{link2}'><i class='{icon2}'></i></a>";
                return new MvcHtmlString($"<h{size} class='panel-heading bold'>{header} {Link1}</h{size}>");
            }
            return new MvcHtmlString($"<h{size} class='panel-heading bold'>{header}</h{size}>");
        }

        public static MvcHtmlString DisplayItemWithIcon(this HtmlHelper html, Object text, string icon)
        {
            if (text is DateTime)
                text = Convert.ToDateTime(text).ToString("dd/MM/yyyy");
            else if (text is BloodTypeEnum)
                text = text.ToString().Replace('_', ' ');
            return new MvcHtmlString($"<li> <i class='{icon}' aria-hidden='true'></i> {text}</li>");
        }

        public static MvcHtmlString DropDownListForMedicinesName(this HtmlHelper htmlHelper)
        {
            IBL bl = new BlClass();
            string options = $"<option disabled selected>בחר שם גנרי</option>";
            IEnumerable<MedicineWrraper> ndc = bl.GetAllNDC();
            foreach (var number in ndc)
            {
                options += $"<option value ='{number.genericName}'>{number.genericName}</option>";
            }
            return new MvcHtmlString($"<select class='form-control'>{options}</select>");
        }

        public static MvcHtmlString DropDownListForMedicines(this HtmlHelper htmlHelper, string name)
        {
            IBL bl = new BlClass();
            string options = "";
            foreach (var medicine in bl.GetMedicines())
            {
                options += $"<option value ='{medicine.Id}'> {medicine.commercialName} </option>";
            }
            return new MvcHtmlString($"<select class='form-control' name='{name}'>{options}</select>");
        }
    }
}