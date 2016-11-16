using System.Threading.Tasks;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Web3;

namespace Ujo.WorkRegistry.Service
{
    //public class WorkRegistryWorkByteCodeMatcher
    //{
    //    private static string workByteCode =
    //       "0x6060604052361561008d5760e060020a6000350463149cc21081146100925780631babd036146100e857806334cae885146101175780633cebb823146101c757806363bb4c52146101da578063654cf88c146101f05780639201de5514610263578063a33e647e14610273578063ded8454a14610286578063eab700db1461032a578063ecdc58c814610340575b610002565b346100025761039960043560008181526003602052604080822090518154819083906002610100600183161502600019019091160480156104fc5780601f106104da5761010080835404028352918201916104fc565b34610002576103ab60043561050f5b6000805433600160a060020a0390811691161415610c6a57506001610c6e565b3461000257604080516020600480358082013583810280860185019096528085526103ab95929460249490939285019282918501908490808284375050604080516020601f8935808c013591820183900483028401830190945280835297999860449892975092909201945092508291508401838280828437509496505093359350505050604080518082018252600080825260208083018290528351908101909352808352909161056a6100f7565b34610002576103ab60043561074b6100f7565b34610002576103ab6004356024356107856100f7565b34610002576103ad60043560036020908152600091825260409182902080548351601f60026000196101006001861615020190931692909204918201849004840281018401909452808452909183018282801561081d5780601f106107f25761010080835404028352916020019161081d565b34610002576103ad600435610423565b34610002576103ab6004356108566100f7565b34610002576103ad6004356020604051908101604052806000815260200150600060146040518059106102b65750595b9080825280602002602001820160405280156102cd575b509150600090505b601481101561059e578060130360080260020a83600160a060020a03168115610002570460f860020a028282815181101561000257906020010190600160f860020a031916908160001a9053506001016102d5565b34610002576103ab6004356024356108b26100f7565b346100025760408051602060046024803582810135601f81018590048502860185019096528585526103ab958335959394604494939290920191819084018382808284375094965050933593505050505b61090e6100f7565b60408051918252519081900360200190f35b005b60405180806020018281038252838181518152602001915080519060200190808383829060006004602084601f0104600302600f01f150905090810190601f16801561040d5780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b506109b89050425b60408051602081810183526000808352835180830185528181529351929392909182918059106104505750595b908082528060200260200182016040528015610467575b509250600091505b602082101561084d57506008810260020a84027fff000000000000000000000000000000000000000000000000000000000000008116156104cf57808383815181101561000257906020010190600160f860020a031916908160001a9053505b60019091019061046f565b820191906000526020600020905b8154815290600101906020018083116104e8575b5050604051908190039020949350505050565b1561008d5780600160a060020a0316634420e486306040518260e060020a0281526004018082600160a060020a03168152602001915050600060405180830381600087803b156100025760325a03f115610002575050505b50565b1561008d576105a4855b60408051808201825260008082526020918201528151808301909252825182528281019082018190525b50919050565b9250600091505b85518210156105f95760408051808201909152600181527f7c00000000000000000000000000000000000000000000000000000000000000602082015261060190610622906106a490610574565b505050505050565b905061073f8683815181101561000257906020019060200201518286610391565b604080516020818101835260008083528351918201845280825284519351929391929091908059106106515750595b908082528060200260200182016040528015610668575b509150602082019050610c71818560200151866000015160005b60208210610c96578251845260209384019390920191601f1990910190610682565b85906040805180820190915260008082526020820152610c7183838360408051808201909152600080825260208083018290528551868201518651928701516108259390600080808080888711610cb55760208711610cc75760018760200360080260020a031980875116888b038a018a96505b818388511614610734576001870196819010610718578b8b0196505b505050839450610cbb565b600191909101906105ab565b1561008d576000805473ffffffffffffffffffffffffffffffffffffffff19166c0100000000000000000000000083810204179055610567565b1561008d5781600160a060020a031663aa67735482306040518360e060020a0281526004018083600160a060020a0316815260200182600160a060020a0316815260200192505050600060405180830381600087803b156100025760325a03f115610002575050505b5050565b820191906000526020600020905b81548152906001019060200180831161080057829003601f168201915b505050505081565b60208087018051918601919091528051820385528651905191925001811415610c7857600085525b50909392505050565b1561008d5780600160a060020a0316632ec2c246306040518260e060020a0281526004018082600160a060020a03168152602001915050600060405180830381600087803b156100025760325a03f11561000257505050610567565b1561008d5781600160a060020a0316632ec2c246826040518260e060020a0281526004018082600160a060020a03168152602001915050600060405180830381600087803b156100025760325a03f115610002575050506107ee565b1561008d57600083815260036020908152604082208451815482855293839020919360026000196001831615610100020190911604601f90810184900483019391929187019083901061098457805160ff19168380011785555b5061041b9291505b808211156109b45760008155600101610970565b82800160010185558215610968579182015b82811115610968578251826000505591602001919060010190610996565b5090565b7f646174654d6f646966696564000000000000000000000000000000000000000060009081526003602090815282517f98e19eede669ae20251fc0021b5471ae27cfea8f84ef648abf72597428d8b18c80549381905293601f6002600019610100600188161502019095169490940484018390047f100bae4bc2c7063ab9723707e6aa89741feb5a177b623be59fefc8153084be699081019492939092910190839010610a7857805160ff19168380011785555b50610aa8929150610970565b82800160010185558215610a6c579182015b82811115610a6c578251826000505591602001919060010190610a8a565b5050808015610b325750600254604080516000602091820181905282517f3560afd5000000000000000000000000000000000000000000000000000000008152600481018890529251600160a060020a0390941693633560afd59360248082019493918390030190829087803b156100025760325a03f11561000257505060405151151560011490505b15610bd05782600019167f7e8c916a2c8d9cc8d8e67f1028137812a6d636c5e1b1dc547a5ca0f9f415e1db8360405180806020018281038252838181518152602001915080519060200190808383829060006004602084601f0104600302600f01f150905090810190601f168015610bbe5780820380516001836020036101000a031916815260200191505b509250505060405180910390a2610c65565b82600019167ffbd6e799d0b7e94983ada5c7c8d53bf8897a567d5453ded6f059b25204bb58248360405180806020018281038252838181518152602001915080519060200190808383829060006004602084601f0104600302600f01f150905090810190601f168015610c575780820380516001836020036101000a031916815260200191505b509250505060405180910390a25b505050565b5060005b90565b5092915050565b83518351865191019003855283518101602086015250909392505050565b50905182516020929092036101000a6000190180199091169116179052565b88880194505b50505050949350505050565b8686208894506000935091505b8689038311610cb5575085832081811415610cf157839450610cbb565b6001938401939290920191610cd456";

    //    private readonly Web3 web3;

    //    public WorkRegistryWorkByteCodeMatcher(Web3 web3)
    //    {
    //        this.web3 = web3;
    //    }

    //    public async Task<bool> IsMatchAsync(string address)
    //    {
    //        var code = await web3.Eth.GetCode.SendRequestAsync(web3.ToValid20ByteAddress(address));
    //        return code.IsTheSameHex(workByteCode); 
    //    }
    //}
}