using Microsoft.VisualStudio.TestTools.UnitTesting;
using IngatlanCentrum.Model;
using IngatlanCentrum.Exceptions;
using System.Diagnostics;

namespace IngatlanCentrum.Validation.Tests
{
    [TestClass()]
    public class EladoValidatorTests
    {
        /// <summary>
        /// Teszt eladó modell.
        /// </summary>
        private Elado elado;

        public EladoValidatorTests()
        {
            elado = new Elado();
            elado.Adoazonosito = "0123456789";
            elado.Vezeteknev = "Teszt";
            elado.Keresztnev = "Elek";
            elado.Telepules = "Szeged";
            elado.Lakcim = "Rózsa utca 24.";
            elado.Telefonszam = "06702945632";
            elado.Email = "teszt@elek.hu";
        }

        [TestMethod()]
        public void ValidateTest_EladoAdoazonositojaUres()
        {
            try
            {
                elado.Adoazonosito = "";
                EladoValidator.Validate(elado);
            }
            catch (EladoException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt üres adószonosítóra!");
        }

        [TestMethod()]
        public void ValidateTest_EladoAdoazonositoKevesebbMintTizKarakter()
        {
            try
            {
                elado.Adoazonosito = "01234";
                EladoValidator.Validate(elado);
            }
            catch (EladoException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt 10-nél kevesebb karakterű adószonosítóra!");
        }

        [TestMethod()]
        public void ValidateTest_EladoAdoazonositoTobbMintTizKarakter()
        {
            try
            {
                elado.Adoazonosito = "12121212121";
                EladoValidator.Validate(elado);
            }
            catch (EladoException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt 10-nél több karakterű adószonosítóra!");
        }

        [TestMethod()]
        public void ValidateTest_EladoVezetekNeveUres()
        {
            try
            {
                elado.Vezeteknev = "";
                EladoValidator.Validate(elado);
            }
            catch (EladoException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt üres vezetéknévre!");
        }

        [TestMethod()]
        public void ValidateTest_EladoKeresztneveUres()
        {
            try
            {
                elado.Keresztnev = "";
                EladoValidator.Validate(elado);
            }
            catch (EladoException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt üres keresztnévre!");
        }

        [TestMethod()]
        public void ValidateTest_EladoTelepuleseUres()
        {
            try
            {
                elado.Telepules = "";
                EladoValidator.Validate(elado);
            }
            catch (EladoException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt üres településre!");
        }

        [TestMethod()]
        public void ValidateTest_EladoLakcimUres()
        {
            try
            {
                elado.Lakcim = "";
                EladoValidator.Validate(elado);
            }
            catch (EladoException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt üres lakcímre!");
        }

        [TestMethod()]
        public void ValidateTest_EladoTelefonszamUres()
        {
            try
            {
                elado.Telefonszam = "";
                EladoValidator.Validate(elado);
            }
            catch (EladoException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt üres telefonszámra!");
        }

        [TestMethod()]
        public void ValidateTest_EladoEmailUres()
        {
            try
            {
                elado.Email = "";
                EladoValidator.Validate(elado);
            }
            catch (EladoException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt üres e-mail címre!");
        }

        [TestMethod()]
        public void ValidateTest_EladoVezetekneveKisbetuvelKezdodik()
        {
            try
            {
                elado.Vezeteknev = "teszt";
                EladoValidator.Validate(elado);
            }
            catch (EladoException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt kisbetűs vezetéknévre!");
        }

        [TestMethod()]
        public void ValidateTest_EladoKeresztneveKisbetuvelKezdodik()
        {
            try
            {
                elado.Keresztnev = "elek";
                EladoValidator.Validate(elado);
            }
            catch (EladoException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt kisbetűs keresztnévre!");
        }

        [TestMethod()]
        public void ValidateTest_EladoVezetekneveSzamotTartalmaz()
        {
            try
            {
                elado.Vezeteknev = "Tes3t";
                EladoValidator.Validate(elado);
            }
            catch (EladoException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt betűt tartalmazó vezetéknévre!");
        }

        [TestMethod()]
        public void ValidateTest_EladoNeveKeresztneveTartalmaz()
        {
            try
            {
                elado.Adoazonosito = "0I23456789";
                EladoValidator.Validate(elado);
            }
            catch (EladoException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt betűt tartalmazó keresztnévre!");
        }

        [TestMethod()]
        public void ValidateTest_EladoAdoazonositojaKaraktertTartalmaz()
        {
            try
            {
                elado.Adoazonosito = "0I23456789";
                EladoValidator.Validate(elado);
            }
            catch (EladoException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt betűt tartalmazó adóazonosítóra!");
        }

        [TestMethod()]
        public void ValidateTest_EladoLakcimKisbetuvelKezdodik()
        {
            try
            {
                elado.Lakcim = "rózsa utca 24.";
                EladoValidator.Validate(elado);
            }
            catch (EladoException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt kisbetűvel kezdődő lakcímre!");
        }

        [TestMethod()]
        public void ValidateTest_EladoTelefonszamkBetutTartalmaz()
        {
            try
            {
                elado.Telefonszam = "067o2945632";
                EladoValidator.Validate(elado);
            }
            catch (EladoException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt betűt tartalmazó telefonszámra!");
        }

        [TestMethod()]
        public void ValidateTest_EladoEmailNemTartalmazPontotEsKukacKataktert_1()
        {
            try
            {
                elado.Email = "tesztelek.hu";
                EladoValidator.Validate(elado);
            }
            catch (EladoException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt rossz e-mail cím formátumra!");
        }

        [TestMethod()]
        public void ValidateTest_EladoEmailNemTartalmazPontotEsKukacKataktert_2()
        {
            try
            {
                elado.Email = "teszt@elek";
                EladoValidator.Validate(elado);
            }
            catch (EladoException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt rossz e-mail cím formátumra!");
        }

        [TestMethod()]
        public void ValidateTest_EladoEmailNemTartalmazPontotEsKukacKataktert_3()
        {
            try
            {
                elado.Email = "tesztelekhu";
                EladoValidator.Validate(elado);
            }
            catch (EladoException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt rossz e-mail cím formátumra!");
        }
    }
}
