using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEFR.Models
{
    public class Transcription
    {
        public int Id { get; set; } // A unique identifier for the transcription
        public string TranscriptionTitle { get; set; } // The title or name of the transcription
        public DateTime TranscriptionDate { get; set; } // The date when the transcription was created or recorded
        public string AudioLink { get; set; } // Link to the audio file (if you're storing it on a server)

        // You can add more properties as needed based on the data structure you're working with
    }
}
