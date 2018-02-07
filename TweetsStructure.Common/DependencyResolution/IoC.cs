// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using FluentNHibernate;
using StructureMap;
using StructureMap.Graph;
using System;
using TweetsStructure.Common.Configuration.Interfaces;
using TweetsStructure.Common.Data.Classes;
using TweetsStructure.Common.Data.Interfaces;
using TweetsStructure.Common.Nhibernate.Classes;
using TweetsStructure.Common.Nhibernate.Interfaces;

namespace TweetsStructure.Common.DependencyResolution {
    public static class IoC {
        public static IContainer Initialize<T,Y>(Action<IInitializationExpression> action) where T : IConfiguration, new()
                                                                                            where Y : IMappingProvider, new()
        {
            ObjectFactory.Initialize(x =>
                        {
                            action.Invoke(x);
                            x.For<IConfiguration>().Use<T>();
                            x.For<ISessionBuilder>().Use<SessionBuilder<Y>>();
                            x.For<ISessionHelper>().Use<SessionHelper<Y>>();
                            x.For(typeof(IRepository<>)).Use(typeof(Repository<>));
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
            //                x.For<IExample>().Use<Example>();
                        });
            return ObjectFactory.Container;
        }
    }
}