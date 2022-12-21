using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOEIRCNet.API;
using MOEIRCNet.API.Responses;
using MOEIRCNet.Constants;
using Newtonsoft.Json;

namespace MOEIRCNet.Classes
{
    public class Session
    {
        /// <summary>
        /// Идентификатор сессии
        /// </summary>
        public string SessionId { get; set; }
        /// <summary>
        /// Время жизни сессии в секундах
        /// </summary>
        public static int TimeLife { get; set; } = 60;
        /// <summary>
        /// срок годности сессии
        /// </summary>
        public long ExpirationTime { get; } = DateTimeOffset.Now.ToUnixTimeSeconds() + TimeLife;

        private bool _isValid = true;

        /// <summary>
        /// Валидна ли сессия
        /// </summary>
        public bool IsValid => _isValid && DateTimeOffset.Now.ToUnixTimeSeconds() < ExpirationTime;

        private readonly IRest _rest;
        public Session(IRest rest)
        {
            _rest = rest;
        }

        /// <summary>
        /// Завершить сеанс аутентификации 
        /// </summary>
        /// <returns></returns>
        public async Task LogOff()
        {
            await _rest.LogOutAsync(SessionId);
            _isValid = false;
        }


    }
}
