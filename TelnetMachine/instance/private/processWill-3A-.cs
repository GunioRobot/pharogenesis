processWill: optionChar
	optionChar == OPTEcho ifTrue: [
		requestedRemoteEcho ifTrue: [
			remoteEchoAgreed _ true ]
		ifFalse: [
			"they are offering remote echo, though we haven't asked.  Answer: oh yes."
			self do: OPTEcho.
			requestedRemoteEcho _ true.
			remoteEchoAgreed _ true. ].
	^self  ].
	

	"they've requested an unknown option.  reject it"
	self dont: optionChar.