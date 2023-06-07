using Temporalio.Workflows;

namespace TemporalChildWorkflowBug;

[Workflow]
public class SimpleWorkflow
{
	[WorkflowRun]
	public async Task Run()
	{
		for (int i = 0; i < 5; i++)
		{
			await Workflow.ExecuteChildWorkflowAsync((ChildWorkflow cw) => cw.Run(i));
		}
	}
}
