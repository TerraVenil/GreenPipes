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
namespace GreenPipes
{
    using System;
    using Specifications;


    public static class LatestConfigurationExtensions
    {
        /// <summary>
        /// Adds a latest value filter to the pipe
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configurator"></param>
        /// <param name="configure"></param>
        public static void UseLatest<T>(this IPipeConfigurator<T> configurator, Action<ILatestConfigurator<T>> configure = null)
            where T : class, PipeContext
        {
            if (configurator == null)
                throw new ArgumentNullException(nameof(configurator));

            var pipeBuilderConfigurator = new LatestPipeSpecification<T>();

            configure?.Invoke(pipeBuilderConfigurator);

            configurator.AddPipeSpecification(pipeBuilderConfigurator);
        }
    }
}