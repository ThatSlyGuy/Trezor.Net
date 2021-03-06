namespace Trezor.Net.Contracts.Bitcoin
{
    [ProtoBuf.ProtoContract()]
    public class GetPublicKey : ProtoBuf.IExtensible
    {
        private ProtoBuf.IExtension __pbn__extensionData;
        ProtoBuf.IExtension ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoBuf.ProtoMember(1, Name = @"address_n")]
        public uint[] AddressNs { get; set; }

        [ProtoBuf.ProtoMember(2, Name = @"ecdsa_curve_name")]
        [System.ComponentModel.DefaultValue("")]
        public string EcdsaCurveName
        {
            get => __pbn__EcdsaCurveName ?? "";
            set => __pbn__EcdsaCurveName = value;
        }
        public bool ShouldSerializeEcdsaCurveName() => __pbn__EcdsaCurveName != null;
        public void ResetEcdsaCurveName() => __pbn__EcdsaCurveName = null;
        private string __pbn__EcdsaCurveName;

        [ProtoBuf.ProtoMember(3, Name = @"show_display")]
        public bool ShowDisplay
        {
            get => __pbn__ShowDisplay.GetValueOrDefault();
            set => __pbn__ShowDisplay = value;
        }
        public bool ShouldSerializeShowDisplay() => __pbn__ShowDisplay != null;
        public void ResetShowDisplay() => __pbn__ShowDisplay = null;
        private bool? __pbn__ShowDisplay;

        [ProtoBuf.ProtoMember(4, Name = @"coin_name")]
        [System.ComponentModel.DefaultValue(@"Bitcoin")]
        public string CoinName
        {
            get => __pbn__CoinName ?? @"Bitcoin";
            set => __pbn__CoinName = value;
        }
        public bool ShouldSerializeCoinName() => __pbn__CoinName != null;
        public void ResetCoinName() => __pbn__CoinName = null;
        private string __pbn__CoinName;

        [ProtoBuf.ProtoMember(5, Name = @"script_type")]
        [System.ComponentModel.DefaultValue(InputScriptType.Spendaddress)]
        public InputScriptType ScriptType
        {
            get => __pbn__ScriptType ?? InputScriptType.Spendaddress;
            set => __pbn__ScriptType = value;
        }
        public bool ShouldSerializeScriptType() => __pbn__ScriptType != null;
        public void ResetScriptType() => __pbn__ScriptType = null;
        private InputScriptType? __pbn__ScriptType;

    }
}