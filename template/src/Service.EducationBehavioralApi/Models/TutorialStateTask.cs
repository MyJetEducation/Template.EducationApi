﻿using System.ComponentModel.DataAnnotations;

namespace Service.EducationBehavioralApi.Models
{
	public class TutorialStateTask
	{
		[Range(1, 6)]
		public int Task { get; set; }

		[Range(1, 100)]
		public int TaskScore { get; set; }

		public RetryInfo Retry { get; set; }
	}
}