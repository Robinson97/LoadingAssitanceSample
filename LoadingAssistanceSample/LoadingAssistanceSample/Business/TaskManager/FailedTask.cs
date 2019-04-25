using System;
using System.Collections.Generic;
using System.Text;

namespace LoadingAssistanceSample.Business.TaskManager
{
    public class FailedTask
    {
        /// <summary>
        /// Task ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Occured Error
        /// </summary>
        public AggregateException Exception { get; set; }
    }
}
