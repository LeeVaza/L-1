using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EventManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventManagementTests
{
    [TestClass]
    public class EventManagerTests
    {
        [TestMethod]
        public void Create_Manager()
        {
            // Arrange & Act
            var events = new List<Event>();

            // Assert
            Assert.IsNotNull(events);
        }

        [TestMethod]
        public void Add_Event()
        {
            // Arrange
            var events = new List<Event>();
            var start = new DateTime(2026, 3, 15, 10, 0, 0);
            var end = new DateTime(2026, 3, 15, 12, 0, 0);

            // Act
            events.Add(new Event("Тест", start, end, "Офис", "Описание"));

            // Assert
            Assert.AreEqual(1, events.Count);
            Assert.AreEqual("Тест", events[0].Name);
        }

        [TestMethod]
        public void Add_Multiple_Events()
        {
            // Arrange
            var events = new List<Event>();
            var start = new DateTime(2026, 3, 15, 10, 0, 0);
            var end = new DateTime(2026, 3, 15, 12, 0, 0);

            // Act
            events.Add(new Event("Событие 1", start, end, "Место 1", "Описание 1"));
            events.Add(new Event("Событие 2", start, end, "Место 2", "Описание 2"));
            events.Add(new Event("Событие 3", start, end, "Место 3", "Описание 3"));

            // Assert
            Assert.AreEqual(3, events.Count);
        }

        [TestMethod]
        public void Empty_List()
        {
            // Arrange
            var events = new List<Event>();

            // Assert
            Assert.AreEqual(0, events.Count);
        }

        [TestMethod]
        public void Remove_Event()
        {
            // Arrange
            var start = new DateTime(2026, 3, 15, 10, 0, 0);
            var end = new DateTime(2026, 3, 15, 12, 0, 0);
            var events = new List<Event>
            {
                new Event("Тест", start, end, "Офис", "Описание")
            };

            // Act
            events.RemoveAt(0);

            // Assert
            Assert.AreEqual(0, events.Count);
        }

        [TestMethod]
        public void Get_All_Events()
        {
            // Arrange
            var start = new DateTime(2026, 3, 15, 10, 0, 0);
            var end = new DateTime(2026, 3, 15, 12, 0, 0);
            var events = new List<Event>
            {
                new Event("Событие 1", start, end, "Место 1", "Описание 1"),
                new Event("Событие 2", start, end, "Место 2", "Описание 2")
            };

            // Act
            var count = events.Count;

            // Assert
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void Event_Properties_Accessible()
        {
            // Arrange
            var start = new DateTime(2026, 3, 15, 10, 0, 0);
            var end = new DateTime(2026, 3, 15, 12, 0, 0);
            var ev = new Event("Тест", start, end, "Офис", "Описание");

            // Assert
            Assert.IsNotNull(ev.Name);
            Assert.IsNotNull(ev.Location);
            Assert.IsNotNull(ev.Description);
        }

        [TestMethod]
        public void Event_Reminder_False_By_Default()
        {
            // Arrange
            var start = new DateTime(2026, 3, 15, 10, 0, 0);
            var end = new DateTime(2026, 3, 15, 12, 0, 0);
            var ev = new Event("Тест", start, end, "Офис", "Описание");

            // Assert
            Assert.IsFalse(ev.ReminderSet);
        }

        [TestMethod]
        public void Event_Reminder_Can_Be_Set()
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
        public void Empty_Name_Allowed()
        {
            // Arrange
            var start = new DateTime(2026, 3, 15, 10, 0, 0);
            var end = new DateTime(2026, 3, 15, 12, 0, 0);

            // Act
            var ev = new Event("", start, end, "Офис", "Описание");

            // Assert
            Assert.IsNotNull(ev);
            Assert.AreEqual("", ev.Name);
        }

        [TestMethod]
        public void Empty_Location_Allowed()
        {
            // Arrange
            var start = new DateTime(2026, 3, 15, 10, 0, 0);
            var end = new DateTime(2026, 3, 15, 12, 0, 0);

            // Act
            var ev = new Event("Тест", start, end, "", "Описание");

            // Assert
            Assert.IsNotNull(ev);
            Assert.AreEqual("", ev.Location);
        }

        [TestMethod]
        public void Event_ToString_Works()
        {
            // Arrange
            var start = new DateTime(2026, 3, 15, 10, 0, 0);
            var end = new DateTime(2026, 3, 15, 12, 0, 0);
            var ev = new Event("Конференция", start, end, "Москва", "IT событие");

            // Act
            var result = ev.ToString();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }
    }
}