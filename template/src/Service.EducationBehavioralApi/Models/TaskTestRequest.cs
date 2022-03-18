using System.ComponentModel.DataAnnotations;

namespace Service.EducationBehavioralApi.Models
{
	public class TaskTestRequest : TaskRequestBase
	{
		[Required]
		public TaskAnswer[] Answers { get; set; }
	}
}