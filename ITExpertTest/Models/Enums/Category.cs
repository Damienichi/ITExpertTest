using System.ComponentModel;

namespace ITExpertTest.Models.Enums;

public enum Category
{
    [Description("bookkeeping")]
    Bookkeeping,
    [Description("marketing")]
    Marketing,
    [Description("analytics")]
    Analytics
}