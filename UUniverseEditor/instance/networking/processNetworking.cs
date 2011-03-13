processNetworking
	client receivedMessagesDo: [ :message |
		message applyToEditor: self ].
