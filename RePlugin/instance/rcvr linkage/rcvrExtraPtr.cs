rcvrExtraPtr

	|extraObj|
	self inline: true.
	extraObj _ interpreterProxy fetchPointer: 3 ofObject: rcvr.
	(extraObj = (interpreterProxy nilObject))
		ifTrue: [^ self cCode: '(int) NULL'].
	^self 
		cCoerce:(interpreterProxy arrayValueOf: extraObj)
		to: 'int'.