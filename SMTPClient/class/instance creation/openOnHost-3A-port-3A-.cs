openOnHost: hostIP port: portNumber

	| client |
	client _ super openOnHost: hostIP port: portNumber.
	client initiateSession.
	^client