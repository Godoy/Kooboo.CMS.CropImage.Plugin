#region License
// 
// Copyright (c) 2013, Kooboo team
// 
// Licensed under the BSD License
// See the file LICENSE.txt for details.
// 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.CMS.Sites.Extension;
using Kooboo.CMS.Sites.View;
using System.Web;
using System.ComponentModel;
using System.IO;
using System.Web.Mvc;

namespace Kooboo.CMS.Sites.View
{
    public static partial class Image
    {
        public static string CropAndResize(int a, int b) //(string imagePath, int width, int height);
        {
            return (a + b).ToString();
        }
    }
}

namespace Kooboo.CMS.CropImage
{

    //tentando extender a classe fronturlhelper
    //public static class FrontUrlHelper
    //{
    //    public static string CropImage(string imagePath, int width, int height)
    //    {
    //        return "teste";
    //    }
    //}

    //public static class Imagem
    //{
    //    public static string Crop(string imagePath, int width, int height)
    //    {
    //        return String.Format("<strong>SHOW</strong>");

    //    }
    //}

    public interface IResponseManager
    {
        void SetHeader(string name, string value);
    }
    [Kooboo.CMS.Common.Runtime.Dependency.Dependency(typeof(IResponseManager))]
    public class ResponseManager : IResponseManager
    {
        public void SetHeader(string name, string value)
        {
            HttpContext.Current.Response.AddHeader(name, "GET");
        }
    }
    [Description("Sample plugin")]
    public class CropImage : IHttpMethodPagePlugin
    {
        IResponseManager _responseManager;
        public CropImage(IResponseManager responseManager)
        {
            _responseManager = responseManager;
        }

        public System.Web.Mvc.ActionResult HttpGet(Page_Context context, PagePositionContext positionContext)
        {
            _responseManager.SetHeader("SamplePlugin", "GET");

            //context.ControllerContext.Controller.ViewBag.ovos = "ovos";

            //context.ControllerContext.Controller.ControllerContext.
            
            return null;
        }

        public System.Web.Mvc.ActionResult HttpPost(Page_Context context, PagePositionContext positionContext)
        {
            _responseManager.SetHeader("SamplePlugin", "POST");
            return null;
        }



    }
}
