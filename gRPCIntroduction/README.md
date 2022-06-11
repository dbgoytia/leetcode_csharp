gRPC Introduction
==================

Today microservices are everywhere. They can be build in different languages,
to accomplish a number of different buisness goals.

Think of a simple buying workflow, you could have the following microservices that
require to communicate with one another:
* Buy 
* Discount
* Delivery
* User

In order to communicate, all of this APIs need to agree on, that makes building
good APIs difficult:
* API to exchange data
* Data Format
* Error Patterns
* Load Balancing
* many other things...

* For example, endpoints:
    * GET /api/v1/user/123/post/456
    * GET /api/v1/123/post

* Data formats:
    * XML
    * JSON
    * Binary

* Handling errors:
    * Behaviours
    * Error codes

* Payload sizes

* Scalability

* Languages interop

* Auth, monitoring, logs

* Latency


**Don't you wish you only focus on the data and leave the rest to the framework?**


What is an RPC?
===============
RPC is a Remote Procedure Call. When you call it, it will look like you're calling
a function directly on the server.


How do I get started?
====================

- Choose a supported language
- Generate the code using protocol buffers (protobuf)
- Have fun <3 !


Sneak peak
==========

```
syntax = "proto3";

message Greeting {
	string first_name = 1;
}

message GreetRequest {
	Greeting greeting = 1;
}

message GreetResponse {
	string result = 1;
}

service GreetService {
	rpc Greet(GreetRequest) returns (GreetResponse) {}
}

```


Why Protobuff?
==============

- Language agnostic
- Small payload -> makes it convenient for big data setups
- Easy API evolution
- You should be familiar with Protobuff (lol, I'm not at all).



Why learn gRPC?
===============

It's the future state of:
- Microservices APIs
- Microcontrollers/Mobile to server APIs
- Web APIs



Objective
==========

* Build a foundation by understanding the theory
* Practicing advanced concepts


Pre-requisites
==============
* Familiarity with C#
* Familiarity with ProtoBuffs
* Basic knowledge of Async programming
* But most importantly, a lot of willingness to learn something new.

