allSendersOf: selector inClass: aClass 
	| sortedSenders special byte |
	sortedSenders := SortedCollection new.
	special := aClass environment hasSpecialSelector: selector ifTrueSetByte: [:b | byte := b ].
	self 
		addSelectorsReferingTo: selector
		in: aClass
		to: sortedSenders
		special: special
		byte: byte.
	^sortedSenders