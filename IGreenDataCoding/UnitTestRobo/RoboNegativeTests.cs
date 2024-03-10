using GreenDataRobo;
using GreenDataRobo.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestRobo
{
    [TestFixture]
    public class RoboNegativeTests
    {
        ToyRobot? robot = null;
        CommandInvoker? invoker = null;


        [SetUp]
        public void InitialSetup()
        {
            invoker = new CommandInvoker();
            robot = new ToyRobot();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            
        }

        [Test]
        public void IncorrectCommand()
        { 
            // Send Incorrect command from commandline - MOVEE
        }

        [Test]
        public void IncorrectPosition()
        {
            // Arrange
            invoker?.AddCommand(new PlaceCommand(new ToyRobot(), 5, 5, "NORTH"));

            // ACT
            invoker?.ExecuteCommands();

            // Assert
            Assert.IsFalse(robot?.IsPlaced);
        }

        [Ignore("This is not covered as part of the requirement")]
        [Test]
        [TestCase(1,1, "NORTHEAST")]
        [TestCase(1,-1, "eastwest")]
        public void IncorrectDirection(int positionX, int positionY, string facing)
        {
            // Arrange
            invoker?.AddCommand(new PlaceCommand(robot ?? new ToyRobot(), positionX, positionY, facing));

            // ACT
            invoker?.ExecuteCommands();

            // Assert
            // bool isPlaced = (bool)GetInstanceField(typeof(ToyRobot), robot, "isPlaced");
            Assert.IsFalse(robot?.IsPlaced);

        }

        /// <summary>
        /// Retrieve the private field value
        /// </summary>
        /// <param name="type"></param>
        /// <param name="instance"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        private object GetInstanceField(Type type, object instance, string fieldName)
        {
            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Static;
            FieldInfo field = type.GetField(fieldName, bindFlags);
            return field.GetValue(instance);
        }

        [TearDown]
        public void Teardown()
        {
            
        }

        

    }
}
