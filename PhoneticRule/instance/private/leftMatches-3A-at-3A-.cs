leftMatches: aString at: anInteger
	| leftindex textindex pattern |
	left isEmpty ifTrue: [^ true].
	leftindex _ left size.
	textindex _ anInteger - 1.
	[leftindex >= 1 and: [textindex >= 1]] whileTrue: [
		pattern _ left at: leftindex.
		"first check for simple text or apostrophe:"
		(pattern isAlphaNumeric or: [pattern = $'])
			ifTrue: [(aString at: textindex) asLowercase ~= pattern asLowercase
						ifTrue: [^ false].
					textindex _ textindex - 1].
		"space:"
		pattern = Character space
			ifTrue: [((aString at: textindex) isSeparator
						or: ['.,;:' includes: (aString at: textindex)]) ifFalse: [^ false].
					textindex _ textindex - 1].
		"one or more vowels:"
		pattern = $#
			ifTrue: [(aString at: textindex) isVowel ifFalse: [^ false].
					textindex _ textindex - 1.
					[textindex >= 1 and: [(aString at: textindex) isVowel]]
						whileTrue: [textindex _ textindex - 1]].
		"zero or more consonants:"
		pattern = $:
			ifTrue: [[textindex >= 1
						and: ['bcdfghjklmnpqrstvwxyz'
								includes: (aString at: textindex) asLowercase]]
							whileTrue: [textindex _ textindex - 1]].
		"one consonant:"
		pattern = $^
			ifTrue: [('bcdfghjklmnpqrstvwxyz' includes: (aString at: textindex))
						ifFalse: [^ false].
					textindex _ textindex - 1].
		"b, d, v, g, j, l, m, n, r, w, z (voiced consonants):"
		pattern = $.
			ifTrue: [('bdvgjlmnrwz' includes: (aString at: textindex) asLowercase)
						ifFalse: [^ false].
					textindex _ textindex - 1].
		"e, i or y (front vowels)"
		pattern = $+
			ifTrue: [('eiy' includes: (aString at: textindex) asLowercase)
						ifFalse: [^ false].
					textindex _ textindex - 1].
		leftindex _ leftindex - 1].
	^ true