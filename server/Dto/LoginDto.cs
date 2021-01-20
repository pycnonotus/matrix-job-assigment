using System.ComponentModel.DataAnnotations;

namespace Dto
{
    public class LoginDto
    {
        /*
           In this current state RegisterDto and LoginDto are the same and I can use just one of them ofc with 
           a better name, but in real life RigesterDto will contain additional information that LoginDto doesnt require.
           so for the sake of simulating a real application I use two of them 
        */
        [Required]

        public string Username { get; set; }
        [Required]

        public string Password { get; set; }

    }
}
