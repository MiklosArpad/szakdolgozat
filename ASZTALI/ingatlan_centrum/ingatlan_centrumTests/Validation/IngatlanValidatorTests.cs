using Microsoft.VisualStudio.TestTools.UnitTesting;
using IngatlanCentrum.Model;
using System.Diagnostics;
using IngatlanCentrum.Exceptions;

namespace IngatlanCentrum.Validation.Tests
{
    [TestClass()]
    public class IngatlanValidatorTests
    {
        /// <summary>
        /// Ingatlan teszt modell.
        /// </summary>
        private Ingatlan ingatlan;

        /// <summary>
        /// Eladó teszt modell.
        /// </summary>
        private Elado elado;

        public IngatlanValidatorTests()
        {
            elado = new Elado();
            elado.Adoazonosito = "0123456789";
            elado.Vezeteknev = "Teszt";
            elado.Keresztnev = "Elek";
            elado.Telepules = "Szeged";
            elado.Lakcim = "Rózsa utca 24.";
            elado.Telefonszam = "06702945632";
            elado.Email = "teszt@elek.hu";

            ingatlan = new Ingatlan();
            ingatlan.HelyrajziSzam = "06/40";
            ingatlan.Telepules = "Szeged";
            ingatlan.Alapterulet = 1550;
            ingatlan.Kategoria = "családi ház";
            ingatlan.Allapot = "új";
            ingatlan.Elado = elado;
        }

        [TestMethod()]
        public void ValidateTest_IngatlanHelyrajziSzamNemTartalmazSzamot()
        {
            try
            {
                ingatlan.HelyrajziSzam = "C/E";
                IngatlanValidator.Validate(ingatlan);
            }
            catch (IngatlanException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt számot nem tartozó ingatlan helyrajzi számra!");
        }

        [TestMethod()]
        public void ValidateTest_IngatlanHelyrajziSzamKisbetutTartalmaz()
        {
            try
            {
                ingatlan.HelyrajziSzam = "06/3e";
                IngatlanValidator.Validate(ingatlan);
            }
            catch (IngatlanException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt kisbetűt tartalmazó ingatlan helyrajzi számra!");
        }

        [TestMethod()]
        public void ValidateTest_IngatlanAlapteruletNulla()
        {
            try
            {
                ingatlan.Alapterulet = 0;
                IngatlanValidator.Validate(ingatlan);
            }
            catch (IngatlanException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob nulla négyzetméterű ingatlan alapterületre!");
        }

        [TestMethod()]
        public void ValidateTest_AlapteruletNegativSzam()
        {
            try
            {
                ingatlan.Alapterulet = -1;
                IngatlanValidator.Validate(ingatlan);
            }
            catch (IngatlanException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob negatív négyzetméterű ingatlan alapterületre!");
        }
    }
}
