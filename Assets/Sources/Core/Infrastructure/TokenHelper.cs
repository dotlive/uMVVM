﻿using System;
using System.Security.Cryptography;
using uMVVM.Sources.Infrastructure;
using UnityEngine;

namespace Assets.Sources.Core.Infrastructure
{
    public class TokenHelper
    {
        public static string Create()
        {
            var deviceId = SystemInfo.deviceUniqueIdentifier;
            var day = DateTime.Now.Day;
            var month = DateTime.Now.Month;
            var last2DigitsOfYear = DateTime.Now.Year % 100;
            // 依照规则可以添加其他字段，确保足够复杂
            var source = ((day * 10) + (month * 100) + (last2DigitsOfYear) * 1000) + deviceId;
            //创建md5
            using (var md5Hash = MD5.Create())
            {
                return MD5Helper.GetMd5Hash(md5Hash, source);
            }
        }
    }
}
