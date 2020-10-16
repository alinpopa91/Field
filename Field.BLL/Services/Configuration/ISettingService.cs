using Field.BLL.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Field.BLL.Services.Configuration
{
    public interface ISettingService
    {
        /// <summary>
        /// Load settings
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        T LoadSetting<T>() where T : ISettings, new();

        /// <summary>
        /// Get setting value by key
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">Key</param>
        /// <param name="defaultValue">Default value</param>        
        /// <returns>Setting value</returns>
        T GetSettingByKey<T>(string key, T defaultValue = default(T));
    }
}
