Protobufs and Language Interoperability
======================================


## ProtoBuffs

We define messages, and services using ProtoBuffs. The reason is that the payload
size with ProtoBuffs is the efficiency over JSON.

If you think about it, JSON is meant to be human-readable. ProtoBuffs are binary,
but they are understandable, and it's a very good representation of how this
actually looks in memory. So the basic idea is to have a less CPU intensive format,
that is closer to how things are stored in memory.

* Intuitive message definition
* Generated code
* Efficient serialization / deserialization

### Supported languages

There are three main implementations, implemented language specific libraries.
* Java
* Go
* C

The rest of the gRPC implementations, rely on the C implementation (also C#).


HTTP/2
=======

gRPC relies on HTTP/2, which is the new technology over HTTP/1.1

* One thing that makes HTTP/1.1 slow is that we have to open one TCP Connection per request.
* HTTP/1.1 does not compress headers, this increases latency.
* HTTP/1.1 only accepts the reponse/request pattern.
* HTTP/1.1 relies on RESTful verbs (get, post) to do some stuff per request.

Example:

A client wants to create three requests:
1. Get CSS file
2. Get some assets
3. Get some JavaScript code 
Total of TCP connections (3), if we scale this, this sounds incredibly slow!

Compared with http1, using http2:
* Will provide one long-lasting TPC Connection
* Supports **server push**, means that one server can respond multiple requests for one client
* This means less chatter.
* Supports multiplexing, means that the server and the client can push messages in parallel over
the same tcp connection.
* Payloads are compressed to binary data.
* HTTP2 is more secure by default, SSL connection will be required by default.

In the same example above, we only open 1 tcp connection,  and we can request everything over the same connection.


Bottom line:
* Less chatter
* Less bandwith
* Increased security layer
* All of this come out of the box by using gRPC


Types of API in gRPC
=====================


## Unary

It's the one that closest resembles REST APIs. A client sends a request, and the server reponds.

## Server streaming

The client sends one request, and the server can return one or more responses depending on the context.
This is useful when you want to update in near real-time on the client side.

## Client streaming

The client can send multiple requests, and the server returns one response. For example, this is one is
usefull when we want to add real-time updating of the information being sent to the server.

## Bi directional streaming

Fancier, the client sends multiple requests, and server responds with multiple responses. The resposnes
can arrive in any order you decide.


Examples:


```
// The main visual difference is the word stream
service GreetService {

	// Unary
	rpc Greet(GreetRequest) returns (GreetResponse) {};

	// Server Streaming
	rpc GreetManyTimes(GreetRequest) returns (stream GreetResponse) {};

	// Client Streaming
	rpc LongGreet(stream GreetRequest) returns (GreetResponse) {};

	// Bi directional Streaming
	rpc GreetEveryone(stream GreetRequest) returns (stream GreetResponse) {};
}
```


Scalability in gRPC
===================

* Server side is Async
* Client can be Async or Blocking process.
* For example, Google can request 10 Billion requests / sec.


Security in gRPC (SSL)
========================

* Schema based serialization. This is on binary format, and you need the schema to read it efficiently.
* Easy SSL certificates initialization.
* Interceptors for Authentication - provide authentication features to our APIs.


Comparisons (gRPC vs REST)
===========================

Use the right tool, for the right situation


gRPC
* Protocol Buffers
* HTTP2
* Streaming support of data
* Bi directional communication
* free design of verbs.

REST
* JSON
* HTTP1
* Unary data
* client -> server communication
* get/post/update/delete









	
References
==========

* [HTTP/2](https://en.wikipedia.org/wiki/HTTP/2)
