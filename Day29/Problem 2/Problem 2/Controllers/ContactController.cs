using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Problem_2.Models;

namespace Problem_2.Controllers
{
    public class ContactController : Controller
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>()
            {
                new ContactInfo(){ContactId=101,FirstName="Rajat",LastName="Pilani",CompanyName="Accenture",EmailId="rajat@gmail.com",Mobile=9756565656,Designation="HR"},
                new ContactInfo(){ContactId=102,FirstName="Anil",LastName="Khanna",CompanyName="Cognizant",EmailId="anil@gmail.com",Mobile=9056565656,Designation="Developer"},
                new ContactInfo(){ContactId=103,FirstName="Dipak",LastName="Kapoor",CompanyName="IBM",EmailId="adipak@gmail.com",Mobile=9056565600,Designation="Team Lead"},
                new ContactInfo(){ContactId=104,FirstName="Raj",LastName="Desai",CompanyName="Capgemini",EmailId="raj@gmail.com",Mobile=9056565006,Designation="Manager"}


            };


        //Show All contacts

        [HttpGet]
        public IActionResult ShowContact()
        {



            ViewData["ContactInfo"] = contacts;

            return View(contacts);

        }


        //getcontactbyid
        [HttpGet]
        public ActionResult GetContactById(int id)
        {
            var getContact = contacts.FirstOrDefault(c => c.ContactId == id);
            if (getContact == null)
            {
                return NotFound();
            }
            return View(getContact);
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo c) {

            if (ModelState.IsValid)
            {
                contacts.Add(c);
                return RedirectToAction("ShowContact");
            }
            return View(c);
        }
        [HttpGet]
        public IActionResult EditContact(int id)
        {
            var c = contacts.FirstOrDefault(c1 => c1.ContactId == id);
            if (c == null)
            {
                return NotFound();
            }
            return View(c);
        }

        [HttpPost]
        public IActionResult EditContact(ContactInfo editContact)
        {
            var c=contacts.FirstOrDefault(c=>c.ContactId == editContact.ContactId);
            if (c == null)
            {
                return NotFound();
            }
            c.ContactId = editContact.ContactId;
            c.FirstName = editContact.FirstName;
            c.LastName = editContact.LastName;
            c.CompanyName = editContact.CompanyName;
            c.EmailId = editContact.EmailId;
            c.Mobile=editContact.Mobile;
            c.Designation=editContact.Designation;

            return RedirectToAction("ShowContact");
        }

       

        [HttpPost]
        public IActionResult DeleteContact(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
            {
                return NotFound();
            }

            contacts.Remove(contact);
            return RedirectToAction("ShowContact");
        }



    }
}


