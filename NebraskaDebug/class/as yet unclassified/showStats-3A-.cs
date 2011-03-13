showStats: queueName

	DEBUG ifNil: [^1 beep].
	self 
		showStats: queueName 
		from: DEBUG.
