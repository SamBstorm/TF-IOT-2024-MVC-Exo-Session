namespace TF_IOT_2024_MVC_Exo_Session.Handlers
{
    public abstract class SessionManager
    {
        protected readonly ISession _session;
        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }
    }
}
