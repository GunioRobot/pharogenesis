testReceiverWithGC
	| m |
	m _ WeakMessageSend
		receiver: Object new
		selector: #isNil.
	Smalltalk garbageCollectMost.
	self assert: (m value isNil).