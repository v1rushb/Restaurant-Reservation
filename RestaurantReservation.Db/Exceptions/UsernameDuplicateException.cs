namespace RestaurantReservation.Db.Exceptions
{
    public class UsernameDuplicateException : Exception
    {
        public UsernameDuplicateException() : base("The username already exists.")
        {
        }

        public UsernameDuplicateException(string Username) : base($"The username '{Username}'" +
            $" already exists.") 
        {

        }
    }
}