using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicatonProcess.July2021.Web.DTOs.Assets
{
    public class UpdateAssetRequest
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Symbol { get; set; }

        public int UserId { get; set; }
    }
}
