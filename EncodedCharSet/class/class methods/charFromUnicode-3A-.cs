charFromUnicode: unicode

	| table index |
	unicode < 256 ifTrue: [^ Character value: unicode].

	table _ self ucsTable.
	index _ table indexOf: unicode.
	index = 0 ifTrue: [
		^ nil.
	].

	^ MultiCharacter leadingChar: self leadingChar code: index - 1.

