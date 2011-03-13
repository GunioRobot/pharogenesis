showAndClearStats: queueName

	DEBUG ifNil: [^1 beep].
	self 
		showStats: queueName 
		from: DEBUG.
	DEBUG _ nil.