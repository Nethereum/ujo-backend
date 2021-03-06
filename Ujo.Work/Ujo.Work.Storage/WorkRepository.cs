﻿using System;
using System.Threading.Tasks;
using CCC.Contracts.StandardData.Processing;
using CCC.Contracts.StandardData.Services.Model;
using Microsoft.WindowsAzure.Storage.Table;
using Nethereum.Web3;
using Ujo.Messaging;
using Ujo.Work.Model;
using Wintellect.Azure.Storage.Table;

namespace Ujo.Work.Storage
{
    public class WorkRepository:IStandardDataProcessingService<MusicRecordingDTO>
    {
        private readonly AzureTable _worksTable;

        public WorkRepository(CloudTable table)
        {
            _worksTable = new AzureTable(table);
        }

        public WorkRepository(AzureTable table)
        {
            _worksTable = table;
        }

        public async Task<WorkEntity> FindAsync(string address)
        {
            return await WorkEntity.FindAsync(_worksTable, address);
        }

        public WorkEntity NewWork(MusicRecordingDTO work)
        {
            var workEntity = new WorkEntity(_worksTable);
            workEntity.Initialise(work);
            return workEntity;
        }

        public async Task<bool> ExistsAsync(string contractAddress)
        {
            return await WorkEntity.ExistsAsync(_worksTable, contractAddress);
        }

        public async Task UpsertAsync(MusicRecordingDTO work)
        {
            if (work != null)
            {
                var workEntity = NewWork(work);
                await workEntity.InsertOrReplaceAsync();
            }
        }

        public async Task DataChangedAsync(MusicRecordingDTO work, EventLog<DataChangedEvent> dataEventLog)
        {
            var workEntity = await FindAsync(dataEventLog.Log.Address);
            var key = dataEventLog.Event.Key;
            var val = dataEventLog.Event.Value;

            WorkSchema schemaField;

            if (Enum.TryParse(key, out schemaField))
            {
                workEntity.Initialise(work);
            }
            else
            {
                workEntity.SetUnknownKey(val, key);
            }
            await workEntity.InsertOrMergeAsync();
        }

        public async Task RemovedAsync(string contractAddress)
        {
            var workEntity = await FindAsync(contractAddress);
            if (workEntity != null)
            {
                await workEntity.DeleteAsync();
            }
        }
    }
}