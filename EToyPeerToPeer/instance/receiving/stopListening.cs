stopListening

	process ifNotNil: [process terminate. process _ nil].
	connectionQueue ifNotNil: [connectionQueue destroy. connectionQueue _ nil].

