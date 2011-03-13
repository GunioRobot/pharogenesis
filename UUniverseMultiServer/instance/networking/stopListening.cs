stopListening	
	connectionQueue ifNotNil: [
		connectionQueue destroy.
		connectionQueue _ nil ].
	