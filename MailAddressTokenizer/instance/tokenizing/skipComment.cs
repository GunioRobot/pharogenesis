skipComment
	| nestLevel paren |
	pos _ pos + 1.
	nestLevel _ 1.

	[ nestLevel > 0 ] whileTrue: [
		pos _ text indexOfAnyOf: CSParens startingAt: pos  ifAbsent: [ 0 ].
		pos = 0 ifTrue: [ 
			self error: 'unterminated comment.  ie, more (''s than )''s' ].

		paren _ self nextChar.
		paren = $( ifTrue: [ nestLevel _ nestLevel + 1 ] ifFalse: [ nestLevel _ nestLevel - 1 ]. ]