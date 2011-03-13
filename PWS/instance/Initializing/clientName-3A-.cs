clientName: addr
	"Return the host name of the client connecting via the given socket. If the host name cannot be found, return a string representing that host's numeric IP address."
	"Details: Since querying the domain name server can take many seconds (up to 13 second delays were observed during busy times), the results of this query are cached. This cache is flushed when the server starts up, although it could be flushed, say, hourly."

	| addrString name |
	addrString _ NetNameResolver stringFromAddress: addr.
	(ClientNameCache includesKey: addrString) ifFalse: [
		name _ NetNameResolver nameForAddress: addr timeout: 15.
		name ifNil: [name _ addrString].  "lookup failed or timed out; use numeric address"
		ClientNameCache at: addrString put: name].

	^ ClientNameCache at: addrString
