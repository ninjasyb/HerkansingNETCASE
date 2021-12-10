using CursusInzicht.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CursusInzicht.API.Services
{
    public class FileValidatorService : IFileValidatorService
    {
        private const int CorrecteParagraaflengte = 5;
        public bool IsGeldig(HttpRequest request) {
            return request.Form.Files.Count > 0;
        }

        public bool IsTekstBestand(IFormFile file) {
            return file.ContentType.Contains("text/plain");
        }

        public int ValideerRegels(string content) {
            int paragraafNr = 0;

            string[] paragraven = content.Trim().Split("\r\n\r\n");

            foreach(string paragraaf in paragraven) {
                int regelNr = 1;
                string[] regel = paragraaf.Split("\r\n");

                if(regel.Length + 1 < CorrecteParagraaflengte) {
                    return CorrecteParagraaflengte * paragraafNr + regel.Length;  
                }

                if(regel.Length + 1 > CorrecteParagraaflengte) {
                    return CorrecteParagraaflengte * (paragraafNr + 1);
                }

                if (!IsTitelCorrect(regel[0])) {
                    return regelNr + (CorrecteParagraaflengte * paragraafNr);
                }
                regelNr++;
                if (!IsCodeCorrect(regel[1])) {
                    return regelNr + (CorrecteParagraaflengte * paragraafNr);
                }
                regelNr++;
                if (!IsDuurCorrect(regel[2])) {
                    return regelNr + (CorrecteParagraaflengte * paragraafNr);
                }
                regelNr++;
                if (!IsStartDatumCorrect(regel[3])) {
                    return regelNr + (CorrecteParagraaflengte * paragraafNr);
                }
                paragraafNr++;
            }
            return 0;
        }

        public bool IsTitelCorrect(string lijn) {
            Regex regex = new Regex(@"^Titel: .{1,300}$");
            return regex.IsMatch(lijn);
        }

        public bool IsCodeCorrect(string lijn) {
            Regex regex = new Regex(@"^Cursuscode: \w{1,10}$");
            return regex.IsMatch(lijn);
        }

        public bool IsDuurCorrect(string lijn) {
            Regex regex = new Regex(@"^Duur: \d dagen$");
            return regex.IsMatch(lijn);
        }

        public bool IsStartDatumCorrect(string lijn) {
            Regex regex = new Regex(@"^Startdatum: \d{1,2}/\d{1,2}/\d{4}$");
            return regex.IsMatch(lijn);
        }
    }
}
