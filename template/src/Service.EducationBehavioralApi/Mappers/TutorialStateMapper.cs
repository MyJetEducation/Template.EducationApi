using System.Linq;
using Service.EducationBehavioralApi.Models;
using Service.TutorialBehavioral.Grpc.Models.State;

namespace Service.EducationBehavioralApi.Mappers
{
	public static class TutorialStateMapper
	{
		public static TestScoreResponse ToModel(this TestScoreGrpcResponse response) => response != null
			? new TestScoreResponse
			{
				IsSuccess = response.IsSuccess,
				Unit = response.Unit?.ToModel()
			}
			: null;

		public static FinishStateResponse ToModel(this FinishStateGrpcResponse grpcResponse) => grpcResponse != null
			? new FinishStateResponse
			{
				Case = grpcResponse.Case,
				Game = grpcResponse.Game,
				Test = grpcResponse.Test,
				Text = grpcResponse.Text,
				Video = grpcResponse.Video,
				TrueFalse = grpcResponse.TrueFalse,
				Achievements = grpcResponse.Achievements
			}
			: null;

		private static TutorialStateUnit ToModel(this StateGrpcModel grpcModel) => grpcModel != null
			? new TutorialStateUnit
			{
				Unit = grpcModel.Unit,
				TaskScore = grpcModel.TestScore,
				Tasks = grpcModel.Tasks?.Select(task => task.ToModel())
			}
			: null;

		private static TutorialStateTask ToModel(this TaskStateGrpcModel grpcModel) => grpcModel != null
			? new TutorialStateTask
			{
				Task = grpcModel.Task,
				TaskScore = grpcModel.TestScore,
				Retry = grpcModel.RetryInfo.ToModel()
			}
			: null;

		private static RetryInfo ToModel(this TaskRetryInfoGrpcModel grpcModel) => grpcModel != null
			? new RetryInfo
			{
				InRetry = grpcModel.InRetry,
				CanRetryByCount = grpcModel.CanRetryByCount,
				CanRetryByTime = grpcModel.CanRetryByTime
			}
			: null;
	}
}