cursor: aNumber
	"Set the cursor to the given number, modulo the number of items I contain. Fractional cursor values are allowed."

	| truncP |
	cursor ~= aNumber ifTrue:  [
		cursor _ self asNumber: aNumber.
		truncP _ cursor truncated.
		truncP > submorphs size ifTrue: [
			submorphs size > 0
				ifTrue: [cursor _ cursor \\ submorphs size]
				ifFalse: [cursor _ 1]].
		truncP < 0 ifTrue: [cursor _ 1].
		self changed].
