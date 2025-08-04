using Assignment_2.Shared.Models;
using Assignment_2.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Shared.Utilities
{
    // Utilities predominantly used in the sidebar, here's what they do.
    // GetUpcomingTasks: Gets the first 10 tasks > the current date.
    // GetCompletedTasks: Gets the first 10 tasks < the current date, due to time restriction and my lack of not caring I initially
    // wanted to have the ability to mark Tasks as completed but instead I resorted to getting the last 10.
    // GroupTaskItemsBySubject: Sorts the users TaskItems into a dictionary of <SubjectId[string], List<TaskItems>>, where 
    // the list of TaskItems SubjectId's == the dictionary key.
    public class ContainerUtilities
    {

        public static List<T> GetUpcomingTasks<T>(List<T> container, Func<T, DateTime> dateSelector) where T : class => container
                .Where(item => dateSelector(item) > DateTime.Now)
                .OrderBy(dateSelector)
                .Take(10)
                .ToList();
        public static List<T> GetCompletedTasks<T>(List<T> container, Func<T, DateTime> dateSelector) where T : class => container
                .Where(item => dateSelector(item) < DateTime.Now)
                .OrderByDescending(dateSelector)
                .Take(10)
                .ToList();
        public static Dictionary<TKey, List<T>> GroupTaskItemsBySubject<T, TKey>(List<T> container, Func<T, TKey> keySelector) where T : class => container
                        .GroupBy(keySelector)
                        .Select(group => new
                        {
                            Key = group.Key,
                            Items = group.ToList()
                        })
                        .ToDictionary(item => item.Key, item => item.Items);
    }
}
