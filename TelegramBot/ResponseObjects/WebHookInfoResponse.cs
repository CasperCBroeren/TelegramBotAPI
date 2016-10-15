 using System.Runtime.Serialization;


namespace TelegramBot.ResponseObjects
{
    /// <summary>
    /// Contains information about the current status of a webhook.
    /// </summary>
    [DataContract]
    public class WebHookInfoResponse
    {
        /// <summary>
        /// Webhook URL, may be empty if webhook is not set up
        /// </summary>
        [DataMember(Name="url")]
        public string Url { get; set; }
        /// <summary>
        /// True, if a custom certificate was provided for webhook certificate checks
        /// </summary>
        [DataMember(Name="has_custom_certificate")]
        public bool HasCustomCertificate { get; set; }
        /// <summary>
        /// Number of updates awaiting delivery
        /// </summary>
        [DataMember(Name="pending_update_count")]
        public int PendingUpdateCount { get; set; }
        /// <summary>
        /// Optional. Unix time for the most recent error that happened when trying to deliver an update via webhook
        /// </summary>
        [DataMember(Name="last_error_date")]
        public int LateErrorDate { get; set; }
        /// <summary>
        /// Optional. Error message in human-readable format for the most recent error that happened when trying to deliver an update via webhook
        /// </summary>
        [DataMember(Name="last_error_message")]
        public string   LastErrorMessage { get; set; }
    }
}
