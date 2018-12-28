﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SystemGear.窗体
{
    /// <summary>
    /// 控件的状态。
    /// </summary>
    internal enum ControlState
    {
        /// <summary>
        ///  正常。
        /// </summary>
        Normal,
        /// <summary>
        /// 鼠标进入。
        /// </summary>
        Hover,
        /// <summary>
        /// 鼠标按下。
        /// </summary>
        Pressed,
        /// <summary>
        /// 获得焦点。
        /// </summary>
        Focused,
    }
}
