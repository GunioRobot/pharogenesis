sendCommand: aString

	| message |
	[message _ IRCProtocolMessage fromString: aString asString] ifError: [nil].
	message ifNil: [^ false].
	connection sendMessage: message.
	^ true
