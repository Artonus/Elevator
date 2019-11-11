using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorCore.DataAccess.Abstract;
using ElevatorCore.DataAccess.Model;
using ElevatorCore.Utils.Abstract;

namespace ElevatorCore.Utils
{
    public class Logger : ILogger
    {
        private readonly ISession _session;
        private static Logger _instance;
        public static ILogger Instance(ISession session)
        {
            return _instance ?? (_instance = new Logger(session));
        }
        private Logger(ISession session)
        {
            _session = session;
        }

        public void LogElevatorArrivedAtFloor(int floorNumber)
        {
            Log(CommonMessages.GetElevatorArrivedMessage(floorNumber));
        }

        public void LogElevatorCalledToFloor(int floorNumber)
        {
            Log(CommonMessages.GetElevatorCalledToFloorMessage(floorNumber));
        }

        public void LogElevatorAlreadyMovingToFloor(int floorNumber)
        {
            Log(CommonMessages.GetElevatorAlreadyMovingMessage(floorNumber));
        }

        public void LogElevatorStartedMoving(int floorNumber)
        {
            Log(CommonMessages.GetElevatorStartedMovingMessage(floorNumber));
        }

        public void LogElevatorClosingDoors(int floorNumber)
        {
            Log(CommonMessages.GetElevatorClosingDoorsMessage(floorNumber));
        }

        public void LogElevatorDoorsAlreadyClosing(int floorNumber)
        {
            Log(CommonMessages.GetElevatorDoorsAlreadyClosingMessage(floorNumber));
        }

        public void LogElevatorOpeningDoors(int floorNumber)
        {
            Log(CommonMessages.GetElevatorOpeningDoorsMessage(floorNumber));
        }

        public void LogElevatorDoorsAlreadyOpening(int floorNumber)
        {
            Log(CommonMessages.GetElevatorDoorsAlreadyOpeningMessage(floorNumber));
        }

        public void LogError(string errorMsg)
        {
            Log(CommonMessages.GetErrorMessage(errorMsg));
        }

        private void Log(string message)
        {
            var log = new Log
            {
                Description = message,
                Timestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)
            };
            _session.Logs.Insert(log);
        }
    }
}
