ircMessageRecieved: aMessage
	| sender |
	sender _ aMessage sender ifNil: [ nick ].
	self addToConsole: (
		sender asText,
		': ',
		aMessage text,
		String cr).