using Temporalio.Activities;

namespace TemporalChildWorkflowBug;

public class MyActivities
{
	[Activity]
	public int ReturnInput(int input)
	{
		return input;
	}
}
