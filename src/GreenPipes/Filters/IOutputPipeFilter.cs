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
    public interface IOutputPipeFilter<TInput, out TOutput> :
        IFilter<TInput>,
        IPipeConnector<TOutput>,
        IObserverConnector<TOutput>
        where TInput : class, PipeContext
        where TOutput : class, PipeContext
    {
    }


    public interface IOutputPipeFilter<TInput, out TOutput, in TKey> :
        IOutputPipeFilter<TInput, TOutput>,
        IKeyPipeConnector<TKey>
        where TInput : class, PipeContext
        where TOutput : class, PipeContext
    {
    }
}