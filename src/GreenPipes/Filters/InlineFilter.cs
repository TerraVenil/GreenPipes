﻿// Copyright 2012-2018 Chris Patterson
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
namespace GreenPipes.Filters
{
    using System.Diagnostics;
    using System.Threading.Tasks;


    public class InlineFilter<TContext> :
        IFilter<TContext>
        where TContext : class, PipeContext
    {
        readonly InlineFilterMethod<TContext> _filterMethod;

        public InlineFilter(InlineFilterMethod<TContext> filterMethod)
        {
            _filterMethod = filterMethod;
        }

        void IProbeSite.Probe(ProbeContext context)
        {
            context.CreateFilterScope("inline");
        }

        [DebuggerNonUserCode]
        [DebuggerStepThrough]
        public Task Send(TContext context, IPipe<TContext> next)
        {
            return _filterMethod(context, next);
        }
    }
}