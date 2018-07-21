using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Exceptions
{
    public class PlayerException : ApplicationException

    {
        public PlayerException()
            : base()
        { }
        public PlayerException(string errormsg)
            : base(errormsg)
        { }
        public PlayerException(string errormsg, System.Exception innerexception)
            : base(errormsg, innerexception)

        { }
    }
    public class MatchException : ApplicationException
    {
        public MatchException()
                : base()
        { }
        public MatchException(string errormsg)
                : base(errormsg)
        { }
        public MatchException(string errormsg, System.Exception innerexception)
                : base(errormsg, innerexception)

        { }
    }
    public class ScheduleException : ApplicationException
    {
        public ScheduleException()
                : base()
        { }
        public ScheduleException(string errormsg)
                : base(errormsg)
        { }
        public ScheduleException(string errormsg, System.Exception innerexception)
                : base(errormsg, innerexception)

        { }
    }
    public class StatisticsException : ApplicationException
    {
        public StatisticsException()
                : base()
        { }
        public StatisticsException(string errormsg)
                : base(errormsg)
        { }
        public StatisticsException(string errormsg, System.Exception innerexception)
                : base(errormsg, innerexception)

        { }
    }
    public class TeamException : ApplicationException

    {
        public TeamException()
            : base()
        { }
        public TeamException(string errormsg)
            : base(errormsg)
        { }
        public TeamException(string errormsg, System.Exception innerexception)
            : base(errormsg, innerexception)

        { }
    }

    public class TicketCategoryException : ApplicationException
    {
        public TicketCategoryException()
                : base()
        { }
        public TicketCategoryException(string errormsg)
                : base(errormsg)
        { }
        public TicketCategoryException(string errormsg, System.Exception innerexception)
                : base(errormsg, innerexception)

        { }
    }
    public class TicketException : ApplicationException

    {
        public TicketException()
                : base()
        { }
        public TicketException(string errormsg)
                : base(errormsg)
        { }
        public TicketException(string errormsg, System.Exception innerexception)
                : base(errormsg, innerexception)

        { }
    }
    public class VenueException : ApplicationException
    {
        public VenueException()
                : base()
        { }
        public VenueException(string errormsg)
                : base(errormsg)
        { }
        public VenueException(string errormsg, System.Exception innerexception)
                : base(errormsg, innerexception)

        { }
    }
    public class StatisticException : ApplicationException
    {
        public StatisticException()
                : base()
        { }
        public StatisticException(string errormsg)
                : base(errormsg)
        { }
        public StatisticException(string errormsg, System.Exception innerexception)
                : base(errormsg, innerexception)

        { }
    }
}
