previous

	| tmp |
	numbers last = 1 ifTrue: 
		[^self class fromCollection: (numbers allButLast)].
	tmp := numbers copy.
	tmp at: numbers size put: (numbers last - 1).
	^self class fromCollection: tmp
