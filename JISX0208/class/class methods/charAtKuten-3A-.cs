charAtKuten: anInteger

	| a b |
	a _ anInteger \\ 100.
	b _ anInteger // 100.
	(a > 94) | (b > 94) ifTrue: [
		self error: 'character code is not valid'.
	].
	^ MultiCharacter leadingChar: self leadingChar code: ((b - 1) * 94) + a - 1.
