using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Val.Hackathon.Lobby
{
    public class LobbyModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Room { get; set; }

        [Required]
        [DisplayName("Display Name")]
        public string DisplayName { get; set; }

        [DisplayName("Camera")]
        public string VideoInputId { get; set; }

        [DisplayName("Microphone")]
        public string AudioInputId { get; set; }

        [DisplayName("Speakers")]
        public string AudioOutputId { get; set; }

        public LobbyModel()
        {

        }
    }
}
