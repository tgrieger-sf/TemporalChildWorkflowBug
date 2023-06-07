using Temporalio.Workflows;

namespace TemporalChildWorkflowBug;

[Workflow]
public class ChildWorkflow
{
	[WorkflowRun]
	public async Task Run(int input)
	{
		int output = await Workflow.ExecuteActivityAsync(
			(MyActivities ma) => ma.ReturnInput(input),
			new ActivityOptions { ScheduleToCloseTimeout = TimeSpan.FromMinutes(5) });

		Console.WriteLine(output);
	}
}
