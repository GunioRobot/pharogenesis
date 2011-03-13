setName: aString
	| name |
	name := aString last isDigit
		ifTrue: [ aString ]
		ifFalse: [ (aString copyUpToLast: $.) copyUpTo: $( ].
	fullName := aString.
	packageName := name copyUpToLast: $-.
	authorName := (name copyAfterLast: $-) copyUpTo: $..
	versionNumber := ((name copyAfterLast: $-) copyAfter: $.).
	versionNumber first isDigit
		ifTrue: [ 
			branchName := ''.
			versionNumber := versionNumber asInteger ]
		ifFalse: [
			branchName := versionNumber copyUpToLast: $..
			versionNumber := (versionNumber copyAfterLast: $.) asInteger ]