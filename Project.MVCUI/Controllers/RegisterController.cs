using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class RegisterController : Controller
    {
        AppUserRepository _apRep;
        ProfileRepository _proRep;

        public RegisterController()
        {
            _apRep = new AppUserRepository();
            _proRep = new ProfileRepository();
        }
        // GET: Register
        public ActionResult RegisterNow()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterNow(AppUser appUser, UserProfile userProfile)
        {
           //if(_apRep.Any(x=>x.UserName == appUser.UserName) || _apRep.Any(x => x.Email == appUser.Email))
           // {
           //     ViewBag.ZatenVar = "Kullanıcı zaten kayıtlı";
           //     return View();
           // }

            appUser.Password = DantexCrypt.Crypt(appUser.Password);
            if (_apRep.Any(x => x.UserName == appUser.UserName))
            {
                ViewBag.ZatenVar = "Kullanıcı ismi daha önce alınmış";
                return View();
            }
            else if (_apRep.Any(x => x.Email == appUser.Email))
            {
                ViewBag.ZatenVar = "Email zaten kayıtlı";
                return View();
            }

            //Kullanıcı başarılı bir şekilde register işlemini tamamladıysa ona mail gönder

            string gonderilecekMail = "Tebrikler! Hesabınız oluşturulmuştur. Hesabınızı aktive etmek için https://localhost:44392/Register/Activation/"+appUser.ActivationCode+" linkine tıklayınız.";

            MailService.Send(appUser.Email, body: gonderilecekMail, subject: "Hesap aktivasyon");
            _apRep.Add(appUser); //Öncelikle bunu eklemelisiniz. Çünkü AppUser'ın ID'si ilk başta oluşmalı. Çünkü bizim kurduğumuz birebir ilişkide AppUser zorunlu alan Profile ise opsiyonel alandır. Dolayısıyla ilk başta AppUser'ın ID'si SaveChanges ile oluşmalı ki sonra Profile'i rahatça ekleyebilelim

            if (!string.IsNullOrEmpty(userProfile.FirstName.Trim()) || !string.IsNullOrEmpty(userProfile.LastName.Trim())) 
            {
                userProfile.ID = appUser.ID;
                _proRep.Add(userProfile);
            }

            return View("RegisterOK");
        }

        public ActionResult Activation (Guid id)
        {
            AppUser aktifEdilecek = _apRep.FirstOrDefault(x => x.ActivationCode == id);
            if (aktifEdilecek != null)
            {
                aktifEdilecek.Active = true;
                _apRep.Update(aktifEdilecek);
                TempData["HesapAktifMi"] = "Hesabınız aktif hale getirildi";
                return RedirectToAction("Login", "Home");
            }
            TempData["HesapAktifMi"] = "Hesabınız bulunamadı";
            return RedirectToAction("Login", "Home");
        }

        public ActionResult RegisterOK()
        {
            return View();
        }
    }
}