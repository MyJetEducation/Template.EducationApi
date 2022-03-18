using System.ComponentModel.DataAnnotations;

namespace Service.EducationBehavioralApi.Models
{
	public class TaskGameRequest : TaskRequestBase
	{
		[Required]
		public bool Passed { get; set; }
	}
}