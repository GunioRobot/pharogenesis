at: index

	<primitive: 143>
	index isInteger ifTrue: [ self errorSubscriptBounds: index ].
	index isNumber ifTrue: [ ^ self at: index truncated ].
	self errorNonIntegerIndex.