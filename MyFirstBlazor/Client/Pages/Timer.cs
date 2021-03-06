﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyFirstBlazor.Client.Pages
{
    public class Timer:ComponentBase
    {   
        [Parameter]
        public double TimeInSeconds { get; set; }

        [Parameter]
        public EventCallback Tick { get; set; }

        protected override void OnInitialized()
        {
            var timer = new System.Threading.Timer(
                    callback: (_)=>InvokeAsync(()=>Tick.InvokeAsync(null)),
                    state: null,
                    dueTime: TimeSpan.FromSeconds(TimeInSeconds),
                    period: Timeout.InfiniteTimeSpan
                );
        }
    }
}
