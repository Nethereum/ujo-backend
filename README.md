# Ujo Backend

This is the deprecated Ujo Backend Ethereum integration using Nethereum, Blockchain Processing, Data Processing, Azure Search, Azure Table Storage, Queuing, Web jobs and Ipfs. Whilts the deprication seemed necessary at the time, due the mainnet constrains with the storage of data, cost and scalability, the solution and structure is still valid on other smart contract data driven scenarios (permissioned chains, consortiums, sidechains, etc)

The solution for this problem domain focuses on the performance needs required to monitor and process events and log changes of millions of smart contracts (ie artists or works) which are part of common registry. It becomes rather hard to create and maintain filter logs using the bloom filters for that huge amount of smart contracts, which will then be queued or injected interface implentation for further processing of the smart contract changes.

The backend solution is split in several parts:

## Common Components / Infrastructure 
The CCC layer or common infrastructure layer, this is the current reference architecture for Nethereums Blokchain Log Processing and Smart contract data processing.

### Blockchain Processing 
https://github.com/Nethereum/ujo-backend/tree/master/Consensys.Common/CCC.BlockchainProcessing

### Registry Processing, a common smart contract registry service
https://github.com/Nethereum/ujo-backend/tree/master/Consensys.Common/CCC.Contracts.Registry.Processing

### Data Processing, a common data processing layer 
https://github.com/Nethereum/ujo-backend/tree/master/Consensys.Common/CCC.Contracts.StandardData.Processing

## Other commmon services:

### IPFS image services 	
The IPFS image services provide a webjob queing processing to resize ipfs hosted images and republish them. https://github.com/Nethereum/ujo-backend/tree/master/Ipfs.Services

## Ujo / Music domain specific implementation including

•	Azure search https://github.com/Nethereum/ujo-backend/tree/master/Ujo.Work/Ujo.Work.Search.Service

•	Azure Storage  https://github.com/Nethereum/ujo-backend/tree/master/Ujo.Work/Ujo.Work.Storage

•	Azure Sql https://github.com/Nethereum/ujo-backend/tree/master/Ujo.Work/Ujo.Repository

•	Web job https://github.com/Nethereum/ujo-backend/tree/master/Ujo.Work/Ujo.WorkRegistry.WebJob

•	Simple Ethereum integration https://github.com/Nethereum/ujo-backend/tree/master/Ujo.Work/Ujo.Work.Services.Ethereum

## Future

The Nethereum blockchain processing layer now is moving into the specific smart contract Data area, which is the hardening of the above in the same ways as we have done with the hardening of the generic blockchain processing, providing a common data layer for domain specific solutions like Music, Commerce, frameworks like the Wonka Rule Engine and other future backend data processing (Ml.Net)


# Thanks and credits
All the love to the Ujo team at the time

Jesse, Simon, Gabe, Karl, Alex and Gael
