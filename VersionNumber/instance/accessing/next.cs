next

	| tmp |
	tmp := numbers copy.
	tmp at: numbers size put: (numbers last + 1).
	^self class fromCollection: tmp