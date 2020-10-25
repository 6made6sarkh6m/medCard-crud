using crudTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crudTest.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index(string search)
        {
            using(PatientsDBEntities medcard = new PatientsDBEntities())
            {
                return View(medcard.Patients.Where(x=>x.p_idcard.StartsWith(search)|| search==null).ToList());
            }
            
            
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            using(PatientsDBEntities medcard = new PatientsDBEntities())
            {
                return View(medcard.Patients.Where(x=>x.id==id).FirstOrDefault());
            }
            
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult Create(Patients patient)
        {
           
            try
            {
                using (PatientsDBEntities medcard = new PatientsDBEntities())
                {
                    medcard.Patients.Add(patient);
                    medcard.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            using(PatientsDBEntities medcard = new PatientsDBEntities())
            {
                return View(medcard.Patients.Where(x=>x.id ==id).FirstOrDefault());
            }
            
        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Patients patient)
        {
            try
            {
                using(PatientsDBEntities medcard = new PatientsDBEntities())
                {
                    medcard.Entry(patient).State = EntityState.Modified;
                    medcard.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            using(PatientsDBEntities medcard = new PatientsDBEntities())
            {
                return View(medcard.Patients.Where(x=>x.id==id).FirstOrDefault());
            }
            
        }

        // POST: Patient/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Patients patient)
        {
            try
            {
                // TODO: Add delete logic here
                using(PatientsDBEntities medcard = new PatientsDBEntities())
                {
                    patient = medcard.Patients.Where(x=>x.id==id).FirstOrDefault();
                    medcard.Patients.Remove(patient);
                    medcard.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
