processMessage: aMessage
	| handler |
	protocolMessageSubscribers do: [ :subscriber |
		subscriber ircProtocolMessage: aMessage ].

	handler _ MessageHandlers at: aMessage command ifAbsent: [ nil ].
	handler ifNil: [	^self ].
	^self perform: handler  with: aMessage