sendRawCommand: aString
	"Send a command directly."

	| message |
	message _ [IRCProtocolMessage fromString: aString asString] ifError: [:a :b | nil].
	message ifNil: [^ false].
	self sendMessage: message.
	^ true
