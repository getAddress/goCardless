using System;


namespace getAddress.GoCardless._2015_07_06.Api
{
    public abstract class ApiBase
    {
        protected readonly GoCardlessApi Api;

        protected ApiBase(GoCardlessApi api)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));

            Api = api;
        }

    }
}
