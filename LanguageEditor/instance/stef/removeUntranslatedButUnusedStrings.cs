removeUntranslatedButUnusedStrings
	(self confirm: 'Are you sure that you want to remove unused strings?' translated)
		ifFalse: [^ self].
	untranslatedList getList
		do: [:each | 
			| timesUsed | 
			timesUsed := self numberOfTimesStringIsUsed: each.
			Transcript show: each.
			Transcript show: timesUsed printString;
				 cr.
			timesUsed isZero 
				ifTrue: [self translator removeUntranslated: each]].

	self update: #untranslated.
