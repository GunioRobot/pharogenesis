isLetter: char

	| value leading |

	leading _ char leadingChar.
	value _ char charCode.

	leading = 0 ifTrue: [^ super isLetter: char].

	value _ value // 94 + 1.
	^ 1 <= value and: [value < 84].
