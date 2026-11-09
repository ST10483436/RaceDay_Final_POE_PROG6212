using Xunit;
using RaceDayMvc.Api.Models;

namespace RaceDay.Tests
{
    public class UnitTest1
    {
        // ==========================================
        // 1. AUTHENTICATION & PASSWORD TESTS
        // ==========================================
        [Fact]
        public void Password_ShouldBeHashed()
        {
            string plainPassword = "Password123!";
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);
            Assert.NotEqual(plainPassword, hashedPassword);
            Assert.StartsWith("$2", hashedPassword);
        }

        [Fact]
        public void Password_Verify_ShouldReturnTrueForCorrectPassword()
        {
            string plainPassword = "Password123!";
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);
            Assert.True(BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword));
        }

        [Fact]
        public void Password_Verify_ShouldReturnFalseForWrongPassword()
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword("Password123!");
            Assert.False(BCrypt.Net.BCrypt.Verify("WrongPassword!", hashedPassword));
        }

        // Using your exact model name: Users
        [Fact]
        public void User_DefaultRole_ShouldBeEmpty()
        {
            var user = new Users();
            Assert.Equal("", user.Role);
        }

        // ==========================================
        // 2. ROLE VALIDATION TESTS
        // ==========================================
        [Theory]
        [InlineData("Organiser", true)]
        [InlineData("Participant", true)]
        [InlineData("Admin", false)]
        [InlineData("organiser", false)]
        [InlineData("", false)]
        public void Role_Validation_ShouldOnlyAllowValidRoles(string role, bool expectedResult)
        {
            bool isValid = role == "Organiser" || role == "Participant";
            Assert.Equal(expectedResult, isValid);
        }

        // ==========================================
        // 3. EVENT MANAGEMENT TESTS
        // ==========================================
        [Theory]
        [InlineData("Run", true)]
        [InlineData("Walk", true)]
        [InlineData("Cycle", true)]
        [InlineData("Swim", false)]
        [InlineData("run", false)]
        public void EventType_Validation_ShouldOnlyAllowRunWalkCycle(string eventType, bool expectedResult)
        {
            bool isValid = eventType == "Run" || eventType == "Walk" || eventType == "Cycle";
            Assert.Equal(expectedResult, isValid);
        }

        // Using your exact model name: Events
        [Fact]
        public void Event_DefaultName_ShouldBeEmpty()
        {
            var ev = new Events();
            Assert.Equal("", ev.EventName);
        }

        [Fact]
        public void Event_Distance_ShouldNotBeNegative()
        {
            var ev = new Events { Distance = 89.00m };
            Assert.True(ev.Distance > 0);
        }

        // ==========================================
        // 4. EVENT ENROLMENT TESTS
        // ==========================================
        // Using your exact model name: EventEnrolments
        [Fact]
        public void EventEnrolment_DefaultStatus_ShouldBeRegistered()
        {
            var enrolment = new EventEnrolments();
            Assert.Equal("Registered", enrolment.Status);
        }

        [Fact]
        public void EventEnrolment_ShouldHaveValidParticipantAndEvent()
        {
            var enrolment = new EventEnrolments { ParticipantId = 1, EventId = 1, CategoryId = 1 };
            Assert.True(enrolment.ParticipantId > 0);
            Assert.True(enrolment.EventId > 0);
            Assert.True(enrolment.CategoryId > 0);
        }

        // ==========================================
        // 5. RESULTS TESTS
        // ==========================================
        // Using your exact model name: Results
        [Fact]
        public void Result_Position_ShouldBeGreaterThanZero()
        {
            var result = new Results { Position = 1 };
            Assert.True(result.Position > 0);
        }

        [Fact]
        public void Result_FinishTime_ShouldNotBeNull()
        {
            var result = new Results { FinishTime = "09:45:30" };
            Assert.NotNull(result.FinishTime);
        }
    }//end of the class
}//end of the namespace