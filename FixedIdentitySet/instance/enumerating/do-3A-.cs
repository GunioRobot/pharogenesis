do: aBlock
	| obj count |
	count _ 0.
	1 to: self basicSize do: [:index |
		count >= tally ifTrue: [^ self].
		obj _ self basicAt: index.
		obj ifNotNil: [count _ count + 1. aBlock value: obj].
	].
