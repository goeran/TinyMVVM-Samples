using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace RichRememberTheMilk.Desktop.Tests.Learning
{
    public class ScenarioClass<T> where T: class
    {
        private Whens whens = new Whens();

        protected T Given { get { return this as T; } }
        protected T And { get { return this as T; } }
        protected Whens When { get { return whens; } }
        protected T Then { get { return this as T; } }

        protected class Whens
        {
            public void User_logon()
            {
                Console.WriteLine("user logon");   
            }
        }
    }

    [TestFixture]
    public class BDDSyntaxTests : ScenarioClass<BDDSyntaxTests>
    {
        [Test]
        public void testing_syntax()
        {
            Given.Hello();
            When.User_logon();
        }

        public void Hello()
        {
            Console.WriteLine("Hello");   
        }
    }
}
