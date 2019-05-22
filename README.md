# Ujo Backend

This is the deprecated Ujo Backend Ethereum integration using Nethereum, Blockchain Processing, Data Processing, Azure Search, Azure Table Storage, Queuing, Web jobs and Ipfs.

The backend solution is splitted in several parts:

The CCC layer or common infrastructure layer, this is the current reference architecture for Nethereums Blokchain Log Processing and Smart contract data processing.

•	Blockchain Processing https://github.com/Nethereum/ujo-backend/tree/master/Consensys.Common/CCC.BlockchainProcessing

•	Registry Processing, a common smart contract registry service https://github.com/Nethereum/ujo-backend/tree/master/Consensys.Common/CCC.Contracts.Registry.Processing

•	Data Processing, a common data processing layer https://github.com/Nethereum/ujo-backend/tree/master/Consensys.Common/CCC.Contracts.StandardData.Processing

Other commmon services:

* IPFS image services 	https://github.com/Nethereum/ujo-backend/tree/master/Ipfs.Services The IPFS image services provide a webjob queing processing to resize ipfs hosted images and republish them.

Finally the Ujo / Music domain specific implementation including

•	Azure search https://github.com/Nethereum/ujo-backend/tree/master/Ujo.Work/Ujo.Work.Search.Service

•	Azure Storage  https://github.com/Nethereum/ujo-backend/tree/master/Ujo.Work/Ujo.Work.Storage

•	Azure Sql https://github.com/Nethereum/ujo-backend/tree/master/Ujo.Work/Ujo.Repository

•	Web job https://github.com/Nethereum/ujo-backend/tree/master/Ujo.Work/Ujo.WorkRegistry.WebJob

•	Simple Ethereum integration https://github.com/Nethereum/ujo-backend/tree/master/Ujo.Work/Ujo.Work.Services.Ethereum

The Nethereum blockchain processing layer now is moving into the specific smart contract Data area, which is the hardening of the above in the same ways as we have done with the hardening of the generic blockchain processing, providing a common data layer for domain specific solutions like Music, Commerce, frameworks like the Wonka Rule Engine and other future backend data processing (Ml.Net)


# Thanks, credits and love to the Ujo team at the time.

Jesse, Simon, Gabe, Karl, Alex and Gael
