using System;
using System.Text;
using UnityEngine;

namespace Assets.Sources.Core.Log
{
    public abstract class LogStrategy
    {
        private readonly StringBuilder _messageBuilder = new StringBuilder();
        protected IContentWriter Writer { get; set; }

        /// <summary>
        /// 模板方法
        /// </summary>
        protected abstract void RecordMessage(string message);

        protected abstract void SetContentWriter();

        /// <summary>
        /// 公共的API
        /// </summary>
        public void Log(string message, bool verbose = false)
        {
            if (verbose)
            {
                //公共方法
                RecordDateTime();
                RecordDeviceModel();
                RecordDeviceName();
                RecordOperatingSystem();
            }

            //抽象方法，交由子类实现
            RecordMessage(_messageBuilder.AppendLine($"Message:{message}").ToString());
        }

        private void RecordDateTime()
        {
            _messageBuilder.AppendLine($"DateTime:{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        }

        private void RecordDeviceModel()
        {
            _messageBuilder.AppendLine($"Device Model:{SystemInfo.deviceModel}");
        }

        private void RecordDeviceName()
        {
            _messageBuilder.AppendLine($"Device Name:{SystemInfo.deviceName}");
        }

        private void RecordOperatingSystem()
        {
            _messageBuilder
                .AppendLine($"Operating System:{SystemInfo.operatingSystem}")
                .AppendLine();
        }
    }
}
