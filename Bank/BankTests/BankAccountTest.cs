using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // preparación del caso de prueba
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // acción a probar
            account.Debit(debitAmount);

            // afirmación de la prueba (valor esperado Vs. Valor obtenido)
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsGreaterThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // preparación
            double beginningBalance = 11.99;
            double debitAmount = 100.00; // Mayor que el saldo
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // acción
            account.Debit(debitAmount);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // preparación
            double beginningBalance = 11.99;
            double debitAmount = -5.00; // Menor que cero
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // acción
            account.Debit(debitAmount);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Debit_WhenBankAccountIsFrozen_ShouldThrowException()
        {
            // preparación
            double beginningBalance = 11.99;
            double debitAmount = 2.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            account.FreezeAccount(); // Congelamos la cuenta

            // acción
            account.Debit(debitAmount);
        }
    }
}
