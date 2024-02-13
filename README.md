# Objective
POC to produce and consume an event/message from a kafka topic and mark for deletion using tombstone.
<br/>
SDK used for kafka operations: Confluent.Kafka.

### Current state
Implemented producer and consumer clients along with core services to communicate with a topic in a local kafka cluster.
<br/>
Pending work:
1. Configurations for local kafka cluster brokers.
2. Unit test cases for code coverage
3. Infra: Docker image to work with local

### Infra
A kafka cluster (hosted on local machine using docker) with a topic.

### Features
1. Produces an event to a kafka topic using Confluent.Kafka
2. Subscribe and consume a message from a kafka topic using Confluent.Kafka
3. Mark the message for deletion once consumed using tombstone

### Languages and Tools:
<img align="left" alt="C#" title="C#" src="/contents/img/csharp.png" width="50" height="36">
<img align="left" alt=".NET Core" title=".NET Core" src="/contents/img/dotNet.png" width="32">
<img align="left" alt="Kafka" title="Kafka" src="/contents/img/kafka.png" width="28">
<img align="left" alt="Visual Studio" title="Visual Studio" src="/contents/img/visual_studio.png" width="30">
<img align="left" alt="Docker" title="Docker" src="/contents/img/docker.png" width="45">
<img align="left" alt="XUnit" title="XUnit" src="/contents/img/xunit.png" width="55" height="30">
<img align="left" alt="MOQ" title="MOQ" src="/contents/img/moq.png" width="40">
