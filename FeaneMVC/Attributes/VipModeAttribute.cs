﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.Interfaces;
using ISession = WebApplication1.Interfaces.ISession;

namespace WebApplication1.Attributes
{
    public class VipModeAttribute : ActionFilterAttribute
    {
        private readonly ISession _session;

        // Constructor to initialize the ISession instance
        public VipModeAttribute(ISession session)
        {
            _session = session;
        }

        // This method is executed before the action method is called
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Retrieve the cookie named "X-KEY" from the HTTP request
            var apiCookie = context.HttpContext.Request.Cookies["X-KEY"];

            if (apiCookie != null)
            {
                // Call the asynchronous method to get the user profile by cookie
                var profile = _session.GetUserByCookie(apiCookie);

                // Check if the profile is not null and if the user role is VIP
                if (profile != null && profile.Roles == Models.Enums.Role.VIP)
                {
                    // Set the user profile in the current HttpContext
                    context.HttpContext.Items["UserProfile"] = profile;
                }
                else
                {
                    // Redirect to the error page if the user is not a VIP
                    context.Result = new RedirectToActionResult("Error404", "Error", null);
                }
            }
            else
            {
                // Redirect to the error page if the cookie is not found
                context.Result = new RedirectToActionResult("Error404", "Error", null);
            }

            // Call the base method to ensure the filter executes correctly
            base.OnActionExecuting(context);
        }
    }
}
