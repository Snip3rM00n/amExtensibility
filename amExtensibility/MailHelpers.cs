using System.Net.Mail;

namespace amExtensibility
{
	/// <summary>
	/// A collection of email helpers.
	/// </summary>
	public static class MailHelpers
	{
		/// <summary>
		/// Sends Mail.
		/// </summary>
		/// <param name="smtp">The SMTP Server address.</param>
		/// <param name="mailTo">String[] of users to email</param>
		/// <param name="subject">The subject of the email</param>
		/// <param name="body">The body of the email</param>
		/// <param name="ccTo">String[] of users to carbon copy</param>
		/// <param name="sendFrom">Where to send the email from.</param>
		public static void sendMail(string smtp, string[] mailTo, string subject, string body, string[] ccTo = null, string sendFrom = null)
		{
			string mailFrom = string.IsNullOrEmpty(sendFrom) ? System.Environment.MachineName + "@amExtensibility.com" : sendFrom;
			string mailToString = string.Join(",", mailTo);
			string ccMail = ccTo == null ? string.Empty : string.Join(",", ccTo);
			sendMail(smtp, mailToString, subject, body, ccMail, mailFrom);
		}

		/// <summary>
		/// Sends Mail.
		/// </summary>
		/// <param name="smtp">The SMTP Server address.</param>
		/// <param name="mailTo">String of users to email seperated by commas</param>
		/// <param name="subject">The subject of the email</param>
		/// <param name="body">The body of the email</param>
		/// <param name="ccTo">String of users to carbon copy seperated by commas</param>
		/// <param name="sendFrom">Where to send the email from.</param>
		public static void sendMail(string smtp, string mailTo, string subject, string body, string ccTo, string sendFrom = null)
		{
			string mailFrom = string.IsNullOrEmpty(sendFrom) ? System.Environment.MachineName + "@amExtensibility.com" : sendFrom;

			MailMessage envelope = new MailMessage(mailFrom, mailTo, subject, body);
			envelope.CC.Add(ccTo);
			
			SmtpClient smtpClient = new SmtpClient(smtp);
			smtpClient.Send(envelope);
		}
	}
}
