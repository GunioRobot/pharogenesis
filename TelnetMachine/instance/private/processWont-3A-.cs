processWont: optionChar
	optionChar == OPTEcho ifTrue: [
		remoteEchoAgreed _ false.
		requestedRemoteEcho _ false.
	^self  ].
	
