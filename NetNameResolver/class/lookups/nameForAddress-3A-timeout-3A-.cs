nameForAddress: hostAddress timeout: secs
	"Look up the given host address and return its name. Return nil if the lookup fails or is not completed in the given number of seconds. Depends on the given host address being known to the gateway, which may not be the case for dynamically allocated addresses."
	"NetNameResolver
		nameForAddress: (NetNameResolver addressFromString: '128.111.92.40')
		timeout: 30"

	| deadline ready success |
	deadline _ Time millisecondClockValue + (secs * 1000).
	ready _ self waitForResolverReadyUntil: deadline.
	ready ifFalse: [^ nil].

	self primStartLookupOfAddress: hostAddress.
	success _ self waitForCompletionUntil: deadline.
	success
		ifTrue: [^ self primAddressLookupResult]
		ifFalse: [^ nil].
