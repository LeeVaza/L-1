using System;
using EventManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventManagementTests
{
    [TestClass]
    public class EventTests
    {
        [TestMethod]
        public void Create_Event()
        {
            // Arrange
            var start = new DateTime(2026, 3, 15, 10, 0, 0);
            var end = new DateTime(2026, 3, 15, 12, 0, 0);

            // Act
            var ev = new Event("Конференция", start, end, "Москва", "IT событие");

            // Assert
            Assert.AreEqual("Конференция", ev.Name);
            Assert.AreEqual(start, ev.StartTime);
            Assert.AreEqual(end, ev.EndTime);
            Assert.AreEqual("Москва", ev.Location);
            Assert.AreEqual("IT событие", ev.Description);
        }

        [TestMethod]
        public void Reminder_Default()
        {
            // Arrange
            var start = new DateTime(2026, 3, 15, 10, 0, 0);
            var end = new DateTime(2026, 3, 15, 12, 0, 0);

            // Act
            var ev = new Event("Тест", start, end, "Офис", "Описание");

            // Assert
            Assert.IsFalse(ev.ReminderSet);
        }

        [TestMethod]
        public void Set_Reminder()
        {
            // Arrange
            var start = new DateTime(2026, 3, 15, 10, 0, 0);
            var end = new DateTime(2026, 3, 15, 12, 0, 0);
            var ev = new Event("Тест", start, end, "Офис", "Описание");

            // Act
            ev.SetReminder();
            // Assert
            Assert.IsTrue(ev.ReminderSet);
        }

        [TestMethod]
        public void Remove_Reminder()
        {
            // Arrange
            var start = new DateTime(2026, 3, 15, 10, 0, 0);
            var end = new DateTime(2026, 3, 15, 12, 0, 0);
            var ev = new Event("Тест", start, end, "Офис", "Описание");
            ev.SetReminder();

            // Act
            ev.RemoveReminder();

            // Assert
            Assert.IsFalse(ev.ReminderSet);
        }

        [TestMethod]
        public void ToString_Check()
        {
            // Arrange
            var start = new DateTime(2026, 3, 15, 10, 0, 0);
            var end = new DateTime(2026, 3, 15, 12, 0, 0);
            var ev = new Event("Конференция", start, end, "Москва", "IT событие");

            // Act
            var res = ev.ToString();

            // Assert
            Assert.IsTrue(res.Contains("Событие: Конференция"));
            Assert.IsTrue(res.Contains("Место: Москва"));
            Assert.IsTrue(res.Contains("Описание: IT событие"));
        }

        [TestMethod]
        public void ToString_Yes()
        {
            // Arrange
            var start = new DateTime(2026, 3, 15, 10, 0, 0);
            var end = new DateTime(2026, 3, 15, 12, 0, 0);
            var ev = new Event("Тест", start, end, "Офис", "Описание");
            ev.SetReminder();

            // Act
            var res = ev.ToString();

            // Assert
            Assert.IsTrue(res.Contains("Напоминание: Да"));
        }

        [TestMethod]
        public void ToString_No()
        {
            // Arrange
            var start = new DateTime(2026, 3, 15, 10, 0, 0);
            var end = new DateTime(2026, 3, 15, 12, 0, 0);
            var ev = new Event("Тест", start, end, "Офис", "Описание");

            // Act
            var res = ev.ToString();

            // Assert
            Assert.IsTrue(res.Contains("Напоминание: Нет"));
        }

        [TestMethod]
        public void Change_Name()
        {
            // Arrange
            var start = new DateTime(2026, 3, 15, 10, 0, 0);
            var end = new DateTime(2026, 3, 15, 12, 0, 0);
            var ev = new Event("Старое", start, end, "Офис", "Описание");

            // Act
            ev.Name = "Новое";

            // Assert
            Assert.AreEqual("Новое", ev.Name);
        }
        [TestMethod]
        public void Change_Location()
        {
            // Arrange
            var start = new DateTime(2026, 3, 15, 10, 0, 0);
            var end = new DateTime(2026, 3, 15, 12, 0, 0);
            var ev = new Event("Тест", start, end, "Старое", "Описание");

            // Act
            ev.Location = "Новое";

            // Assert
            Assert.AreEqual("Новое", ev.Location);
        }

        [TestMethod]
        public void Reminder_Toggle()
        {
            // Arrange
            var start = new DateTime(2026, 3, 15, 10, 0, 0);
            var end = new DateTime(2026, 3, 15, 12, 0, 0);
            var ev = new Event("Тест", start, end, "Офис", "Описание");

            // Act
            ev.SetReminder();
            ev.RemoveReminder();
            ev.SetReminder();

            // Assert
            Assert.IsTrue(ev.ReminderSet);
        }
    }
}