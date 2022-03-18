using System.ComponentModel.DataAnnotations;

namespace Service.EducationBehavioralApi.Models
{
	public class TaskTrueFalseRequest : TaskRequestBase
	{
		[Required]
		public TaskTrueFalse[] Answers { get; set; }
	}
}