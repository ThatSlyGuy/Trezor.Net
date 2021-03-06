namespace Trezor.Net.Contracts.Lisk
{
    [ProtoBuf.ProtoContract()]
    public class LiskVerifyMessage : ProtoBuf.IExtensible
    {
        private ProtoBuf.IExtension __pbn__extensionData;
        ProtoBuf.IExtension ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoBuf.ProtoMember(1, Name = @"public_key")]
        public byte[] PublicKey { get; set; }
        public bool ShouldSerializePublicKey() => PublicKey != null;
        public void ResetPublicKey() => PublicKey = null;

        [ProtoBuf.ProtoMember(2, Name = @"signature")]
        public byte[] Signature { get; set; }
        public bool ShouldSerializeSignature() => Signature != null;
        public void ResetSignature() => Signature = null;

        [ProtoBuf.ProtoMember(3, Name = @"message")]
        public byte[] Message { get; set; }
        public bool ShouldSerializeMessage() => Message != null;
        public void ResetMessage() => Message = null;
    }
}