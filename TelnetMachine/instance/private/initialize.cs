initialize
	outputBuffer _ WriteStream on: String new.
	port _ 23.
	processingCommand _ false.
	displayLines _ (1 to: 25) asOrderedCollection collect: [ :i |
		Text new: 80 withAll: Character space ].
	cursorX _ 1.
	cursorY _ 1.
	foregroundColor _ Color white.
	displayMode _ #normal.
	requestedRemoteEcho _ false.
	remoteEchoAgreed _ false.
	hostname _ ''.