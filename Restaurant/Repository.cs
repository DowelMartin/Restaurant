using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Repository
    {
        private readonly RestauracjaEntities db;

        public Repository()
        {
            db = new RestauracjaEntities();
        }
        /// <returns>true if everything worked as it should or false when exception an exception occurred</returns>
        public bool AddPotrawa(string nazwa, double cena)
        {
            try
            {
                db.Potrawy.Add(new Potrawy { Nazwa = nazwa, Cena = cena, });
                db.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("Błąd przy próbie zapisu do bazy");
                return false;
            }
            return true;
        }
        public bool AddKlient(string imie, string nazwisko, string email, string haslo)
        {
            try
            {
                db.Credentials.Add(new Credentials{ Email = email, Password = haslo });
                db.Klienci.Add(new Klienci{ Imie = imie, Nazwisko = nazwisko, Email = email });
                db.SaveChanges();

            }
            catch (Exception)
            {
                Console.WriteLine("Błąd przy próbie zapisu do bazy");
                return false;
            }
            return true;
        }

        public List<Potrawa> GetPotrawy()
        {
            var returnList = new List<Potrawa>();
            var potrawy = db.Potrawy.ToList();
            foreach (var p in potrawy)
            {
                returnList.Add(new Potrawa()
                {
                    Id_potrawy = p.Id_potrawy,
                    Nazwa = p.Nazwa,
                    Cena = p.Cena
                });
            }
            return returnList;
        }

        public void DelPotrawa(int id)
        {
            try
            {
                db.Potrawy.Remove(db.Potrawy.Where(x => x.Id_potrawy == id).FirstOrDefault());
                db.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("Błąd przy próbie kasowania!");
            }
        }
        public List<Stoliki> GetStoliki()
        {
            var returnList = new List<Stoliki>();
            var stoliki = db.Stoliki.ToList();
            foreach (var s in stoliki)
            {
                returnList.Add(new Stoliki()
                {
                    Nr_stolika = s.Nr_stolika,
                    Ilosc_miejsc = s.Ilosc_miejsc
                });
            }
            return returnList;
        }
        public List<Stoliki> GetStoliki(DateTime day)
        {
            //var result = new List<Stoliki>();
            var rezerwacje = (from s in db.Rezerwacje
                              where s.Rezerwacja_do == day
                              select s.Stoliki).ToList();
            return  GetStoliki().Except(rezerwacje).ToList();
            //return result
        }
        public List<Klienci> GetKlienci()
        {
            var returnList = new List<Klienci>();
            var klienci = db.Klienci.ToList();
            foreach (var k in klienci)
            {
                returnList.Add(new Klienci()
                {
                    Id_klienta = k.Id_klienta,
                    Imie = k.Imie,
                    Nazwisko = k.Nazwisko,
                    Email = k.Email
                });
            }
            return returnList;
        }
        /// <summary>
        /// Checks if given credentials exists in database
        /// </summary>
        /// <returns>True if they do or false if they do not</returns>
        public bool CheckCredentials(string email, string password)
        {
            return (from login in db.Credentials
                    where login.Email == email && login.Password == password
                    select login).Any();
        }
        public bool IsEmailFree(string email)
        {
            return db.Credentials.Where(x => x.Email == email).Count() == 0;

        }
        public int GetUserID(string email)
        {
            return db.Klienci.Where(x => x.Email == email).FirstOrDefault().Id_klienta;
        }

        public List<RezerwacjaDto> GetRezerwacjaDtos()
        {
            return db.Rezerwacje.Select(rezerwacja => new RezerwacjaDto()
            {
                Id_rezerwacji = rezerwacja.Id_rezerwacji,
                Nazwisko = rezerwacja.Klienci.Nazwisko,
                NumerStolika = rezerwacja.Stoliki.Nr_stolika,
                RezerwacjaOd = rezerwacja.Rezerwacja_od
            }).ToList();
        }
    }
}
