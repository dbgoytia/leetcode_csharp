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

References
==========
* [HTTP/2](https://en.wikipedia.org/wiki/HTTP/2)
