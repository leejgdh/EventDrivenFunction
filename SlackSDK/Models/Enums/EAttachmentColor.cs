using System.Runtime.Serialization;

namespace SlackSDK.Models.Enums
{
    public enum EAttachmentColor
    {
        [EnumMember(Value = "#1D87EA")]
        Normal,

        [EnumMember(Value = "#0275D8")]
        Primary,

        [EnumMember(Value = "#5CB85C")]
        Success,

        [EnumMember(Value = "#5BC0DE")]
        Info,

        [EnumMember(Value = "#F0AD4E")]
        Warning,

        [EnumMember(Value = "#D9534F")]
        Danger,

        [EnumMember(Value = "#292B2C")]
        Inverse
    }
}
