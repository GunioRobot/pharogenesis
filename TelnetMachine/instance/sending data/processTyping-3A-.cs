processTyping: aString
	"process aString as if it were typed"
	outputBuffer nextPutAll: aString asString.
	remoteEchoAgreed ifFalse: [ self displayString: aString asString ].
	^true