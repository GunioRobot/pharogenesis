allSendersOf: selector 
	|  sortedSenders special byte |
	sortedSenders := SortedCollection new.
	special := Smalltalk 
		hasSpecialSelector: selector
		ifTrueSetByte: [ :b | byte := b ].
	self allBehaviorsDo: 
		[ :behavior | 
		self 
			addSelectorsReferingTo: selector
			in: behavior
			to: sortedSenders
			special: special
			byte: byte ].
	^ sortedSenders