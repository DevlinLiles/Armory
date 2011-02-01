using System.Web.Mvc;
using System;

namespace Armory.Web
{
    public static class HtmlHelperExtensions
    {
        public static Gravatar Gravatar(this HtmlHelper html, string email)
        {
            return new Gravatar(email);
        }
    }
}
