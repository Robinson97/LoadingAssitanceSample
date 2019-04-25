using System;
using System.Collections.Generic;
using System.Text;

namespace LoadingAssistanceSample.Business.TaskManager
{
    public class TaskResult
    {
        /// <summary>
        /// ID of the Task
        /// </summary>
        public int TaskID { get; set; }

        /// <summary>
        /// Task Result
        /// </summary>
        public object Result { get; set; }
    }
}
