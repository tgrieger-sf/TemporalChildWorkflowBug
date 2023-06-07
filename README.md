# TemporalChildWorkflowBug

## Repro steps

1. Put a breakpoint in MyActivities.cs:10
2. Debug the project
3. Kill it after at least one child workflow has started
4. Comment out Program.cs:19
5. Run (or debug) the project again and neither the child workflow nor the parent workflow start

If instead of killing it while in the middle of a child workflow,
if it is killed after a child workflow completes,
the parent workflow will continue as expected.
