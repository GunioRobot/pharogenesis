testTwoArguments
	| m |
	m _ WeakMessageSend
		receiver: Array
		selector: #with:with:
		arguments: { 1 . 2 }.
	Smalltalk garbageCollectMost.
	self should: [ m value = { 1 . 2 } ].
