
using System;

namespace TestNinja.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; private set; }

        public event EventHandler<Guid> ErrorLogged;

        public void Log(string error)
        {
            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException(); //testing throw exception case

            LastError = error; //testing major logic of method

            //Write the log to a storage
            // ...

            ErrorLogged?.Invoke(this, Guid.NewGuid()); //testing event
        }
    }
}