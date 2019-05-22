# Ujo Nethereum backend reference architecture

This Backend Ethereum integration uses Nethereum, Blockchain Processing, Data Processing, Azure Search, Azure Table Storage, Queuing, Web jobs and Ipfs. The Ujo elements were deprecated due to a change on architecture direction but a good reference architecture to get started on smart contract data driven scenarios (permissioned chains, consortiums, sidechains, etc), also it fits other requirements which may not be specific to smart contract data events, another could be the monitoring of ERC20 tokens in a DEX registry. 

The solution for this problem domain focuses on the performance needs required to monitor and process events and log changes of millions of smart contracts (ie artists or works) which are part of common registry. It becomes rather hard to create and maintain filter logs using the bloom filters for that huge amount of smart contracts, which will then be queued or injected interface implentation for further processing of the smart contract changes.

The backend solution is split in several parts:

## Common Components / Infrastructure 
The CCC layer or common infrastructure layer, this is the current reference architecture for Nethereums Blokchain Log Processing and Smart contract data processing.

### Blockchain Processing 

The blockchain processing component provides a pluggable infrastructure to monitor and process transactions, smart contracts changes on state and / or events (logs) raised.

For example, the continuous processing and monitoring of token transfers (Erc20) made by a specific address, or in a more complex scenario the monitoring and processing of all the transactions made by many token contracts (Erc20) registered in an exchange.
Processing can be of any type, storage of transaction history, indexing of data, data analytics, monitoring of payments, etc.

https://github.com/Nethereum/ujo-backend/tree/master/Consensys.Common/CCC.BlockchainProcessing

### Registry Processing, a common smart contract registry service
The registry processing component provides the components to monitor and backend processing of registration and unregistrations of addresses on a standard registration contract.

https://github.com/Nethereum/ujo-backend/tree/master/Consensys.Common/CCC.Contracts.Registry.Processing

### Data Processing, a common data processing layer 
The standard data processing component allows to monitor and backend processing all the data changed events of contracts which follow the standard.

#### Standard DataLog Processor
The StandardDataLogProcessor is an implementation of the ILogProcessor, allowing it to be plugged into the Blockchain Log Processor.
The log processor validates matching event logs and if contracts belong to the standard data registry.
#### IStandardDataProcessingService
Different implementations of the IStandardDataProcessingService can be configured / registered either by code or Queues. Current implementations stores the data in Azure Search for indexing, Azure Table Storage and Azure Sql.

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
