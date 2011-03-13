startUp: resuming

	WasListeningAtShutdown == true ifTrue: [
		self startListening.
	].
