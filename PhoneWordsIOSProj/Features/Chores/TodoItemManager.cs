using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneWordsIOSProj.Services.Rest;

namespace PhoneWordsIOSProj.Features.Chores
{
    public class TodoItemManager
    {
        IRestService restService;

        public TodoItemManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<string>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }
    }

}
