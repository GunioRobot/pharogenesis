willSend
	"Answer whether the next bytecode is a message-send."

	| byte |
	byte _ self method at: pc.
	byte < 128 ifTrue: [^false].
	byte >= 176 ifTrue: [^true].	"special send or short send"
	^byte between: 131 and: 134	"long sends"