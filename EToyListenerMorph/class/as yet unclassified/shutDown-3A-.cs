shutDown: quitting

	WasListeningAtShutdown _ GlobalListener notNil.
	self stopListening.
