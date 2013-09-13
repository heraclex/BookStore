namespace WebApp.Controllers
{
    using System;
    using System.Web.Mvc;

    using Ojb.DomainServices.Contract.MessageModels.Response;
    using Ojb.DomainServices.Contract.Services;

    using WebApp.Security;
    using WebApp.ViewModel;
    using Ojb.Framework.Common.Logger;
    using Ojb.Framework.WebBase.Authorize;

    public class LoginController : Controller
    {
        private readonly IFormsAuthenticationService formsAuthenticationService;
        private readonly IOjbMemberShipProvider memberShipProvider;
        private readonly ILogger logger = LogManager.GetLogger(typeof(LoginController));

        public LoginController(
            IFormsAuthenticationService formsAuthenticationService, 
            ISecurityService securityService,
            IOjbMemberShipProvider memberShipProvider)
        {
            this.formsAuthenticationService = formsAuthenticationService;
            this.memberShipProvider = memberShipProvider;
        }


        /// <summary>
        ///   The index view.
        /// </summary>
        /// <returns> The view login. </returns>
        [HttpGet]
        public ActionResult Index()
        {
            if (this.Request.IsAuthenticated)
            {
                return this.RedirectToAction("Logout");
            }

            var autoLoginErrorMessage = string.Empty;
            if (this.Session["Auto_Login_Message"] != null && !string.IsNullOrEmpty(this.Session["Auto_Login_Message"].ToString()))
            {
                autoLoginErrorMessage = Session["Auto_Login_Message"].ToString();
                this.Session.Remove("Auto_Login_Message");
            }

            var loginViewModel = new LoginVM
            {
                AssistanceText = string.Empty,
                EnvironmentName = "Book Store Oneline",
                OrganizationName = "NerverLand UK Ltd",
                AutoLoginErrorMessage = autoLoginErrorMessage,
            };

            return this.View("Index", loginViewModel);
        }

        [HttpPost]
        public ActionResult Index(LoginVM loginVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.logger.InfoFormat("User login: {0}", loginVM.LoginModel.UserName);
                    return this.Login(loginVM);
                }
            }
            catch (Exception ex)
            {
                this.logger.Error("Login failed: ", ex);
            }

            return this.Json(new { message = "Invalid login. Please try again." }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        ///   The logout.
        /// </summary>
        /// <returns> The login page . </returns>
        public ActionResult Logout()
        {
            this.formsAuthenticationService.SignOut();
            this.Session.RemoveAll();
            this.Session.Abandon();
            this.Session.Clear();
            return this.RedirectToAction("Index", "Login");
        }
        
        #region private methods

        /// <summary>
        /// The login with cx.
        /// </summary>
        /// <param name="LoginVM">
        /// The login view model.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        private JsonResult Login(LoginVM loginVM)
        {
            var username = loginVM.LoginModel.UserName;
            this.memberShipProvider.ValidateUser(username, loginVM.LoginModel.Password);

            if (this.memberShipProvider.LoginStatus != null && !this.memberShipProvider.LoginStatus.IsSuccess)
            {
                this.logger.InfoFormat("Login failed: {0}", this.memberShipProvider.LoginStatus.InvalidLoginInfo.Value);
                if (this.memberShipProvider.LoginStatus.InvalidLoginInfo.Key
                    == LoginResult.InvalidLoginType.InvalidUsernameOrPassword)
                {
                    return this.Json(
                        new { message = this.memberShipProvider.LoginStatus.InvalidLoginInfo.Value },
                        JsonRequestBehavior.AllowGet);
                }

                if (this.memberShipProvider.LoginStatus.InvalidLoginInfo.Key == LoginResult.InvalidLoginType.UserLocked)
                {
                    return this.Json(
                        new { message = this.memberShipProvider.LoginStatus.InvalidLoginInfo.Value },
                        JsonRequestBehavior.AllowGet);
                }

                if (this.memberShipProvider.LoginStatus.InvalidLoginInfo.Key
                    == LoginResult.InvalidLoginType.NoAccessRight)
                {
                    return this.Json(
                            new
                            {
                                isDialog = true,
                                message = this.memberShipProvider.LoginStatus.InvalidLoginInfo.Value
                            },
                            JsonRequestBehavior.AllowGet);
                }
            }
            else if (this.memberShipProvider.LoginStatus != null)
            {
                this.logger.Info("Login successfully");

                this.formsAuthenticationService.SignIn(loginVM.LoginModel.UserName, false);

                if (this.memberShipProvider.LoginStatus.IsForcedChangePassword)
                {
                    this.logger.Info("Force change password.");
                    this.Session["IsForceChangePassword"] = true;
                    return this.Json(new { isChangePass = true }, JsonRequestBehavior.AllowGet);
                }
                return this.Json(new { url = string.Empty }, JsonRequestBehavior.AllowGet);
            }

            return this.Json(new { message = "Invalid login. Please try again." }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
