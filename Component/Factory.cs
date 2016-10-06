using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;

namespace Component
{
    /// <summary>
    /// service factory.It's used to create the concrete class
    /// </summary>
    public class Factory
    {
        private static Factory _instance = null;
        private static readonly object lockHelper=new object();
        /// <summary>
        /// get the Factory class,keep there's only one Factory
        /// </summary>
        /// <returns>Factory</returns>
        public static Factory Instance()
        {
            if (_instance != null) return _instance;
            lock (lockHelper)
            {
                if (_instance != null) return _instance;
                _instance = new Factory();
            }
            return _instance;
        }

        /// <summary>
        /// Get the concrete service based TU
        /// if TU was a interface then return the concrete TU
        /// </summary>
        /// <typeparam name="TU">The class wanted</typeparam>
        /// <returns>TU</returns>
        public TU GetService<TU>() where TU:class 
        {
            StringBuilder suffix=new StringBuilder();
            StringBuilder prefix=new StringBuilder();
            suffix.Append(ConfigurationSettings.AppSettings.Get("FactorySuffix"));
            prefix.Append(ConfigurationSettings.AppSettings.Get("FactoryPrefix"));

            var result=typeof (TU);
            //define the path of the implemented class
            string filePath = "";
            //define the class name of the implemented class
            string className = "";
            
            if (!string.IsNullOrEmpty(prefix.ToString()) && !string.IsNullOrEmpty(suffix.ToString()))
            {
                var path = result.Assembly.Location.Split('\\');
                //get the interface name
                var name = result.Name;
                //get the implemented class name
                var shouldLast = name.Remove(0, prefix.Length);
                //get the implemented class namespace
                var spaceName=result.Namespace.Remove(result.Namespace.Length - suffix.Length, suffix.Length);
                //get the implemented class name and namespace
                className = string.Format("{0}.{1}",spaceName, shouldLast);
                filePath = result.Assembly.Location.Replace(path[path.Length - 1], string.Format("{0}.dll", spaceName));
            }
            var assem=Assembly.LoadFile(filePath);
            return (TU)assem.CreateInstance(className);
            
        }

        /// <summary>
        /// get the classes by loading domain
        /// </summary>
        /// <typeparam name="TU">class</typeparam>
        /// <returns></returns>
        public TU GetServiceByLoad<TU>() where TU:class 
        {
            //get the prefix from configure
            var prefix =ConfigurationSettings.AppSettings.Get("FactoryPrefix");
            //get the suffix from configure
            var suffix =ConfigurationSettings.AppSettings.Get("FactorySuffix");

            //get the type of the class
            var type = typeof (TU);
            //get the type namespace
            var nameSpace = type.Namespace;
            //get the type of the name
            var name = type.Name;
            //get the assemblyName of the type
            var assemblyName = type.Assembly.GetName().Name;
            //the get the real namespace of class
            if (!string.IsNullOrEmpty(suffix))
            {
                var sl = suffix.Length;
                nameSpace = nameSpace.Remove(nameSpace.Length-sl,sl);
                assemblyName = assemblyName.Remove(assemblyName.Length-sl,sl);
            }

            if (!string.IsNullOrEmpty(prefix))
            {
                name = name.Remove(0, prefix.Length);
            }
            var mName = string.Format(@"{0}.{1}",nameSpace,name);
            var assem = Assembly.Load(assemblyName);
            return (TU)assem.CreateInstance(mName);
        }
    }
}
