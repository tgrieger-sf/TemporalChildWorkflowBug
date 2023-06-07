using TemporalChildWorkflowBug;
using Temporalio.Client;
using Temporalio.Worker;

MyActivities myActivities = new();

using TemporalWorker worker = new TemporalWorker(
	await TemporalClient.ConnectAsync(new TemporalClientConnectOptions { TargetHost = "localhost:7233" }),
	new TemporalWorkerOptions("task-queue")
		.AddWorkflow<SimpleWorkflow>()
		.AddWorkflow<ChildWorkflow>()
		.AddAllActivities(myActivities));

Task workerTask = worker.ExecuteAsync(default);

TemporalClient client = await TemporalClient.ConnectAsync(new TemporalClientConnectOptions("localhost:7233"));

// Comment out after first run
await client.ExecuteWorkflowAsync((SimpleWorkflow shw) => shw.Run(), new WorkflowOptions(id: "id", taskQueue: "task-queue"));

await workerTask;
