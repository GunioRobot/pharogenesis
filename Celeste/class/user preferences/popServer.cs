popServer
	"Answer the server for downloading email via POP"

	(PopServer isNil or: [PopServer isEmpty])
		ifTrue: [self setPopServer].

	PopServer isEmpty ifTrue: [
		self error: 'POP server not specified' ].

	^PopServer