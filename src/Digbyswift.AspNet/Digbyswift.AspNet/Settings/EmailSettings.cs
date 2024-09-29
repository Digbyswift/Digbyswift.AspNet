using Digbyswift.Core.Constants;
using Digbyswift.Core.Extensions;
using Digbyswift.Core.Extensions.Validation;
using Microsoft.Extensions.Configuration;

namespace Digbyswift.AspNet.Settings;

public class EmailSettings
{
    private const string DefaultFromAddress = "noreply@example.com";

    private string? _defaultFrom;
    public string DefaultFrom
    {
        get
        {
            if (!String.IsNullOrWhiteSpace(_defaultFrom) && _defaultFrom.IsEmail())
                return _defaultFrom;

            if (!String.IsNullOrWhiteSpace(SmtpSection?.From) && SmtpSection.From.IsEmail())
                return (_defaultFrom ??= SmtpSection.From);

            return (_defaultFrom = DefaultFromAddress);
        }
    }

    public virtual SmtpOptions? SmtpSection { get; }
    public IReadOnlyCollection<string> TestRecipientsTo { get; }
    public IReadOnlyCollection<string> TestRecipientsCc { get; }
    public IReadOnlyCollection<string> TestRecipientsBcc { get; }

    public EmailSettings(IConfiguration config)
    {
        var toValue = config.GetValue<string>("Site:Email:TestRecipients:To");
        TestRecipientsTo = toValue?.SplitAndTrim(CharConstants.Comma).Where(x => x.IsEmail()).ToList() ?? new List<string>();

        var ccValue = config.GetValue<string>("Site:Email:TestRecipients:Cc");
        TestRecipientsCc = ccValue?.SplitAndTrim(CharConstants.Comma).Where(x => x.IsEmail()).ToList() ?? new List<string>();

        var bccValue = config.GetValue<string>("Site:Email:TestRecipients:Bcc");
        TestRecipientsBcc = bccValue?.SplitAndTrim(CharConstants.Comma).Where(x => x.IsEmail()).ToList() ?? new List<string>();

        SmtpSection = config.GetSection(SmtpOptions.SectionName).Get<SmtpOptions>();
    }
}
