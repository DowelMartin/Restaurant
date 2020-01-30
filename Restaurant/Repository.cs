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
                db.Credentials.Add(new Credentials { Email = email, Password = haslo });
                db.Klienci.Add(new Klienci { Imie = imie, Nazwisko = nazwisko, Email = email });
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
                              where s.Rezerwacja_od == day
                              select s.Stoliki).ToList();
            return GetStoliki().Except(rezerwacje).ToList();
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
        public bool PlaceOrder(int user, DateTime when, int table, Potrawa dish)
        {
            try
            {
                var potrawa = db.Potrawy.FirstOrDefault(x => x.Id_potrawy == dish.Id_potrawy);
                var rezerwacje = new Rezerwacje()
                {
                    Id_klienta = user,
                    Numer_stolika = table,
                    Rezerwacja_od = when,
                    Rezerwacja_do = when.AddHours(1),
                };
                db.Rezerwacje.Add(rezerwacje);
                db.Rezerwacje_Potrawy.Add(new Rezerwacje_Potrawy()
                {
                    id_zamowienia = rezerwacje.Id_rezerwacji,
                    id_potrawy = potrawa.Id_potrawy
                });
                db.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("Błąd przy próbie zapisu do bazy");
                return false;
            }
            return true;
        }
        public List<RezerwacjaDto> GetRezerwacjaDtos(int user)
        {
            var result = new List<RezerwacjaDto>();
            foreach (var rez in db.Rezerwacje_Potrawy.Where(x=>x.Rezerwacje.Id_klienta==user))
            {
                var potrawa = new Potrawa()
                {
                    Cena = rez.Potrawy.Cena,
                    Id_potrawy = rez.Potrawy.Id_potrawy,
                    Nazwa = rez.Potrawy.Nazwa
                };
                result.Add(new RezerwacjaDto()
                {
                    Nazwisko = rez.Rezerwacje.Klienci.Nazwisko,
                    Id_rezerwacji = rez.id_zamowienia,
                    NumerStolika = rez.Rezerwacje.Numer_stolika,
                    Potrawa = potrawa,
                    RezerwacjaOd=rez.Rezerwacje.Rezerwacja_od
                });
            }
            return result;
        }  
        public List<RezerwacjaDto> GetRezerwacjaDtos()
        {
            var result = new List<RezerwacjaDto>();
            foreach (var rez in db.Rezerwacje_Potrawy)
            {
                var potrawa = new Potrawa()
                {
                    Cena = rez.Potrawy.Cena,
                    Id_potrawy = rez.Potrawy.Id_potrawy,
                    Nazwa = rez.Potrawy.Nazwa
                };
                result.Add(new RezerwacjaDto()
                {
                    Nazwisko = rez.Rezerwacje.Klienci.Nazwisko,
                    Id_rezerwacji = rez.id_zamowienia,
                    NumerStolika = rez.Rezerwacje.Numer_stolika,
                    Potrawa = potrawa,
                    RezerwacjaOd=rez.Rezerwacje.Rezerwacja_od
                });
            }
            return result;
        }
        public void CancelReservation(int id)
        {
            var potr_rez = db.Rezerwacje_Potrawy.Where(x => x.id_zamowienia == id).FirstOrDefault();
            var rez = db.Rezerwacje.Where(x => x.Id_rezerwacji == id).FirstOrDefault();
            db.Rezerwacje.Remove(rez);
            db.Rezerwacje_Potrawy.Remove(potr_rez);
            db.SaveChanges();
        }
    }
}
