waitForAcceptFor: timeout
	"Wait and accept an incoming connection. Return nil if it falis"
	[self waitForConnectionFor: timeout] on: ConnectionTimedOut do: [:ex | ^nil].
	^self isConnected
		ifTrue:[self accept]
		