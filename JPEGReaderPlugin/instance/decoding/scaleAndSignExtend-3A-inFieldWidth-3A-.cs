scaleAndSignExtend: aNumber inFieldWidth: w
	self inline: true.
	aNumber < (1 bitShift: (w - 1))
		ifTrue: [^aNumber - (1 bitShift: w) + 1]
		ifFalse: [^aNumber]