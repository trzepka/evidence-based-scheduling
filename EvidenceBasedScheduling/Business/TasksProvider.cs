using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvidenceBasedScheduling.Models.Api;
using Newtonsoft.Json;

namespace EvidenceBasedScheduling.Business
{
    public class TasksProvider
    {
        private class SerializedTasks
        {
            public IEnumerable<Task> Tasks { get; set; }
            public IEnumerable<Task> HistoricalTasks { get; set; }
        }

        #region Serialized tasks

        private string serializedTasks = @"
{
  'tasks': [
    {
      'key': 'DH-1',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-2',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-3',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-4',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-5',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-6',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-7',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-8',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-9',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-10',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-61',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-62',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-63',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-64',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-65',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-66',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-67',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-68',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-69',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-70',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-121',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-122',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-123',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-124',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-125',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-126',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-127',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-128',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-129',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-130',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-181',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-182',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-183',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-184',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-185',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-186',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-187',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-188',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-189',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-190',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-241',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-242',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-243',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-244',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-245',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-246',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-247',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-248',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-249',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-250',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-301',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-302',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-303',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-304',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-305',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-306',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-307',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-308',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-309',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-310',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-361',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-362',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-363',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-364',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-365',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-366',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-367',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-368',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-369',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-370',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 0,
      'estimateSeconds': 10800
    }
  ],
  'historicalTasks': [
    {
      'key': 'DH-11',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 19053,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-12',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 28403,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-13',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 17981,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-14',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 19407,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-15',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 26487,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-16',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 20162,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-17',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 18926,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-18',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 20029,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-19',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 13833,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-20',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 35371,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-21',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 10584,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-22',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 20156,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-23',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 21895,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-24',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 14935,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-25',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 15699,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-26',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 21337,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-27',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 18215,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-28',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 26901,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-29',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 31020,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-30',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 29426,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-31',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 16669,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-32',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 30346,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-33',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 19376,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-34',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 20017,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-35',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 12950,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-36',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 35720,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-37',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 25985,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-38',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 10093,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-39',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 33402,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-40',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 14690,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-41',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 8347,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-42',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 21028,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-43',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 11804,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-44',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 37880,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-45',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 7315,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-46',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 16489,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-47',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 28177,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-48',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 23845,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-49',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 10840,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-50',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 17010,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-51',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 32054,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-52',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 21223,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-53',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 20972,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-54',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 11238,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-55',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 18207,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-56',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 23864,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-57',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 14740,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-58',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 11744,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-59',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 9855,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-60',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'John Smith',
        'emailAddress': null
      },
      'timeSpentSeconds': 16589,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-71',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 4912,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-72',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 26566,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-73',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 12265,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-74',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 4515,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-75',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 5712,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-76',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 14590,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-77',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 16462,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-78',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 8156,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-79',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 12409,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-80',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 5077,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-81',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 9434,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-82',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 14017,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-83',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 18514,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-84',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 7094,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-85',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 12086,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-86',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 9809,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-87',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 10986,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-88',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 9716,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-89',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 29378,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-90',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 18223,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-91',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 25643,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-92',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 7586,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-93',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 20254,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-94',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 11679,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-95',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 5953,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-96',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 12646,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-97',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 4766,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-98',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 15774,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-99',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 10918,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-100',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 19396,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-101',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 15179,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-102',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 13737,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-103',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 4642,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-104',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 15504,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-105',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 9485,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-106',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 19954,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-107',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 16679,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-108',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 6986,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-109',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 14544,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-110',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 23972,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-111',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 21541,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-112',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 6952,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-113',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 19243,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-114',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 17386,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-115',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 10488,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-116',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 13354,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-117',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 14484,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-118',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 11404,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-119',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 14410,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-120',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Jane Doe',
        'emailAddress': null
      },
      'timeSpentSeconds': 11491,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-131',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 21428,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-132',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 25628,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-133',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 10360,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-134',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 20488,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-135',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 26406,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-136',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 9952,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-137',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 22108,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-138',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 49174,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-139',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 39490,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-140',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 57513,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-141',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 41710,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-142',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 10793,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-143',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 26358,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-144',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 8474,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-145',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 7856,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-146',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 28229,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-147',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 41051,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-148',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 38593,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-149',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 13042,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-150',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 23018,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-151',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 12721,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-152',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 45186,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-153',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 34211,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-154',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 19902,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-155',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 25636,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-156',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 13251,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-157',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 13638,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-158',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 17195,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-159',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 7047,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-160',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 18581,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-161',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 26307,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-162',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 29926,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-163',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 22746,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-164',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 10806,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-165',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 9465,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-166',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 28765,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-167',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 22763,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-168',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 16542,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-169',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 21133,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-170',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 26439,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-171',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 10987,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-172',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 28872,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-173',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 10917,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-174',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 19769,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-175',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 29450,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-176',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 15338,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-177',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 19002,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-178',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 10173,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-179',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 14840,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-180',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Steve Black',
        'emailAddress': null
      },
      'timeSpentSeconds': 9703,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-191',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 32062,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-192',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 31653,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-193',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 17916,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-194',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 13505,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-195',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 52890,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-196',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 13790,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-197',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 41985,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-198',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 17859,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-199',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 28827,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-200',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 35568,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-201',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 22220,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-202',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 58142,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-203',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 27173,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-204',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 28488,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-205',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 34085,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-206',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 53995,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-207',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 39257,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-208',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 36068,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-209',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 41408,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-210',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 35077,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-211',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 12149,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-212',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 27290,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-213',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 29785,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-214',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 29447,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-215',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 20376,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-216',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 15113,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-217',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 9450,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-218',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 13514,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-219',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 36654,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-220',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 11906,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-221',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 16947,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-222',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 22557,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-223',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 41695,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-224',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 29274,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-225',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 31646,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-226',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 36721,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-227',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 16359,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-228',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 14225,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-229',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 27133,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-230',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 15338,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-231',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 40369,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-232',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 14136,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-233',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 18227,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-234',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 35174,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-235',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 21002,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-236',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 14522,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-237',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 50750,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-238',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 18029,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-239',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 14989,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-240',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'James Green',
        'emailAddress': null
      },
      'timeSpentSeconds': 20777,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-251',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 87947,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-252',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 28912,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-253',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 28054,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-254',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 83438,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-255',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 62597,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-256',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 12635,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-257',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 15930,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-258',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 83144,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-259',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 23920,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-260',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 58756,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-261',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 30943,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-262',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 28514,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-263',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 22985,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-264',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 19847,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-265',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 27151,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-266',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 17666,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-267',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 24956,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-268',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 54459,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-269',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 21650,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-270',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 20003,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-271',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 7480,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-272',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 46852,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-273',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 28344,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-274',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 52209,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-275',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 31777,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-276',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 50893,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-277',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 24358,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-278',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 15845,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-279',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 15544,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-280',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 24347,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-281',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 89951,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-282',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 19900,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-283',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 30990,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-284',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 70593,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-285',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 36322,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-286',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 52287,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-287',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 12874,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-288',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 12116,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-289',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 75426,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-290',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 21341,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-291',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 53308,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-292',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 22067,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-293',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 28824,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-294',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 21086,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-295',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 23662,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-296',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 35803,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-297',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 25848,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-298',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 27091,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-299',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 39477,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-300',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Samuel Alister',
        'emailAddress': null
      },
      'timeSpentSeconds': 103178,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-311',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 17120,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-312',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 42971,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-313',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 11775,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-314',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 35535,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-315',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 16170,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-316',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 26342,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-317',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 19007,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-318',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 73190,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-319',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 31413,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-320',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 68046,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-321',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 18191,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-322',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 48255,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-323',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 23238,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-324',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 45040,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-325',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 33525,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-326',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 16118,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-327',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 31256,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-328',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 48913,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-329',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 65956,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-330',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 62042,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-331',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 49811,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-332',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 25006,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-333',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 48256,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-334',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 25613,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-335',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 21723,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-336',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 48301,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-337',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 105333,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-338',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 21187,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-339',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 10432,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-340',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 26219,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-341',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 77858,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-342',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 69553,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-343',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 18486,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-344',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 75197,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-345',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 18354,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-346',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 47881,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-347',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 37798,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-348',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 25991,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-349',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 33344,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-350',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 9168,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-351',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 66197,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-352',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 24001,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-353',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 40053,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-354',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 18862,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-355',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 32325,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-356',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 20620,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-357',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 45572,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-358',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 48927,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-359',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 37553,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-360',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Dennis Keen',
        'emailAddress': null
      },
      'timeSpentSeconds': 19354,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-371',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 45268,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-372',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 43755,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-373',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 19880,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-374',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 41261,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-375',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 16235,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-376',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 15323,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-377',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 20816,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-378',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 31176,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-379',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 22600,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-380',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 35537,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-381',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 27690,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-382',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 30070,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-383',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 19850,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-384',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 36926,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-385',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 26714,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-386',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 26017,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-387',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 17825,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-388',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 13545,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-389',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 7997,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-390',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 37870,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-391',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 7616,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-392',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 28887,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-393',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 27126,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-394',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 13210,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-395',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 43281,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-396',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 17711,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-397',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 22178,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-398',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 14816,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-399',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 29059,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-400',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 40984,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-401',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 8970,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-402',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 60850,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-403',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 30646,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-404',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 14570,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-405',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 8450,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-406',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 26406,
      'estimateSeconds': 18000
    },
    {
      'key': 'DH-407',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 7699,
      'estimateSeconds': 7200
    },
    {
      'key': 'DH-408',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 25831,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-409',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 26642,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-410',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 25790,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-411',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 16287,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-412',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 30174,
      'estimateSeconds': 14400
    },
    {
      'key': 'DH-413',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 47977,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-414',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 17179,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-415',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 20545,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-416',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 21841,
      'estimateSeconds': 21600
    },
    {
      'key': 'DH-417',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 32341,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-418',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 17126,
      'estimateSeconds': 10800
    },
    {
      'key': 'DH-419',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 27382,
      'estimateSeconds': 25200
    },
    {
      'key': 'DH-420',
      'name': null,
      'description': null,
      'assignee': {
        'name': 'Joan Albertville',
        'emailAddress': null
      },
      'timeSpentSeconds': 26038,
      'estimateSeconds': 10800
    }
  ]
}
";

        #endregion

        public IEnumerable<Task> CurrentTasks { get; private set; }
        public IEnumerable<Task> HistoricalTasks { get; private set; }

        public TasksProvider()
        {
            var deserializedTasks = JsonConvert.DeserializeObject<SerializedTasks>(serializedTasks);
            CurrentTasks = deserializedTasks.Tasks;
            HistoricalTasks = deserializedTasks.HistoricalTasks;
        }
    }
}