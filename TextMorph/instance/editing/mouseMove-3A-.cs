mouseMove: evt
	evt redButtonPressed ifFalse: [^ self].
	self handleInteraction: [editor mouseMove: evt] fromEvent: evt