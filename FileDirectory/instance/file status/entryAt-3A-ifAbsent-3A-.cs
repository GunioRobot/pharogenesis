entryAt: fileName ifAbsent: aBlock
	"Find the entry with local name fileName and answer it.
	If not found, answer the result of evaluating aBlock."

	| comparisonBlock |
	self isCaseSensitive
		ifTrue: [comparisonBlock _ [:entry | (entry at: 1) = fileName]]
		ifFalse: [comparisonBlock _ [:entry | (entry at: 1) sameAs: fileName]].
	^ self entries detect: comparisonBlock ifNone: [aBlock value]