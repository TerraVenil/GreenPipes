﻿// Copyright 2007-2016 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace GreenPipes.Specifications
{
    using System;
    using System.Collections.Generic;
    using Filters;


    public class RateLimitPipeSpecification<T> :
        IPipeSpecification<T>
        where T : class, PipeContext
    {
        readonly IPipeRouter _router;
        readonly TimeSpan _interval;
        readonly int _rateLimit;

        public RateLimitPipeSpecification(int rateLimit, TimeSpan interval, IPipeRouter router = null)
        {
            _rateLimit = rateLimit;
            _interval = interval;
            _router = router;
        }

        public void Apply(IPipeBuilder<T> builder)
        {
            var filter = new RateLimitFilter<T>(_rateLimit, _interval);

            builder.AddFilter(filter);

            _router?.ConnectPipe(filter);
        }

        public IEnumerable<ValidationResult> Validate()
        {
            if (_rateLimit < 1)
                yield return this.Failure("RateLimit", "must be >= 1");
            if (_interval <= TimeSpan.Zero)
                yield return this.Failure("Interval", "must be > 0");
        }
    }
}