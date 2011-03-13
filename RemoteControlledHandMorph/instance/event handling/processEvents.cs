processEvents
	| |
	eventDecoder processIO.
	eventDecoder applyMessagesTo: self.
