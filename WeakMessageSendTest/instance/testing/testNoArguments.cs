testNoArguments
	| m |
	m _ WeakMessageSend
		receiver: true
		selector: #yourself.
	self should: [ m value  ].
