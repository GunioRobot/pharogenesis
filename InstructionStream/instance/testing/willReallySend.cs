willReallySend
	"Answer whether the next bytecode is a real message-send,
	not blockCopy:."

	| byte |
	byte _ self method at: pc.
	byte < 128 ifTrue: [^false].
	byte == 200 ifTrue: [^false].
	byte >= 176 ifTrue: [^true].	"special send or short send"
	^byte between: 131 and: 134	"long sends"