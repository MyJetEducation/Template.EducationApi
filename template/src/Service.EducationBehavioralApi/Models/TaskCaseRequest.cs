using System.ComponentModel.DataAnnotations;

namespace Service.EducationBehavioralApi.Models
{
	public class TaskCaseRequest : TaskRequestBase
	{
		[Required]
		public int Value { get; set; }
	}
}