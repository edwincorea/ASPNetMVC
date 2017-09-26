// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
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

namespace EjemploUsoSessionYAjax.DependencyResolution {
    using AutoMapper;
    using AutoMapper.Configuration;
    using Controllers;
    using Core;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                });

            //Obtener los perfiles
            IEnumerable<AutoMapper.Profile> profiles = from t in typeof(DefaultRegistry).Assembly.GetTypes()
                                                       where typeof(Profile).IsAssignableFrom(t)
                                                       select (Profile)Activator.CreateInstance(t);

            //Para cada perfil, incluir el perfil en el MapperConfigurationExpression
            MapperConfigurationExpression configuracion = new MapperConfigurationExpression();
            foreach (var profile in profiles)
            {
                configuracion.AddProfile(profile);
            }

            MapperConfiguration configuracionDeMapeador = new MapperConfiguration(configuracion);

            //Crear mapeador que será usado por el contenedor DI
            var mapeadorDeObjetos = new Mapper(configuracionDeMapeador);

            //Regitrar las interfaces DI con su implementación
            For<MapperConfiguration>().Use(configuracionDeMapeador);
            For<IMapper>().Use(mapeadorDeObjetos);
        }

        #endregion
    }
}