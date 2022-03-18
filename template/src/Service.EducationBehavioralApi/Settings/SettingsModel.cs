using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.EducationBehavioralApi.Settings
{
	public class SettingsModel
	{
		[YamlProperty("EducationBehavioralApi.SeqServiceUrl")]
		public string SeqServiceUrl { get; set; }

		[YamlProperty("EducationBehavioralApi.ZipkinUrl")]
		public string ZipkinUrl { get; set; }

		[YamlProperty("EducationBehavioralApi.ElkLogs")]
		public LogElkSettings ElkLogs { get; set; }

		[YamlProperty("EducationBehavioralApi.EducationFlowServiceUrl")]
		public string EducationFlowServiceUrl { get; set; }
	}
}
