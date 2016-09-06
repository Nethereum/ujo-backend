﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ujo.Search.Service.Tests
{
    public class SearchTests
    {
        string apiAdminKey = "61AC004C8217E1C7E498C81D64B99422";
        string apiSearchKey = "C25D90CA9CF1F3317351A0476D0C2668";
        string serviceName = "ujo";
        string indexName = "worktestindex";

        [Fact]
        public async Task Test()
        {
            var service = new WorkSearchService(serviceName, apiSearchKey, apiAdminKey, indexName);
            await service.DeleteIndexAsync();
            await service.CreateIndexAsync();

            var works = new Work[]
            {
                new Work()
                {
                    Address = "0x050c98dfa840cf812c948fa5b4e247fff75bb063",
                    CreatorsAddresses = new string[] { "0x050c98dfa840cf812c948fa5b4e247fff75bb063_1", "0x050c98dfa840cf812c948fa5b4e247fff75bb063_2" },
                    CreatorsNames = new string[] {"Lil Louis", "Somebody"},
                    Genre = "Techno",
                    Tags = new string[] { "TechHouse", "House" },
                    Title = "Blackout",
                    CoverFile = "QmbwG5QB9ssqu49WDyw93hwGBYMZiueqNKYCkGL6DZC7Vb",
                    WorkFile = "workFile"
                },
                new Work()
                {
                    Address = "0x23c575374941865b641e733c44073c8f02a11229",
                    CreatorsAddresses = new string[] { "0x23c575374941865b641e733c44073c8f02a11229_1", "0x050c98dfa840cf812c948fa5b4e247fff75bb063_2" },
                    CreatorsNames = new string[] { "Laurent Garnier", "Somebody"},
                    Genre = "Techno",
                    Tags = new string[] { "Trance", "House" },
                    Title = "Wake Up",
                    CoverFile = "QmSQVuwTC3oBeAVhXDcY676qkevSvSj4Yv1heC4B7i8qQ5",
                    WorkFile = "workFile"
                }
            };

            await service.BatchUpdateAsync(works);

            //Wait to be indexed
            Thread.Sleep(2000);

            var result = await service.Search("House");
            Assert.Equal(2, result.Count);
            Assert.Equal(3, result.Facets["tags"].Count);
            //we have 1 house, 1 techHouse, 1 Trance
            Assert.Equal(1, result.Facets["genre"].Count);
            //we have 1 main genre Techno

            //we may want to add genre as the fisrt tag as per sound cloud

            result = await service.Search("Somebody");
            Assert.Equal(2, result.Count);

            result = await service.GetWorksByArtistAsync("0x050c98dfa840cf812c948fa5b4e247fff75bb063_2");
            Assert.Equal(2, result.Count);

            result = await service.GetWorksByArtistAsync("0x23c575374941865b641e733c44073c8f02a11229_1");
            Assert.Equal(1, result.Count);

            var suggestResult = await service.SuggestAsync("Laur", true);
            Assert.Equal(1, suggestResult.Results.Count);

            await service.DeleteIndexAsync();
        }
    }
}
