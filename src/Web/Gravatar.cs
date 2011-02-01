using System.Collections.Generic;
using System.Security.Cryptography;
using System.Web.Mvc;
using System;
using System.Web;

namespace Armory.Web
{
    public class Gravatar
    {
        private string email;
        private string defaultUrl;
        private string rating;
        private int size;
        private string alt;

        public Gravatar(string email)
        {
            this.email = email;
        }

        public Gravatar Default(string url)
        {
            defaultUrl = url;
            return this;
        }

        public Gravatar Default(GravatarDefaults provider)
        {
            switch (provider)
            {
                case GravatarDefaults.return404:
                    defaultUrl = "404";
                    break;
                default:
                    defaultUrl = provider.ToString().ToLower();
                    break;
            }

            return this;
        }

        public Gravatar Rating(GravatarRating rating)
        {
            this.rating = rating.ToString().ToLower();
            return this;
        }

        public Gravatar Size(int size)
        {
            if (size < 1 || size > 512) throw new ArgumentException("Gravatars can only be between 1 and 512 in size.", "size");
            this.size = size;
            return this;
        }

        public Gravatar AlternateText(string alt)
        {
            this.alt = alt;
            return this;
        }

        public override string ToString()
        {
            var bld = new TagBuilder("img");

            var src = string.Format("http://www.gravatar.com/avatar/{0}?", CreateMD5Hash(email));
            
            if (!String.IsNullOrEmpty(rating)) 
                src += string.Format("r={0}&", rating);
            
            if (size != 0) 
                src += string.Format("s={0}&", size);

            if (!String.IsNullOrEmpty(defaultUrl)) 
                src += string.Format("d={0}&", HttpUtility.UrlEncode(defaultUrl));

            bld.MergeAttribute("src", src);

            bld.MergeAttribute("alt", alt ?? "Gravatar");

            return bld.ToString(TagRenderMode.SelfClosing);
        }

        public static string CreateMD5Hash(string Value)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                byte[] valueArray = System.Text.Encoding.ASCII.GetBytes(Value);
                valueArray = md5.ComputeHash(valueArray);
                string encrypted = "";
                for (int i = 0; i < valueArray.Length; i++)
                    encrypted += valueArray[i].ToString("x2").ToLower();
                return encrypted;
            }
        }
    }
}