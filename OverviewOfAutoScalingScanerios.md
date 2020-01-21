# Understanding Function scaling in a Premium Plan

## Scaling Scenarios

### Test Configuration

The test conifugration will put 25,000 message into a service bus queue: 

![alt text](LoadTestSettings.png "Test Settings")

The function logic is a Thread.Sleep(15000) to simulate 15 deconds of execution time.
The azure binding host.json file has the default maxConcurrentCalls setting of 16.

This test configuration equates to a throughput of 64 messages per minute per azure function instance.

### Scenario 1
Minimum Instances: 1
Maximum Instances: 15

This scenario demonstrates the scale controller adding instance to a max of 15. Then execution continues at 15 instance until completion.

![alt text](Scenario1.png "Minimum instances 1, Maximum instances 15")

### Scenario 2
Minimum Instances: 1
Maximum Instances: 30

This scenario demonstrates the scale controller adding instance to a max of 30. Then execution continues at 30 instance until completion. The increasted instances reduces the processing time but does not increase cost as charges don't occur for additional instances after processing is complete.

![alt text](Scenario2.png "Minimum instances 1, Maximum instances 30")

### Scenario 3
Minimum Instances: 20
Maximum Instances: 30

This scenario demonstrates the expedited inital scalling because of the increased warm instances configuration. There is additional cost due keeping the 20 instances warm. 

![alt text](Scenario3.png "Minimum instances 20, Maximum instances 30")

## Reference

* https://docs.microsoft.com/en-us/azure/azure-functions/functions-scale
* https://docs.microsoft.com/en-us/azure/azure-functions/functions-best-practices#scalability-best-practices