﻿using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSwag.Annotations;
using Service.Core.Client.Services;
using Service.Education.Helpers;
using Service.EducationBehavioralApi.Mappers;
using Service.EducationBehavioralApi.Models;
using Service.Grpc;
using Service.TutorialBehavioral.Grpc;
using Service.TutorialBehavioral.Grpc.Models.State;
using Service.Web;

namespace Service.EducationBehavioralApi.Controllers
{
	[Route("/api/v1/education/behavioral")]
	public class EducationController : BaseController
	{
		private readonly IGrpcServiceProxy<ITutorialBehavioralService> _tutorialService;

		public EducationController(IGrpcServiceProxy<ITutorialBehavioralService> tutorialService,
			IEncoderDecoder encoderDecoder, ISystemClock systemClock,
			ILogger<EducationController> logger) : base(systemClock, encoderDecoder, logger) => _tutorialService = tutorialService;

		[HttpPost("state")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<FinishStateResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> GetFinishStateAsync([FromBody] GetFinishStateRequest request)
		{
			if (request.Unit != null && EducationHelper.GetUnit(Tutorial, request.Unit.Value) == null)
				return StatusResponse.Error(ResponseCode.NotValidEducationRequestData);

			return await Process(userId => _tutorialService.Service.GetFinishStateAsync(new GetFinishStateGrpcRequest { UserId = userId, Unit = request.Unit }), grpc => grpc.ToModel());
		}

		#region Unit1 (Casino secrets around you)

		[HttpPost("unit1/text")]
		[OpenApiTag("Unit1")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit1TextAsync([FromBody] TaskTextRequest request) =>
			await ProcessTask(1, 1, request, (userId, timespan) => _tutorialService.Service.Unit1TextAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit1/test")]
		[OpenApiTag("Unit1")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit1TestAsync([FromBody] TaskTestRequest request) =>
			await ProcessTask(1, 2, request, (userId, timespan) => _tutorialService.Service.Unit1TestAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit1/video")]
		[OpenApiTag("Unit1")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit1VideoAsync([FromBody] TaskVideoRequest request) =>
			await ProcessTask(1, 3, request, (userId, timespan) => _tutorialService.Service.Unit1VideoAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit1/case")]
		[OpenApiTag("Unit1")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit1CaseAsync([FromBody] TaskCaseRequest request) =>
			await ProcessTask(1, 4, request, (userId, timespan) => _tutorialService.Service.Unit1CaseAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit1/truefalse")]
		[OpenApiTag("Unit1")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit1TrueFalseAsync([FromBody] TaskTrueFalseRequest request) =>
			await ProcessTask(1, 5, request, (userId, timespan) => _tutorialService.Service.Unit1TrueFalseAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit1/game")]
		[OpenApiTag("Unit1")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit1GameAsync([FromBody] TaskGameRequest request) =>
			await ProcessTask(1, 6, request, (userId, timespan) => _tutorialService.Service.Unit1GameAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		#endregion

		#region Unit2 (It doesn’t matter how much money you give a person. Miracle won't happen)

		[HttpPost("unit2/text")]
		[OpenApiTag("Unit2")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit2TextAsync([FromBody] TaskTextRequest request) =>
			await ProcessTask(2, 1, request, (userId, timespan) => _tutorialService.Service.Unit2TextAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit2/test")]
		[OpenApiTag("Unit2")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit2TestAsync([FromBody] TaskTestRequest request) =>
			await ProcessTask(2, 2, request, (userId, timespan) => _tutorialService.Service.Unit2TestAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit2/video")]
		[OpenApiTag("Unit2")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit2VideoAsync([FromBody] TaskVideoRequest request) =>
			await ProcessTask(2, 3, request, (userId, timespan) => _tutorialService.Service.Unit2VideoAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit2/case")]
		[OpenApiTag("Unit2")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit2CaseAsync([FromBody] TaskCaseRequest request) =>
			await ProcessTask(2, 4, request, (userId, timespan) => _tutorialService.Service.Unit2CaseAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit2/truefalse")]
		[OpenApiTag("Unit2")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit2TrueFalseAsync([FromBody] TaskTrueFalseRequest request) =>
			await ProcessTask(2, 5, request, (userId, timespan) => _tutorialService.Service.Unit2TrueFalseAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit2/game")]
		[OpenApiTag("Unit2")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit2GameAsync([FromBody] TaskGameRequest request) =>
			await ProcessTask(2, 6, request, (userId, timespan) => _tutorialService.Service.Unit2GameAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		#endregion

		#region Unit3 (Shopping list and time. Savings today)

		[HttpPost("unit3/text")]
		[OpenApiTag("Unit3")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit3TextAsync([FromBody] TaskTextRequest request) =>
			await ProcessTask(3, 1, request, (userId, timespan) => _tutorialService.Service.Unit3TextAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit3/test")]
		[OpenApiTag("Unit3")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit3TestAsync([FromBody] TaskTestRequest request) =>
			await ProcessTask(3, 2, request, (userId, timespan) => _tutorialService.Service.Unit3TestAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit3/video")]
		[OpenApiTag("Unit3")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit3VideoAsync([FromBody] TaskVideoRequest request) =>
			await ProcessTask(3, 3, request, (userId, timespan) => _tutorialService.Service.Unit3VideoAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit3/case")]
		[OpenApiTag("Unit3")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit3CaseAsync([FromBody] TaskCaseRequest request) =>
			await ProcessTask(3, 4, request, (userId, timespan) => _tutorialService.Service.Unit3CaseAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit3/truefalse")]
		[OpenApiTag("Unit3")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit3TrueFalseAsync([FromBody] TaskTrueFalseRequest request) =>
			await ProcessTask(3, 5, request, (userId, timespan) => _tutorialService.Service.Unit3TrueFalseAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit3/game")]
		[OpenApiTag("Unit3")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit3GameAsync([FromBody] TaskGameRequest request) =>
			await ProcessTask(3, 6, request, (userId, timespan) => _tutorialService.Service.Unit3GameAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		#endregion

		#region Unit4 (Financial ecology. Do you consume for pleasure, or because of advertising?)

		[HttpPost("unit4/text")]
		[OpenApiTag("Unit4")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit4TextAsync([FromBody] TaskTextRequest request) =>
			await ProcessTask(4, 1, request, (userId, timespan) => _tutorialService.Service.Unit4TextAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit4/test")]
		[OpenApiTag("Unit4")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit4TestAsync([FromBody] TaskTestRequest request) =>
			await ProcessTask(4, 2, request, (userId, timespan) => _tutorialService.Service.Unit4TestAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit4/video")]
		[OpenApiTag("Unit4")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit4VideoAsync([FromBody] TaskVideoRequest request) =>
			await ProcessTask(4, 3, request, (userId, timespan) => _tutorialService.Service.Unit4VideoAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit4/case")]
		[OpenApiTag("Unit4")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit4CaseAsync([FromBody] TaskCaseRequest request) =>
			await ProcessTask(4, 4, request, (userId, timespan) => _tutorialService.Service.Unit4CaseAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit4/truefalse")]
		[OpenApiTag("Unit4")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit4TrueFalseAsync([FromBody] TaskTrueFalseRequest request) =>
			await ProcessTask(4, 5, request, (userId, timespan) => _tutorialService.Service.Unit4TrueFalseAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit4/game")]
		[OpenApiTag("Unit4")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit4GameAsync([FromBody] TaskGameRequest request) =>
			await ProcessTask(4, 6, request, (userId, timespan) => _tutorialService.Service.Unit4GameAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		#endregion

		#region Unit5 (Habits. financial habits. Your personal revolution)

		[HttpPost("unit5/text")]
		[OpenApiTag("Unit5")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit5TextAsync([FromBody] TaskTextRequest request) =>
			await ProcessTask(5, 1, request, (userId, timespan) => _tutorialService.Service.Unit5TextAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit5/test")]
		[OpenApiTag("Unit5")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit5TestAsync([FromBody] TaskTestRequest request) =>
			await ProcessTask(5, 2, request, (userId, timespan) => _tutorialService.Service.Unit5TestAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit5/video")]
		[OpenApiTag("Unit5")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit5VideoAsync([FromBody] TaskVideoRequest request) =>
			await ProcessTask(5, 3, request, (userId, timespan) => _tutorialService.Service.Unit5VideoAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit5/case")]
		[OpenApiTag("Unit5")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit5CaseAsync([FromBody] TaskCaseRequest request) =>
			await ProcessTask(5, 4, request, (userId, timespan) => _tutorialService.Service.Unit5CaseAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit5/truefalse")]
		[OpenApiTag("Unit5")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit5TrueFalseAsync([FromBody] TaskTrueFalseRequest request) =>
			await ProcessTask(5, 5, request, (userId, timespan) => _tutorialService.Service.Unit5TrueFalseAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		[HttpPost("unit5/game")]
		[OpenApiTag("Unit5")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(DataResponse<TestScoreResponse>), Description = "Ok")]
		public async ValueTask<IActionResult> Unit5GameAsync([FromBody] TaskGameRequest request) =>
			await ProcessTask(5, 6, request, (userId, timespan) => _tutorialService.Service.Unit5GameAsync(request.ToGrpcModel(userId, timespan)), grpc => grpc.ToModel());

		#endregion
	}
}
