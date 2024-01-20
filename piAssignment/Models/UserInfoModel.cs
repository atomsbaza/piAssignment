using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace piAssignment.Models
{
	public class UserInfoRequestModel
	{
        public string? Name { get; set; }
        public string? EmailAddress { get; set; }
    }

	public class UserInfoModel
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

		public string? Name { get; set; }
		public string? EmailAddress { get; set; }

		[Required]
		public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }
    }

	public class UserInfoResultsByIdModel
	{
		public bool status { get; set; }
		public UserInfoModel? results { get; set; }
	}

    public class UserInfoResultsByNameModel
    {
        public bool status { get; set; }
        public List<UserInfoModel?> results { get; set; }
    }
}

