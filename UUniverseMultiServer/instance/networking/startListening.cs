startListening
	self stopListening.
	connectionQueue _ ConnectionQueue portNumber: port queueLength: 5.
	