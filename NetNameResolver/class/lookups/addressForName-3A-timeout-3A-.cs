addressForName: hostName timeout: secs
	"Look up the given host name and return its address. Return nil if the address is not found in the given number of seconds."
	"NetNameResolver addressForName: 'create.ucsb.edu' timeout: 30"

	| deadline ready success |
	(hostName isEmpty not and: [hostName first isDigit]) ifTrue: [
		"assume a numeric host address if first character is a digit"
		^ self addressFromString: hostName].
	deadline _ Time millisecondClockValue + (secs * 1000).
	ready _ self waitForResolverReadyUntil: deadline.
	ready ifFalse: [^ nil].

	self primStartLookupOfName: hostName.
	success _ self waitForCompletionUntil: deadline.
	success
		ifTrue: [^ self primNameLookupResult]
		ifFalse: [^ nil].
