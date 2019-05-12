using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadingAssistanceSample.Business.TaskManager
{
    public class TaskManager
    {

        #region Fields

        #endregion

        #region Propertys
        public List<TaskResult> TaskResults { get; set; }

        public List<FailedTask> FailedTasks { get; set; }
        #endregion

        #region Methods
        public async Task<bool> RunTaskAsync(IEnumerable<Task> taskCollection)
        {
            FailedTasks = new List<FailedTask>();
            TaskResults = new List<TaskResult>();

            //The main difference between Task.WaitAll and Task.WhenAll is that the former will block (similar to using Wait on a single task) while the latter will not and can be awaited, yielding control back to the caller until all tasks finish. 

            try
            {
                //foreach (var item in task)
                //{

                //    try
                //    {
                //        var result = await item;

                //        if (item.Exception != null)
                //        {
                //            _failedTasks.Add(new FailedTask() { ID = item.Id, Exception = item.Exception });
                //        }

                //        TaskResults.Add(new TaskResult() { TaskID = item.Id, Result = result });
                //    }
                //    catch (Exception ex)
                //    {
                //        _failedTasks.Add(new FailedTask() { ID = item.Id, Exception = ex as AggregateException });
                //    }  
                //}
                await Task.WhenAll(taskCollection.ToArray());

                foreach (var task in taskCollection)
                {
                    if (task.Exception != null)
                    {
                        FailedTasks.Add(new FailedTask() { ID = task.Id, Exception = task.Exception});
                    }  
                }
            }
            catch (Exception ex)
            {
                Debugger.Break();
                return false;
            }
           

            return FailedTasks.Count == 0;

        }
        #endregion
    }
}
