testOneArgument
	| m |
	m _ WeakMessageSend
		receiver: Array
		selector: #with:
		argument: 1.
	Smalltalk garbageCollectMost.
	self should: [ m value  = { 1 } ].
