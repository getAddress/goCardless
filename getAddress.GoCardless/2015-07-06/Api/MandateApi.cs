﻿using getAddress.GoCardless._2015_07_06.Api.Responses;
using getAddress.GoCardless._2015_07_06.Common.Ids;
using System.Threading.Tasks;

namespace getAddress.GoCardless._2015_07_06.Api
{
    public class MandateApi : ApiBase
    {

        private const string Path = "mandates/";

        internal MandateApi(GoCardlessApi api) : base(api)
        {

        }
        public async Task<MandateResponse> Get(MandateId mandateId)
        {
            var json = await Api.Get(Path + mandateId.Value);

            var single = Api.Deserialize<MandateResponseSingle>(json);

            return single.Mandate;
        }
    }
}
