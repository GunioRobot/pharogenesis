testOneArgumentWithGC
	| m |
	m _ WeakMessageSend
		receiver: Array
		selector: #with:
		arguments: { Object new }.
	Smalltalk garbageCollectMost.
	self assert: (m value isNil)