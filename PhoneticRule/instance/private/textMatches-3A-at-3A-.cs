textMatches: aString at: anInteger
	text size > (aString size - anInteger + 1) ifTrue: [^ false].
	1 to: text size do: [ :each |
		(text at: each) asLowercase = (aString at: anInteger + each - 1) asLowercase ifFalse: [^ false]].
	^ true