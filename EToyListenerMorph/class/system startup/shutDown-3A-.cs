shutDown: quitting

	WasListeningAtShutdown := GlobalListener notNil.
	self stopListening.
