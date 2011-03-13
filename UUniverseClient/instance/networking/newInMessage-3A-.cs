newInMessage: aMessage
	aMessage applyToClient: self.
	inMessages add: aMessage.
	