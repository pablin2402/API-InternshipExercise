using System;
namespace BusinessLogic.Exception
{
    public class EmptyOrNullStatus : System.Exception
    {
        public int Code { get { return 406; } }

        public EmptyOrNullStatus(string message) : base(message)
        {

        }

    }
    public class EmptyOrNullId : System.Exception
    {
        public int Code { get { return 406; } }

        public EmptyOrNullId(string message) : base(message)
        {

        }

    }
    public class EmptyOrNullName : System.Exception
    {
        public int Code { get { return 406; } }

        public EmptyOrNullName(string message) : base(message)
        {

        }

    }
}