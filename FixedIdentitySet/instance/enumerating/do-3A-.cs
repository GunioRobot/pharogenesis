do: aBlock
	| obj count |
	count := 0.
	1 to: self basicSize do: [:index |
		count >= tally ifTrue: [^ self].
		obj := self basicAt: index.
		obj ifNotNil: [count := count + 1. aBlock value: obj].
	].
