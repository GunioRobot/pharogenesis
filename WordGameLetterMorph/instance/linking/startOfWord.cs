startOfWord
	(predecessor isNil or: [predecessor isBlank]) ifTrue: [^self].
	^predecessor startOfWord