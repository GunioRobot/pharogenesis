startNewAddress
	"set up data structures to begin a new address"
	(curAddrTokens ~~ nil) ifTrue: [
		self error: 'starting new address before finishing the last one!' ].

	curAddrTokens _ OrderedCollection new.
	