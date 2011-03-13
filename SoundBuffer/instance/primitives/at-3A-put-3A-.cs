at: index put: value

	<primitive: 144>
	index isInteger ifTrue: [
		(index >= 1 and: [index <= self size])
				ifTrue: [ self errorImproperStore ]
				ifFalse: [ self errorSubscriptBounds: index ].
	].
	index isNumber ifTrue: [ ^ self at: index truncated put: value ].
	self errorNonIntegerIndex.
