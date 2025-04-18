using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests //Naming principle is name of the class which we test its methods + "Tests"
    {
        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue() //Naming principle is name of tested method + scenario(condition) + behavior(what should do).
        {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true }); //act is to apply method itself with the argument which is set in scenario. (admin)

            //Assert
            Assert.IsTrue(result); //one way of assert syntax
        }

        [Test]
        public void CanbeCancelledBy_SameUserCancelling_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();
            reservation.MadeBy = new User { IsAdmin = false };

            //Act
            var result = reservation.CanBeCancelledBy(reservation.MadeBy);

            //Assert
            Assert.That(result, Is.True); //second way of assert syntax (more readable)
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnsFalse()
        {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = false });

            //Assert
            Assert.That(result == false); //third way of assert syntax
        }
    }
}
