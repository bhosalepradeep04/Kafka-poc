# Objective
POC to produce an event to a kafka topic, consume the same and mark for deletion using tombstone.

# Current state
Completed base setup and pending with actual work.

# Infra
A kafka cluster (hosted on local machine using docker) with a topic.

# Features
1. Produces an event to a kafka topic using Confluent.Kafka
2. Subscribe and consume a message from a kafka topic using Confluent.Kafka
3. Mark the message for deletion once consumed using tombstone

### Languages and Tools:
<img align="left" alt="C#" title="C#" src="/img/csharp.png" width="50" height="36">
<img align="left" alt=".NET Core" title=".NET Core" src="/img/dotNet.png" width="32">
<img align="left" alt="Kafka" title="Kafka" src="/img/kafka.png" width="28">
<img align="left" alt="Visual Studio" title="Visual Studio" src="/img/visual_studio.png" width="30">
<img align="left" alt="Docker" title="Docker" src="/img/docker.png" width="48">
