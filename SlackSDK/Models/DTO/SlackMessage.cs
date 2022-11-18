using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SlackSDK.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace SlackSDK.Models.DTO
{
    public class SlackMessage
    {
        public SlackMessage(EAttachmentColor color, string title, string value)
        {

            Attachments = new List<_Attachment>
            {
                new _Attachment()
                {
                    Color = color,
                    Fields = new List<_Attachment._Field>()
                {
                    new _Attachment._Field(title, value)
                }
                }
            };

        }

        public SlackMessage(string title, string value)
        {
            Attachments = new List<_Attachment>
            {
                new _Attachment()
                {
                    Fields = new List<_Attachment._Field>()
                {
                    new _Attachment._Field(title, value)
                }
                }
            };

        }

        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public string? Channel { get; set; }

        [JsonProperty("blocks", NullValueHandling = NullValueHandling.Ignore)]
        public List<_Block>? Blocks { get; set; }

        [JsonProperty("attachments", NullValueHandling = NullValueHandling.Ignore)]
        public List<_Attachment> Attachments { get; set; }

        public class _Block
        {
            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public string? Type { get; set; }

            [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
            public string? BlockId { get; set; }

            [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
            public _SlackText Text { get; set; }

            [JsonProperty("accessory", NullValueHandling = NullValueHandling.Ignore)]
            public _Accessory Accessory { get; set; }

            public class _SlackText
            {
                [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
                public string? Type { get; set; }

                [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
                public string? Text { get; set; }
            }

            public class _Accessory
            {
                [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
                public string? Type { get; set; }

                [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
                public Uri? ImageUrl { get; set; }

                [JsonProperty("alt_text", NullValueHandling = NullValueHandling.Ignore)]
                public string? AltText { get; set; }
            }
        }

        public class _Attachment
        {
            public _Attachment()
            {
                Color = EAttachmentColor.Normal;
            }

            public _Attachment(EAttachmentColor color)
            {
                Color = color;
            }

            [JsonProperty("fallback", NullValueHandling = NullValueHandling.Ignore)]
            public string? Fallback { get; set; }

            [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(StringEnumConverter))]
            public EAttachmentColor Color { get; set; }

            [JsonProperty("pretext", NullValueHandling = NullValueHandling.Ignore)]
            public string? Pretext { get; set; }

            [JsonProperty("author_name", NullValueHandling = NullValueHandling.Ignore)]
            public string? AuthorName { get; set; }

            [JsonProperty("author_link", NullValueHandling = NullValueHandling.Ignore)]
            public Uri? AuthorLink { get; set; }

            [JsonProperty("author_icon", NullValueHandling = NullValueHandling.Ignore)]
            public Uri? AuthorIcon { get; set; }

            [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
            public string? Title { get; set; }

            [JsonProperty("title_link", NullValueHandling = NullValueHandling.Ignore)]
            public Uri? TitleLink { get; set; }

            [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
            public string? Text { get; set; }

            [JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
            public List<_Field> Fields { get; set; }

            [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
            public Uri? ImageUrl { get; set; }

            [JsonProperty("thumb_url", NullValueHandling = NullValueHandling.Ignore)]
            public Uri? ThumbUrl { get; set; }

            [JsonProperty("footer", NullValueHandling = NullValueHandling.Ignore)]
            public string? Footer { get; set; }

            [JsonProperty("footer_icon", NullValueHandling = NullValueHandling.Ignore)]
            public Uri? FooterIcon { get; set; }

            [JsonProperty("ts", NullValueHandling = NullValueHandling.Ignore)]
            public long? Ts { get; set; }


            public _Attachment AppendField(_Field field)
            {
                if (Fields == null)
                {
                    Fields = new List<_Field>();
                }

                Fields.Add(field);

                return this;
            }

            public class _Field
            {
                public _Field(string value)
                {
                    Value = value;
                }

                public _Field(string title, string value)
                {
                    Title = title;
                    Value = value;
                }

                [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
                public string? Title { get; set; }

                [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
                public string Value { get; set; }

                [JsonProperty("short", NullValueHandling = NullValueHandling.Ignore)]
                public bool? Short { get; set; }
            }

        }


        public SlackMessage AppendField(string title, string value)
        {
            Attachments.First().Fields.Add(new _Attachment._Field(title, value));

            return this;
        }
    }
}
