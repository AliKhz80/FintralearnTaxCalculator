namespace Application.Extentions.ServiceException
{
    /// <summary>
    /// this method used for returning business Logic Massages to Client 
    /// </summary>
    public class LogicException : Exception
    {


        public LogicException(string Massage) : base(Massage)
        {

        }
    }


}
