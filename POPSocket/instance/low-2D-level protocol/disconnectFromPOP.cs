disconnectFromPOP
	"Send a QUIT message, then disconnect."

	self isValid ifFalse: [^ self].  "already closed"
	self reportToObservers: 'closing connection'.
	numMessages _ nil.
	self sendCommand: 'QUIT'.
	self reportToObservers: self getResponse.
	self closeAndDestroy.
