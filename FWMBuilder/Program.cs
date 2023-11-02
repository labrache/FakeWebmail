using FWMCommons;
using MimeKit;
using System.Text.Json;

namespace FWMBuilder
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ArgumentParser parser = new ArgumentParser(args);
            if (!parser.getIn(out String Input))
                throw new ArgumentException("Input parameter missing");

            if (!parser.getOut(out String Output))
                throw new ArgumentException("Output parameter missing");

            if(!Directory.Exists(Input))
                throw new ArgumentException("Input directory not existing");

            if(!Directory.Exists(Output))
                throw new ArgumentException("Output directory not existing");

            foreach (String oldFile in Directory.GetFiles(Output))
                File.Delete(oldFile);
            List<MailMetadata> MailMetadataList = new List<MailMetadata>();
            foreach(var FileMail in Directory.GetFiles(Input,"*.eml",SearchOption.AllDirectories)) {
                MimeMessage message = MimeMessage.Load(FileMail);
                MailMetadata mailMetadata = new MailMetadata()
                {
                    From = message.From.ToString(),
                    Date = message.Date.DateTime,
                    Subject = message.Subject,
                    FileName = String.Format("{0}.eml",Guid.NewGuid().ToString()),
                };
                MailMetadataList.Add(mailMetadata);
                File.Copy(FileMail, Path.Combine(Output, mailMetadata.FileName));
            }
            using (var fw = File.OpenWrite(Path.Combine(Output, "maillist.json")))
                await JsonSerializer.SerializeAsync(fw, MailMetadataList);
        }
    }
}