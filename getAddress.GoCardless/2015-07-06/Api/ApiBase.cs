
using System;

namespace getAddress.GoCardless.Api
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
