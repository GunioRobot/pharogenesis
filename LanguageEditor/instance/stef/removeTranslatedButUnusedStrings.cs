removeTranslatedButUnusedStrings
	(self confirm: 'Are you sure that you want to remove unused strings?' translated)
		ifFalse: [^ self].
	translationsList getList
		do: [:each | 
			| timesUsed | 
			timesUsed := self numberOfTimesStringIsUsed: each.
			Transcript show: each.
			Transcript show: timesUsed printString;
				 cr.
			timesUsed isZero
				ifTrue: [self translator removeTranslationFor: each]]