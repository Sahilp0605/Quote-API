using System;
using System.ComponentModel;

namespace QuoteUI.Common
{
    public class ApiResponse
    {
        public Enums.Status StatusCode { get; set; }
        public string Message { get; set; }
        public object ReturnValue { get; set; }
    }

    public class Enums
    {
        public enum NotificationType
        {
            error,
            success,
            warning,
            info
        }
        public enum Status
        {
            Create = 1,
            Approved = 2,
            Cancel = 3,
            Close = 4,
            Received = 5,
            Error = 6,
            Success = 7,
            PartialSuccess = 8
        }

        public enum Message
        {
            [Description("Record Saved Successfully")]
            Save,
            [Description("Record Updated Successfully")]
            Edit,
            [Description("Record Deleted Successfully")]
            Delete
        }

        public static string GetEnumDescription(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes =
             (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;

            //if no attribute was specified, then we will return the regular enum.ToString()
            return value.ToString();
        }
    }
}
