unEscape: aString
  "Convert escape sequences to their proper characters."

	| rs ws c |
	rs := ReadStream on: aString.
	ws := WriteStream on: ''.
	[ rs atEnd ] whileFalse: [
		c := rs next.
		ws nextPut:
			(c = $+ ifTrue: [ $  ] ifFalse: [
				c = $%
					ifTrue: [ (Number readFrom: (rs
next: 2) asUppercase base: 16) asCharacter ]
					ifFalse: [ c ]
				]).
		].
	^ws contents 